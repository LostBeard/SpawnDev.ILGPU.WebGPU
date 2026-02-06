// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuFFTWNativeMethods.tt/CuFFTWNativeMethods.cs
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

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1716 // Identifiers should not match keywords
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable IDE1006 // Naming Styles

namespace ILGPU.Runtime.Cuda.API
{
    public enum CuFFTWAPIVersion
    {
        V10,
        V11,
        V12,
    }

    partial class CuFFTWAPI
    {
        #region Creation

        private static CuFFTWAPI? CreateInternal(CuFFTWAPIVersion version)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTWAPIVersion.V10)
            {
                return new CuFFTWAPI_Windows_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTWAPIVersion.V10)
            {
                return new CuFFTWAPI_Linux_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                version == CuFFTWAPIVersion.V10)
            {
                return new CuFFTWAPI_OSX_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTWAPIVersion.V11)
            {
                return new CuFFTWAPI_Windows_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTWAPIVersion.V11)
            {
                return new CuFFTWAPI_Linux_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuFFTWAPIVersion.V12)
            {
                return new CuFFTWAPI_Windows_V12();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuFFTWAPIVersion.V12)
            {
                return new CuFFTWAPI_Linux_V12();
            }
            return null;
        }

        #endregion

        #region Basic Interface - Complex - Double Precision

        public unsafe abstract IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        public unsafe abstract IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        public unsafe abstract IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endregion

        #region Advanced Interface - Double Precision

        public unsafe abstract IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endregion

        #region Guru Interface - Double Precision

        public unsafe abstract IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        public unsafe abstract IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endregion

        #region Plan Execution - Double Precision

        public abstract void fftw_execute(
            [In] IntPtr plan);

        public unsafe abstract void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        public unsafe abstract void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        public unsafe abstract void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endregion

        #region Utilities - Double Precision

        public abstract void fftw_destroy_plan(
            [In] IntPtr plan);

        public abstract void fftw_set_timelimit(
            [In] double seconds);

        public abstract void fftw_cleanup(
              );

        #endregion

        #region Basic Interface - Complex - Single Precision

        public unsafe abstract IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        public unsafe abstract IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        public unsafe abstract IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endregion

        #region Advanced Interface - Single Precision

        public unsafe abstract IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endregion

        #region Guru Interface - Single Precision

        public unsafe abstract IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        public unsafe abstract IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        public unsafe abstract IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endregion

        #region Plan Execution - Single Precision

        public abstract void fftwf_execute(
            [In] IntPtr plan);

        public unsafe abstract void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        public unsafe abstract void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        public unsafe abstract void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endregion

        #region Utilities - Single Precision

        public abstract void fftwf_destroy_plan(
            [In] IntPtr plan);

        public abstract void fftwf_set_timelimit(
            [In] double seconds);

        public abstract void fftwf_cleanup(
              );

        #endregion

        #region Unsupported

        internal abstract IntPtr @malloc(
            [In] IntPtr size);

        internal abstract void @free(
            [In] IntPtr size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Windows_V10 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "cufftw64_10.dll";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Linux_V10 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "libcufftw.so.10";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_OSX_V10 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "libcufftw.10.dylib";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Windows_V11 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "cufftw64_11.dll";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Linux_V11 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "libcufftw.so.11";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Windows_V12 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "cufftw64_11.dll";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuFFTWAPI_Linux_V12 : CuFFTWAPI
    {
        #region Constants

        public const string LibName = "libcufftw.so.12";

        #endregion

        #region Basic Interface - Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_1d_Import(
             int nx,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_r2c_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_1d_Import(
             int nx,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_1d(
            [In] int nx,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_dft_c2r_Import(
             int rank,
             int* n,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             double* @in,
             int* inembded,
             int istride,
             int idist,
             double* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] double* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] double* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftw_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] int sign,
            [In] uint flags) =>
            fftw_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftw_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             double* @in,
             double* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftw_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftw_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] double* @in,
            [In] double* @out,
            [In] uint flags) =>
            fftw_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_execute(
            [In] IntPtr plan) =>
            fftw_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_r2c_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_r2c(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftw_execute_dft_c2r_Import(
             IntPtr plan,
             double* @in,
             double* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftw_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out);

        #endif
        public unsafe sealed override void fftw_execute_dft_c2r(
            [In] IntPtr plan,
            [In] double* @in,
            [In] double* @out) =>
            fftw_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Double Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftw_destroy_plan(
            [In] IntPtr plan) =>
            fftw_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftw_set_timelimit(
            [In] double seconds) =>
            fftw_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_cleanup_Import(
              );

        #endif
        public sealed override void fftw_cleanup(
              ) =>
            fftw_cleanup_Import(
                );

        #endregion

        #region Basic Interface - Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_1d_Import(
             int nx,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_1d_Import(
                nx,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_2d_Import(
                nx,
                ny,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_dft_Import(
                rank,
                n,
                @in,
                @out,
                sign,
                flags);

        #endregion

        #region Basic Interface - Real to Complex - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_r2c_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_r2c_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Basic Interface - Complex to Real - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_1d_Import(
             int nx,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_1d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_1d_Import(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_1d(
            [In] int nx,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_1d_Import(
                nx,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_2d_Import(
             int nx,
             int ny,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_2d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_2d_Import(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_2d(
            [In] int nx,
            [In] int ny,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_2d_Import(
                nx,
                ny,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_3d_Import(
             int nx,
             int ny,
             int nz,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r_3d"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_3d_Import(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r_3d(
            [In] int nx,
            [In] int ny,
            [In] int nz,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_3d_Import(
                nx,
                ny,
                nz,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_dft_c2r_Import(
             int rank,
             int* n,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_dft_c2r_Import(
                rank,
                n,
                @in,
                @out,
                flags);

        #endregion

        #region Advanced Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_many_dft_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_r2c_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_r2c_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_r2c(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_r2c_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_many_dft_c2r_Import(
             int rank,
             int* n,
             int batch,
             float* @in,
             int* inembded,
             int istride,
             int idist,
             float* @out,
             int* onembded,
             int ostride,
             int odist,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_many_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_many_dft_c2r_Import(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_many_dft_c2r(
            [In] int rank,
            [In] int* n,
            [In] int batch,
            [In] float* @in,
            [In] int* inembded,
            [In] int istride,
            [In] int idist,
            [In] float* @out,
            [In] int* onembded,
            [In] int ostride,
            [In] int odist,
            [In] uint flags) =>
            fftwf_plan_many_dft_c2r_Import(
                rank,
                n,
                batch,
                @in,
                inembded,
                istride,
                idist,
                @out,
                onembded,
                ostride,
                odist,
                flags);

        #endregion

        #region Guru Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_r2c_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_r2c_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_r2c(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru_dft_c2r_Import(
             int rank,
             iodim* dims,
             int batch_rank,
             iodim* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru_dft_c2r_Import(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru_dft_c2r(
            [In] int rank,
            [In] iodim* dims,
            [In] int batch_rank,
            [In] iodim* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Guru 64-bit Interface - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             int sign,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] int sign,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                sign,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_r2c_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_r2c(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_r2c_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
             int rank,
             iodim64* dims,
             int batch_rank,
             iodim64* batch_dims,
             float* @in,
             float* @out,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_plan_guru64_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         IntPtr fftwf_plan_guru64_dft_c2r_Import(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags);

        #endif
        public unsafe sealed override IntPtr fftwf_plan_guru64_dft_c2r(
            [In] int rank,
            [In] iodim64* dims,
            [In] int batch_rank,
            [In] iodim64* batch_dims,
            [In] float* @in,
            [In] float* @out,
            [In] uint flags) =>
            fftwf_plan_guru64_dft_c2r_Import(
                rank,
                dims,
                batch_rank,
                batch_dims,
                @in,
                @out,
                flags);

        #endregion

        #region Plan Execution - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_execute_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_execute_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_execute(
            [In] IntPtr plan) =>
            fftwf_execute_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_r2c_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_r2c"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_r2c_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_r2c(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_r2c_Import(
                plan,
                @in,
                @out);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         void fftwf_execute_dft_c2r_Import(
             IntPtr plan,
             float* @in,
             float* @out);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_execute_dft_c2r"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         void fftwf_execute_dft_c2r_Import(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out);

        #endif
        public unsafe sealed override void fftwf_execute_dft_c2r(
            [In] IntPtr plan,
            [In] float* @in,
            [In] float* @out) =>
            fftwf_execute_dft_c2r_Import(
                plan,
                @in,
                @out);

        #endregion

        #region Utilities - Single Precision

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_destroy_plan_Import(
             IntPtr plan);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_destroy_plan"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_destroy_plan_Import(
            [In] IntPtr plan);

        #endif
        public sealed override void fftwf_destroy_plan(
            [In] IntPtr plan) =>
            fftwf_destroy_plan_Import(
                plan);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_set_timelimit_Import(
             double seconds);

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_set_timelimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_set_timelimit_Import(
            [In] double seconds);

        #endif
        public sealed override void fftwf_set_timelimit(
            [In] double seconds) =>
            fftwf_set_timelimit_Import(
                seconds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftwf_cleanup_Import(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "fftwf_cleanup"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftwf_cleanup_Import(
              );

        #endif
        public sealed override void fftwf_cleanup(
              ) =>
            fftwf_cleanup_Import(
                );

        #endregion

        #region Unsupported

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr fftw_malloc_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_malloc"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr fftw_malloc_Import(
            [In] IntPtr size);

        #endif
        internal sealed override IntPtr @malloc(
            [In] IntPtr size) =>
            fftw_malloc_Import(
                size);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         void fftw_free_Import(
             IntPtr size);

        #else
        [DllImport(LibName,
            EntryPoint = "fftw_free"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         void fftw_free_Import(
            [In] IntPtr size);

        #endif
        internal sealed override void @free(
            [In] IntPtr size) =>
            fftw_free_Import(
                size);

        #endregion

    }

}


#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore CA1716 // Identifiers should not match keywords
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore IDE1006 // Naming Styles