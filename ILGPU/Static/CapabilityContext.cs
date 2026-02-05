// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CapabilityContext.tt/CapabilityContext.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2024 ILGPU Project
//                                    www.ilgpu.net
//
// File: TypeInformation.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CapabilitiesImporter.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

using System;
using System.Collections.Immutable;
using ILGPU.Resources;

namespace ILGPU.Runtime
{
    /// <summary>
    /// Represents general capabilities available to all accelerators.
    /// </summary>
    public abstract class CapabilityContext
    {
        #region Properties

        /// <summary>
        /// Supports Float16 (Half) data type.
        /// </summary>
        public bool Float16 { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates exception for 'Float16'.
        /// </summary>
        public static Exception GetNotSupportedFloat16Exception() =>
            new CapabilityNotSupportedException(
                string.Format(
                    ErrorMessages.CapabilityNotSupported,
                    "Float16"));

        #endregion
    }
}

namespace ILGPU.Runtime.CPU
{
    /// <summary>
    /// Represents capabilities available to the CPU accelerator.
    /// </summary>
    public sealed class CPUCapabilityContext : CapabilityContext
    {
        #region Instance

        internal CPUCapabilityContext()
        {
            Float16 = true;
        }

        #endregion
    }
}

namespace ILGPU.Runtime.Velocity
{
    /// <summary>
    /// Represents capabilities available to the Velocity accelerator.
    /// </summary>
    public sealed class VelocityCapabilityContext : CapabilityContext
    {
        #region Instance

        internal VelocityCapabilityContext()
        {
            Float16 = false;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}

namespace ILGPU.Runtime.Cuda
{
    /// <summary>
    /// Represents capabilities available to Cuda accelerators.
    /// </summary>
    public sealed class CudaCapabilityContext : CapabilityContext
    {
        #region Instance

        /// <summary>
        /// Create a new capability context of Cuda accelerators.
        /// </summary>
        public CudaCapabilityContext(CudaArchitecture arch)
        {
            Float16 = arch >= CudaArchitecture.SM_53;
            Float16_Min = arch >= CudaArchitecture.SM_75;
            Float16_Max = arch >= CudaArchitecture.SM_80;
            Float16_TanH = arch >= CudaArchitecture.SM_80;
            Float32_TanH = arch >= CudaArchitecture.SM_75;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Supports Float16 intrinsic Min.
        /// </summary>
        public bool Float16_Min { get; internal set; }

        /// <summary>
        /// Supports Float16 intrinsic Max.
        /// </summary>
        public bool Float16_Max { get; internal set; }

        /// <summary>
        /// Supports Float16 intrinsic TanH.
        /// </summary>
        public bool Float16_TanH { get; internal set; }

        /// <summary>
        /// Supports Float32 intrinsic TanH.
        /// </summary>
        public bool Float32_TanH { get; internal set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates exception for 'Float16_Min'.
        /// </summary>
        public static Exception GetNotSupportedFloat16_MinException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupportedCuda,
                    "Intrinsic 'Min' for Float16",
                    CudaArchitecture.SM_75));

        /// <summary>
        /// Creates exception for 'Float16_Max'.
        /// </summary>
        public static Exception GetNotSupportedFloat16_MaxException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupportedCuda,
                    "Intrinsic 'Max' for Float16",
                    CudaArchitecture.SM_80));

        /// <summary>
        /// Creates exception for 'Float16_TanH'.
        /// </summary>
        public static Exception GetNotSupportedFloat16_TanHException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupportedCuda,
                    "Intrinsic 'TanH' for Float16",
                    CudaArchitecture.SM_80));

        /// <summary>
        /// Creates exception for 'Float32_TanH'.
        /// </summary>
        public static Exception GetNotSupportedFloat32_TanHException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupportedCuda,
                    "Intrinsic 'TanH' for Float32",
                    CudaArchitecture.SM_75));

        #endregion
    }
}

namespace ILGPU.Runtime.OpenCL
{
    /// <summary>
    /// Represents capabilities available to OpenCL accelerators.
    /// </summary>
    public sealed class CLCapabilityContext : CapabilityContext
    {
        #region Static

        /// <summary>
        /// Extensions for Float16.
        /// </summary>
        internal static readonly ImmutableArray<string> Float16Extensions =
            ImmutableArray.Create("cl_khr_fp16");

        /// <summary>
        /// Extensions for Float64.
        /// </summary>
        internal static readonly ImmutableArray<string> Float64Extensions =
            ImmutableArray.Create("cl_khr_fp64");

        /// <summary>
        /// Extensions for Int64_Atomics.
        /// </summary>
        internal static readonly ImmutableArray<string> Int64_AtomicsExtensions =
            ImmutableArray.Create("cl_khr_int64_base_atomics", "cl_khr_int64_extended_atomics");

        #endregion

        #region Instance

        /// <summary>
        /// Create a new capability context of OpenCL accelerators.
        /// </summary>
        public CLCapabilityContext(
            bool float16,
            bool float64,
            bool genericAddressSpace,
            bool int64_Atomics,
            bool subGroups
            )
        {
            var extensions = ImmutableArray.CreateBuilder<string>();
            Float16 = float16;
            if (Float16)
                extensions.AddRange(Float16Extensions);
            Float64 = float64;
            if (Float64)
                extensions.AddRange(Float64Extensions);
            GenericAddressSpace = genericAddressSpace;
            Int64_Atomics = int64_Atomics;
            if (Int64_Atomics)
                extensions.AddRange(Int64_AtomicsExtensions);
            SubGroups = subGroups;
            Extensions = extensions.ToImmutable();
        }

        internal CLCapabilityContext(CLDevice device)
        {
            var extensions = ImmutableArray.CreateBuilder<string>();
            Float16 = device.HasAllExtensions(Float16Extensions);
            if (Float16)
                extensions.AddRange(Float16Extensions);
            Float64 = device.HasAllExtensions(Float64Extensions);
            if (Float64)
                extensions.AddRange(Float64Extensions);
            GenericAddressSpace = false;
            Int64_Atomics = device.HasAllExtensions(Int64_AtomicsExtensions);
            if (Int64_Atomics)
                extensions.AddRange(Int64_AtomicsExtensions);
            SubGroups = false;
            Extensions = extensions.ToImmutable();
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of OpenCL extensions.
        /// </summary>
        public ImmutableArray<string> Extensions { get; }

        /// <summary>
        /// Supports Float64 (double) data type.
        /// </summary>
        public bool Float64 { get; internal set; }

        /// <summary>
        /// Supports generic address space.
        /// </summary>
        public bool GenericAddressSpace { get; internal set; }

        /// <summary>
        /// Supports 64-bit Atomics.
        /// </summary>
        public bool Int64_Atomics { get; internal set; }

        /// <summary>
        /// Supports SubGroups.
        /// </summary>
        public bool SubGroups { get; internal set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates exception for 'Float64'.
        /// </summary>
        public static Exception GetNotSupportedFloat64Exception() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupported,
                    "Float64 (double) type"));

        /// <summary>
        /// Creates exception for 'GenericAddressSpace'.
        /// </summary>
        public static Exception GetNotSupportedGenericAddressSpaceException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupported,
                    "GenericAddressSpace feature"));

        /// <summary>
        /// Creates exception for 'Int64_Atomics'.
        /// </summary>
        public static Exception GetNotSupportedInt64_AtomicsException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupported,
                    "64-bit atomics extension"));

        /// <summary>
        /// Creates exception for 'SubGroups'.
        /// </summary>
        public static Exception GetNotSupportedSubGroupsException() =>
            new CapabilityNotSupportedException(
                string.Format(ErrorMessages.CapabilityNotSupported,
                    "SubGroups extension"));

        #endregion
    }
}