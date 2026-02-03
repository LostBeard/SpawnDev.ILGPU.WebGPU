using ILGPU;
using global::ILGPU.IR;
using global::ILGPU.IR.Types;
using global::ILGPU.Util;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpawnDev.ILGPU.WebGPU.Backend
{
    /// <summary>
    /// Generates internal WGSL type structures that are used inside kernels.
    /// </summary>
    public sealed class WGSLTypeGenerator : DisposeBase
    {
        #region Instance

        private readonly ReaderWriterLockSlim readerWriterLock =
            new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private readonly Dictionary<TypeNode, string> mapping =
            new Dictionary<TypeNode, string>();

        /// <summary>
        /// Constructs a new type generator.
        /// </summary>
        internal WGSLTypeGenerator(IRTypeContext typeContext)
        {
            TypeContext = typeContext;

            // Declare primitive types
            mapping[typeContext.VoidType] = "void";
            mapping[typeContext.StringType] = "u32"; // Not supported, placeholder

            // Map basic types
            foreach (var basicValueType in IRTypeContext.BasicValueTypes)
            {
                string wgslType = GetBasicValueType(basicValueType);
                if (wgslType != null)
                {
                    var primitiveType = typeContext.GetPrimitiveType(basicValueType);
                    mapping[primitiveType] = wgslType;
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the underlying type context.
        /// </summary>
        public IRTypeContext TypeContext { get; }

        /// <summary>
        /// Returns the associated WGSL type name.
        /// </summary>
        public string this[TypeNode typeNode]
        {
            get
            {
                using var readWriteScope = readerWriterLock.EnterUpgradeableReadScope();
                if (mapping.TryGetValue(typeNode, out string? typeName))
                    return typeName;

                using var writeScope = readWriteScope.EnterWriteScope();
                return GetOrCreateType(typeNode);
            }
        }

        #endregion

        #region Methods

        public static string GetBasicValueType(BasicValueType type)
        {
            return type switch
            {
                BasicValueType.Int1 => "bool",
                BasicValueType.Int8 => "i32", // WGSL doesn't have i8, promote to i32
                BasicValueType.Int16 => "i32", // WGSL doesn't have i16, promote to i32
                BasicValueType.Int32 => "i32",
                BasicValueType.Int64 => "i32", // TODO: i64 not supported in default WGSL
                BasicValueType.Float16 => "f32", // Promoting
                BasicValueType.Float32 => "f32",
                BasicValueType.Float64 => "f32", // Promoting
                _ => null
            };
        }
        
        public static string GetBasicValueType(ArithmeticBasicValueType type)
        {
             return type switch
            {
                ArithmeticBasicValueType.UInt1 => "bool",
                ArithmeticBasicValueType.Int8 => "i32",
                ArithmeticBasicValueType.Int16 => "i32",
                ArithmeticBasicValueType.Int32 => "i32",
                ArithmeticBasicValueType.Int64 => "i32",
                ArithmeticBasicValueType.UInt8 => "u32",
                ArithmeticBasicValueType.UInt16 => "u32",
                ArithmeticBasicValueType.UInt32 => "u32",
                ArithmeticBasicValueType.UInt64 => "u32",
                ArithmeticBasicValueType.Float16 => "f32",
                ArithmeticBasicValueType.Float32 => "f32",
                ArithmeticBasicValueType.Float64 => "f32",
                _ => null
            };
        }

        private string GetOrCreateType(TypeNode typeNode)
        {
            if (mapping.TryGetValue(typeNode, out string? name))
                return name;

            if (typeNode is PointerType pointerType)
            {
                // In WGSL, pointers are explicit: ptr<storage_class, element_type [, access_mode]>
                var storageClass = pointerType.AddressSpace switch
                {
                    MemoryAddressSpace.Global => "storage",
                    MemoryAddressSpace.Shared => "workgroup",
                    _ => "function"
                };

                var elementType = this[pointerType.ElementType];
                
                if (storageClass == "storage")
                    name = $"ptr<{storageClass}, {elementType}, read_write>";
                else
                    name = $"ptr<{storageClass}, {elementType}>";
            }
            else if (typeNode is StructureType structureType)
            {
                var typeNameStr = structureType.ToString();
                if (typeNameStr.Contains("Index1D") || typeNameStr.Contains("LongIndex1D"))
                {
                    name = "i32";
                }
                else if (typeNameStr.Contains("Index2D") || typeNameStr.Contains("LongIndex2D"))
                {
                    name = "vec2<i32>";
                }
                else if (typeNameStr.Contains("Index3D") || typeNameStr.Contains("LongIndex3D"))
                {
                    name = "vec3<i32>";
                }
                else
                {
                    name = "struct_" + typeNode.Id;
                }
            }
            else if (typeNode is PrimitiveType primitiveType)
            {
                 // Try to resolve primitive type logic again if missing from map
                 name = GetBasicValueType(primitiveType.BasicValueType);
                 if (name == null) name = "u32"; // Actual fallback for unknown primitives
            }
            else
            {
                name = "u32"; // Fallback for unknown node types
            }

            mapping[typeNode] = name;
            return name;
        }

        public void GenerateTypeDefinitions(StringBuilder builder)
        {
             // Emit struct definitions
             foreach(var kvp in mapping)
             {
                 if (kvp.Key is StructureType structType)
                 {
                     builder.AppendLine($"struct {kvp.Value} {{");
                     int fieldIdx = 0;
                     foreach(var fieldType in structType.Fields)
                     {
                         builder.AppendLine($"    field_{fieldIdx} : {this[fieldType]},");
                         fieldIdx++;
                     }
                     builder.AppendLine("};");
                     builder.AppendLine();
                 }
             }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            readerWriterLock.Dispose();
            base.Dispose(disposing);
        }
    }
}
