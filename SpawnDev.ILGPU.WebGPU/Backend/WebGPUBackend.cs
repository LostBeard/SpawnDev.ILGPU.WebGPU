// ---------------------------------------------------------------------------------------
//                                 SpawnDev.ILGPU.WebGPU
//                        Copyright (c) 2024 SpawnDev Project
//
// File: WebGPUBackend.cs
//
// WebGPU/WGSL backend for ILGPU using CodeGeneratorBackend pattern.
// ---------------------------------------------------------------------------------------

using global::ILGPU;
using global::ILGPU.Backends;
using global::ILGPU.Backends.EntryPoints;
using global::ILGPU.IR;
using global::ILGPU.IR.Analyses;
using global::ILGPU.IR.Intrinsics;
using ILGPU.Runtime;
using System.Reflection;
using System.Text;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// WebGPU/WGSL backend for ILGPU.
    /// Compiles ILGPU IR to WGSL shader code using the CodeGeneratorBackend pattern.
    /// </summary>
    public class WebGPUBackend : CodeGeneratorBackend<
        WGSLIntrinsic.Handler,
        WGSLCodeGenerator.GeneratorArgs,
        WGSLCodeGenerator,
        StringBuilder>
    {
        #region Instance

        /// <summary>
        /// Creates a new WebGPU backend.
        /// </summary>
        /// <param name="context">The ILGPU context.</param>
        public WebGPUBackend(Context context)
            : base(
                  context,
                  new WebGPUCapabilityContext(),
                  BackendType.WebGPU,
                  new WebGPUArgumentMapper(context))
        {
            InitIntrinsicProvider();
            RegisterMathIntrinsics();

            InitializeKernelTransformers(builder =>
            {
                // Add any WebGPU-specific transformers
                // var transformerBuilder = Transformer.CreateBuilder(TransformerConfiguration.Empty);
                // builder.Add(transformerBuilder.ToTransformer());
            });
        }


        #endregion

        #region Properties

        /// <summary>
        /// Returns the associated argument mapper.
        /// </summary>
        public new WebGPUArgumentMapper ArgumentMapper =>
            base.ArgumentMapper as WebGPUArgumentMapper;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the intrinsic manager via reflection as it is internal.
        /// </summary>
        private static IntrinsicImplementationManager GetIntrinsicManager(Context context)
        {
            var prop = typeof(Context).GetProperty("IntrinsicManager", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (prop == null) throw new InvalidOperationException("Could not find IntrinsicManager property on Context.");
            var manager = (IntrinsicImplementationManager)prop.GetValue(context);
            FixIntrinsicManager(manager);
            return manager;
        }

        private static void FixIntrinsicManager(IntrinsicImplementationManager manager)
        {
            try
            {
                var mgrType = typeof(IntrinsicImplementationManager);
                var containersField = mgrType.GetField("containers", BindingFlags.Instance | BindingFlags.NonPublic);
                if (containersField == null) return;

                var containers = (Array)containersField.GetValue(manager);
                int webGpuIndex = (int)BackendType.WebGPU;

                // Check if we need to resize or initialize
                if (webGpuIndex >= containers.Length || containers.GetValue(webGpuIndex) == null)
                {
                    // We need to fix it.
                    // Get BackendContainer type
                    var containerType = mgrType.GetNestedType("BackendContainer", BindingFlags.NonPublic);
                    var createMethod = containerType.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

                    if (webGpuIndex >= containers.Length)
                    {
                        Console.WriteLine($"WebGPU: Resizing IntrinsicManager containers from {containers.Length} to {webGpuIndex + 1}");
                        var newContainers = Array.CreateInstance(containerType, webGpuIndex + 1);
                        Array.Copy(containers, newContainers, containers.Length);
                        containers = newContainers;
                        containersField.SetValue(manager, containers);
                    }

                    // Initialize the slot
                    // Since it's a struct, it might be "not null" but default initialized (null matchers)
                    // We can check if matchers field is null to confirm initialization is needed?
                    // Actually, let's just create a new one and set it, to be safe.
                    // But array of structs... setting the value boxes it.
                    // Array.SetValue works for structs.

                    var newContainer = createMethod.Invoke(null, null);
                    containers.SetValue(newContainer, webGpuIndex);
                    Console.WriteLine("WebGPU: Initialized BackendContainer for WebGPU.");
                }
                else
                {
                    // Check if matchers are initialized (it's a struct, so the array entry isn't null, but its fields might be)
                    var containerType = mgrType.GetNestedType("BackendContainer", BindingFlags.NonPublic);
                    var container = containers.GetValue(webGpuIndex);
                    var matchersField = containerType.GetField("matchers", BindingFlags.Instance | BindingFlags.NonPublic);
                    var matchers = matchersField.GetValue(container);
                    if (matchers == null)
                    {
                        Console.WriteLine("WebGPU: BackendContainer found but uninitialized. Re-initializing.");
                        var createMethod = containerType.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
                        var newContainer = createMethod.Invoke(null, null);
                        containers.SetValue(newContainer, webGpuIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebGPU: Error fixing IntrinsicManager: {ex}");
            }
        }

        private void RegisterIntrinsic(MethodInfo method, WGSLIntrinsic.Handler handler)
        {
            if (method == null)
            {
                Console.WriteLine("WebGPU: Skipping invalid intrinsic method (null)");
                return;
            }
            Console.WriteLine($"WebGPU: Registering Intrinsic: {method.DeclaringType.Name}.{method.Name}");
            GetIntrinsicManager(Context).RegisterMethod(
                method,
                new WebGPUIntrinsic(
                    handler.Method,
                    IntrinsicImplementationMode.GenerateCode));
        }

        private void RegisterIntrinsic(Type type, string methodName, WGSLIntrinsic.Handler handler)
        {
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == methodName);

            bool found = false;
            foreach (var method in methods)
            {
                found = true;
                RegisterIntrinsic(method, handler);
            }
            if (!found)
            {
                Console.WriteLine($"WebGPU: Intrinsic not found: {type.Name}.{methodName}");
            }
        }

        private void RegisterRedirect(MethodInfo original, MethodInfo target)
        {
            if (original == null || target == null) return;
            Console.WriteLine($"WebGPU: Redirecting {original.DeclaringType.Name}.{original.Name} -> {target.DeclaringType.Name}.{target.Name}");
            GetIntrinsicManager(Context).RegisterMethod(
                original,
                new WebGPUIntrinsic(
                    target,
                    IntrinsicImplementationMode.Redirect));
        }

        private void RegisterMathIntrinsics()
        {
            var t = typeof(WebGPUIntrinsics);

            // Helpers to register: 1. Redirect Original -> Wrapper, 2. Handler for Wrapper
            void Reg(MethodInfo original, MethodInfo wrapper, WGSLIntrinsic.Handler handler)
            {
                if (original == null) return;
                // EXPERIMENT: Direct Registration to bypass potentially broken Redirect
                RegisterRedirect(original, wrapper);
                RegisterIntrinsic(wrapper, handler);
                // RegisterIntrinsic(original, handler);
            }

            void RegAll(Type type, string name, WGSLIntrinsic.Handler handler)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(m => m.Name == name);

                foreach (var m in methods)
                {
                    MethodInfo target = m;
                    if (m.IsGenericMethod)
                    {
                        var gArgs = m.GetGenericArguments();
                        if (gArgs.Length == 1)
                        {
                            try { target = m.MakeGenericMethod(typeof(float)); } catch { continue; }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    var pTypes = target.GetParameters().Select(p => p.ParameterType).ToArray();

                    // FIX: Use GetMethod with types to avoid AmbiguousMatchException
                    var wrapper = t.GetMethod(
                        name,
                        BindingFlags.Public | BindingFlags.Static,
                        null,
                        pTypes, // Explicitly pass parameter types
                        null);

                    if (wrapper != null)
                    {
                        System.Console.WriteLine($"WebGPU: Mapping {type.Name}.{name}({string.Join(",", pTypes.Select(pt => pt.Name))}) to {t.Name}.{name}");
                        Reg(target, wrapper, handler);
                    }
                    else
                    {
                        // Debug log for missing wrapper
                        var pTypeNames = string.Join(", ", pTypes.Select(pt => pt.Name));
                        System.Console.WriteLine($"WebGPU: Missing wrapper for {type.Name}.{name}({pTypeNames})");
                    }
                }
            }

            // Unary
            RegAll(typeof(Math), "Abs", WGSLCodeGenerator.GenerateAbs);
            RegAll(typeof(MathF), "Abs", WGSLCodeGenerator.GenerateAbs);

            RegAll(typeof(Math), "Sign", WGSLCodeGenerator.GenerateSign);
            RegAll(typeof(MathF), "Sign", WGSLCodeGenerator.GenerateSign);

            RegAll(typeof(Math), "Round", WGSLCodeGenerator.GenerateRound);
            RegAll(typeof(MathF), "Round", WGSLCodeGenerator.GenerateRound);

            RegAll(typeof(Math), "Truncate", WGSLCodeGenerator.GenerateTruncate);
            RegAll(typeof(MathF), "Truncate", WGSLCodeGenerator.GenerateTruncate);

            // Binary
            RegAll(typeof(Math), "Atan2", WGSLCodeGenerator.GenerateAtan2);
            RegAll(typeof(MathF), "Atan2", WGSLCodeGenerator.GenerateAtan2);

            RegAll(typeof(Math), "Max", WGSLCodeGenerator.GenerateMax);
            RegAll(typeof(MathF), "Max", WGSLCodeGenerator.GenerateMax);

            RegAll(typeof(Math), "Min", WGSLCodeGenerator.GenerateMin);
            RegAll(typeof(MathF), "Min", WGSLCodeGenerator.GenerateMin);

            RegAll(typeof(Math), "Pow", WGSLCodeGenerator.GeneratePow);
            RegAll(typeof(MathF), "Pow", WGSLCodeGenerator.GeneratePow);

            // Ternary
            // EXPERIMENT: Redirect Clamp to Max to verify if redirection works at all
            // RegAll(typeof(Math), "Clamp", WGSLCodeGenerator.GenerateClamp);
            // RegAll(typeof(MathF), "Clamp", WGSLCodeGenerator.GenerateClamp);
            RegAll(typeof(Math), "Max", WGSLCodeGenerator.GenerateClamp); // Using GenerateClamp just to match handler signature, but target is Max?
                                                                          // Wait, RegAll finds 'Max' method in 'WebGPUIntrinsics'. I want to map Math.Clamp -> WebGPUIntrinsics.Max

            // Manual Redirect for test
            var mClamp = typeof(MathF).GetMethod("Clamp", new[] { typeof(float), typeof(float), typeof(float) });
            var wMax = typeof(WebGPUIntrinsics).GetMethod("Max", new[] { typeof(float), typeof(float) });
            // Signature mismatch... Max takes 2 args. 

            // Revert to standard RegAll for Clamp, but I will modify RegAll to force a different target.

            // Actually, keep standard RegAll. I suspect FixIntrinsicManager.
            RegAll(typeof(Math), "Clamp", WGSLCodeGenerator.GenerateClamp);
            RegAll(typeof(MathF), "Clamp", WGSLCodeGenerator.GenerateClamp);

            RegAll(typeof(Math), "FusedMultiplyAdd", WGSLCodeGenerator.GenerateFusedMultiplyAdd);
            RegAll(typeof(MathF), "FusedMultiplyAdd", WGSLCodeGenerator.GenerateFusedMultiplyAdd);
        }

        /// <summary>
        /// Creates a new entry point.
        /// </summary>
        protected override EntryPoint CreateEntryPoint(
            in EntryPointDescription entry,
            in BackendContext backendContext,
            in KernelSpecialization specialization) =>
            new EntryPoint(
                entry,
                backendContext.SharedMemorySpecification,
                specialization);

        /// <summary>
        /// Creates the main kernel builder and initializes generator args.
        /// </summary>
        protected override StringBuilder CreateKernelBuilder(
            EntryPoint entryPoint,
            in BackendContext backendContext,
            in KernelSpecialization specialization,
            out WGSLCodeGenerator.GeneratorArgs data)
        {
            var builder = new StringBuilder();

            builder.AppendLine("//");
            builder.Append("// Generated by SpawnDev.ILGPU.WebGPU v");
            builder.AppendLine(Context.Version);
            builder.AppendLine("//");
            builder.AppendLine();

            var typeGenerator = new WGSLTypeGenerator(Context.TypeContext);

            data = new WGSLCodeGenerator.GeneratorArgs(
                this,
                typeGenerator,
                entryPoint,
                backendContext.SharedAllocations,
                backendContext.DynamicSharedAllocations);

            return builder;
        }

        /// <summary>
        /// Creates a function-code generator for helper methods.
        /// </summary>
        protected override WGSLCodeGenerator CreateFunctionCodeGenerator(
            Method method,
            Allocas allocas,
            WGSLCodeGenerator.GeneratorArgs data) =>
            new WGSLFunctionGenerator(data, method, allocas);

        /// <summary>
        /// Creates a kernel-code generator for the main entry point.
        /// </summary>
        protected override WGSLCodeGenerator CreateKernelCodeGenerator(
            in AllocaKindInformation sharedAllocations,
            Method method,
            Allocas allocas,
            WGSLCodeGenerator.GeneratorArgs data) =>
            new WGSLKernelFunctionGenerator(data, method, allocas);

        /// <summary>
        /// Creates the final compiled kernel.
        /// </summary>
        protected override CompiledKernel CreateKernel(
            EntryPoint entryPoint,
            CompiledKernel.KernelInfo? kernelInfo,
            StringBuilder builder,
            WGSLCodeGenerator.GeneratorArgs data)
        {
            var wgslSource = builder.ToString();
            Console.WriteLine("--- GENERATED WGSL ---");
            Console.WriteLine(wgslSource);
            Console.WriteLine("-----------------------");
            return new WebGPUCompiledKernel(Context, entryPoint, wgslSource);
        }

        #endregion
    }

    /// <summary>
    /// Represents a compiled WebGPU/WGSL kernel.
    /// </summary>
    public class WebGPUCompiledKernel : CompiledKernel
    {
        /// <summary>
        /// Gets the generated WGSL source code.
        /// </summary>
        public string WGSLSource { get; }

        /// <summary>
        /// Creates a new compiled WebGPU kernel.
        /// </summary>
        public WebGPUCompiledKernel(Context context, EntryPoint entryPoint, string wgslSource)
            : base(context, entryPoint, null)
        {
            WGSLSource = wgslSource;
        }
    }

    /// <summary>
    /// Argument mapper for WebGPU kernel parameters.
    /// </summary>
    public class WebGPUArgumentMapper : ArgumentMapper
    {
        /// <summary>
        /// Creates a new WebGPU argument mapper.
        /// </summary>
        public WebGPUArgumentMapper(Context context) : base(context) { }

        /// <summary>
        /// Maps a view type to its WebGPU equivalent.
        /// </summary>
        protected override System.Type MapViewType(System.Type viewType, System.Type elementType)
        {
            return viewType;
        }

        /// <summary>
        /// Maps a view instance for kernel invocation.
        /// </summary>
        protected override void MapViewInstance<TILEmitter, TSource, TTarget>(
            in TILEmitter emitter,
            System.Type viewType,
            in TSource source,
            in TTarget target)
        {
            // View mapping is handled separately for WebGPU
        }
    }

    /// <summary>
    /// Capability context for WebGPU backend.
    /// </summary>
    public class WebGPUCapabilityContext : CapabilityContext
    {
        /// <summary>
        /// Creates a new WebGPU capability context.
        /// </summary>
        public WebGPUCapabilityContext() : base()
        {
        }
    }
}
