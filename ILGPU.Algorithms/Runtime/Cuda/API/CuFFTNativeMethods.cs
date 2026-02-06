// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTNativeMethods.tt/CuFFTNativeMethods.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2021-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: DllLibraryImporter.ttinclude
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
// File: DllImporter.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: TextTemplateHelpers.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ILGPU.Runtime.Cuda.API
{
    public enum CuFFTAPIVersion
    {
        V10,
        V11,
        V12,
    }

    partial class CuFFTAPI
    {
        #region Creation

        private static CuFFTAPI? CreateInternal(CuFFTAPIVersion version)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTAPIVersion.V10)
            {
                return new CuFFTAPI_Windows_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTAPIVersion.V10)
            {
                return new CuFFTAPI_Linux_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                version == CuFFTAPIVersion.V10)
            {
                return new CuFFTAPI_OSX_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTAPIVersion.V11)
            {
                return new CuFFTAPI_Windows_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTAPIVersion.V11)
            {
                return new CuFFTAPI_Linux_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTAPIVersion.V12)
            {
                return new CuFFTAPI_Windows_V12();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTAPIVersion.V12)
            {
                return new CuFFTAPI_Linux_V12();
            }
            return null;
        }

        #endregion

        #region Basic Plans

        public abstract CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        public abstract CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        public abstract CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        public unsafe abstract CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endregion

        #region Extensible Plans

        public abstract CuFFTResult Create(
            [Out] out IntPtr plan);

        public unsafe abstract CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endregion

        #region Estimated Size Of Work Area

        public unsafe abstract CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        public unsafe abstract CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        public unsafe abstract CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endregion

        #region Caller Allocated Work Area Support

        public abstract CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        public abstract CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endregion

        #region Execution

        public abstract CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        public abstract CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        public abstract CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        public abstract CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        public abstract CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        public abstract CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endregion

        #region Utilities

        public abstract CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        public abstract CuFFTResult Destroy(
            [In] IntPtr plan);

        public abstract CuFFTResult GetVersion(
            [Out] out int version);

        public abstract CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Windows_V10 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "cufft64_10.dll";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Linux_V10 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "libcufft.so.10";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_OSX_V10 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "libcufft.10.dylib";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Windows_V11 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "cufft64_11.dll";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Linux_V11 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "libcufft.so.11";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Windows_V12 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "cufft64_11.dll";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTAPI_Linux_V12 : CuFFTAPI
    {
        #region Constants

        public const string LibName = "libcufft.so.12";

        #endregion

        #region Basic Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan1d(
             out IntPtr plan,
             int nx,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan1d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public sealed override CuFFTResult Plan1D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlan1d(
                out plan,
                nx,
                type,
                batch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan2d(
             out IntPtr plan,
             int nx,
             int ny,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan2d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan2D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type) =>
            cufftPlan2d(
                out plan,
                nx,
                ny,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftPlan3d(
             out IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftPlan3d(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type);

        #endif
        public sealed override CuFFTResult Plan3D(
            [Out] out IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type) =>
            cufftPlan3d(
                out plan,
                nx,
                ny,
                nz,
                type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftPlanMany(
             out IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftPlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftPlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch);

        #endif
        public unsafe sealed override CuFFTResult PlanMany(
            [Out] out IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch) =>
            cufftPlanMany(
                out plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch);

        #endregion

        #region Extensible Plans

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftCreate(
             out IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftCreate(
            [Out] out IntPtr plan);

        #endif
        public sealed override CuFFTResult Create(
            [Out] out IntPtr plan) =>
            cufftCreate(
                out plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlan1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlan3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlan3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlan3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlan3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftMakePlan3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftMakePlanMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftMakePlanMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftMakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult MakePlanMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftMakePlanMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate1d(
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate1d(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate1D(
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimate1d(
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate2d(
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate2d(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate2D(
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate2d(
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimate3d(
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimate3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimate3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult Estimate3D(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftEstimate3d(
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftEstimateMany(
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftEstimateMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftEstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult EstimateMany(
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftEstimateMany(
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #endregion

        #region Refined Estimated Size Of Work Area

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize1d(
             IntPtr plan,
             int nx,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize1d(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize1D(
            [In] IntPtr plan,
            [In] int nx,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSize1d(
                plan,
                nx,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize2d(
             IntPtr plan,
             int nx,
             int ny,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize2d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize2D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize2d(
                plan,
                nx,
                ny,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize3d(
             IntPtr plan,
             int nx,
             int ny,
             int nz,
             CuFFTType type,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize3d(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSize3D(
            [In] IntPtr plan,
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] CuFFTType type,
            [In] UIntPtr* workSize) =>
            cufftGetSize3d(
                plan,
                nx,
                ny,
                nz,
                type,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany(
             IntPtr plan,
             int rank,
             int* n,
             int* inembed,
             int istride,
             int idist,
             int* onembed,
             int ostride,
             int odist,
             CuFFTType type,
             int batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany(
            [In] IntPtr plan,
            [In] int rank,
            [In] int* n,
            [In] int* inembed,
            [In] int istride,
            [In] int idist,
            [In] int* onembed,
            [In] int ostride,
            [In] int odist,
            [In] CuFFTType type,
            [In] int batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSizeMany64(
             IntPtr plan,
             int rank,
             long* n,
             long* inembed,
             long istride,
             long idist,
             long* onembed,
             long ostride,
             long odist,
             CuFFTType type,
             long batch,
             UIntPtr* workSize);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSizeMany64"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize);

        #endif
        public unsafe sealed override CuFFTResult GetSizeMany64(
            [In] IntPtr plan,
            [In] int rank,
            [In] long* n,
            [In] long* inembed,
            [In] long istride,
            [In] long idist,
            [In] long* onembed,
            [In] long ostride,
            [In] long odist,
            [In] CuFFTType type,
            [In] long batch,
            [In] UIntPtr* workSize) =>
            cufftGetSizeMany64(
                plan,
                rank,
                n,
                inembed,
                istride,
                idist,
                onembed,
                ostride,
                odist,
                type,
                batch,
                workSize);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         CuFFTResult cufftGetSize(
             IntPtr plan,
             UIntPtr* workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         CuFFTResult cufftGetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea);

        #endif
        public unsafe sealed override CuFFTResult GetSize(
            [In] IntPtr plan,
            [In] UIntPtr* workArea) =>
            cufftGetSize(
                plan,
                workArea);

        #endregion

        #region Caller Allocated Work Area Support

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetAutoAllocation(
             IntPtr plan,
             int autoAllocate);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetAutoAllocation"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate);

        #endif
        public sealed override CuFFTResult SetAutoAllocation(
            [In] IntPtr plan,
            [In] int autoAllocate) =>
            cufftSetAutoAllocation(
                plan,
                autoAllocate);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetWorkArea(
             IntPtr plan,
             IntPtr workArea);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetWorkArea"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea);

        #endif
        public sealed override CuFFTResult SetWorkArea(
            [In] IntPtr plan,
            [In] IntPtr workArea) =>
            cufftSetWorkArea(
                plan,
                workArea);

        #endregion

        #region Execution

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecC2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecC2C(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata,
             CuFFTDirection direction);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction);

        #endif
        public sealed override CuFFTResult ExecZ2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata,
            [In] CuFFTDirection direction) =>
            cufftExecZ2Z(
                plan,
                idata,
                odata,
                direction);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecR2C(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecR2C"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecR2C(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecR2C(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecD2Z(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecD2Z"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecD2Z(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecD2Z(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecC2R(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecC2R"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecC2R(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecC2R(
                plan,
                idata,
                odata);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftExecZ2D(
             IntPtr plan,
             IntPtr idata,
             IntPtr odata);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftExecZ2D"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata);

        #endif
        public sealed override CuFFTResult ExecZ2D(
            [In] IntPtr plan,
            [In] IntPtr idata,
            [In] IntPtr odata) =>
            cufftExecZ2D(
                plan,
                idata,
                odata);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftSetStream(
             IntPtr plan,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftSetStream(
            [In] IntPtr plan,
            [In] IntPtr stream);

        #endif
        public sealed override CuFFTResult SetStream(
            [In] IntPtr plan,
            [In] IntPtr stream) =>
            cufftSetStream(
                plan,
                stream);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftDestroy(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftDestroy"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftDestroy(
            [In] IntPtr plan);

        #endif
        public sealed override CuFFTResult Destroy(
            [In] IntPtr plan) =>
            cufftDestroy(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuFFTResult GetVersion(
            [Out] out int version) =>
            cufftGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuFFTResult cufftGetProperty(
             LibraryPropertyType type,
             out int value);

        #else
        [DllImport(LibName,
            EntryPoint = "cufftGetProperty"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuFFTResult cufftGetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value);

        #endif
        public sealed override CuFFTResult GetProperty(
            [In] LibraryPropertyType type,
            [Out] out int value) =>
            cufftGetProperty(
                type,
                out value);

        #endregion

    }

}


#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member