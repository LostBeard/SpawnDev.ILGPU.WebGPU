// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CuRandNativeMethods.tt/CuRandNativeMethods.cs
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
    public enum CuRandAPIVersion
    {
        V9,
        V10,
        V11,
        V12,
    }

    partial class CuRandAPI
    {
        #region Creation

        private static CuRandAPI? CreateInternal(CuRandAPIVersion version)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuRandAPIVersion.V9)
            {
                return new CuRandAPI_Windows_V9();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuRandAPIVersion.V9)
            {
                return new CuRandAPI_Linux_V9();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                version == CuRandAPIVersion.V9)
            {
                return new CuRandAPI_OSX_V9();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuRandAPIVersion.V10)
            {
                return new CuRandAPI_Windows_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuRandAPIVersion.V10)
            {
                return new CuRandAPI_Linux_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                version == CuRandAPIVersion.V10)
            {
                return new CuRandAPI_OSX_V10();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuRandAPIVersion.V11)
            {
                return new CuRandAPI_Windows_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuRandAPIVersion.V11)
            {
                return new CuRandAPI_Linux_V11();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == CuRandAPIVersion.V12)
            {
                return new CuRandAPI_Windows_V12();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == CuRandAPIVersion.V12)
            {
                return new CuRandAPI_Linux_V12();
            }
            return null;
        }

        #endregion

        #region Creation

        public abstract CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        public abstract CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        public abstract CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle);

        #endregion

        #region Generation

        public abstract CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        public abstract CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle);

        public abstract CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        public abstract CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        public abstract CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        public abstract CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        public abstract CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        public abstract CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endregion

        #region Utilities

        public abstract CuRandStatus GetVersion(
            [Out] out int version);

        public abstract CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Windows_V9 : CuRandAPI
    {
        #region Constants

        public const string LibName = "curand64_9.dll";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Linux_V9 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.so.9";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_OSX_V9 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.9.dylib";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Windows_V10 : CuRandAPI
    {
        #region Constants

        public const string LibName = "curand64_10.dll";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Linux_V10 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.so.10";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_OSX_V10 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.10.dylib";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Windows_V11 : CuRandAPI
    {
        #region Constants

        public const string LibName = "curand64_10.dll";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Linux_V11 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.so.11";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Windows_V12 : CuRandAPI
    {
        #region Constants

        public const string LibName = "curand64_10.dll";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class CuRandAPI_Linux_V12 : CuRandAPI
    {
        #region Constants

        public const string LibName = "libcurand.so.12";

        #endregion

        #region Creation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGenerator(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGenerator(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGenerator(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandCreateGeneratorHost(
             out IntPtr libHandle,
             CuRandRngType rngType);

        #else
        [DllImport(LibName,
            EntryPoint = "curandCreateGeneratorHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandCreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType);

        #endif
        public sealed override CuRandStatus CreateGeneratorHost(
            [Out] out IntPtr libHandle,
            [In] CuRandRngType rngType) =>
            curandCreateGeneratorHost(
                out libHandle,
                rngType);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandDestroyGenerator(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandDestroyGenerator"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandDestroyGenerator(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus DestroyGenerator(
            [In] IntPtr libHandle) =>
            curandDestroyGenerator(
                libHandle);

        #endregion

        #region Generation

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
             IntPtr libHandle,
             long seed);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetPseudoRandomGeneratorSeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetPseudoRandomGeneratorSeed(
            [In] IntPtr libHandle,
            [In] long seed);

        #endif
        public sealed override CuRandStatus SetSeed(
            [In] IntPtr libHandle,
            [In] long seed) =>
            curandSetPseudoRandomGeneratorSeed(
                libHandle,
                seed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateSeeds(
             IntPtr libHandle);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateSeeds"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateSeeds(
            [In] IntPtr libHandle);

        #endif
        public sealed override CuRandStatus GenerateSeeds(
            [In] IntPtr libHandle) =>
            curandGenerateSeeds(
                libHandle);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerate(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerate(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUInt(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerate(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateLongLong(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateLongLong"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateLongLong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateULong(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateLongLong(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniform(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniform"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniform(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniform(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateUniformDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateUniformDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length);

        #endif
        public sealed override CuRandStatus GenerateUniformDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length) =>
            curandGenerateUniformDouble(
                libHandle,
                outputPtr,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormal(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             float mean,
             float stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormal"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormal(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalFloat(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] float mean,
            [In] float stddev) =>
            curandGenerateNormal(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGenerateNormalDouble(
             IntPtr libHandle,
             IntPtr outputPtr,
             IntPtr length,
             double mean,
             double stddev);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGenerateNormalDouble"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev);

        #endif
        public sealed override CuRandStatus GenerateNormalDouble(
            [In] IntPtr libHandle,
            [In] IntPtr outputPtr,
            [In] IntPtr length,
            [In] double mean,
            [In] double stddev) =>
            curandGenerateNormalDouble(
                libHandle,
                outputPtr,
                length,
                mean,
                stddev);

        #endregion

        #region Utilities

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandGetVersion(
             out int version);

        #else
        [DllImport(LibName,
            EntryPoint = "curandGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandGetVersion(
            [Out] out int version);

        #endif
        public sealed override CuRandStatus GetVersion(
            [Out] out int version) =>
            curandGetVersion(
                out version);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CuRandStatus curandSetStream(
             IntPtr libHandle,
             IntPtr stream);

        #else
        [DllImport(LibName,
            EntryPoint = "curandSetStream"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CuRandStatus curandSetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream);

        #endif
        public sealed override CuRandStatus SetStream(
            [In] IntPtr libHandle,
            [In] IntPtr stream) =>
            curandSetStream(
                libHandle,
                stream);

        #endregion

    }

}


#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member