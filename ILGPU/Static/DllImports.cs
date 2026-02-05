// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                        Copyright (c) 2016-2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: DllImports.tt/DllImports.cs
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

using ILGPU.Resources;
using System;
using System.Runtime.InteropServices;

#pragma warning disable IDE1006 // Naming
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace ILGPU.Runtime.Cuda
{
    public unsafe abstract partial class CudaAPI : RuntimeAPI
    {
        #region Constants

        /// <summary>
        /// Represents the driver library name on Windows.
        /// </summary>
        public const string LibNameWindows = "nvcuda";

        /// <summary>
        /// Represents the driver library name on Linux.
        /// </summary>
        public const string LibNameLinux = "cuda";

        /// <summary>
        /// Represents the driver library name on MacOS.
        /// </summary>
        public const string LibNameMacOS = "cuda";

        #endregion

        #region Native Methods

        internal abstract CudaError cuInit(
            [In] int flags);

        internal abstract CudaError cuDriverGetVersion(
            [Out] out int driverVersion);

        internal abstract CudaError cuDeviceGet(
            [Out] out int device,
            [In] int ordinal);

        internal abstract CudaError cuDeviceGetCount(
            [Out] out int count);

        internal abstract CudaError cuDeviceGetName(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device);

        internal abstract CudaError cuDeviceTotalMem_v2(
            [Out] out IntPtr bytes,
            [In] int device);

        internal abstract CudaError cuDeviceGetAttribute(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device);

        internal abstract CudaError cuCtxCreate_v2(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device);

        internal abstract CudaError cuCtxDestroy_v2(
            [In] IntPtr context);

        internal abstract CudaError cuCtxSetCurrent(
            [In] IntPtr context);

        internal abstract CudaError cuCtxSynchronize(
              );

        internal abstract CudaError cuCtxGetCacheConfig(
            [Out] out CudaCacheConfiguration pconfig);

        internal abstract CudaError cuCtxSetCacheConfig(
            [In] CudaCacheConfiguration config);

        internal abstract CudaError cuCtxGetSharedMemConfig(
            [Out] out CudaSharedMemoryConfiguration pConfig);

        internal abstract CudaError cuCtxSetSharedMemConfig(
            [In] CudaSharedMemoryConfiguration config);

        internal abstract CudaError cuDeviceCanAccessPeer(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev);

        internal abstract CudaError cuCtxEnablePeerAccess(
            [In] IntPtr peerContext,
            [In] int flags);

        internal abstract CudaError cuCtxDisablePeerAccess(
            [In] IntPtr peerContext);

        internal abstract CudaError cuDeviceGetP2PAttribute(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice);

        internal abstract CudaError cuPointerGetAttribute(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr);

        internal abstract CudaError cuMemGetInfo_v2(
            [Out] out IntPtr free,
            [Out] out IntPtr total);

        internal abstract CudaError cuMemAlloc_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        internal abstract CudaError cuMemFree_v2(
            [In] IntPtr devicePtr);

        internal abstract CudaError cuMemAllocHost_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        internal abstract CudaError cuMemFreeHost(
            [In] IntPtr devicePtr);

        internal abstract CudaError cuMemcpyAsync(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream);

        internal abstract CudaError cuMemsetD8Async(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream);

        internal abstract CudaError cuMemHostRegister_v2(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags);

        internal abstract CudaError cuMemHostUnregister(
            [In] IntPtr hostPtr);

        internal abstract CudaError cuMemHostGetDevicePointer_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags);

        internal abstract CudaError cuStreamCreate(
            [Out] out IntPtr stream,
            [In] StreamFlags flags);

        internal abstract CudaError cuStreamCreateWithPriority(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority);

        internal abstract CudaError cuStreamDestroy_v2(
            [In] IntPtr stream);

        internal abstract CudaError cuStreamSynchronize(
            [In] IntPtr stream);

        internal abstract CudaError cuGetErrorString(
            [In] CudaError error,
            [Out] out IntPtr pStr);

        internal abstract CudaError cuModuleLoadData(
            [Out] out IntPtr module,
            [In] string moduleData);

        internal abstract CudaError cuModuleLoadDataEx(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues);

        internal abstract CudaError cuModuleUnload(
            [In] IntPtr module);

        internal abstract CudaError cuModuleGetFunction(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName);

        internal abstract CudaError cuLaunchKernel(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs);

        internal abstract CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize);

        internal abstract CudaError cuOccupancyMaxPotentialBlockSize(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit);

        internal abstract CudaError cuEventCreate(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags);

        internal abstract CudaError cuEventDestroy_v2(
            [In] IntPtr @event);

        internal abstract CudaError cuEventQuery(
            [In] IntPtr @event);

        internal abstract CudaError cuEventElapsedTime(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end);

        internal abstract CudaError cuEventRecord(
            [In] IntPtr @event,
            [In] IntPtr stream);

        internal abstract CudaError cuEventSynchronize(
            [In] IntPtr @event);

        #endregion

        #region Static

        /// <summary>
        /// Returns the driver API for the current platform.
        /// </summary>
        public static CudaAPI CurrentAPI { get; } =
            LoadRuntimeAPI<
            CudaAPI,
            CudaAPI_0,
            CudaAPI_1,
            CudaAPI_1,
            CudaAPI_NotSupported>();

        #endregion
    }

    // Platform implementations


    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    sealed unsafe partial class CudaAPI_0 : CudaAPI
    {
        #region Native Methods

        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuInit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuInit_Import(
             int flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuInit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuInit_Import(
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDriverGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDriverGetVersion_Import(
             out int driverVersion);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDriverGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDriverGetVersion_Import(
            [Out] out int driverVersion);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceGet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGet_Import(
             out int device,
             int ordinal);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceGet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGet_Import(
            [Out] out int device,
            [In] int ordinal);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetCount_Import(
             out int count);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetCount_Import(
            [Out] out int count);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetName_Import(
             byte[] name,
             int length,
             int device);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetName_Import(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceTotalMem_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceTotalMem_v2_Import(
             out IntPtr bytes,
             int device);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceTotalMem_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceTotalMem_v2_Import(
            [Out] out IntPtr bytes,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetAttribute_Import(
             out int value,
             DeviceAttributeKind attribute,
             int device);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetAttribute_Import(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxCreate_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxCreate_v2_Import(
             out IntPtr context,
             CudaAcceleratorFlags flags,
             int device);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxCreate_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxCreate_v2_Import(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxDestroy_v2_Import(
             IntPtr context);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxDestroy_v2_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxSetCurrent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetCurrent_Import(
             IntPtr context);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxSetCurrent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetCurrent_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSynchronize_Import(
              );

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSynchronize_Import(
              );

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxGetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxGetCacheConfig_Import(
             out CudaCacheConfiguration pconfig);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxGetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxGetCacheConfig_Import(
            [Out] out CudaCacheConfiguration pconfig);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxSetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetCacheConfig_Import(
             CudaCacheConfiguration config);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxSetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetCacheConfig_Import(
            [In] CudaCacheConfiguration config);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxGetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxGetSharedMemConfig_Import(
             out CudaSharedMemoryConfiguration pConfig);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxGetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxGetSharedMemConfig_Import(
            [Out] out CudaSharedMemoryConfiguration pConfig);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxSetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetSharedMemConfig_Import(
             CudaSharedMemoryConfiguration config);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxSetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetSharedMemConfig_Import(
            [In] CudaSharedMemoryConfiguration config);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceCanAccessPeer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceCanAccessPeer_Import(
             out int canAccess,
             int device,
             int peerDev);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceCanAccessPeer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceCanAccessPeer_Import(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxEnablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxEnablePeerAccess_Import(
             IntPtr peerContext,
             int flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxEnablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxEnablePeerAccess_Import(
            [In] IntPtr peerContext,
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuCtxDisablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxDisablePeerAccess_Import(
             IntPtr peerContext);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuCtxDisablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxDisablePeerAccess_Import(
            [In] IntPtr peerContext);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuDeviceGetP2PAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetP2PAttribute_Import(
             out int value,
             Peer2PeerAttribute attrib,
             int sourceDevice,
             int destinationDevice);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuDeviceGetP2PAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetP2PAttribute_Import(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuPointerGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuPointerGetAttribute_Import(
             IntPtr targetPtr,
             PointerAttribute attribute,
             IntPtr devicePtr);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuPointerGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuPointerGetAttribute_Import(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemGetInfo_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemGetInfo_v2_Import(
             out IntPtr free,
             out IntPtr total);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemGetInfo_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemGetInfo_v2_Import(
            [Out] out IntPtr free,
            [Out] out IntPtr total);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemAlloc_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemAlloc_v2_Import(
             out IntPtr devicePtr,
             IntPtr bytesize);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemAlloc_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemAlloc_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemFree_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemFree_v2_Import(
             IntPtr devicePtr);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemFree_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemFree_v2_Import(
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemAllocHost_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemAllocHost_v2_Import(
             out IntPtr devicePtr,
             IntPtr bytesize);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemAllocHost_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemAllocHost_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemFreeHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemFreeHost_Import(
             IntPtr devicePtr);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemFreeHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemFreeHost_Import(
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemcpyAsync"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemcpyAsync_Import(
             IntPtr destination,
             IntPtr source,
             IntPtr length,
             IntPtr stream);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemcpyAsync"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemcpyAsync_Import(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemsetD8Async"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemsetD8Async_Import(
             IntPtr destinationDevice,
             byte value,
             IntPtr length,
             IntPtr stream);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemsetD8Async"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemsetD8Async_Import(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemHostRegister_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostRegister_v2_Import(
             IntPtr hostPtr,
             IntPtr bytesize,
             MemHostRegisterFlags flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemHostRegister_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostRegister_v2_Import(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemHostUnregister"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostUnregister_Import(
             IntPtr hostPtr);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemHostUnregister"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostUnregister_Import(
            [In] IntPtr hostPtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuMemHostGetDevicePointer_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostGetDevicePointer_v2_Import(
             out IntPtr devicePtr,
             IntPtr hostPtr,
             int flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuMemHostGetDevicePointer_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostGetDevicePointer_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuStreamCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamCreate_Import(
             out IntPtr stream,
             StreamFlags flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuStreamCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamCreate_Import(
            [Out] out IntPtr stream,
            [In] StreamFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuStreamCreateWithPriority"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamCreateWithPriority_Import(
             out IntPtr stream,
             StreamFlags flags,
             int priority);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuStreamCreateWithPriority"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamCreateWithPriority_Import(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuStreamDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamDestroy_v2_Import(
             IntPtr stream);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuStreamDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamDestroy_v2_Import(
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuStreamSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamSynchronize_Import(
             IntPtr stream);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuStreamSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamSynchronize_Import(
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuGetErrorString"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuGetErrorString_Import(
             CudaError error,
             out IntPtr pStr);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuGetErrorString"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuGetErrorString_Import(
            [In] CudaError error,
            [Out] out IntPtr pStr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuModuleLoadData"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleLoadData_Import(
             out IntPtr module,
             string moduleData);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuModuleLoadData"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleLoadData_Import(
            [Out] out IntPtr module,
            [In] string moduleData);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuModuleLoadDataEx"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleLoadDataEx_Import(
             out IntPtr module,
             string moduleData,
             int numOptions,
             IntPtr jitOptions,
             IntPtr jitOptionValues);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuModuleLoadDataEx"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleLoadDataEx_Import(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuModuleUnload"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleUnload_Import(
             IntPtr module);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuModuleUnload"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleUnload_Import(
            [In] IntPtr module);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuModuleGetFunction"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleGetFunction_Import(
             out IntPtr function,
             IntPtr module,
             string functionName);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuModuleGetFunction"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleGetFunction_Import(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuLaunchKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuLaunchKernel_Import(
             IntPtr function,
             int gridDimX,
             int gridDimY,
             int gridDimZ,
             int blockDimX,
             int blockDimY,
             int blockDimZ,
             int sharedMemSizeInBytes,
             IntPtr stream,
             IntPtr args,
             IntPtr kernelArgs);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuLaunchKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuLaunchKernel_Import(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuOccupancyMaxActiveBlocksPerMultiprocessor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
             out int numBlocks,
             IntPtr func,
             int blockSize,
             IntPtr dynamicSMemSize);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuOccupancyMaxActiveBlocksPerMultiprocessor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuOccupancyMaxPotentialBlockSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuOccupancyMaxPotentialBlockSize_Import(
             out int minGridSize,
             out int blockSize,
             IntPtr func,
             ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
             IntPtr dynamicSMemSize,
             int blockSizeLimit);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuOccupancyMaxPotentialBlockSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuOccupancyMaxPotentialBlockSize_Import(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventCreate_Import(
             out IntPtr @event,
             CudaEventFlags flags);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventCreate_Import(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventDestroy_v2_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventDestroy_v2_Import(
            [In] IntPtr @event);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventQuery"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventQuery_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventQuery"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventQuery_Import(
            [In] IntPtr @event);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventElapsedTime"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventElapsedTime_Import(
             out float milliseconds,
             IntPtr start,
             IntPtr end);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventElapsedTime"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventElapsedTime_Import(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventRecord"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventRecord_Import(
             IntPtr @event,
             IntPtr stream);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventRecord"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventRecord_Import(
            [In] IntPtr @event,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "cuEventSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventSynchronize_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "cuEventSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventSynchronize_Import(
            [In] IntPtr @event);

        #endif
        #endregion

        #region RuntimeAPI

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsSupported => true;

        #endregion

        #region Implementations

        internal sealed override CudaError cuInit(
            [In] int flags) =>
            cuInit_Import(
                flags);

        internal sealed override CudaError cuDriverGetVersion(
            [Out] out int driverVersion) =>
            cuDriverGetVersion_Import(
                out driverVersion);

        internal sealed override CudaError cuDeviceGet(
            [Out] out int device,
            [In] int ordinal) =>
            cuDeviceGet_Import(
                out device,
                ordinal);

        internal sealed override CudaError cuDeviceGetCount(
            [Out] out int count) =>
            cuDeviceGetCount_Import(
                out count);

        internal sealed override CudaError cuDeviceGetName(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device) =>
            cuDeviceGetName_Import(
                name,
                length,
                device);

        internal sealed override CudaError cuDeviceTotalMem_v2(
            [Out] out IntPtr bytes,
            [In] int device) =>
            cuDeviceTotalMem_v2_Import(
                out bytes,
                device);

        internal sealed override CudaError cuDeviceGetAttribute(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device) =>
            cuDeviceGetAttribute_Import(
                out value,
                attribute,
                device);

        internal sealed override CudaError cuCtxCreate_v2(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device) =>
            cuCtxCreate_v2_Import(
                out context,
                flags,
                device);

        internal sealed override CudaError cuCtxDestroy_v2(
            [In] IntPtr context) =>
            cuCtxDestroy_v2_Import(
                context);

        internal sealed override CudaError cuCtxSetCurrent(
            [In] IntPtr context) =>
            cuCtxSetCurrent_Import(
                context);

        internal sealed override CudaError cuCtxSynchronize(
              ) =>
            cuCtxSynchronize_Import(
                );

        internal sealed override CudaError cuCtxGetCacheConfig(
            [Out] out CudaCacheConfiguration pconfig) =>
            cuCtxGetCacheConfig_Import(
                out pconfig);

        internal sealed override CudaError cuCtxSetCacheConfig(
            [In] CudaCacheConfiguration config) =>
            cuCtxSetCacheConfig_Import(
                config);

        internal sealed override CudaError cuCtxGetSharedMemConfig(
            [Out] out CudaSharedMemoryConfiguration pConfig) =>
            cuCtxGetSharedMemConfig_Import(
                out pConfig);

        internal sealed override CudaError cuCtxSetSharedMemConfig(
            [In] CudaSharedMemoryConfiguration config) =>
            cuCtxSetSharedMemConfig_Import(
                config);

        internal sealed override CudaError cuDeviceCanAccessPeer(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev) =>
            cuDeviceCanAccessPeer_Import(
                out canAccess,
                device,
                peerDev);

        internal sealed override CudaError cuCtxEnablePeerAccess(
            [In] IntPtr peerContext,
            [In] int flags) =>
            cuCtxEnablePeerAccess_Import(
                peerContext,
                flags);

        internal sealed override CudaError cuCtxDisablePeerAccess(
            [In] IntPtr peerContext) =>
            cuCtxDisablePeerAccess_Import(
                peerContext);

        internal sealed override CudaError cuDeviceGetP2PAttribute(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice) =>
            cuDeviceGetP2PAttribute_Import(
                out value,
                attrib,
                sourceDevice,
                destinationDevice);

        internal sealed override CudaError cuPointerGetAttribute(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr) =>
            cuPointerGetAttribute_Import(
                targetPtr,
                attribute,
                devicePtr);

        internal sealed override CudaError cuMemGetInfo_v2(
            [Out] out IntPtr free,
            [Out] out IntPtr total) =>
            cuMemGetInfo_v2_Import(
                out free,
                out total);

        internal sealed override CudaError cuMemAlloc_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            cuMemAlloc_v2_Import(
                out devicePtr,
                bytesize);

        internal sealed override CudaError cuMemFree_v2(
            [In] IntPtr devicePtr) =>
            cuMemFree_v2_Import(
                devicePtr);

        internal sealed override CudaError cuMemAllocHost_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            cuMemAllocHost_v2_Import(
                out devicePtr,
                bytesize);

        internal sealed override CudaError cuMemFreeHost(
            [In] IntPtr devicePtr) =>
            cuMemFreeHost_Import(
                devicePtr);

        internal sealed override CudaError cuMemcpyAsync(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            cuMemcpyAsync_Import(
                destination,
                source,
                length,
                stream);

        internal sealed override CudaError cuMemsetD8Async(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            cuMemsetD8Async_Import(
                destinationDevice,
                value,
                length,
                stream);

        internal sealed override CudaError cuMemHostRegister_v2(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags) =>
            cuMemHostRegister_v2_Import(
                hostPtr,
                bytesize,
                flags);

        internal sealed override CudaError cuMemHostUnregister(
            [In] IntPtr hostPtr) =>
            cuMemHostUnregister_Import(
                hostPtr);

        internal sealed override CudaError cuMemHostGetDevicePointer_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags) =>
            cuMemHostGetDevicePointer_v2_Import(
                out devicePtr,
                hostPtr,
                flags);

        internal sealed override CudaError cuStreamCreate(
            [Out] out IntPtr stream,
            [In] StreamFlags flags) =>
            cuStreamCreate_Import(
                out stream,
                flags);

        internal sealed override CudaError cuStreamCreateWithPriority(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority) =>
            cuStreamCreateWithPriority_Import(
                out stream,
                flags,
                priority);

        internal sealed override CudaError cuStreamDestroy_v2(
            [In] IntPtr stream) =>
            cuStreamDestroy_v2_Import(
                stream);

        internal sealed override CudaError cuStreamSynchronize(
            [In] IntPtr stream) =>
            cuStreamSynchronize_Import(
                stream);

        internal sealed override CudaError cuGetErrorString(
            [In] CudaError error,
            [Out] out IntPtr pStr) =>
            cuGetErrorString_Import(
                error,
                out pStr);

        internal sealed override CudaError cuModuleLoadData(
            [Out] out IntPtr module,
            [In] string moduleData) =>
            cuModuleLoadData_Import(
                out module,
                moduleData);

        internal sealed override CudaError cuModuleLoadDataEx(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues) =>
            cuModuleLoadDataEx_Import(
                out module,
                moduleData,
                numOptions,
                jitOptions,
                jitOptionValues);

        internal sealed override CudaError cuModuleUnload(
            [In] IntPtr module) =>
            cuModuleUnload_Import(
                module);

        internal sealed override CudaError cuModuleGetFunction(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName) =>
            cuModuleGetFunction_Import(
                out function,
                module,
                functionName);

        internal sealed override CudaError cuLaunchKernel(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs) =>
            cuLaunchKernel_Import(
                function,
                gridDimX,
                gridDimY,
                gridDimZ,
                blockDimX,
                blockDimY,
                blockDimZ,
                sharedMemSizeInBytes,
                stream,
                args,
                kernelArgs);

        internal sealed override CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize) =>
            cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
                out numBlocks,
                func,
                blockSize,
                dynamicSMemSize);

        internal sealed override CudaError cuOccupancyMaxPotentialBlockSize(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit) =>
            cuOccupancyMaxPotentialBlockSize_Import(
                out minGridSize,
                out blockSize,
                func,
                blockSizeToDynamicSMemSize,
                dynamicSMemSize,
                blockSizeLimit);

        internal sealed override CudaError cuEventCreate(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags) =>
            cuEventCreate_Import(
                out @event,
                flags);

        internal sealed override CudaError cuEventDestroy_v2(
            [In] IntPtr @event) =>
            cuEventDestroy_v2_Import(
                @event);

        internal sealed override CudaError cuEventQuery(
            [In] IntPtr @event) =>
            cuEventQuery_Import(
                @event);

        internal sealed override CudaError cuEventElapsedTime(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end) =>
            cuEventElapsedTime_Import(
                out milliseconds,
                start,
                end);

        internal sealed override CudaError cuEventRecord(
            [In] IntPtr @event,
            [In] IntPtr stream) =>
            cuEventRecord_Import(
                @event,
                stream);

        internal sealed override CudaError cuEventSynchronize(
            [In] IntPtr @event) =>
            cuEventSynchronize_Import(
                @event);

        #endregion
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    sealed unsafe partial class CudaAPI_1 : CudaAPI
    {
        #region Native Methods

        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuInit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuInit_Import(
             int flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuInit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuInit_Import(
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDriverGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDriverGetVersion_Import(
             out int driverVersion);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDriverGetVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDriverGetVersion_Import(
            [Out] out int driverVersion);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceGet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGet_Import(
             out int device,
             int ordinal);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceGet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGet_Import(
            [Out] out int device,
            [In] int ordinal);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetCount_Import(
             out int count);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetCount_Import(
            [Out] out int count);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetName_Import(
             byte[] name,
             int length,
             int device);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetName_Import(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceTotalMem_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceTotalMem_v2_Import(
             out IntPtr bytes,
             int device);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceTotalMem_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceTotalMem_v2_Import(
            [Out] out IntPtr bytes,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetAttribute_Import(
             out int value,
             DeviceAttributeKind attribute,
             int device);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetAttribute_Import(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxCreate_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxCreate_v2_Import(
             out IntPtr context,
             CudaAcceleratorFlags flags,
             int device);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxCreate_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxCreate_v2_Import(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxDestroy_v2_Import(
             IntPtr context);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxDestroy_v2_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxSetCurrent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetCurrent_Import(
             IntPtr context);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxSetCurrent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetCurrent_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSynchronize_Import(
              );

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSynchronize_Import(
              );

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxGetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxGetCacheConfig_Import(
             out CudaCacheConfiguration pconfig);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxGetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxGetCacheConfig_Import(
            [Out] out CudaCacheConfiguration pconfig);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxSetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetCacheConfig_Import(
             CudaCacheConfiguration config);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxSetCacheConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetCacheConfig_Import(
            [In] CudaCacheConfiguration config);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxGetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxGetSharedMemConfig_Import(
             out CudaSharedMemoryConfiguration pConfig);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxGetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxGetSharedMemConfig_Import(
            [Out] out CudaSharedMemoryConfiguration pConfig);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxSetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxSetSharedMemConfig_Import(
             CudaSharedMemoryConfiguration config);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxSetSharedMemConfig"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxSetSharedMemConfig_Import(
            [In] CudaSharedMemoryConfiguration config);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceCanAccessPeer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceCanAccessPeer_Import(
             out int canAccess,
             int device,
             int peerDev);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceCanAccessPeer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceCanAccessPeer_Import(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxEnablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxEnablePeerAccess_Import(
             IntPtr peerContext,
             int flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxEnablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxEnablePeerAccess_Import(
            [In] IntPtr peerContext,
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuCtxDisablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuCtxDisablePeerAccess_Import(
             IntPtr peerContext);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuCtxDisablePeerAccess"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuCtxDisablePeerAccess_Import(
            [In] IntPtr peerContext);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuDeviceGetP2PAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuDeviceGetP2PAttribute_Import(
             out int value,
             Peer2PeerAttribute attrib,
             int sourceDevice,
             int destinationDevice);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuDeviceGetP2PAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuDeviceGetP2PAttribute_Import(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuPointerGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuPointerGetAttribute_Import(
             IntPtr targetPtr,
             PointerAttribute attribute,
             IntPtr devicePtr);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuPointerGetAttribute"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuPointerGetAttribute_Import(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemGetInfo_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemGetInfo_v2_Import(
             out IntPtr free,
             out IntPtr total);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemGetInfo_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemGetInfo_v2_Import(
            [Out] out IntPtr free,
            [Out] out IntPtr total);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemAlloc_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemAlloc_v2_Import(
             out IntPtr devicePtr,
             IntPtr bytesize);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemAlloc_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemAlloc_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemFree_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemFree_v2_Import(
             IntPtr devicePtr);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemFree_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemFree_v2_Import(
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemAllocHost_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemAllocHost_v2_Import(
             out IntPtr devicePtr,
             IntPtr bytesize);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemAllocHost_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemAllocHost_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemFreeHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemFreeHost_Import(
             IntPtr devicePtr);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemFreeHost"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemFreeHost_Import(
            [In] IntPtr devicePtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemcpyAsync"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemcpyAsync_Import(
             IntPtr destination,
             IntPtr source,
             IntPtr length,
             IntPtr stream);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemcpyAsync"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemcpyAsync_Import(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemsetD8Async"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemsetD8Async_Import(
             IntPtr destinationDevice,
             byte value,
             IntPtr length,
             IntPtr stream);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemsetD8Async"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemsetD8Async_Import(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemHostRegister_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostRegister_v2_Import(
             IntPtr hostPtr,
             IntPtr bytesize,
             MemHostRegisterFlags flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemHostRegister_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostRegister_v2_Import(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemHostUnregister"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostUnregister_Import(
             IntPtr hostPtr);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemHostUnregister"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostUnregister_Import(
            [In] IntPtr hostPtr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuMemHostGetDevicePointer_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuMemHostGetDevicePointer_v2_Import(
             out IntPtr devicePtr,
             IntPtr hostPtr,
             int flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuMemHostGetDevicePointer_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuMemHostGetDevicePointer_v2_Import(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuStreamCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamCreate_Import(
             out IntPtr stream,
             StreamFlags flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuStreamCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamCreate_Import(
            [Out] out IntPtr stream,
            [In] StreamFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuStreamCreateWithPriority"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamCreateWithPriority_Import(
             out IntPtr stream,
             StreamFlags flags,
             int priority);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuStreamCreateWithPriority"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamCreateWithPriority_Import(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuStreamDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamDestroy_v2_Import(
             IntPtr stream);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuStreamDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamDestroy_v2_Import(
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuStreamSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuStreamSynchronize_Import(
             IntPtr stream);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuStreamSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuStreamSynchronize_Import(
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuGetErrorString"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuGetErrorString_Import(
             CudaError error,
             out IntPtr pStr);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuGetErrorString"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuGetErrorString_Import(
            [In] CudaError error,
            [Out] out IntPtr pStr);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuModuleLoadData"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleLoadData_Import(
             out IntPtr module,
             string moduleData);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuModuleLoadData"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleLoadData_Import(
            [Out] out IntPtr module,
            [In] string moduleData);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuModuleLoadDataEx"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleLoadDataEx_Import(
             out IntPtr module,
             string moduleData,
             int numOptions,
             IntPtr jitOptions,
             IntPtr jitOptionValues);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuModuleLoadDataEx"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleLoadDataEx_Import(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuModuleUnload"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleUnload_Import(
             IntPtr module);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuModuleUnload"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleUnload_Import(
            [In] IntPtr module);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuModuleGetFunction"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuModuleGetFunction_Import(
             out IntPtr function,
             IntPtr module,
             string functionName);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuModuleGetFunction"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuModuleGetFunction_Import(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuLaunchKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuLaunchKernel_Import(
             IntPtr function,
             int gridDimX,
             int gridDimY,
             int gridDimZ,
             int blockDimX,
             int blockDimY,
             int blockDimZ,
             int sharedMemSizeInBytes,
             IntPtr stream,
             IntPtr args,
             IntPtr kernelArgs);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuLaunchKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuLaunchKernel_Import(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuOccupancyMaxActiveBlocksPerMultiprocessor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
             out int numBlocks,
             IntPtr func,
             int blockSize,
             IntPtr dynamicSMemSize);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuOccupancyMaxActiveBlocksPerMultiprocessor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuOccupancyMaxPotentialBlockSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuOccupancyMaxPotentialBlockSize_Import(
             out int minGridSize,
             out int blockSize,
             IntPtr func,
             ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
             IntPtr dynamicSMemSize,
             int blockSizeLimit);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuOccupancyMaxPotentialBlockSize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuOccupancyMaxPotentialBlockSize_Import(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventCreate_Import(
             out IntPtr @event,
             CudaEventFlags flags);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventCreate"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventCreate_Import(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventDestroy_v2_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventDestroy_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventDestroy_v2_Import(
            [In] IntPtr @event);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventQuery"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventQuery_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventQuery"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventQuery_Import(
            [In] IntPtr @event);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventElapsedTime"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventElapsedTime_Import(
             out float milliseconds,
             IntPtr start,
             IntPtr end);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventElapsedTime"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventElapsedTime_Import(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventRecord"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventRecord_Import(
             IntPtr @event,
             IntPtr stream);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventRecord"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventRecord_Import(
            [In] IntPtr @event,
            [In] IntPtr stream);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "cuEventSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CudaError cuEventSynchronize_Import(
             IntPtr @event);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "cuEventSynchronize"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CudaError cuEventSynchronize_Import(
            [In] IntPtr @event);

        #endif
        #endregion

        #region RuntimeAPI

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsSupported => true;

        #endregion

        #region Implementations

        internal sealed override CudaError cuInit(
            [In] int flags) =>
            cuInit_Import(
                flags);

        internal sealed override CudaError cuDriverGetVersion(
            [Out] out int driverVersion) =>
            cuDriverGetVersion_Import(
                out driverVersion);

        internal sealed override CudaError cuDeviceGet(
            [Out] out int device,
            [In] int ordinal) =>
            cuDeviceGet_Import(
                out device,
                ordinal);

        internal sealed override CudaError cuDeviceGetCount(
            [Out] out int count) =>
            cuDeviceGetCount_Import(
                out count);

        internal sealed override CudaError cuDeviceGetName(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device) =>
            cuDeviceGetName_Import(
                name,
                length,
                device);

        internal sealed override CudaError cuDeviceTotalMem_v2(
            [Out] out IntPtr bytes,
            [In] int device) =>
            cuDeviceTotalMem_v2_Import(
                out bytes,
                device);

        internal sealed override CudaError cuDeviceGetAttribute(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device) =>
            cuDeviceGetAttribute_Import(
                out value,
                attribute,
                device);

        internal sealed override CudaError cuCtxCreate_v2(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device) =>
            cuCtxCreate_v2_Import(
                out context,
                flags,
                device);

        internal sealed override CudaError cuCtxDestroy_v2(
            [In] IntPtr context) =>
            cuCtxDestroy_v2_Import(
                context);

        internal sealed override CudaError cuCtxSetCurrent(
            [In] IntPtr context) =>
            cuCtxSetCurrent_Import(
                context);

        internal sealed override CudaError cuCtxSynchronize(
              ) =>
            cuCtxSynchronize_Import(
                );

        internal sealed override CudaError cuCtxGetCacheConfig(
            [Out] out CudaCacheConfiguration pconfig) =>
            cuCtxGetCacheConfig_Import(
                out pconfig);

        internal sealed override CudaError cuCtxSetCacheConfig(
            [In] CudaCacheConfiguration config) =>
            cuCtxSetCacheConfig_Import(
                config);

        internal sealed override CudaError cuCtxGetSharedMemConfig(
            [Out] out CudaSharedMemoryConfiguration pConfig) =>
            cuCtxGetSharedMemConfig_Import(
                out pConfig);

        internal sealed override CudaError cuCtxSetSharedMemConfig(
            [In] CudaSharedMemoryConfiguration config) =>
            cuCtxSetSharedMemConfig_Import(
                config);

        internal sealed override CudaError cuDeviceCanAccessPeer(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev) =>
            cuDeviceCanAccessPeer_Import(
                out canAccess,
                device,
                peerDev);

        internal sealed override CudaError cuCtxEnablePeerAccess(
            [In] IntPtr peerContext,
            [In] int flags) =>
            cuCtxEnablePeerAccess_Import(
                peerContext,
                flags);

        internal sealed override CudaError cuCtxDisablePeerAccess(
            [In] IntPtr peerContext) =>
            cuCtxDisablePeerAccess_Import(
                peerContext);

        internal sealed override CudaError cuDeviceGetP2PAttribute(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice) =>
            cuDeviceGetP2PAttribute_Import(
                out value,
                attrib,
                sourceDevice,
                destinationDevice);

        internal sealed override CudaError cuPointerGetAttribute(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr) =>
            cuPointerGetAttribute_Import(
                targetPtr,
                attribute,
                devicePtr);

        internal sealed override CudaError cuMemGetInfo_v2(
            [Out] out IntPtr free,
            [Out] out IntPtr total) =>
            cuMemGetInfo_v2_Import(
                out free,
                out total);

        internal sealed override CudaError cuMemAlloc_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            cuMemAlloc_v2_Import(
                out devicePtr,
                bytesize);

        internal sealed override CudaError cuMemFree_v2(
            [In] IntPtr devicePtr) =>
            cuMemFree_v2_Import(
                devicePtr);

        internal sealed override CudaError cuMemAllocHost_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            cuMemAllocHost_v2_Import(
                out devicePtr,
                bytesize);

        internal sealed override CudaError cuMemFreeHost(
            [In] IntPtr devicePtr) =>
            cuMemFreeHost_Import(
                devicePtr);

        internal sealed override CudaError cuMemcpyAsync(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            cuMemcpyAsync_Import(
                destination,
                source,
                length,
                stream);

        internal sealed override CudaError cuMemsetD8Async(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            cuMemsetD8Async_Import(
                destinationDevice,
                value,
                length,
                stream);

        internal sealed override CudaError cuMemHostRegister_v2(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags) =>
            cuMemHostRegister_v2_Import(
                hostPtr,
                bytesize,
                flags);

        internal sealed override CudaError cuMemHostUnregister(
            [In] IntPtr hostPtr) =>
            cuMemHostUnregister_Import(
                hostPtr);

        internal sealed override CudaError cuMemHostGetDevicePointer_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags) =>
            cuMemHostGetDevicePointer_v2_Import(
                out devicePtr,
                hostPtr,
                flags);

        internal sealed override CudaError cuStreamCreate(
            [Out] out IntPtr stream,
            [In] StreamFlags flags) =>
            cuStreamCreate_Import(
                out stream,
                flags);

        internal sealed override CudaError cuStreamCreateWithPriority(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority) =>
            cuStreamCreateWithPriority_Import(
                out stream,
                flags,
                priority);

        internal sealed override CudaError cuStreamDestroy_v2(
            [In] IntPtr stream) =>
            cuStreamDestroy_v2_Import(
                stream);

        internal sealed override CudaError cuStreamSynchronize(
            [In] IntPtr stream) =>
            cuStreamSynchronize_Import(
                stream);

        internal sealed override CudaError cuGetErrorString(
            [In] CudaError error,
            [Out] out IntPtr pStr) =>
            cuGetErrorString_Import(
                error,
                out pStr);

        internal sealed override CudaError cuModuleLoadData(
            [Out] out IntPtr module,
            [In] string moduleData) =>
            cuModuleLoadData_Import(
                out module,
                moduleData);

        internal sealed override CudaError cuModuleLoadDataEx(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues) =>
            cuModuleLoadDataEx_Import(
                out module,
                moduleData,
                numOptions,
                jitOptions,
                jitOptionValues);

        internal sealed override CudaError cuModuleUnload(
            [In] IntPtr module) =>
            cuModuleUnload_Import(
                module);

        internal sealed override CudaError cuModuleGetFunction(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName) =>
            cuModuleGetFunction_Import(
                out function,
                module,
                functionName);

        internal sealed override CudaError cuLaunchKernel(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs) =>
            cuLaunchKernel_Import(
                function,
                gridDimX,
                gridDimY,
                gridDimZ,
                blockDimX,
                blockDimY,
                blockDimZ,
                sharedMemSizeInBytes,
                stream,
                args,
                kernelArgs);

        internal sealed override CudaError cuOccupancyMaxActiveBlocksPerMultiprocessor(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize) =>
            cuOccupancyMaxActiveBlocksPerMultiprocessor_Import(
                out numBlocks,
                func,
                blockSize,
                dynamicSMemSize);

        internal sealed override CudaError cuOccupancyMaxPotentialBlockSize(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit) =>
            cuOccupancyMaxPotentialBlockSize_Import(
                out minGridSize,
                out blockSize,
                func,
                blockSizeToDynamicSMemSize,
                dynamicSMemSize,
                blockSizeLimit);

        internal sealed override CudaError cuEventCreate(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags) =>
            cuEventCreate_Import(
                out @event,
                flags);

        internal sealed override CudaError cuEventDestroy_v2(
            [In] IntPtr @event) =>
            cuEventDestroy_v2_Import(
                @event);

        internal sealed override CudaError cuEventQuery(
            [In] IntPtr @event) =>
            cuEventQuery_Import(
                @event);

        internal sealed override CudaError cuEventElapsedTime(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end) =>
            cuEventElapsedTime_Import(
                out milliseconds,
                start,
                end);

        internal sealed override CudaError cuEventRecord(
            [In] IntPtr @event,
            [In] IntPtr stream) =>
            cuEventRecord_Import(
                @event,
                stream);

        internal sealed override CudaError cuEventSynchronize(
            [In] IntPtr @event) =>
            cuEventSynchronize_Import(
                @event);

        #endregion
    }

    /// <summary>
    /// The NotSupported implementation of the CudaAPI wrapper.
    /// </summary>
    sealed unsafe class CudaAPI_NotSupported : CudaAPI
    {
        #region RuntimeAPI

        /// <summary>
        /// Returns false.
        /// </summary>
        public override bool IsSupported => false;

        #endregion

        #region Implementations

        internal sealed override CudaError
            cuInit(
            [In] int flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDriverGetVersion(
            [Out] out int driverVersion) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceGet(
            [Out] out int device,
            [In] int ordinal) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceGetCount(
            [Out] out int count) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceGetName(
            [In, Out] byte[] name,
            [In] int length,
            [In] int device) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceTotalMem_v2(
            [Out] out IntPtr bytes,
            [In] int device) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceGetAttribute(
            [Out] out int value,
            [In] DeviceAttributeKind attribute,
            [In] int device) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxCreate_v2(
            [Out] out IntPtr context,
            [In] CudaAcceleratorFlags flags,
            [In] int device) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxDestroy_v2(
            [In] IntPtr context) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxSetCurrent(
            [In] IntPtr context) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxSynchronize(
              ) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxGetCacheConfig(
            [Out] out CudaCacheConfiguration pconfig) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxSetCacheConfig(
            [In] CudaCacheConfiguration config) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxGetSharedMemConfig(
            [Out] out CudaSharedMemoryConfiguration pConfig) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxSetSharedMemConfig(
            [In] CudaSharedMemoryConfiguration config) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceCanAccessPeer(
            [Out] out int canAccess,
            [In] int device,
            [In] int peerDev) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxEnablePeerAccess(
            [In] IntPtr peerContext,
            [In] int flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuCtxDisablePeerAccess(
            [In] IntPtr peerContext) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuDeviceGetP2PAttribute(
            [Out] out int value,
            [In] Peer2PeerAttribute attrib,
            [In] int sourceDevice,
            [In] int destinationDevice) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuPointerGetAttribute(
            [In] IntPtr targetPtr,
            [In] PointerAttribute attribute,
            [In] IntPtr devicePtr) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemGetInfo_v2(
            [Out] out IntPtr free,
            [Out] out IntPtr total) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemAlloc_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemFree_v2(
            [In] IntPtr devicePtr) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemAllocHost_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr bytesize) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemFreeHost(
            [In] IntPtr devicePtr) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemcpyAsync(
            [In] IntPtr destination,
            [In] IntPtr source,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemsetD8Async(
            [In] IntPtr destinationDevice,
            [In] byte value,
            [In] IntPtr length,
            [In] IntPtr stream) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemHostRegister_v2(
            [In] IntPtr hostPtr,
            [In] IntPtr bytesize,
            [In] MemHostRegisterFlags flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemHostUnregister(
            [In] IntPtr hostPtr) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuMemHostGetDevicePointer_v2(
            [Out] out IntPtr devicePtr,
            [In] IntPtr hostPtr,
            [In] int flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuStreamCreate(
            [Out] out IntPtr stream,
            [In] StreamFlags flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuStreamCreateWithPriority(
            [Out] out IntPtr stream,
            [In] StreamFlags flags,
            [In] int priority) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuStreamDestroy_v2(
            [In] IntPtr stream) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuStreamSynchronize(
            [In] IntPtr stream) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuGetErrorString(
            [In] CudaError error,
            [Out] out IntPtr pStr) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuModuleLoadData(
            [Out] out IntPtr module,
            [In] string moduleData) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuModuleLoadDataEx(
            [Out] out IntPtr module,
            [In] string moduleData,
            [In] int numOptions,
            [In] IntPtr jitOptions,
            [In] IntPtr jitOptionValues) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuModuleUnload(
            [In] IntPtr module) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuModuleGetFunction(
            [Out] out IntPtr function,
            [In] IntPtr module,
            [In] string functionName) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuLaunchKernel(
            [In] IntPtr function,
            [In] int gridDimX,
            [In] int gridDimY,
            [In] int gridDimZ,
            [In] int blockDimX,
            [In] int blockDimY,
            [In] int blockDimZ,
            [In] int sharedMemSizeInBytes,
            [In] IntPtr stream,
            [In] IntPtr args,
            [In] IntPtr kernelArgs) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuOccupancyMaxActiveBlocksPerMultiprocessor(
            [Out] out int numBlocks,
            [In] IntPtr func,
            [In] int blockSize,
            [In] IntPtr dynamicSMemSize) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuOccupancyMaxPotentialBlockSize(
            [Out] out int minGridSize,
            [Out] out int blockSize,
            [In] IntPtr func,
            [In] ComputeDynamicMemorySizeForBlockSize? blockSizeToDynamicSMemSize,
            [In] IntPtr dynamicSMemSize,
            [In] int blockSizeLimit) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventCreate(
            [Out] out IntPtr @event,
            [In] CudaEventFlags flags) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventDestroy_v2(
            [In] IntPtr @event) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventQuery(
            [In] IntPtr @event) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventElapsedTime(
            [Out] out float milliseconds,
            [In] IntPtr start,
            [In] IntPtr end) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventRecord(
            [In] IntPtr @event,
            [In] IntPtr stream) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        
        internal sealed override CudaError
            cuEventSynchronize(
            [In] IntPtr @event) =>
            throw new NotSupportedException(RuntimeErrorMessages.CudaNotSupported);
        

        #endregion
    }
}

namespace ILGPU.Runtime.OpenCL
{
    public unsafe abstract partial class CLAPI : RuntimeAPI
    {
        #region Constants

        /// <summary>
        /// Represents the driver library name on Windows.
        /// </summary>
        public const string LibNameWindows = "opencl";

        /// <summary>
        /// Represents the driver library name on Linux.
        /// </summary>
        public const string LibNameLinux = "OpenCL";

        /// <summary>
        /// Represents the driver library name on MacOS.
        /// </summary>
        public const string LibNameMacOS = "OpenCL";

        #endregion

        #region Native Methods

        internal abstract CLError clGetPlatformIDs(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms);

        internal abstract CLError clGetPlatformInfo(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        internal abstract CLError clGetDeviceIDs(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice);

        internal abstract CLError clReleaseDevice(
            [In] IntPtr deviceId);

        internal abstract CLError clGetDeviceInfo(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        internal abstract IntPtr clGetExtensionFunctionAddressForPlatform(
            [In] IntPtr platformId,
            [In] string name);

        internal abstract IntPtr clCreateContext(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode);

        internal abstract CLError clReleaseContext(
            [In] IntPtr context);

        internal abstract IntPtr clCreateCommandQueue(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode);

        internal abstract IntPtr clCreateCommandQueueWithProperties(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode);

        internal abstract CLError clReleaseCommandQueue(
            [In] IntPtr queue);

        internal abstract CLError clFlush(
            [In] IntPtr queue);

        internal abstract CLError clFinish(
            [In] IntPtr queue);

        internal abstract IntPtr clCreateProgramWithSource(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode);

        internal abstract CLError clBuildProgram(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData);

        internal abstract CLError clReleaseProgram(
            [In] IntPtr program);

        internal abstract CLError clGetProgramInfo(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        internal abstract CLError clGetProgramBuildInfo(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        internal abstract IntPtr clCreateKernel(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode);

        internal abstract CLError clReleaseKernel(
            [In] IntPtr kernel);

        internal abstract CLError clSetKernelArg(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value);

        internal abstract CLError clEnqueueNDRangeKernel(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent);

        internal abstract CLError clGetKernelWorkGroupInfo(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size);

        internal abstract IntPtr clCreateBuffer(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode);

        internal abstract CLError clReleaseMemObject(
            [In] IntPtr buffer);

        internal abstract CLError clEnqueueReadBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        internal abstract CLError clEnqueueWriteBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        internal abstract CLError clEnqueueFillBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        internal abstract CLError clEnqueueCopyBuffer(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        internal abstract CLError clReleaseEvent(
            [In] IntPtr buffer);

        internal abstract CLError clWaitForEvents(
            [In] int numEvents,
            [In] IntPtr* events);

        internal abstract CLError clGetEventInfo(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        internal abstract CLError clEnqueueBarrierWithWaitList(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        internal abstract CLError clGetEventProfilingInfo(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        #endregion

        #region Static

        /// <summary>
        /// Returns the driver API for the current platform.
        /// </summary>
        public static CLAPI CurrentAPI { get; } =
            LoadRuntimeAPI<
            CLAPI,
            CLAPI_0,
            CLAPI_1,
            CLAPI_1,
            CLAPI_NotSupported>();

        #endregion
    }

    // Platform implementations


    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    sealed unsafe partial class CLAPI_0 : CLAPI
    {
        #region Native Methods

        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetPlatformIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetPlatformIDs_Import(
             int maxNumPlatforms,
             IntPtr* platforms,
             out int numPlatforms);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetPlatformIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetPlatformIDs_Import(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetPlatformInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetPlatformInfo_Import(
             IntPtr platform,
             CLPlatformInfoType platformInfoType,
             IntPtr maxSize,
             void* value,
             IntPtr size);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetPlatformInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetPlatformInfo_Import(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetDeviceIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetDeviceIDs_Import(
             IntPtr platform,
             CLDeviceType deviceType,
             int maxNumDevices,
             IntPtr* devices,
             out int numDevice);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetDeviceIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetDeviceIDs_Import(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseDevice"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseDevice_Import(
             IntPtr deviceId);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseDevice"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseDevice_Import(
            [In] IntPtr deviceId);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetDeviceInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetDeviceInfo_Import(
             IntPtr deviceId,
             CLDeviceInfoType deviceInfoType,
             IntPtr maxSize,
             void* value,
             IntPtr size);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetDeviceInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetDeviceInfo_Import(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetExtensionFunctionAddressForPlatform"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clGetExtensionFunctionAddressForPlatform_Import(
             IntPtr platformId,
             string name);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetExtensionFunctionAddressForPlatform"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clGetExtensionFunctionAddressForPlatform_Import(
            [In] IntPtr platformId,
            [In] string name);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateContext_Import(
             IntPtr* properties,
             int numDevices,
             IntPtr* devices,
             IntPtr callback,
             IntPtr userData,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateContext_Import(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseContext_Import(
             IntPtr context);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseContext_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateCommandQueue_Import(
             IntPtr context,
             IntPtr device,
             CLCommandQueueProperties properties,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateCommandQueue_Import(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateCommandQueueWithProperties"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateCommandQueueWithProperties_Import(
             IntPtr context,
             IntPtr deviceId,
             IntPtr properties,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateCommandQueueWithProperties"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateCommandQueueWithProperties_Import(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseCommandQueue_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseCommandQueue_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clFlush"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clFlush_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clFlush"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clFlush_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clFinish"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clFinish_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clFinish"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clFinish_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateProgramWithSource"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateProgramWithSource_Import(
             IntPtr context,
             int numPrograms,
             ref string source,
             ref IntPtr lengths,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateProgramWithSource"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateProgramWithSource_Import(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clBuildProgram"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clBuildProgram_Import(
             IntPtr program,
             int numDevices,
             IntPtr* devices,
             string options,
             IntPtr callback,
             IntPtr userData);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clBuildProgram"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clBuildProgram_Import(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseProgram"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseProgram_Import(
             IntPtr program);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseProgram"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseProgram_Import(
            [In] IntPtr program);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetProgramInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetProgramInfo_Import(
             IntPtr program,
             CLProgramInfo param_name,
             IntPtr paramValueSize,
             void* paramValue,
             out IntPtr paramValueSizeRet);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetProgramInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetProgramInfo_Import(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetProgramBuildInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetProgramBuildInfo_Import(
             IntPtr program,
             IntPtr device,
             CLProgramBuildInfo paramName,
             IntPtr paramValueSize,
             void* paramValue,
             out IntPtr paramValueSizeRet);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetProgramBuildInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetProgramBuildInfo_Import(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateKernel"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateKernel_Import(
             IntPtr program,
             string kernelName,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateKernel"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateKernel_Import(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseKernel_Import(
             IntPtr kernel);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseKernel_Import(
            [In] IntPtr kernel);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clSetKernelArg"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clSetKernelArg_Import(
             IntPtr kernel,
             int index,
             IntPtr size,
             void* value);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clSetKernelArg"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clSetKernelArg_Import(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueNDRangeKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueNDRangeKernel_Import(
             IntPtr queue,
             IntPtr kernel,
             int workDimensions,
             IntPtr* workOffsets,
             IntPtr* globalWorkSizes,
             IntPtr* localWorkSizes,
             int numEvents,
             IntPtr* events,
             IntPtr* creatingEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueNDRangeKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueNDRangeKernel_Import(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetKernelWorkGroupInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetKernelWorkGroupInfo_Import(
             IntPtr kernel,
             IntPtr device,
             CLKernelWorkGroupInfoType workGroupInfoType,
             IntPtr maxSize,
             void* paramValue,
             IntPtr size);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetKernelWorkGroupInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetKernelWorkGroupInfo_Import(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clCreateBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateBuffer_Import(
             IntPtr context,
             CLBufferFlags flags,
             IntPtr size,
             IntPtr hostPointer,
             out CLError errorCode);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clCreateBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateBuffer_Import(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseMemObject"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseMemObject_Import(
             IntPtr buffer);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseMemObject"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseMemObject_Import(
            [In] IntPtr buffer);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueReadBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueReadBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
            [MarshalAs(UnmanagedType.U4)] bool blockingRead,
             IntPtr offset,
             IntPtr size,
             IntPtr ptr,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueReadBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueReadBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueWriteBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueWriteBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
            [MarshalAs(UnmanagedType.U4)] bool blockingWrite,
             IntPtr offset,
             IntPtr size,
             IntPtr ptr,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueWriteBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueWriteBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueFillBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueFillBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
             void* pattern,
             IntPtr patternSize,
             IntPtr offset,
             IntPtr size,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueFillBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueFillBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueCopyBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueCopyBuffer_Import(
             IntPtr queue,
             IntPtr sourceBuffer,
             IntPtr targetBuffer,
             IntPtr sourceOffset,
             IntPtr targetOffset,
             IntPtr size,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueCopyBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueCopyBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clReleaseEvent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseEvent_Import(
             IntPtr buffer);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clReleaseEvent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseEvent_Import(
            [In] IntPtr buffer);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clWaitForEvents"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clWaitForEvents_Import(
             int numEvents,
             IntPtr* events);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clWaitForEvents"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clWaitForEvents_Import(
            [In] int numEvents,
            [In] IntPtr* events);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetEventInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetEventInfo_Import(
             IntPtr @event,
             CLEventInfo param_name,
             IntPtr param_value_size,
             void* param_value,
             IntPtr param_value_size_ret);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetEventInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetEventInfo_Import(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clEnqueueBarrierWithWaitList"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueBarrierWithWaitList_Import(
             IntPtr queue,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clEnqueueBarrierWithWaitList"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueBarrierWithWaitList_Import(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameWindows,
            EntryPoint = "clGetEventProfilingInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetEventProfilingInfo_Import(
             IntPtr @event,
             CLProfilingInfo param_name,
             IntPtr param_value_size,
             void* param_value,
             IntPtr param_value_size_ret);

        #else
        [DllImport(LibNameWindows,
            EntryPoint = "clGetEventProfilingInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetEventProfilingInfo_Import(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        #endif
        #endregion

        #region RuntimeAPI

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsSupported => true;

        #endregion

        #region Implementations

        internal sealed override CLError clGetPlatformIDs(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms) =>
            clGetPlatformIDs_Import(
                maxNumPlatforms,
                platforms,
                out numPlatforms);

        internal sealed override CLError clGetPlatformInfo(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            clGetPlatformInfo_Import(
                platform,
                platformInfoType,
                maxSize,
                value,
                size);

        internal sealed override CLError clGetDeviceIDs(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice) =>
            clGetDeviceIDs_Import(
                platform,
                deviceType,
                maxNumDevices,
                devices,
                out numDevice);

        internal sealed override CLError clReleaseDevice(
            [In] IntPtr deviceId) =>
            clReleaseDevice_Import(
                deviceId);

        internal sealed override CLError clGetDeviceInfo(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            clGetDeviceInfo_Import(
                deviceId,
                deviceInfoType,
                maxSize,
                value,
                size);

        internal sealed override IntPtr clGetExtensionFunctionAddressForPlatform(
            [In] IntPtr platformId,
            [In] string name) =>
            clGetExtensionFunctionAddressForPlatform_Import(
                platformId,
                name);

        internal sealed override IntPtr clCreateContext(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode) =>
            clCreateContext_Import(
                properties,
                numDevices,
                devices,
                callback,
                userData,
                out errorCode);

        internal sealed override CLError clReleaseContext(
            [In] IntPtr context) =>
            clReleaseContext_Import(
                context);

        internal sealed override IntPtr clCreateCommandQueue(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode) =>
            clCreateCommandQueue_Import(
                context,
                device,
                properties,
                out errorCode);

        internal sealed override IntPtr clCreateCommandQueueWithProperties(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode) =>
            clCreateCommandQueueWithProperties_Import(
                context,
                deviceId,
                properties,
                out errorCode);

        internal sealed override CLError clReleaseCommandQueue(
            [In] IntPtr queue) =>
            clReleaseCommandQueue_Import(
                queue);

        internal sealed override CLError clFlush(
            [In] IntPtr queue) =>
            clFlush_Import(
                queue);

        internal sealed override CLError clFinish(
            [In] IntPtr queue) =>
            clFinish_Import(
                queue);

        internal sealed override IntPtr clCreateProgramWithSource(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode) =>
            clCreateProgramWithSource_Import(
                context,
                numPrograms,
                ref source,
                ref lengths,
                out errorCode);

        internal sealed override CLError clBuildProgram(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData) =>
            clBuildProgram_Import(
                program,
                numDevices,
                devices,
                options,
                callback,
                userData);

        internal sealed override CLError clReleaseProgram(
            [In] IntPtr program) =>
            clReleaseProgram_Import(
                program);

        internal sealed override CLError clGetProgramInfo(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            clGetProgramInfo_Import(
                program,
                param_name,
                paramValueSize,
                paramValue,
                out paramValueSizeRet);

        internal sealed override CLError clGetProgramBuildInfo(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            clGetProgramBuildInfo_Import(
                program,
                device,
                paramName,
                paramValueSize,
                paramValue,
                out paramValueSizeRet);

        internal sealed override IntPtr clCreateKernel(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode) =>
            clCreateKernel_Import(
                program,
                kernelName,
                out errorCode);

        internal sealed override CLError clReleaseKernel(
            [In] IntPtr kernel) =>
            clReleaseKernel_Import(
                kernel);

        internal sealed override CLError clSetKernelArg(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value) =>
            clSetKernelArg_Import(
                kernel,
                index,
                size,
                value);

        internal sealed override CLError clEnqueueNDRangeKernel(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent) =>
            clEnqueueNDRangeKernel_Import(
                queue,
                kernel,
                workDimensions,
                workOffsets,
                globalWorkSizes,
                localWorkSizes,
                numEvents,
                events,
                creatingEvent);

        internal sealed override CLError clGetKernelWorkGroupInfo(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size) =>
            clGetKernelWorkGroupInfo_Import(
                kernel,
                device,
                workGroupInfoType,
                maxSize,
                paramValue,
                size);

        internal sealed override IntPtr clCreateBuffer(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode) =>
            clCreateBuffer_Import(
                context,
                flags,
                size,
                hostPointer,
                out errorCode);

        internal sealed override CLError clReleaseMemObject(
            [In] IntPtr buffer) =>
            clReleaseMemObject_Import(
                buffer);

        internal sealed override CLError clEnqueueReadBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueReadBuffer_Import(
                queue,
                buffer,
                blockingRead,
                offset,
                size,
                ptr,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueWriteBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueWriteBuffer_Import(
                queue,
                buffer,
                blockingWrite,
                offset,
                size,
                ptr,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueFillBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueFillBuffer_Import(
                queue,
                buffer,
                pattern,
                patternSize,
                offset,
                size,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueCopyBuffer(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueCopyBuffer_Import(
                queue,
                sourceBuffer,
                targetBuffer,
                sourceOffset,
                targetOffset,
                size,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clReleaseEvent(
            [In] IntPtr buffer) =>
            clReleaseEvent_Import(
                buffer);

        internal sealed override CLError clWaitForEvents(
            [In] int numEvents,
            [In] IntPtr* events) =>
            clWaitForEvents_Import(
                numEvents,
                events);

        internal sealed override CLError clGetEventInfo(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            clGetEventInfo_Import(
                @event,
                param_name,
                param_value_size,
                param_value,
                param_value_size_ret);

        internal sealed override CLError clEnqueueBarrierWithWaitList(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueBarrierWithWaitList_Import(
                queue,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clGetEventProfilingInfo(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            clGetEventProfilingInfo_Import(
                @event,
                param_name,
                param_value_size,
                param_value,
                param_value_size_ret);

        #endregion
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    sealed unsafe partial class CLAPI_1 : CLAPI
    {
        #region Native Methods

        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetPlatformIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetPlatformIDs_Import(
             int maxNumPlatforms,
             IntPtr* platforms,
             out int numPlatforms);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetPlatformIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetPlatformIDs_Import(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetPlatformInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetPlatformInfo_Import(
             IntPtr platform,
             CLPlatformInfoType platformInfoType,
             IntPtr maxSize,
             void* value,
             IntPtr size);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetPlatformInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetPlatformInfo_Import(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetDeviceIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetDeviceIDs_Import(
             IntPtr platform,
             CLDeviceType deviceType,
             int maxNumDevices,
             IntPtr* devices,
             out int numDevice);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetDeviceIDs"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetDeviceIDs_Import(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseDevice"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseDevice_Import(
             IntPtr deviceId);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseDevice"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseDevice_Import(
            [In] IntPtr deviceId);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetDeviceInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetDeviceInfo_Import(
             IntPtr deviceId,
             CLDeviceInfoType deviceInfoType,
             IntPtr maxSize,
             void* value,
             IntPtr size);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetDeviceInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetDeviceInfo_Import(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetExtensionFunctionAddressForPlatform"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clGetExtensionFunctionAddressForPlatform_Import(
             IntPtr platformId,
             string name);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetExtensionFunctionAddressForPlatform"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clGetExtensionFunctionAddressForPlatform_Import(
            [In] IntPtr platformId,
            [In] string name);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateContext_Import(
             IntPtr* properties,
             int numDevices,
             IntPtr* devices,
             IntPtr callback,
             IntPtr userData,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateContext_Import(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseContext_Import(
             IntPtr context);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseContext"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseContext_Import(
            [In] IntPtr context);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateCommandQueue_Import(
             IntPtr context,
             IntPtr device,
             CLCommandQueueProperties properties,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateCommandQueue_Import(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateCommandQueueWithProperties"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateCommandQueueWithProperties_Import(
             IntPtr context,
             IntPtr deviceId,
             IntPtr properties,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateCommandQueueWithProperties"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateCommandQueueWithProperties_Import(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseCommandQueue_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseCommandQueue"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseCommandQueue_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clFlush"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clFlush_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clFlush"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clFlush_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clFinish"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clFinish_Import(
             IntPtr queue);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clFinish"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clFinish_Import(
            [In] IntPtr queue);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateProgramWithSource"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateProgramWithSource_Import(
             IntPtr context,
             int numPrograms,
             ref string source,
             ref IntPtr lengths,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateProgramWithSource"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateProgramWithSource_Import(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clBuildProgram"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clBuildProgram_Import(
             IntPtr program,
             int numDevices,
             IntPtr* devices,
             string options,
             IntPtr callback,
             IntPtr userData);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clBuildProgram"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clBuildProgram_Import(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseProgram"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseProgram_Import(
             IntPtr program);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseProgram"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseProgram_Import(
            [In] IntPtr program);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetProgramInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetProgramInfo_Import(
             IntPtr program,
             CLProgramInfo param_name,
             IntPtr paramValueSize,
             void* paramValue,
             out IntPtr paramValueSizeRet);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetProgramInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetProgramInfo_Import(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetProgramBuildInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetProgramBuildInfo_Import(
             IntPtr program,
             IntPtr device,
             CLProgramBuildInfo paramName,
             IntPtr paramValueSize,
             void* paramValue,
             out IntPtr paramValueSizeRet);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetProgramBuildInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetProgramBuildInfo_Import(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateKernel"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateKernel_Import(
             IntPtr program,
             string kernelName,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateKernel"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateKernel_Import(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseKernel_Import(
             IntPtr kernel);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseKernel_Import(
            [In] IntPtr kernel);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clSetKernelArg"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clSetKernelArg_Import(
             IntPtr kernel,
             int index,
             IntPtr size,
             void* value);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clSetKernelArg"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clSetKernelArg_Import(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueNDRangeKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueNDRangeKernel_Import(
             IntPtr queue,
             IntPtr kernel,
             int workDimensions,
             IntPtr* workOffsets,
             IntPtr* globalWorkSizes,
             IntPtr* localWorkSizes,
             int numEvents,
             IntPtr* events,
             IntPtr* creatingEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueNDRangeKernel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueNDRangeKernel_Import(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetKernelWorkGroupInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetKernelWorkGroupInfo_Import(
             IntPtr kernel,
             IntPtr device,
             CLKernelWorkGroupInfoType workGroupInfoType,
             IntPtr maxSize,
             void* paramValue,
             IntPtr size);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetKernelWorkGroupInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetKernelWorkGroupInfo_Import(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clCreateBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         IntPtr clCreateBuffer_Import(
             IntPtr context,
             CLBufferFlags flags,
             IntPtr size,
             IntPtr hostPointer,
             out CLError errorCode);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clCreateBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         IntPtr clCreateBuffer_Import(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseMemObject"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseMemObject_Import(
             IntPtr buffer);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseMemObject"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseMemObject_Import(
            [In] IntPtr buffer);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueReadBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueReadBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
            [MarshalAs(UnmanagedType.U4)] bool blockingRead,
             IntPtr offset,
             IntPtr size,
             IntPtr ptr,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueReadBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueReadBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueWriteBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueWriteBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
            [MarshalAs(UnmanagedType.U4)] bool blockingWrite,
             IntPtr offset,
             IntPtr size,
             IntPtr ptr,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueWriteBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueWriteBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueFillBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueFillBuffer_Import(
             IntPtr queue,
             IntPtr buffer,
             void* pattern,
             IntPtr patternSize,
             IntPtr offset,
             IntPtr size,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueFillBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueFillBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueCopyBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueCopyBuffer_Import(
             IntPtr queue,
             IntPtr sourceBuffer,
             IntPtr targetBuffer,
             IntPtr sourceOffset,
             IntPtr targetOffset,
             IntPtr size,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueCopyBuffer"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueCopyBuffer_Import(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clReleaseEvent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clReleaseEvent_Import(
             IntPtr buffer);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clReleaseEvent"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clReleaseEvent_Import(
            [In] IntPtr buffer);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clWaitForEvents"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clWaitForEvents_Import(
             int numEvents,
             IntPtr* events);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clWaitForEvents"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clWaitForEvents_Import(
            [In] int numEvents,
            [In] IntPtr* events);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetEventInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetEventInfo_Import(
             IntPtr @event,
             CLEventInfo param_name,
             IntPtr param_value_size,
             void* param_value,
             IntPtr param_value_size_ret);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetEventInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetEventInfo_Import(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clEnqueueBarrierWithWaitList"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clEnqueueBarrierWithWaitList_Import(
             IntPtr queue,
             int numEvents,
             IntPtr* events,
             IntPtr* resultEvent);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clEnqueueBarrierWithWaitList"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clEnqueueBarrierWithWaitList_Import(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent);

        #endif
        #if NET7_0_OR_GREATER
        [LibraryImport(LibNameLinux,
            EntryPoint = "clGetEventProfilingInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         CLError clGetEventProfilingInfo_Import(
             IntPtr @event,
             CLProfilingInfo param_name,
             IntPtr param_value_size,
             void* param_value,
             IntPtr param_value_size_ret);

        #else
        [DllImport(LibNameLinux,
            EntryPoint = "clGetEventProfilingInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         CLError clGetEventProfilingInfo_Import(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret);

        #endif
        #endregion

        #region RuntimeAPI

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsSupported => true;

        #endregion

        #region Implementations

        internal sealed override CLError clGetPlatformIDs(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms) =>
            clGetPlatformIDs_Import(
                maxNumPlatforms,
                platforms,
                out numPlatforms);

        internal sealed override CLError clGetPlatformInfo(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            clGetPlatformInfo_Import(
                platform,
                platformInfoType,
                maxSize,
                value,
                size);

        internal sealed override CLError clGetDeviceIDs(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice) =>
            clGetDeviceIDs_Import(
                platform,
                deviceType,
                maxNumDevices,
                devices,
                out numDevice);

        internal sealed override CLError clReleaseDevice(
            [In] IntPtr deviceId) =>
            clReleaseDevice_Import(
                deviceId);

        internal sealed override CLError clGetDeviceInfo(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            clGetDeviceInfo_Import(
                deviceId,
                deviceInfoType,
                maxSize,
                value,
                size);

        internal sealed override IntPtr clGetExtensionFunctionAddressForPlatform(
            [In] IntPtr platformId,
            [In] string name) =>
            clGetExtensionFunctionAddressForPlatform_Import(
                platformId,
                name);

        internal sealed override IntPtr clCreateContext(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode) =>
            clCreateContext_Import(
                properties,
                numDevices,
                devices,
                callback,
                userData,
                out errorCode);

        internal sealed override CLError clReleaseContext(
            [In] IntPtr context) =>
            clReleaseContext_Import(
                context);

        internal sealed override IntPtr clCreateCommandQueue(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode) =>
            clCreateCommandQueue_Import(
                context,
                device,
                properties,
                out errorCode);

        internal sealed override IntPtr clCreateCommandQueueWithProperties(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode) =>
            clCreateCommandQueueWithProperties_Import(
                context,
                deviceId,
                properties,
                out errorCode);

        internal sealed override CLError clReleaseCommandQueue(
            [In] IntPtr queue) =>
            clReleaseCommandQueue_Import(
                queue);

        internal sealed override CLError clFlush(
            [In] IntPtr queue) =>
            clFlush_Import(
                queue);

        internal sealed override CLError clFinish(
            [In] IntPtr queue) =>
            clFinish_Import(
                queue);

        internal sealed override IntPtr clCreateProgramWithSource(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode) =>
            clCreateProgramWithSource_Import(
                context,
                numPrograms,
                ref source,
                ref lengths,
                out errorCode);

        internal sealed override CLError clBuildProgram(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData) =>
            clBuildProgram_Import(
                program,
                numDevices,
                devices,
                options,
                callback,
                userData);

        internal sealed override CLError clReleaseProgram(
            [In] IntPtr program) =>
            clReleaseProgram_Import(
                program);

        internal sealed override CLError clGetProgramInfo(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            clGetProgramInfo_Import(
                program,
                param_name,
                paramValueSize,
                paramValue,
                out paramValueSizeRet);

        internal sealed override CLError clGetProgramBuildInfo(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            clGetProgramBuildInfo_Import(
                program,
                device,
                paramName,
                paramValueSize,
                paramValue,
                out paramValueSizeRet);

        internal sealed override IntPtr clCreateKernel(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode) =>
            clCreateKernel_Import(
                program,
                kernelName,
                out errorCode);

        internal sealed override CLError clReleaseKernel(
            [In] IntPtr kernel) =>
            clReleaseKernel_Import(
                kernel);

        internal sealed override CLError clSetKernelArg(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value) =>
            clSetKernelArg_Import(
                kernel,
                index,
                size,
                value);

        internal sealed override CLError clEnqueueNDRangeKernel(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent) =>
            clEnqueueNDRangeKernel_Import(
                queue,
                kernel,
                workDimensions,
                workOffsets,
                globalWorkSizes,
                localWorkSizes,
                numEvents,
                events,
                creatingEvent);

        internal sealed override CLError clGetKernelWorkGroupInfo(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size) =>
            clGetKernelWorkGroupInfo_Import(
                kernel,
                device,
                workGroupInfoType,
                maxSize,
                paramValue,
                size);

        internal sealed override IntPtr clCreateBuffer(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode) =>
            clCreateBuffer_Import(
                context,
                flags,
                size,
                hostPointer,
                out errorCode);

        internal sealed override CLError clReleaseMemObject(
            [In] IntPtr buffer) =>
            clReleaseMemObject_Import(
                buffer);

        internal sealed override CLError clEnqueueReadBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueReadBuffer_Import(
                queue,
                buffer,
                blockingRead,
                offset,
                size,
                ptr,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueWriteBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueWriteBuffer_Import(
                queue,
                buffer,
                blockingWrite,
                offset,
                size,
                ptr,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueFillBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueFillBuffer_Import(
                queue,
                buffer,
                pattern,
                patternSize,
                offset,
                size,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clEnqueueCopyBuffer(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueCopyBuffer_Import(
                queue,
                sourceBuffer,
                targetBuffer,
                sourceOffset,
                targetOffset,
                size,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clReleaseEvent(
            [In] IntPtr buffer) =>
            clReleaseEvent_Import(
                buffer);

        internal sealed override CLError clWaitForEvents(
            [In] int numEvents,
            [In] IntPtr* events) =>
            clWaitForEvents_Import(
                numEvents,
                events);

        internal sealed override CLError clGetEventInfo(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            clGetEventInfo_Import(
                @event,
                param_name,
                param_value_size,
                param_value,
                param_value_size_ret);

        internal sealed override CLError clEnqueueBarrierWithWaitList(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            clEnqueueBarrierWithWaitList_Import(
                queue,
                numEvents,
                events,
                resultEvent);

        internal sealed override CLError clGetEventProfilingInfo(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            clGetEventProfilingInfo_Import(
                @event,
                param_name,
                param_value_size,
                param_value,
                param_value_size_ret);

        #endregion
    }

    /// <summary>
    /// The NotSupported implementation of the CLAPI wrapper.
    /// </summary>
    sealed unsafe class CLAPI_NotSupported : CLAPI
    {
        #region RuntimeAPI

        /// <summary>
        /// Returns false.
        /// </summary>
        public override bool IsSupported => false;

        #endregion

        #region Implementations

        internal sealed override CLError
            clGetPlatformIDs(
            [In] int maxNumPlatforms,
            [Out] IntPtr* platforms,
            [Out] out int numPlatforms) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetPlatformInfo(
            [In] IntPtr platform,
            [In] CLPlatformInfoType platformInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetDeviceIDs(
            [In] IntPtr platform,
            [In] CLDeviceType deviceType,
            [In] int maxNumDevices,
            [Out] IntPtr* devices,
            [Out] out int numDevice) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseDevice(
            [In] IntPtr deviceId) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetDeviceInfo(
            [In] IntPtr deviceId,
            [In] CLDeviceInfoType deviceInfoType,
            [In] IntPtr maxSize,
            [Out] void* value,
            [Out] IntPtr size) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clGetExtensionFunctionAddressForPlatform(
            [In] IntPtr platformId,
            [In] string name) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateContext(
            [In] IntPtr* properties,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] IntPtr callback,
            [In] IntPtr userData,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseContext(
            [In] IntPtr context) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateCommandQueue(
            [In] IntPtr context,
            [In] IntPtr device,
            [In] CLCommandQueueProperties properties,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateCommandQueueWithProperties(
            [In] IntPtr context,
            [In] IntPtr deviceId,
            [In] IntPtr properties,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseCommandQueue(
            [In] IntPtr queue) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clFlush(
            [In] IntPtr queue) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clFinish(
            [In] IntPtr queue) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateProgramWithSource(
            [In] IntPtr context,
            [In] int numPrograms,
            [In] ref string source,
            [In] ref IntPtr lengths,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clBuildProgram(
            [In] IntPtr program,
            [In] int numDevices,
            [In] IntPtr* devices,
            [In] string options,
            [In] IntPtr callback,
            [In] IntPtr userData) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseProgram(
            [In] IntPtr program) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetProgramInfo(
            [In] IntPtr program,
            [In] CLProgramInfo param_name,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetProgramBuildInfo(
            [In] IntPtr program,
            [In] IntPtr device,
            [In] CLProgramBuildInfo paramName,
            [In] IntPtr paramValueSize,
            [Out] void* paramValue,
            [Out] out IntPtr paramValueSizeRet) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateKernel(
            [In] IntPtr program,
            [In] string kernelName,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseKernel(
            [In] IntPtr kernel) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clSetKernelArg(
            [In] IntPtr kernel,
            [In] int index,
            [In] IntPtr size,
            [In] void* value) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueNDRangeKernel(
            [In] IntPtr queue,
            [In] IntPtr kernel,
            [In] int workDimensions,
            [In] IntPtr* workOffsets,
            [In] IntPtr* globalWorkSizes,
            [In] IntPtr* localWorkSizes,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* creatingEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetKernelWorkGroupInfo(
            [In] IntPtr kernel,
            [In] IntPtr device,
            [In] CLKernelWorkGroupInfoType workGroupInfoType,
            [In] IntPtr maxSize,
            [Out] void* paramValue,
            [Out] IntPtr size) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override IntPtr
            clCreateBuffer(
            [In] IntPtr context,
            [In] CLBufferFlags flags,
            [In] IntPtr size,
            [In] IntPtr hostPointer,
            [Out] out CLError errorCode) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseMemObject(
            [In] IntPtr buffer) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueReadBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingRead,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueWriteBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] bool blockingWrite,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] IntPtr ptr,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueFillBuffer(
            [In] IntPtr queue,
            [In] IntPtr buffer,
            [In] void* pattern,
            [In] IntPtr patternSize,
            [In] IntPtr offset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueCopyBuffer(
            [In] IntPtr queue,
            [In] IntPtr sourceBuffer,
            [In] IntPtr targetBuffer,
            [In] IntPtr sourceOffset,
            [In] IntPtr targetOffset,
            [In] IntPtr size,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clReleaseEvent(
            [In] IntPtr buffer) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clWaitForEvents(
            [In] int numEvents,
            [In] IntPtr* events) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetEventInfo(
            [In] IntPtr @event,
            [In] CLEventInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clEnqueueBarrierWithWaitList(
            [In] IntPtr queue,
            [In] int numEvents,
            [In] IntPtr* events,
            [In, Out] IntPtr* resultEvent) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        
        internal sealed override CLError
            clGetEventProfilingInfo(
            [In] IntPtr @event,
            [In] CLProfilingInfo param_name,
            [In] IntPtr param_value_size,
            [Out] void* param_value,
            [Out] IntPtr param_value_size_ret) =>
            throw new NotSupportedException(RuntimeErrorMessages.CLNotSupported);
        

        #endregion
    }
}


#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning restore IDE1006 // Naming

