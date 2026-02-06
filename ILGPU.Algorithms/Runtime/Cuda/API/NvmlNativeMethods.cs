// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                           Copyright (c) 2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: NvmlNativeMethods.tt/NvmlNativeMethods.cs
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace ILGPU.Runtime.Cuda.API
{
    public enum NvmlAPIVersion
    {
        V6,
    }

    partial class NvmlAPI
    {
        #region Creation

        private static NvmlAPI? CreateInternal(NvmlAPIVersion version)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
                version == NvmlAPIVersion.V6)
            {
                return new NvmlAPI_Windows_V6();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                version == NvmlAPIVersion.V6)
            {
                return new NvmlAPI_Linux_V6();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) &&
                version == NvmlAPIVersion.V6)
            {
                return new NvmlAPI_OSX_V6();
            }
            return null;
        }

        #endregion

        #region Initialization

        public abstract NvmlReturn Init(
              );

        public abstract NvmlReturn Shutdown(
              );

        #endregion

        #region Device Queries

        public abstract NvmlReturn DeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted);

        public abstract NvmlReturn DeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        public abstract NvmlReturn DeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch);

        public abstract NvmlReturn DeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes);

        public abstract NvmlReturn DeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled);

        public abstract NvmlReturn DeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory);

        public abstract NvmlReturn DeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId);

        public unsafe abstract NvmlReturn DeviceGetBoardPartNumber_Interop(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length);

        public abstract NvmlReturn DeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type);

        public abstract NvmlReturn DeviceGetBridgeChipInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        public abstract NvmlReturn DeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz);

        public abstract NvmlReturn DeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock);

        public abstract NvmlReturn DeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode);

        public unsafe abstract NvmlReturn DeviceGetComputeRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        public abstract NvmlReturn DeviceGetCount(
            [Out] out uint deviceCount);

        public abstract NvmlReturn DeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor);

        public abstract NvmlReturn DeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen);

        public abstract NvmlReturn DeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth);

        public abstract NvmlReturn DeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons);

        public abstract NvmlReturn DeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        public abstract NvmlReturn DeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        public abstract NvmlReturn DeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts);

        public abstract NvmlReturn DeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive);

        public abstract NvmlReturn DeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display);

        public abstract NvmlReturn DeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending);

        public abstract NvmlReturn DeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending);

        public abstract NvmlReturn DeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity);

        public unsafe abstract NvmlReturn DeviceGetEncoderSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos);

        public abstract NvmlReturn DeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency);

        public abstract NvmlReturn DeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        public abstract NvmlReturn DeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        public unsafe abstract NvmlReturn DeviceGetFBCSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos);

        public abstract NvmlReturn DeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats);

        public abstract NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed);

        public abstract NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed);

        public abstract NvmlReturn DeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending);

        public unsafe abstract NvmlReturn DeviceGetGraphicsRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        public abstract NvmlReturn DeviceGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr device);

        public abstract NvmlReturn DeviceGetHandleByPciBusId(
            [In] string pciBusId,
            [Out] out IntPtr device);

        public abstract NvmlReturn DeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device);

        public abstract NvmlReturn DeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device);

        public abstract NvmlReturn DeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index);

        public abstract NvmlReturn DeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum);

        public unsafe abstract NvmlReturn DeviceGetInforomImageVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        public unsafe abstract NvmlReturn DeviceGetInforomVersion_Interop(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length);

        public abstract NvmlReturn DeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock);

        public abstract NvmlReturn DeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        public abstract NvmlReturn DeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen);

        public abstract NvmlReturn DeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth);

        public abstract NvmlReturn DeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count);

        public abstract NvmlReturn DeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory);

        public abstract NvmlReturn DeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber);

        public abstract NvmlReturn DeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool);

        public unsafe abstract NvmlReturn DeviceGetName_Interop(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length);

        public abstract NvmlReturn DeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus);

        public abstract NvmlReturn DeviceGetPciInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci);

        public abstract NvmlReturn DeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value);

        public abstract NvmlReturn DeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value);

        public abstract NvmlReturn DeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state);

        public abstract NvmlReturn DeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        public abstract NvmlReturn DeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit);

        public abstract NvmlReturn DeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        public abstract NvmlReturn DeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit);

        public abstract NvmlReturn DeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        public abstract NvmlReturn DeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState);

        public abstract NvmlReturn DeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power);

        public abstract NvmlReturn DeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred);

        public unsafe abstract NvmlReturn DeviceGetRetiredPages_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses);

        public abstract NvmlReturn DeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending);

        public unsafe abstract NvmlReturn DeviceGetRetiredPages_v2_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps);

        public unsafe abstract NvmlReturn DeviceGetSamples_Interop(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples);

        public unsafe abstract NvmlReturn DeviceGetSerial_Interop(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length);

        public abstract NvmlReturn DeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        public unsafe abstract NvmlReturn DeviceGetSupportedGraphicsClocks_Interop(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz);

        public unsafe abstract NvmlReturn DeviceGetSupportedMemoryClocks_Interop(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz);

        public abstract NvmlReturn DeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp);

        public abstract NvmlReturn DeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp);

        public abstract NvmlReturn DeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo);

        public unsafe abstract NvmlReturn DeviceGetTopologyNearestGpus_Interop(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        public abstract NvmlReturn DeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts);

        public abstract NvmlReturn DeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy);

        public unsafe abstract NvmlReturn DeviceGetUUID_Interop(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length);

        public abstract NvmlReturn DeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization);

        public unsafe abstract NvmlReturn DeviceGetVbiosVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        public abstract NvmlReturn DeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime);

        public abstract NvmlReturn DeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard);

        public abstract NvmlReturn DeviceResetApplicationsClocks(
            [In] IntPtr device1);

        public abstract NvmlReturn DeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled);

        public abstract NvmlReturn DeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags);

        public abstract NvmlReturn DeviceValidateInforom(
            [In] IntPtr device);

        public unsafe abstract NvmlReturn SystemGetTopologyGpuSet_Interop(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        public unsafe abstract NvmlReturn VgpuInstanceGetMdevUUID_Interop(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size);

        #endregion

        #region Device Queries - CPU and Memory Affinity

        public abstract NvmlReturn DeviceClearCpuAffinity(
            [In] IntPtr device);

        public unsafe abstract NvmlReturn DeviceGetCpuAffinity_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet);

        public unsafe abstract NvmlReturn DeviceGetCpuAffinityWithinScope_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope);

        public unsafe abstract NvmlReturn DeviceGetMemoryAffinity_Interop(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope);

        public abstract NvmlReturn DeviceSetCpuAffinity(
            [In] IntPtr device);

        #endregion

        #region System Queries

        public abstract NvmlReturn SystemGetCudaDriverVersion_Interop(
            [Out] out int cudaDriverVersion);

        public abstract NvmlReturn SystemGetCudaDriverVersion_v2_Interop(
            [Out] out int cudaDriverVersion);

        public abstract NvmlReturn SystemGetDriverVersion_Interop(
            [In] IntPtr name,
            [In] uint length);

        public abstract NvmlReturn SystemGetNVMLVersion_Interop(
            [In] IntPtr name,
            [In] uint length);

        public abstract NvmlReturn SystemGetProcessName_Interop(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length);

        #endregion

        #region Unit Queries

        public unsafe abstract NvmlReturn SystemGetHicVersion_Interop(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries);

        public abstract NvmlReturn UnitGetCount(
            [Out] out uint unitCount);

        public unsafe abstract NvmlReturn UnitGetDevices_Interop(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices);

        public abstract NvmlReturn UnitGetFanSpeedInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds);

        public abstract NvmlReturn UnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit);

        public abstract NvmlReturn UnitGetLedState_Interop(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state);

        public abstract NvmlReturn UnitGetPsuInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu);

        public abstract NvmlReturn UnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp);

        public abstract NvmlReturn UnitGetUnitInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class NvmlAPI_Windows_V6 : NvmlAPI
    {
        #region Constants

        public const string LibName = "nvml";

        #endregion

        #region Initialization

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlInit_v2(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlInit_v2(
              );

        #endif
        public sealed override NvmlReturn Init(
              ) =>
            nvmlInit_v2(
                );

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlShutdown(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlShutdown(
              );

        #endif
        public sealed override NvmlReturn Shutdown(
              ) =>
            nvmlShutdown(
                );

        #endregion

        #region Device Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAPIRestriction(
             IntPtr device,
             NvmlRestrictedAPI apiType,
             out NvmlEnableState isRestricted);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted);

        #endif
        public sealed override NvmlReturn DeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted) =>
            nvmlDeviceGetAPIRestriction(
                device,
                apiType,
                out isRestricted);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetArchitecture(
             IntPtr device,
             out NvmlDeviceArchitecture arch);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch);

        #endif
        public sealed override NvmlReturn DeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch) =>
            nvmlDeviceGetArchitecture(
                device,
                out arch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAttributes(
             IntPtr device,
             out NvmlDeviceAttributes attributes);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes);

        #endif
        public sealed override NvmlReturn DeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes) =>
            nvmlDeviceGetAttributes(
                device,
                out attributes);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
             IntPtr device,
             out NvmlEnableState isEnabled,
             out NvmlEnableState defaultIsEnabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled);

        #endif
        public sealed override NvmlReturn DeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled) =>
            nvmlDeviceGetAutoBoostedClocksEnabled(
                device,
                out isEnabled,
                out defaultIsEnabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
             IntPtr device,
             out NvmlBAR1Memory bar1Memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory);

        #endif
        public sealed override NvmlReturn DeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory) =>
            nvmlDeviceGetBAR1MemoryInfo(
                device,
                out bar1Memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBoardId(
             IntPtr device,
             out uint boardId);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId);

        #endif
        public sealed override NvmlReturn DeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId) =>
            nvmlDeviceGetBoardId(
                device,
                out boardId);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetBoardPartNumber(
             IntPtr device,
             IntPtr partNumber,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetBoardPartNumber(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetBoardPartNumber_Interop(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length) =>
            nvmlDeviceGetBoardPartNumber(
                device,
                partNumber,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBrand(
             IntPtr device,
             out NvmlBrandType type);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type);

        #endif
        public sealed override NvmlReturn DeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type) =>
            nvmlDeviceGetBrand(
                device,
                out type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
             IntPtr device,
             out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #endif
        public sealed override NvmlReturn DeviceGetBridgeChipInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy) =>
            nvmlDeviceGetBridgeChipInfo(
                device,
                out bridgeHierarchy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClock(
             IntPtr device,
             NvmlClockType clockType,
             NvmlClockId clockId,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetClock(
                device,
                clockType,
                clockId,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClockInfo(
             IntPtr device,
             NvmlClockType clockType,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock) =>
            nvmlDeviceGetClockInfo(
                device,
                clockType,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetComputeMode(
             IntPtr device,
             out NvmlComputeMode mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode);

        #endif
        public sealed override NvmlReturn DeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode) =>
            nvmlDeviceGetComputeMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetComputeRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetComputeRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCount_v2(
             out uint deviceCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCount_v2(
            [Out] out uint deviceCount);

        #endif
        public sealed override NvmlReturn DeviceGetCount(
            [Out] out uint deviceCount) =>
            nvmlDeviceGetCount_v2(
                out deviceCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
             IntPtr device,
             out int major,
             out int minor);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor);

        #endif
        public sealed override NvmlReturn DeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor) =>
            nvmlDeviceGetCudaComputeCapability(
                device,
                out major,
                out minor);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
             IntPtr device,
             out uint currLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen) =>
            nvmlDeviceGetCurrPcieLinkGeneration(
                device,
                out currLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
             IntPtr device,
             out uint currLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth) =>
            nvmlDeviceGetCurrPcieLinkWidth(
                device,
                out currLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
             IntPtr device,
             out ulong clocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons) =>
            nvmlDeviceGetCurrentClocksThrottleReasons(
                device,
                out clocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDecoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetDecoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetDefaultApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out NvmlEccErrorCounts eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts) =>
            nvmlDeviceGetDetailedEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayActive(
             IntPtr device,
             out NvmlEnableState isActive);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive) =>
            nvmlDeviceGetDisplayActive(
                device,
                out isActive);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayMode(
             IntPtr device,
             out NvmlEnableState display);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display) =>
            nvmlDeviceGetDisplayMode(
                device,
                out display);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDriverModel(
             IntPtr device,
             out NvmlDriverModel current,
             out NvmlDriverModel pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending);

        #endif
        public sealed override NvmlReturn DeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending) =>
            nvmlDeviceGetDriverModel(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEccMode(
             IntPtr device,
             out NvmlEnableState current,
             out NvmlEnableState pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending);

        #endif
        public sealed override NvmlReturn DeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending) =>
            nvmlDeviceGetEccMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderCapacity(
             IntPtr device,
             NvmlEncoderType encoderQueryType,
             out uint encoderCapacity);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity) =>
            nvmlDeviceGetEncoderCapacity(
                device,
                encoderQueryType,
                out encoderCapacity);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetEncoderSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlEncoderSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetEncoderSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetEncoderSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos) =>
            nvmlDeviceGetEncoderSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderStats(
             IntPtr device,
             out uint sessionCount,
             out uint averageFps,
             out uint averageLatency);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency) =>
            nvmlDeviceGetEncoderStats(
                device,
                out sessionCount,
                out averageFps,
                out averageLatency);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetEncoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetEnforcedPowerLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetFBCSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlFBCSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetFBCSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetFBCSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos) =>
            nvmlDeviceGetFBCSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFBCStats(
             IntPtr device,
             out NvmlFBCStats fbcStats);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats);

        #endif
        public sealed override NvmlReturn DeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats) =>
            nvmlDeviceGetFBCStats(
                device,
                out fbcStats);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed(
             IntPtr device,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed(
                device,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
             IntPtr device,
             uint fan,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed_v2(
                device,
                fan,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetGpuOperationMode(
             IntPtr device,
             out NvmlGpuOperationMode current,
             out NvmlGpuOperationMode pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending);

        #endif
        public sealed override NvmlReturn DeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending) =>
            nvmlDeviceGetGpuOperationMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetGraphicsRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetGraphicsRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
             uint index,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
            [In] uint index,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByIndex_v2(
                index,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
             string pciBusId,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
            [In] string pciBusId,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByPciBusId(
            [In] string pciBusId,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByPciBusId_v2(
                pciBusId,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleBySerial(
             string serial,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleBySerial(
                serial,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByUUID(
             string uuid,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByUUID(
                uuid,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetIndex(
             IntPtr device,
             out uint index);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index);

        #endif
        public sealed override NvmlReturn DeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index) =>
            nvmlDeviceGetIndex(
                device,
                out index);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
             IntPtr device,
             out uint checksum);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum);

        #endif
        public sealed override NvmlReturn DeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum) =>
            nvmlDeviceGetInforomConfigurationChecksum(
                device,
                out checksum);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomImageVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomImageVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomImageVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomImageVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomVersion(
             IntPtr device,
             NvmlInforomObject inforomObject,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomVersion(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomVersion_Interop(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomVersion(
                device,
                inforomObject,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxClockInfo(
             IntPtr device,
             NvmlClockType type,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock) =>
            nvmlDeviceGetMaxClockInfo(
                device,
                type,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetMaxCustomerBoostClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
             IntPtr device,
             out uint maxLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen) =>
            nvmlDeviceGetMaxPcieLinkGeneration(
                device,
                out maxLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
             IntPtr device,
             out uint maxLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth) =>
            nvmlDeviceGetMaxPcieLinkWidth(
                device,
                out maxLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             NvmlMemoryLocation locationType,
             out ulong count);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count) =>
            nvmlDeviceGetMemoryErrorCounter(
                device,
                errorType,
                counterType,
                locationType,
                out count);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryInfo(
             IntPtr device,
             out NvmlMemory memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory) =>
            nvmlDeviceGetMemoryInfo(
                device,
                out memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMinorNumber(
             IntPtr device,
             out uint minorNumber);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber);

        #endif
        public sealed override NvmlReturn DeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber) =>
            nvmlDeviceGetMinorNumber(
                device,
                out minorNumber);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
             IntPtr device,
             out uint multiGpuBool);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool);

        #endif
        public sealed override NvmlReturn DeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool) =>
            nvmlDeviceGetMultiGpuBoard(
                device,
                out multiGpuBool);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetName(
             IntPtr device,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetName(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetName_Interop(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlDeviceGetName(
                device,
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetP2PStatus(
             IntPtr device1,
             IntPtr device2,
             NvmlGpuP2PCapsIndex p2pIndex,
             out NvmlGpuP2PStatus p2pStatus);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus);

        #endif
        public sealed override NvmlReturn DeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus) =>
            nvmlDeviceGetP2PStatus(
                device1,
                device2,
                p2pIndex,
                out p2pStatus);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPciInfo_v3(
             IntPtr device,
             out NvmlPciInfo_Interop pci);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPciInfo_v3(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci);

        #endif
        public sealed override NvmlReturn DeviceGetPciInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci) =>
            nvmlDeviceGetPciInfo_v3(
                device,
                out pci);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
             IntPtr device,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value) =>
            nvmlDeviceGetPcieReplayCounter(
                device,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieThroughput(
             IntPtr device,
             NvmlPcieUtilCounter counter,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value) =>
            nvmlDeviceGetPcieThroughput(
                device,
                counter,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPerformanceState(
             IntPtr device,
             out NvmlPstates state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state);

        #endif
        public sealed override NvmlReturn DeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state) =>
            nvmlDeviceGetPerformanceState(
                device,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPersistenceMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPersistenceMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
             IntPtr device,
             out uint defaultLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit) =>
            nvmlDeviceGetPowerManagementDefaultLimit(
                device,
                out defaultLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetPowerManagementLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
             IntPtr device,
             out uint minLimit,
             out uint maxLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit) =>
            nvmlDeviceGetPowerManagementLimitConstraints(
                device,
                out minLimit,
                out maxLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPowerManagementMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerState(
             IntPtr device,
             out NvmlPstates pState);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState);

        #endif
        public sealed override NvmlReturn DeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState) =>
            nvmlDeviceGetPowerState(
                device,
                out pState);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerUsage(
             IntPtr device,
             out uint power);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power);

        #endif
        public sealed override NvmlReturn DeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power) =>
            nvmlDeviceGetPowerUsage(
                device,
                out power);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRemappedRows(
             IntPtr device,
             out uint corrRows,
             out uint uncRows,
             out uint isPending,
             out uint failureOccurred);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred);

        #endif
        public sealed override NvmlReturn DeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred) =>
            nvmlDeviceGetRemappedRows(
                device,
                out corrRows,
                out uncRows,
                out isPending,
                out failureOccurred);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses) =>
            nvmlDeviceGetRetiredPages(
                device,
                cause,
                ref pageCount,
                addresses);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
             IntPtr device,
             out NvmlEnableState isPending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending);

        #endif
        public sealed override NvmlReturn DeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending) =>
            nvmlDeviceGetRetiredPagesPendingStatus(
                device,
                out isPending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses,
             ulong* timestamps);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_v2_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps) =>
            nvmlDeviceGetRetiredPages_v2(
                device,
                cause,
                ref pageCount,
                addresses,
                timestamps);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSamples(
             IntPtr device,
             NvmlSamplingType type,
             ulong lastSeenTimeStamp,
             out NvmlValueType sampleValType,
             ref uint sampleCount,
             NvmlSample* samples);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSamples(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSamples_Interop(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples) =>
            nvmlDeviceGetSamples(
                device,
                type,
                lastSeenTimeStamp,
                out sampleValType,
                ref sampleCount,
                samples);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSerial(
             IntPtr device,
             IntPtr serial,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSerial(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSerial_Interop(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length) =>
            nvmlDeviceGetSerial(
                device,
                serial,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
             IntPtr device,
             out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons) =>
            nvmlDeviceGetSupportedClocksThrottleReasons(
                device,
                out supportedClocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
             IntPtr device,
             uint memoryClockMHz,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedGraphicsClocks_Interop(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedGraphicsClocks(
                device,
                memoryClockMHz,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
             IntPtr device,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedMemoryClocks_Interop(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedMemoryClocks(
                device,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperature(
             IntPtr device,
             NvmlTemperatureSensors sensorType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperature(
                device,
                sensorType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
             IntPtr device,
             NvmlTemperatureThresholds thresholdType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperatureThreshold(
                device,
                thresholdType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
             IntPtr device1,
             IntPtr device2,
             out NvmlGpuTopologyLevel pathInfo);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo);

        #endif
        public sealed override NvmlReturn DeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo) =>
            nvmlDeviceGetTopologyCommonAncestor(
                device1,
                device2,
                out pathInfo);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
             IntPtr device,
             NvmlGpuTopologyLevel level,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetTopologyNearestGpus_Interop(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlDeviceGetTopologyNearestGpus(
                device,
                level,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out ulong eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts) =>
            nvmlDeviceGetTotalEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
             IntPtr device,
             out ulong energy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy) =>
            nvmlDeviceGetTotalEnergyConsumption(
                device,
                out energy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetUUID(
             IntPtr device,
             IntPtr uuid,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetUUID(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetUUID_Interop(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length) =>
            nvmlDeviceGetUUID(
                device,
                uuid,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetUtilizationRates(
             IntPtr device,
             out NvmlUtilization utilization);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization);

        #endif
        public sealed override NvmlReturn DeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization) =>
            nvmlDeviceGetUtilizationRates(
                device,
                out utilization);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetVbiosVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetVbiosVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetVbiosVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetVbiosVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetViolationStatus(
             IntPtr device,
             NvmlPerfPolicyType perfPolicyType,
             out NvmlViolationTime violTime);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime);

        #endif
        public sealed override NvmlReturn DeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime) =>
            nvmlDeviceGetViolationStatus(
                device,
                perfPolicyType,
                out violTime);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceOnSameBoard(
             IntPtr device1,
             IntPtr device2,
             out int onSameBoard);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard);

        #endif
        public sealed override NvmlReturn DeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard) =>
            nvmlDeviceOnSameBoard(
                device1,
                device2,
                out onSameBoard);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceResetApplicationsClocks(
             IntPtr device1);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceResetApplicationsClocks(
            [In] IntPtr device1);

        #endif
        public sealed override NvmlReturn DeviceResetApplicationsClocks(
            [In] IntPtr device1) =>
            nvmlDeviceResetApplicationsClocks(
                device1);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled);

        #endif
        public sealed override NvmlReturn DeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled) =>
            nvmlDeviceSetAutoBoostedClocksEnabled(
                device,
                enabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags);

        #endif
        public sealed override NvmlReturn DeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags) =>
            nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
                device,
                enabled,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceValidateInforom(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceValidateInforom(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceValidateInforom(
            [In] IntPtr device) =>
            nvmlDeviceValidateInforom(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetTopologyGpuSet(
             uint cpuNumber,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetTopologyGpuSet(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn SystemGetTopologyGpuSet_Interop(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlSystemGetTopologyGpuSet(
                cpuNumber,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
             uint vgpuInstance,
             IntPtr mdevUuid,
             uint size);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size);

        #endif
        public unsafe sealed override NvmlReturn VgpuInstanceGetMdevUUID_Interop(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size) =>
            nvmlVgpuInstanceGetMdevUUID(
                vgpuInstance,
                mdevUuid,
                size);

        #endregion

        #region Device Queries - CPU and Memory Affinity

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceClearCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceClearCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceClearCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceClearCpuAffinity(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinity(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinity(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinity_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet) =>
            nvmlDeviceGetCpuAffinity(
                device,
                cpuSetSize,
                cpuSet);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinityWithinScope_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetCpuAffinityWithinScope(
                device,
                cpuSetSize,
                cpuSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetMemoryAffinity(
             IntPtr device,
             uint nodeSetSize,
             ulong* nodeSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetMemoryAffinity(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetMemoryAffinity_Interop(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetMemoryAffinity(
                device,
                nodeSetSize,
                nodeSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceSetCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceSetCpuAffinity(
                device);

        #endregion

        #region System Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_v2_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion_v2(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetDriverVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetDriverVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetDriverVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetDriverVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetNVMLVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetNVMLVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetNVMLVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetNVMLVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetProcessName(
             uint pid,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetProcessName(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetProcessName_Interop(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetProcessName(
                pid,
                name,
                length);

        #endregion

        #region Unit Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetHicVersion(
             ref uint hwbcCount,
             NvmlHwbcEntry_Interop* hwbcEntries);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetHicVersion(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries);

        #endif
        public unsafe sealed override NvmlReturn SystemGetHicVersion_Interop(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries) =>
            nvmlSystemGetHicVersion(
                ref hwbcCount,
                hwbcEntries);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetCount(
             out uint unitCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetCount(
            [Out] out uint unitCount);

        #endif
        public sealed override NvmlReturn UnitGetCount(
            [Out] out uint unitCount) =>
            nvmlUnitGetCount(
                out unitCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlUnitGetDevices(
             IntPtr unit,
             ref uint deviceCount,
             IntPtr* devices);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlUnitGetDevices(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices);

        #endif
        public unsafe sealed override NvmlReturn UnitGetDevices_Interop(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices) =>
            nvmlUnitGetDevices(
                unit,
                ref deviceCount,
                devices);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetFanSpeedInfo(
             IntPtr unit,
             out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetFanSpeedInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #endif
        public sealed override NvmlReturn UnitGetFanSpeedInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds) =>
            nvmlUnitGetFanSpeedInfo(
                unit,
                out fanSpeeds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetHandleByIndex(
             uint index,
             out IntPtr unit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit);

        #endif
        public sealed override NvmlReturn UnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit) =>
            nvmlUnitGetHandleByIndex(
                index,
                out unit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetLedState(
             IntPtr unit,
             out NvmlLedState_Interop state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetLedState(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state);

        #endif
        public sealed override NvmlReturn UnitGetLedState_Interop(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state) =>
            nvmlUnitGetLedState(
                unit,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetPsuInfo(
             IntPtr unit,
             out NvmlPSUInfo_Interop psu);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetPsuInfo(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu);

        #endif
        public sealed override NvmlReturn UnitGetPsuInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu) =>
            nvmlUnitGetPsuInfo(
                unit,
                out psu);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetTemperature(
             IntPtr unit,
             uint type,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn UnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp) =>
            nvmlUnitGetTemperature(
                unit,
                type,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetUnitInfo(
             IntPtr unit,
             out NvmlUnitInfo_Interop info);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetUnitInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info);

        #endif
        public sealed override NvmlReturn UnitGetUnitInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info) =>
            nvmlUnitGetUnitInfo(
                unit,
                out info);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class NvmlAPI_Linux_V6 : NvmlAPI
    {
        #region Constants

        public const string LibName = "nvidia-ml.so";

        #endregion

        #region Initialization

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlInit_v2(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlInit_v2(
              );

        #endif
        public sealed override NvmlReturn Init(
              ) =>
            nvmlInit_v2(
                );

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlShutdown(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlShutdown(
              );

        #endif
        public sealed override NvmlReturn Shutdown(
              ) =>
            nvmlShutdown(
                );

        #endregion

        #region Device Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAPIRestriction(
             IntPtr device,
             NvmlRestrictedAPI apiType,
             out NvmlEnableState isRestricted);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted);

        #endif
        public sealed override NvmlReturn DeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted) =>
            nvmlDeviceGetAPIRestriction(
                device,
                apiType,
                out isRestricted);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetArchitecture(
             IntPtr device,
             out NvmlDeviceArchitecture arch);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch);

        #endif
        public sealed override NvmlReturn DeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch) =>
            nvmlDeviceGetArchitecture(
                device,
                out arch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAttributes(
             IntPtr device,
             out NvmlDeviceAttributes attributes);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes);

        #endif
        public sealed override NvmlReturn DeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes) =>
            nvmlDeviceGetAttributes(
                device,
                out attributes);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
             IntPtr device,
             out NvmlEnableState isEnabled,
             out NvmlEnableState defaultIsEnabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled);

        #endif
        public sealed override NvmlReturn DeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled) =>
            nvmlDeviceGetAutoBoostedClocksEnabled(
                device,
                out isEnabled,
                out defaultIsEnabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
             IntPtr device,
             out NvmlBAR1Memory bar1Memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory);

        #endif
        public sealed override NvmlReturn DeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory) =>
            nvmlDeviceGetBAR1MemoryInfo(
                device,
                out bar1Memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBoardId(
             IntPtr device,
             out uint boardId);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId);

        #endif
        public sealed override NvmlReturn DeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId) =>
            nvmlDeviceGetBoardId(
                device,
                out boardId);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetBoardPartNumber(
             IntPtr device,
             IntPtr partNumber,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetBoardPartNumber(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetBoardPartNumber_Interop(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length) =>
            nvmlDeviceGetBoardPartNumber(
                device,
                partNumber,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBrand(
             IntPtr device,
             out NvmlBrandType type);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type);

        #endif
        public sealed override NvmlReturn DeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type) =>
            nvmlDeviceGetBrand(
                device,
                out type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
             IntPtr device,
             out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #endif
        public sealed override NvmlReturn DeviceGetBridgeChipInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy) =>
            nvmlDeviceGetBridgeChipInfo(
                device,
                out bridgeHierarchy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClock(
             IntPtr device,
             NvmlClockType clockType,
             NvmlClockId clockId,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetClock(
                device,
                clockType,
                clockId,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClockInfo(
             IntPtr device,
             NvmlClockType clockType,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock) =>
            nvmlDeviceGetClockInfo(
                device,
                clockType,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetComputeMode(
             IntPtr device,
             out NvmlComputeMode mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode);

        #endif
        public sealed override NvmlReturn DeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode) =>
            nvmlDeviceGetComputeMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetComputeRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetComputeRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCount_v2(
             out uint deviceCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCount_v2(
            [Out] out uint deviceCount);

        #endif
        public sealed override NvmlReturn DeviceGetCount(
            [Out] out uint deviceCount) =>
            nvmlDeviceGetCount_v2(
                out deviceCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
             IntPtr device,
             out int major,
             out int minor);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor);

        #endif
        public sealed override NvmlReturn DeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor) =>
            nvmlDeviceGetCudaComputeCapability(
                device,
                out major,
                out minor);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
             IntPtr device,
             out uint currLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen) =>
            nvmlDeviceGetCurrPcieLinkGeneration(
                device,
                out currLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
             IntPtr device,
             out uint currLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth) =>
            nvmlDeviceGetCurrPcieLinkWidth(
                device,
                out currLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
             IntPtr device,
             out ulong clocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons) =>
            nvmlDeviceGetCurrentClocksThrottleReasons(
                device,
                out clocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDecoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetDecoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetDefaultApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out NvmlEccErrorCounts eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts) =>
            nvmlDeviceGetDetailedEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayActive(
             IntPtr device,
             out NvmlEnableState isActive);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive) =>
            nvmlDeviceGetDisplayActive(
                device,
                out isActive);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayMode(
             IntPtr device,
             out NvmlEnableState display);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display) =>
            nvmlDeviceGetDisplayMode(
                device,
                out display);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDriverModel(
             IntPtr device,
             out NvmlDriverModel current,
             out NvmlDriverModel pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending);

        #endif
        public sealed override NvmlReturn DeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending) =>
            nvmlDeviceGetDriverModel(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEccMode(
             IntPtr device,
             out NvmlEnableState current,
             out NvmlEnableState pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending);

        #endif
        public sealed override NvmlReturn DeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending) =>
            nvmlDeviceGetEccMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderCapacity(
             IntPtr device,
             NvmlEncoderType encoderQueryType,
             out uint encoderCapacity);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity) =>
            nvmlDeviceGetEncoderCapacity(
                device,
                encoderQueryType,
                out encoderCapacity);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetEncoderSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlEncoderSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetEncoderSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetEncoderSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos) =>
            nvmlDeviceGetEncoderSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderStats(
             IntPtr device,
             out uint sessionCount,
             out uint averageFps,
             out uint averageLatency);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency) =>
            nvmlDeviceGetEncoderStats(
                device,
                out sessionCount,
                out averageFps,
                out averageLatency);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetEncoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetEnforcedPowerLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetFBCSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlFBCSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetFBCSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetFBCSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos) =>
            nvmlDeviceGetFBCSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFBCStats(
             IntPtr device,
             out NvmlFBCStats fbcStats);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats);

        #endif
        public sealed override NvmlReturn DeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats) =>
            nvmlDeviceGetFBCStats(
                device,
                out fbcStats);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed(
             IntPtr device,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed(
                device,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
             IntPtr device,
             uint fan,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed_v2(
                device,
                fan,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetGpuOperationMode(
             IntPtr device,
             out NvmlGpuOperationMode current,
             out NvmlGpuOperationMode pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending);

        #endif
        public sealed override NvmlReturn DeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending) =>
            nvmlDeviceGetGpuOperationMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetGraphicsRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetGraphicsRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
             uint index,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
            [In] uint index,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByIndex_v2(
                index,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
             string pciBusId,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
            [In] string pciBusId,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByPciBusId(
            [In] string pciBusId,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByPciBusId_v2(
                pciBusId,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleBySerial(
             string serial,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleBySerial(
                serial,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByUUID(
             string uuid,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByUUID(
                uuid,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetIndex(
             IntPtr device,
             out uint index);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index);

        #endif
        public sealed override NvmlReturn DeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index) =>
            nvmlDeviceGetIndex(
                device,
                out index);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
             IntPtr device,
             out uint checksum);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum);

        #endif
        public sealed override NvmlReturn DeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum) =>
            nvmlDeviceGetInforomConfigurationChecksum(
                device,
                out checksum);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomImageVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomImageVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomImageVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomImageVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomVersion(
             IntPtr device,
             NvmlInforomObject inforomObject,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomVersion(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomVersion_Interop(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomVersion(
                device,
                inforomObject,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxClockInfo(
             IntPtr device,
             NvmlClockType type,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock) =>
            nvmlDeviceGetMaxClockInfo(
                device,
                type,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetMaxCustomerBoostClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
             IntPtr device,
             out uint maxLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen) =>
            nvmlDeviceGetMaxPcieLinkGeneration(
                device,
                out maxLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
             IntPtr device,
             out uint maxLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth) =>
            nvmlDeviceGetMaxPcieLinkWidth(
                device,
                out maxLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             NvmlMemoryLocation locationType,
             out ulong count);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count) =>
            nvmlDeviceGetMemoryErrorCounter(
                device,
                errorType,
                counterType,
                locationType,
                out count);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryInfo(
             IntPtr device,
             out NvmlMemory memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory) =>
            nvmlDeviceGetMemoryInfo(
                device,
                out memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMinorNumber(
             IntPtr device,
             out uint minorNumber);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber);

        #endif
        public sealed override NvmlReturn DeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber) =>
            nvmlDeviceGetMinorNumber(
                device,
                out minorNumber);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
             IntPtr device,
             out uint multiGpuBool);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool);

        #endif
        public sealed override NvmlReturn DeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool) =>
            nvmlDeviceGetMultiGpuBoard(
                device,
                out multiGpuBool);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetName(
             IntPtr device,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetName(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetName_Interop(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlDeviceGetName(
                device,
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetP2PStatus(
             IntPtr device1,
             IntPtr device2,
             NvmlGpuP2PCapsIndex p2pIndex,
             out NvmlGpuP2PStatus p2pStatus);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus);

        #endif
        public sealed override NvmlReturn DeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus) =>
            nvmlDeviceGetP2PStatus(
                device1,
                device2,
                p2pIndex,
                out p2pStatus);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPciInfo_v3(
             IntPtr device,
             out NvmlPciInfo_Interop pci);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPciInfo_v3(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci);

        #endif
        public sealed override NvmlReturn DeviceGetPciInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci) =>
            nvmlDeviceGetPciInfo_v3(
                device,
                out pci);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
             IntPtr device,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value) =>
            nvmlDeviceGetPcieReplayCounter(
                device,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieThroughput(
             IntPtr device,
             NvmlPcieUtilCounter counter,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value) =>
            nvmlDeviceGetPcieThroughput(
                device,
                counter,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPerformanceState(
             IntPtr device,
             out NvmlPstates state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state);

        #endif
        public sealed override NvmlReturn DeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state) =>
            nvmlDeviceGetPerformanceState(
                device,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPersistenceMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPersistenceMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
             IntPtr device,
             out uint defaultLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit) =>
            nvmlDeviceGetPowerManagementDefaultLimit(
                device,
                out defaultLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetPowerManagementLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
             IntPtr device,
             out uint minLimit,
             out uint maxLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit) =>
            nvmlDeviceGetPowerManagementLimitConstraints(
                device,
                out minLimit,
                out maxLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPowerManagementMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerState(
             IntPtr device,
             out NvmlPstates pState);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState);

        #endif
        public sealed override NvmlReturn DeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState) =>
            nvmlDeviceGetPowerState(
                device,
                out pState);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerUsage(
             IntPtr device,
             out uint power);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power);

        #endif
        public sealed override NvmlReturn DeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power) =>
            nvmlDeviceGetPowerUsage(
                device,
                out power);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRemappedRows(
             IntPtr device,
             out uint corrRows,
             out uint uncRows,
             out uint isPending,
             out uint failureOccurred);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred);

        #endif
        public sealed override NvmlReturn DeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred) =>
            nvmlDeviceGetRemappedRows(
                device,
                out corrRows,
                out uncRows,
                out isPending,
                out failureOccurred);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses) =>
            nvmlDeviceGetRetiredPages(
                device,
                cause,
                ref pageCount,
                addresses);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
             IntPtr device,
             out NvmlEnableState isPending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending);

        #endif
        public sealed override NvmlReturn DeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending) =>
            nvmlDeviceGetRetiredPagesPendingStatus(
                device,
                out isPending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses,
             ulong* timestamps);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_v2_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps) =>
            nvmlDeviceGetRetiredPages_v2(
                device,
                cause,
                ref pageCount,
                addresses,
                timestamps);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSamples(
             IntPtr device,
             NvmlSamplingType type,
             ulong lastSeenTimeStamp,
             out NvmlValueType sampleValType,
             ref uint sampleCount,
             NvmlSample* samples);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSamples(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSamples_Interop(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples) =>
            nvmlDeviceGetSamples(
                device,
                type,
                lastSeenTimeStamp,
                out sampleValType,
                ref sampleCount,
                samples);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSerial(
             IntPtr device,
             IntPtr serial,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSerial(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSerial_Interop(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length) =>
            nvmlDeviceGetSerial(
                device,
                serial,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
             IntPtr device,
             out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons) =>
            nvmlDeviceGetSupportedClocksThrottleReasons(
                device,
                out supportedClocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
             IntPtr device,
             uint memoryClockMHz,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedGraphicsClocks_Interop(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedGraphicsClocks(
                device,
                memoryClockMHz,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
             IntPtr device,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedMemoryClocks_Interop(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedMemoryClocks(
                device,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperature(
             IntPtr device,
             NvmlTemperatureSensors sensorType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperature(
                device,
                sensorType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
             IntPtr device,
             NvmlTemperatureThresholds thresholdType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperatureThreshold(
                device,
                thresholdType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
             IntPtr device1,
             IntPtr device2,
             out NvmlGpuTopologyLevel pathInfo);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo);

        #endif
        public sealed override NvmlReturn DeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo) =>
            nvmlDeviceGetTopologyCommonAncestor(
                device1,
                device2,
                out pathInfo);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
             IntPtr device,
             NvmlGpuTopologyLevel level,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetTopologyNearestGpus_Interop(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlDeviceGetTopologyNearestGpus(
                device,
                level,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out ulong eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts) =>
            nvmlDeviceGetTotalEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
             IntPtr device,
             out ulong energy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy) =>
            nvmlDeviceGetTotalEnergyConsumption(
                device,
                out energy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetUUID(
             IntPtr device,
             IntPtr uuid,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetUUID(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetUUID_Interop(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length) =>
            nvmlDeviceGetUUID(
                device,
                uuid,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetUtilizationRates(
             IntPtr device,
             out NvmlUtilization utilization);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization);

        #endif
        public sealed override NvmlReturn DeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization) =>
            nvmlDeviceGetUtilizationRates(
                device,
                out utilization);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetVbiosVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetVbiosVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetVbiosVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetVbiosVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetViolationStatus(
             IntPtr device,
             NvmlPerfPolicyType perfPolicyType,
             out NvmlViolationTime violTime);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime);

        #endif
        public sealed override NvmlReturn DeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime) =>
            nvmlDeviceGetViolationStatus(
                device,
                perfPolicyType,
                out violTime);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceOnSameBoard(
             IntPtr device1,
             IntPtr device2,
             out int onSameBoard);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard);

        #endif
        public sealed override NvmlReturn DeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard) =>
            nvmlDeviceOnSameBoard(
                device1,
                device2,
                out onSameBoard);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceResetApplicationsClocks(
             IntPtr device1);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceResetApplicationsClocks(
            [In] IntPtr device1);

        #endif
        public sealed override NvmlReturn DeviceResetApplicationsClocks(
            [In] IntPtr device1) =>
            nvmlDeviceResetApplicationsClocks(
                device1);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled);

        #endif
        public sealed override NvmlReturn DeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled) =>
            nvmlDeviceSetAutoBoostedClocksEnabled(
                device,
                enabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags);

        #endif
        public sealed override NvmlReturn DeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags) =>
            nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
                device,
                enabled,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceValidateInforom(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceValidateInforom(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceValidateInforom(
            [In] IntPtr device) =>
            nvmlDeviceValidateInforom(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetTopologyGpuSet(
             uint cpuNumber,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetTopologyGpuSet(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn SystemGetTopologyGpuSet_Interop(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlSystemGetTopologyGpuSet(
                cpuNumber,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
             uint vgpuInstance,
             IntPtr mdevUuid,
             uint size);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size);

        #endif
        public unsafe sealed override NvmlReturn VgpuInstanceGetMdevUUID_Interop(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size) =>
            nvmlVgpuInstanceGetMdevUUID(
                vgpuInstance,
                mdevUuid,
                size);

        #endregion

        #region Device Queries - CPU and Memory Affinity

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceClearCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceClearCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceClearCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceClearCpuAffinity(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinity(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinity(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinity_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet) =>
            nvmlDeviceGetCpuAffinity(
                device,
                cpuSetSize,
                cpuSet);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinityWithinScope_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetCpuAffinityWithinScope(
                device,
                cpuSetSize,
                cpuSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetMemoryAffinity(
             IntPtr device,
             uint nodeSetSize,
             ulong* nodeSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetMemoryAffinity(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetMemoryAffinity_Interop(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetMemoryAffinity(
                device,
                nodeSetSize,
                nodeSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceSetCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceSetCpuAffinity(
                device);

        #endregion

        #region System Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_v2_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion_v2(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetDriverVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetDriverVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetDriverVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetDriverVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetNVMLVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetNVMLVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetNVMLVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetNVMLVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetProcessName(
             uint pid,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetProcessName(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetProcessName_Interop(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetProcessName(
                pid,
                name,
                length);

        #endregion

        #region Unit Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetHicVersion(
             ref uint hwbcCount,
             NvmlHwbcEntry_Interop* hwbcEntries);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetHicVersion(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries);

        #endif
        public unsafe sealed override NvmlReturn SystemGetHicVersion_Interop(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries) =>
            nvmlSystemGetHicVersion(
                ref hwbcCount,
                hwbcEntries);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetCount(
             out uint unitCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetCount(
            [Out] out uint unitCount);

        #endif
        public sealed override NvmlReturn UnitGetCount(
            [Out] out uint unitCount) =>
            nvmlUnitGetCount(
                out unitCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlUnitGetDevices(
             IntPtr unit,
             ref uint deviceCount,
             IntPtr* devices);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlUnitGetDevices(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices);

        #endif
        public unsafe sealed override NvmlReturn UnitGetDevices_Interop(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices) =>
            nvmlUnitGetDevices(
                unit,
                ref deviceCount,
                devices);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetFanSpeedInfo(
             IntPtr unit,
             out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetFanSpeedInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #endif
        public sealed override NvmlReturn UnitGetFanSpeedInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds) =>
            nvmlUnitGetFanSpeedInfo(
                unit,
                out fanSpeeds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetHandleByIndex(
             uint index,
             out IntPtr unit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit);

        #endif
        public sealed override NvmlReturn UnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit) =>
            nvmlUnitGetHandleByIndex(
                index,
                out unit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetLedState(
             IntPtr unit,
             out NvmlLedState_Interop state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetLedState(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state);

        #endif
        public sealed override NvmlReturn UnitGetLedState_Interop(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state) =>
            nvmlUnitGetLedState(
                unit,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetPsuInfo(
             IntPtr unit,
             out NvmlPSUInfo_Interop psu);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetPsuInfo(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu);

        #endif
        public sealed override NvmlReturn UnitGetPsuInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu) =>
            nvmlUnitGetPsuInfo(
                unit,
                out psu);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetTemperature(
             IntPtr unit,
             uint type,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn UnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp) =>
            nvmlUnitGetTemperature(
                unit,
                type,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetUnitInfo(
             IntPtr unit,
             out NvmlUnitInfo_Interop info);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetUnitInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info);

        #endif
        public sealed override NvmlReturn UnitGetUnitInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info) =>
            nvmlUnitGetUnitInfo(
                unit,
                out info);

        #endregion

    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA5393:Do not use unsafe DllImportSearchPath value")]
    internal sealed partial class NvmlAPI_OSX_V6 : NvmlAPI
    {
        #region Constants

        public const string LibName = "nvidia-ml.dylib";

        #endregion

        #region Initialization

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlInit_v2(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlInit_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlInit_v2(
              );

        #endif
        public sealed override NvmlReturn Init(
              ) =>
            nvmlInit_v2(
                );

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlShutdown(
              );

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlShutdown"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlShutdown(
              );

        #endif
        public sealed override NvmlReturn Shutdown(
              ) =>
            nvmlShutdown(
                );

        #endregion

        #region Device Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAPIRestriction(
             IntPtr device,
             NvmlRestrictedAPI apiType,
             out NvmlEnableState isRestricted);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAPIRestriction"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted);

        #endif
        public sealed override NvmlReturn DeviceGetAPIRestriction(
            [In] IntPtr device,
            [In] NvmlRestrictedAPI apiType,
            [Out] out NvmlEnableState isRestricted) =>
            nvmlDeviceGetAPIRestriction(
                device,
                apiType,
                out isRestricted);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetArchitecture(
             IntPtr device,
             out NvmlDeviceArchitecture arch);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetArchitecture"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch);

        #endif
        public sealed override NvmlReturn DeviceGetArchitecture(
            [In] IntPtr device,
            [Out] out NvmlDeviceArchitecture arch) =>
            nvmlDeviceGetArchitecture(
                device,
                out arch);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAttributes(
             IntPtr device,
             out NvmlDeviceAttributes attributes);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAttributes"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes);

        #endif
        public sealed override NvmlReturn DeviceGetAttributes(
            [In] IntPtr device,
            [Out] out NvmlDeviceAttributes attributes) =>
            nvmlDeviceGetAttributes(
                device,
                out attributes);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
             IntPtr device,
             out NvmlEnableState isEnabled,
             out NvmlEnableState defaultIsEnabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled);

        #endif
        public sealed override NvmlReturn DeviceGetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [Out] out NvmlEnableState isEnabled,
            [Out] out NvmlEnableState defaultIsEnabled) =>
            nvmlDeviceGetAutoBoostedClocksEnabled(
                device,
                out isEnabled,
                out defaultIsEnabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
             IntPtr device,
             out NvmlBAR1Memory bar1Memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBAR1MemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory);

        #endif
        public sealed override NvmlReturn DeviceGetBAR1MemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlBAR1Memory bar1Memory) =>
            nvmlDeviceGetBAR1MemoryInfo(
                device,
                out bar1Memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBoardId(
             IntPtr device,
             out uint boardId);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardId"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId);

        #endif
        public sealed override NvmlReturn DeviceGetBoardId(
            [In] IntPtr device,
            [Out] out uint boardId) =>
            nvmlDeviceGetBoardId(
                device,
                out boardId);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetBoardPartNumber(
             IntPtr device,
             IntPtr partNumber,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBoardPartNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetBoardPartNumber(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetBoardPartNumber_Interop(
            [In] IntPtr device,
            [In] IntPtr partNumber,
            [In] uint length) =>
            nvmlDeviceGetBoardPartNumber(
                device,
                partNumber,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBrand(
             IntPtr device,
             out NvmlBrandType type);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBrand"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type);

        #endif
        public sealed override NvmlReturn DeviceGetBrand(
            [In] IntPtr device,
            [Out] out NvmlBrandType type) =>
            nvmlDeviceGetBrand(
                device,
                out type);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
             IntPtr device,
             out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetBridgeChipInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetBridgeChipInfo(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy);

        #endif
        public sealed override NvmlReturn DeviceGetBridgeChipInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlBridgeChipHierarchy_Interop bridgeHierarchy) =>
            nvmlDeviceGetBridgeChipInfo(
                device,
                out bridgeHierarchy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClock(
             IntPtr device,
             NvmlClockType clockType,
             NvmlClockId clockId,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [In] NvmlClockId clockId,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetClock(
                device,
                clockType,
                clockId,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetClockInfo(
             IntPtr device,
             NvmlClockType clockType,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clock) =>
            nvmlDeviceGetClockInfo(
                device,
                clockType,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetComputeMode(
             IntPtr device,
             out NvmlComputeMode mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode);

        #endif
        public sealed override NvmlReturn DeviceGetComputeMode(
            [In] IntPtr device,
            [Out] out NvmlComputeMode mode) =>
            nvmlDeviceGetComputeMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetComputeRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetComputeRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetComputeRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetComputeRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCount_v2(
             out uint deviceCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCount_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCount_v2(
            [Out] out uint deviceCount);

        #endif
        public sealed override NvmlReturn DeviceGetCount(
            [Out] out uint deviceCount) =>
            nvmlDeviceGetCount_v2(
                out deviceCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
             IntPtr device,
             out int major,
             out int minor);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCudaComputeCapability"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor);

        #endif
        public sealed override NvmlReturn DeviceGetCudaComputeCapability(
            [In] IntPtr device,
            [Out] out int major,
            [Out] out int minor) =>
            nvmlDeviceGetCudaComputeCapability(
                device,
                out major,
                out minor);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
             IntPtr device,
             out uint currLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint currLinkGen) =>
            nvmlDeviceGetCurrPcieLinkGeneration(
                device,
                out currLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
             IntPtr device,
             out uint currLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetCurrPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint currLinkWidth) =>
            nvmlDeviceGetCurrPcieLinkWidth(
                device,
                out currLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
             IntPtr device,
             out ulong clocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCurrentClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetCurrentClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out ulong clocksThrottleReasons) =>
            nvmlDeviceGetCurrentClocksThrottleReasons(
                device,
                out clocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDecoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDecoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetDecoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetDecoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDefaultApplicationsClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetDefaultApplicationsClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetDefaultApplicationsClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out NvmlEccErrorCounts eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDetailedEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetDetailedEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out NvmlEccErrorCounts eccCounts) =>
            nvmlDeviceGetDetailedEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayActive(
             IntPtr device,
             out NvmlEnableState isActive);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayActive"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayActive(
            [In] IntPtr device,
            [Out] out NvmlEnableState isActive) =>
            nvmlDeviceGetDisplayActive(
                device,
                out isActive);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDisplayMode(
             IntPtr device,
             out NvmlEnableState display);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDisplayMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display);

        #endif
        public sealed override NvmlReturn DeviceGetDisplayMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState display) =>
            nvmlDeviceGetDisplayMode(
                device,
                out display);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetDriverModel(
             IntPtr device,
             out NvmlDriverModel current,
             out NvmlDriverModel pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetDriverModel"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending);

        #endif
        public sealed override NvmlReturn DeviceGetDriverModel(
            [In] IntPtr device,
            [Out] out NvmlDriverModel current,
            [Out] out NvmlDriverModel pending) =>
            nvmlDeviceGetDriverModel(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEccMode(
             IntPtr device,
             out NvmlEnableState current,
             out NvmlEnableState pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEccMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending);

        #endif
        public sealed override NvmlReturn DeviceGetEccMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState current,
            [Out] out NvmlEnableState pending) =>
            nvmlDeviceGetEccMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderCapacity(
             IntPtr device,
             NvmlEncoderType encoderQueryType,
             out uint encoderCapacity);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderCapacity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderCapacity(
            [In] IntPtr device,
            [In] NvmlEncoderType encoderQueryType,
            [Out] out uint encoderCapacity) =>
            nvmlDeviceGetEncoderCapacity(
                device,
                encoderQueryType,
                out encoderCapacity);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetEncoderSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlEncoderSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetEncoderSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetEncoderSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlEncoderSessionInfo* sessionInfos) =>
            nvmlDeviceGetEncoderSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderStats(
             IntPtr device,
             out uint sessionCount,
             out uint averageFps,
             out uint averageLatency);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderStats(
            [In] IntPtr device,
            [Out] out uint sessionCount,
            [Out] out uint averageFps,
            [Out] out uint averageLatency) =>
            nvmlDeviceGetEncoderStats(
                device,
                out sessionCount,
                out averageFps,
                out averageLatency);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEncoderUtilization(
             IntPtr device,
             out uint utilization,
             out uint samplingPeriodUs);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEncoderUtilization"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs);

        #endif
        public sealed override NvmlReturn DeviceGetEncoderUtilization(
            [In] IntPtr device,
            [Out] out uint utilization,
            [Out] out uint samplingPeriodUs) =>
            nvmlDeviceGetEncoderUtilization(
                device,
                out utilization,
                out samplingPeriodUs);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetEnforcedPowerLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetEnforcedPowerLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetEnforcedPowerLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetFBCSessions(
             IntPtr device,
             ref uint sessionCount,
             NvmlFBCSessionInfo* sessionInfos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCSessions"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetFBCSessions(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetFBCSessions_Interop(
            [In] IntPtr device,
            [In] ref uint sessionCount,
            [In] NvmlFBCSessionInfo* sessionInfos) =>
            nvmlDeviceGetFBCSessions(
                device,
                ref sessionCount,
                sessionInfos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFBCStats(
             IntPtr device,
             out NvmlFBCStats fbcStats);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFBCStats"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats);

        #endif
        public sealed override NvmlReturn DeviceGetFBCStats(
            [In] IntPtr device,
            [Out] out NvmlFBCStats fbcStats) =>
            nvmlDeviceGetFBCStats(
                device,
                out fbcStats);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed(
             IntPtr device,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed(
                device,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
             IntPtr device,
             uint fan,
             out uint speed);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetFanSpeed_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetFanSpeed_v2(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed);

        #endif
        public sealed override NvmlReturn DeviceGetFanSpeed(
            [In] IntPtr device,
            [In] uint fan,
            [Out] out uint speed) =>
            nvmlDeviceGetFanSpeed_v2(
                device,
                fan,
                out speed);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetGpuOperationMode(
             IntPtr device,
             out NvmlGpuOperationMode current,
             out NvmlGpuOperationMode pending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGpuOperationMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending);

        #endif
        public sealed override NvmlReturn DeviceGetGpuOperationMode(
            [In] IntPtr device,
            [Out] out NvmlGpuOperationMode current,
            [Out] out NvmlGpuOperationMode pending) =>
            nvmlDeviceGetGpuOperationMode(
                device,
                out current,
                out pending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
             IntPtr device,
             ref uint infoCount,
             NvmlProcessInfo* infos);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetGraphicsRunningProcesses_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetGraphicsRunningProcesses_v2(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetGraphicsRunningProcesses_v2_Interop(
            [In] IntPtr device,
            [In] ref uint infoCount,
            [In] NvmlProcessInfo* infos) =>
            nvmlDeviceGetGraphicsRunningProcesses_v2(
                device,
                ref infoCount,
                infos);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
             uint index,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByIndex_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByIndex_v2(
            [In] uint index,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByIndex_v2(
                index,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
             string pciBusId,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByPciBusId_v2"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByPciBusId_v2(
            [In] string pciBusId,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByPciBusId(
            [In] string pciBusId,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByPciBusId_v2(
                pciBusId,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleBySerial(
             string serial,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleBySerial"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleBySerial(
            [In] string serial,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleBySerial(
                serial,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , StringMarshalling = StringMarshalling.Utf8
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetHandleByUUID(
             string uuid,
             out IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetHandleByUUID"
            , CharSet = CharSet.Ansi
            , BestFitMapping = false
            , ThrowOnUnmappableChar = true
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceGetHandleByUUID(
            [In] string uuid,
            [Out] out IntPtr device) =>
            nvmlDeviceGetHandleByUUID(
                uuid,
                out device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetIndex(
             IntPtr device,
             out uint index);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index);

        #endif
        public sealed override NvmlReturn DeviceGetIndex(
            [In] IntPtr device,
            [Out] out uint index) =>
            nvmlDeviceGetIndex(
                device,
                out index);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
             IntPtr device,
             out uint checksum);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomConfigurationChecksum"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum);

        #endif
        public sealed override NvmlReturn DeviceGetInforomConfigurationChecksum(
            [In] IntPtr device,
            [Out] out uint checksum) =>
            nvmlDeviceGetInforomConfigurationChecksum(
                device,
                out checksum);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomImageVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomImageVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomImageVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomImageVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomImageVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetInforomVersion(
             IntPtr device,
             NvmlInforomObject inforomObject,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetInforomVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetInforomVersion(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetInforomVersion_Interop(
            [In] IntPtr device,
            [In] NvmlInforomObject inforomObject,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetInforomVersion(
                device,
                inforomObject,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxClockInfo(
             IntPtr device,
             NvmlClockType type,
             out uint clock);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxClockInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock);

        #endif
        public sealed override NvmlReturn DeviceGetMaxClockInfo(
            [In] IntPtr device,
            [In] NvmlClockType type,
            [Out] out uint clock) =>
            nvmlDeviceGetMaxClockInfo(
                device,
                type,
                out clock);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
             IntPtr device,
             NvmlClockType clockType,
             out uint clockMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxCustomerBoostClock"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz);

        #endif
        public sealed override NvmlReturn DeviceGetMaxCustomerBoostClock(
            [In] IntPtr device,
            [In] NvmlClockType clockType,
            [Out] out uint clockMHz) =>
            nvmlDeviceGetMaxCustomerBoostClock(
                device,
                clockType,
                out clockMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
             IntPtr device,
             out uint maxLinkGen);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkGeneration"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkGeneration(
            [In] IntPtr device,
            [Out] out uint maxLinkGen) =>
            nvmlDeviceGetMaxPcieLinkGeneration(
                device,
                out maxLinkGen);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
             IntPtr device,
             out uint maxLinkWidth);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMaxPcieLinkWidth"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth);

        #endif
        public sealed override NvmlReturn DeviceGetMaxPcieLinkWidth(
            [In] IntPtr device,
            [Out] out uint maxLinkWidth) =>
            nvmlDeviceGetMaxPcieLinkWidth(
                device,
                out maxLinkWidth);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             NvmlMemoryLocation locationType,
             out ulong count);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryErrorCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryErrorCounter(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [In] NvmlMemoryLocation locationType,
            [Out] out ulong count) =>
            nvmlDeviceGetMemoryErrorCounter(
                device,
                errorType,
                counterType,
                locationType,
                out count);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMemoryInfo(
             IntPtr device,
             out NvmlMemory memory);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory);

        #endif
        public sealed override NvmlReturn DeviceGetMemoryInfo(
            [In] IntPtr device,
            [Out] out NvmlMemory memory) =>
            nvmlDeviceGetMemoryInfo(
                device,
                out memory);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMinorNumber(
             IntPtr device,
             out uint minorNumber);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMinorNumber"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber);

        #endif
        public sealed override NvmlReturn DeviceGetMinorNumber(
            [In] IntPtr device,
            [Out] out uint minorNumber) =>
            nvmlDeviceGetMinorNumber(
                device,
                out minorNumber);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
             IntPtr device,
             out uint multiGpuBool);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMultiGpuBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool);

        #endif
        public sealed override NvmlReturn DeviceGetMultiGpuBoard(
            [In] IntPtr device,
            [Out] out uint multiGpuBool) =>
            nvmlDeviceGetMultiGpuBoard(
                device,
                out multiGpuBool);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetName(
             IntPtr device,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetName(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetName_Interop(
            [In] IntPtr device,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlDeviceGetName(
                device,
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetP2PStatus(
             IntPtr device1,
             IntPtr device2,
             NvmlGpuP2PCapsIndex p2pIndex,
             out NvmlGpuP2PStatus p2pStatus);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetP2PStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus);

        #endif
        public sealed override NvmlReturn DeviceGetP2PStatus(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [In] NvmlGpuP2PCapsIndex p2pIndex,
            [Out] out NvmlGpuP2PStatus p2pStatus) =>
            nvmlDeviceGetP2PStatus(
                device1,
                device2,
                p2pIndex,
                out p2pStatus);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPciInfo_v3(
             IntPtr device,
             out NvmlPciInfo_Interop pci);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPciInfo_v3"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPciInfo_v3(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci);

        #endif
        public sealed override NvmlReturn DeviceGetPciInfo_Interop(
            [In] IntPtr device,
            [Out] out NvmlPciInfo_Interop pci) =>
            nvmlDeviceGetPciInfo_v3(
                device,
                out pci);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
             IntPtr device,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieReplayCounter"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieReplayCounter(
            [In] IntPtr device,
            [Out] out uint value) =>
            nvmlDeviceGetPcieReplayCounter(
                device,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPcieThroughput(
             IntPtr device,
             NvmlPcieUtilCounter counter,
             out uint value);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPcieThroughput"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value);

        #endif
        public sealed override NvmlReturn DeviceGetPcieThroughput(
            [In] IntPtr device,
            [In] NvmlPcieUtilCounter counter,
            [Out] out uint value) =>
            nvmlDeviceGetPcieThroughput(
                device,
                counter,
                out value);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPerformanceState(
             IntPtr device,
             out NvmlPstates state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPerformanceState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state);

        #endif
        public sealed override NvmlReturn DeviceGetPerformanceState(
            [In] IntPtr device,
            [Out] out NvmlPstates state) =>
            nvmlDeviceGetPerformanceState(
                device,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPersistenceMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPersistenceMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPersistenceMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPersistenceMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
             IntPtr device,
             out uint defaultLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementDefaultLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementDefaultLimit(
            [In] IntPtr device,
            [Out] out uint defaultLimit) =>
            nvmlDeviceGetPowerManagementDefaultLimit(
                device,
                out defaultLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
             IntPtr device,
             out uint limit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimit"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimit(
            [In] IntPtr device,
            [Out] out uint limit) =>
            nvmlDeviceGetPowerManagementLimit(
                device,
                out limit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
             IntPtr device,
             out uint minLimit,
             out uint maxLimit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementLimitConstraints"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementLimitConstraints(
            [In] IntPtr device,
            [Out] out uint minLimit,
            [Out] out uint maxLimit) =>
            nvmlDeviceGetPowerManagementLimitConstraints(
                device,
                out minLimit,
                out maxLimit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerManagementMode(
             IntPtr device,
             out NvmlEnableState mode);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerManagementMode"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode);

        #endif
        public sealed override NvmlReturn DeviceGetPowerManagementMode(
            [In] IntPtr device,
            [Out] out NvmlEnableState mode) =>
            nvmlDeviceGetPowerManagementMode(
                device,
                out mode);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerState(
             IntPtr device,
             out NvmlPstates pState);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState);

        #endif
        public sealed override NvmlReturn DeviceGetPowerState(
            [In] IntPtr device,
            [Out] out NvmlPstates pState) =>
            nvmlDeviceGetPowerState(
                device,
                out pState);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetPowerUsage(
             IntPtr device,
             out uint power);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetPowerUsage"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power);

        #endif
        public sealed override NvmlReturn DeviceGetPowerUsage(
            [In] IntPtr device,
            [Out] out uint power) =>
            nvmlDeviceGetPowerUsage(
                device,
                out power);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRemappedRows(
             IntPtr device,
             out uint corrRows,
             out uint uncRows,
             out uint isPending,
             out uint failureOccurred);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRemappedRows"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred);

        #endif
        public sealed override NvmlReturn DeviceGetRemappedRows(
            [In] IntPtr device,
            [Out] out uint corrRows,
            [Out] out uint uncRows,
            [Out] out uint isPending,
            [Out] out uint failureOccurred) =>
            nvmlDeviceGetRemappedRows(
                device,
                out corrRows,
                out uncRows,
                out isPending,
                out failureOccurred);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses) =>
            nvmlDeviceGetRetiredPages(
                device,
                cause,
                ref pageCount,
                addresses);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
             IntPtr device,
             out NvmlEnableState isPending);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPagesPendingStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending);

        #endif
        public sealed override NvmlReturn DeviceGetRetiredPagesPendingStatus(
            [In] IntPtr device,
            [Out] out NvmlEnableState isPending) =>
            nvmlDeviceGetRetiredPagesPendingStatus(
                device,
                out isPending);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
             IntPtr device,
             NvmlPageRetirementCause cause,
             ref uint pageCount,
             ulong* addresses,
             ulong* timestamps);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetRetiredPages_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetRetiredPages_v2(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetRetiredPages_v2_Interop(
            [In] IntPtr device,
            [In] NvmlPageRetirementCause cause,
            [In] ref uint pageCount,
            [In] ulong* addresses,
            [In] ulong* timestamps) =>
            nvmlDeviceGetRetiredPages_v2(
                device,
                cause,
                ref pageCount,
                addresses,
                timestamps);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSamples(
             IntPtr device,
             NvmlSamplingType type,
             ulong lastSeenTimeStamp,
             out NvmlValueType sampleValType,
             ref uint sampleCount,
             NvmlSample* samples);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSamples"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSamples(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSamples_Interop(
            [In] IntPtr device,
            [In] NvmlSamplingType type,
            [In] ulong lastSeenTimeStamp,
            [Out] out NvmlValueType sampleValType,
            [In] ref uint sampleCount,
            [In] NvmlSample* samples) =>
            nvmlDeviceGetSamples(
                device,
                type,
                lastSeenTimeStamp,
                out sampleValType,
                ref sampleCount,
                samples);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSerial(
             IntPtr device,
             IntPtr serial,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSerial"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSerial(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSerial_Interop(
            [In] IntPtr device,
            [In] IntPtr serial,
            [In] uint length) =>
            nvmlDeviceGetSerial(
                device,
                serial,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
             IntPtr device,
             out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedClocksThrottleReasons"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons);

        #endif
        public sealed override NvmlReturn DeviceGetSupportedClocksThrottleReasons(
            [In] IntPtr device,
            [Out] out NvmlClocksThrottleReasons supportedClocksThrottleReasons) =>
            nvmlDeviceGetSupportedClocksThrottleReasons(
                device,
                out supportedClocksThrottleReasons);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
             IntPtr device,
             uint memoryClockMHz,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedGraphicsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedGraphicsClocks(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedGraphicsClocks_Interop(
            [In] IntPtr device,
            [In] uint memoryClockMHz,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedGraphicsClocks(
                device,
                memoryClockMHz,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
             IntPtr device,
             ref uint count,
             uint* clocksMHz);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetSupportedMemoryClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetSupportedMemoryClocks(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetSupportedMemoryClocks_Interop(
            [In] IntPtr device,
            [In] ref uint count,
            [In] uint* clocksMHz) =>
            nvmlDeviceGetSupportedMemoryClocks(
                device,
                ref count,
                clocksMHz);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperature(
             IntPtr device,
             NvmlTemperatureSensors sensorType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperature(
            [In] IntPtr device,
            [In] NvmlTemperatureSensors sensorType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperature(
                device,
                sensorType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
             IntPtr device,
             NvmlTemperatureThresholds thresholdType,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTemperatureThreshold"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn DeviceGetTemperatureThreshold(
            [In] IntPtr device,
            [In] NvmlTemperatureThresholds thresholdType,
            [Out] out uint temp) =>
            nvmlDeviceGetTemperatureThreshold(
                device,
                thresholdType,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
             IntPtr device1,
             IntPtr device2,
             out NvmlGpuTopologyLevel pathInfo);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyCommonAncestor"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo);

        #endif
        public sealed override NvmlReturn DeviceGetTopologyCommonAncestor(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out NvmlGpuTopologyLevel pathInfo) =>
            nvmlDeviceGetTopologyCommonAncestor(
                device1,
                device2,
                out pathInfo);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
             IntPtr device,
             NvmlGpuTopologyLevel level,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTopologyNearestGpus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetTopologyNearestGpus(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetTopologyNearestGpus_Interop(
            [In] IntPtr device,
            [In] NvmlGpuTopologyLevel level,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlDeviceGetTopologyNearestGpus(
                device,
                level,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEccErrors(
             IntPtr device,
             NvmlMemoryErrorType errorType,
             NvmlEccCounterType counterType,
             out ulong eccCounts);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEccErrors"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEccErrors(
            [In] IntPtr device,
            [In] NvmlMemoryErrorType errorType,
            [In] NvmlEccCounterType counterType,
            [Out] out ulong eccCounts) =>
            nvmlDeviceGetTotalEccErrors(
                device,
                errorType,
                counterType,
                out eccCounts);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
             IntPtr device,
             out ulong energy);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetTotalEnergyConsumption"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy);

        #endif
        public sealed override NvmlReturn DeviceGetTotalEnergyConsumption(
            [In] IntPtr device,
            [Out] out ulong energy) =>
            nvmlDeviceGetTotalEnergyConsumption(
                device,
                out energy);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetUUID(
             IntPtr device,
             IntPtr uuid,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetUUID(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetUUID_Interop(
            [In] IntPtr device,
            [In] IntPtr uuid,
            [In] uint length) =>
            nvmlDeviceGetUUID(
                device,
                uuid,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetUtilizationRates(
             IntPtr device,
             out NvmlUtilization utilization);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetUtilizationRates"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization);

        #endif
        public sealed override NvmlReturn DeviceGetUtilizationRates(
            [In] IntPtr device,
            [Out] out NvmlUtilization utilization) =>
            nvmlDeviceGetUtilizationRates(
                device,
                out utilization);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetVbiosVersion(
             IntPtr device,
             IntPtr version,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetVbiosVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetVbiosVersion(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetVbiosVersion_Interop(
            [In] IntPtr device,
            [In] IntPtr version,
            [In] uint length) =>
            nvmlDeviceGetVbiosVersion(
                device,
                version,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceGetViolationStatus(
             IntPtr device,
             NvmlPerfPolicyType perfPolicyType,
             out NvmlViolationTime violTime);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetViolationStatus"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime);

        #endif
        public sealed override NvmlReturn DeviceGetViolationStatus(
            [In] IntPtr device,
            [In] NvmlPerfPolicyType perfPolicyType,
            [Out] out NvmlViolationTime violTime) =>
            nvmlDeviceGetViolationStatus(
                device,
                perfPolicyType,
                out violTime);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceOnSameBoard(
             IntPtr device1,
             IntPtr device2,
             out int onSameBoard);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceOnSameBoard"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard);

        #endif
        public sealed override NvmlReturn DeviceOnSameBoard(
            [In] IntPtr device1,
            [In] IntPtr device2,
            [Out] out int onSameBoard) =>
            nvmlDeviceOnSameBoard(
                device1,
                device2,
                out onSameBoard);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceResetApplicationsClocks(
             IntPtr device1);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceResetApplicationsClocks"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceResetApplicationsClocks(
            [In] IntPtr device1);

        #endif
        public sealed override NvmlReturn DeviceResetApplicationsClocks(
            [In] IntPtr device1) =>
            nvmlDeviceResetApplicationsClocks(
                device1);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled);

        #endif
        public sealed override NvmlReturn DeviceSetAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled) =>
            nvmlDeviceSetAutoBoostedClocksEnabled(
                device,
                enabled);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
             IntPtr device,
             NvmlEnableState enabled,
             uint flags);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetDefaultAutoBoostedClocksEnabled"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags);

        #endif
        public sealed override NvmlReturn DeviceSetDefaultAutoBoostedClocksEnabled(
            [In] IntPtr device,
            [In] NvmlEnableState enabled,
            [In] uint flags) =>
            nvmlDeviceSetDefaultAutoBoostedClocksEnabled(
                device,
                enabled,
                flags);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceValidateInforom(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceValidateInforom"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceValidateInforom(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceValidateInforom(
            [In] IntPtr device) =>
            nvmlDeviceValidateInforom(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetTopologyGpuSet(
             uint cpuNumber,
             ref uint count,
             IntPtr* deviceArray);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetTopologyGpuSet"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetTopologyGpuSet(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray);

        #endif
        public unsafe sealed override NvmlReturn SystemGetTopologyGpuSet_Interop(
            [In] uint cpuNumber,
            [In] ref uint count,
            [In] IntPtr* deviceArray) =>
            nvmlSystemGetTopologyGpuSet(
                cpuNumber,
                ref count,
                deviceArray);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
             uint vgpuInstance,
             IntPtr mdevUuid,
             uint size);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlVgpuInstanceGetMdevUUID"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlVgpuInstanceGetMdevUUID(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size);

        #endif
        public unsafe sealed override NvmlReturn VgpuInstanceGetMdevUUID_Interop(
            [In] uint vgpuInstance,
            [In] IntPtr mdevUuid,
            [In] uint size) =>
            nvmlVgpuInstanceGetMdevUUID(
                vgpuInstance,
                mdevUuid,
                size);

        #endregion

        #region Device Queries - CPU and Memory Affinity

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceClearCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceClearCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceClearCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceClearCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceClearCpuAffinity(
                device);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinity(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinity(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinity_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet) =>
            nvmlDeviceGetCpuAffinity(
                device,
                cpuSetSize,
                cpuSet);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
             IntPtr device,
             uint cpuSetSize,
             ulong* cpuSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetCpuAffinityWithinScope"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetCpuAffinityWithinScope(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetCpuAffinityWithinScope_Interop(
            [In] IntPtr device,
            [In] uint cpuSetSize,
            [In] ulong* cpuSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetCpuAffinityWithinScope(
                device,
                cpuSetSize,
                cpuSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlDeviceGetMemoryAffinity(
             IntPtr device,
             uint nodeSetSize,
             ulong* nodeSet,
             NvmlAffinityScope scope);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceGetMemoryAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlDeviceGetMemoryAffinity(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope);

        #endif
        public unsafe sealed override NvmlReturn DeviceGetMemoryAffinity_Interop(
            [In] IntPtr device,
            [In] uint nodeSetSize,
            [In] ulong* nodeSet,
            [In] NvmlAffinityScope scope) =>
            nvmlDeviceGetMemoryAffinity(
                device,
                nodeSetSize,
                nodeSet,
                scope);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlDeviceSetCpuAffinity(
             IntPtr device);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlDeviceSetCpuAffinity"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlDeviceSetCpuAffinity(
            [In] IntPtr device);

        #endif
        public sealed override NvmlReturn DeviceSetCpuAffinity(
            [In] IntPtr device) =>
            nvmlDeviceSetCpuAffinity(
                device);

        #endregion

        #region System Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
             out int cudaDriverVersion);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetCudaDriverVersion_v2"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetCudaDriverVersion_v2(
            [Out] out int cudaDriverVersion);

        #endif
        public sealed override NvmlReturn SystemGetCudaDriverVersion_v2_Interop(
            [Out] out int cudaDriverVersion) =>
            nvmlSystemGetCudaDriverVersion_v2(
                out cudaDriverVersion);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetDriverVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetDriverVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetDriverVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetDriverVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetDriverVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetNVMLVersion(
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetNVMLVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetNVMLVersion(
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetNVMLVersion_Interop(
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetNVMLVersion(
                name,
                length);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlSystemGetProcessName(
             uint pid,
             IntPtr name,
             uint length);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetProcessName"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlSystemGetProcessName(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length);

        #endif
        public sealed override NvmlReturn SystemGetProcessName_Interop(
            [In] uint pid,
            [In] IntPtr name,
            [In] uint length) =>
            nvmlSystemGetProcessName(
                pid,
                name,
                length);

        #endregion

        #region Unit Queries

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlSystemGetHicVersion(
             ref uint hwbcCount,
             NvmlHwbcEntry_Interop* hwbcEntries);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlSystemGetHicVersion"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlSystemGetHicVersion(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries);

        #endif
        public unsafe sealed override NvmlReturn SystemGetHicVersion_Interop(
            [In] ref uint hwbcCount,
            [In] NvmlHwbcEntry_Interop* hwbcEntries) =>
            nvmlSystemGetHicVersion(
                ref hwbcCount,
                hwbcEntries);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetCount(
             out uint unitCount);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetCount"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetCount(
            [Out] out uint unitCount);

        #endif
        public sealed override NvmlReturn UnitGetCount(
            [Out] out uint unitCount) =>
            nvmlUnitGetCount(
                out unitCount);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static partial
         NvmlReturn nvmlUnitGetDevices(
             IntPtr unit,
             ref uint deviceCount,
             IntPtr* devices);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetDevices"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal unsafe static extern
         NvmlReturn nvmlUnitGetDevices(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices);

        #endif
        public unsafe sealed override NvmlReturn UnitGetDevices_Interop(
            [In] IntPtr unit,
            [In] ref uint deviceCount,
            [In] IntPtr* devices) =>
            nvmlUnitGetDevices(
                unit,
                ref deviceCount,
                devices);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetFanSpeedInfo(
             IntPtr unit,
             out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetFanSpeedInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetFanSpeedInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds);

        #endif
        public sealed override NvmlReturn UnitGetFanSpeedInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitFanSpeeds_Interop fanSpeeds) =>
            nvmlUnitGetFanSpeedInfo(
                unit,
                out fanSpeeds);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetHandleByIndex(
             uint index,
             out IntPtr unit);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetHandleByIndex"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit);

        #endif
        public sealed override NvmlReturn UnitGetHandleByIndex(
            [In] uint index,
            [Out] out IntPtr unit) =>
            nvmlUnitGetHandleByIndex(
                index,
                out unit);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetLedState(
             IntPtr unit,
             out NvmlLedState_Interop state);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetLedState"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetLedState(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state);

        #endif
        public sealed override NvmlReturn UnitGetLedState_Interop(
            [In] IntPtr unit,
            [Out] out NvmlLedState_Interop state) =>
            nvmlUnitGetLedState(
                unit,
                out state);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetPsuInfo(
             IntPtr unit,
             out NvmlPSUInfo_Interop psu);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetPsuInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetPsuInfo(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu);

        #endif
        public sealed override NvmlReturn UnitGetPsuInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlPSUInfo_Interop psu) =>
            nvmlUnitGetPsuInfo(
                unit,
                out psu);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetTemperature(
             IntPtr unit,
             uint type,
             out uint temp);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetTemperature"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp);

        #endif
        public sealed override NvmlReturn UnitGetTemperature(
            [In] IntPtr unit,
            [In] uint type,
            [Out] out uint temp) =>
            nvmlUnitGetTemperature(
                unit,
                type,
                out temp);

        #if NET7_0_OR_GREATER
        [LibraryImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static partial
         NvmlReturn nvmlUnitGetUnitInfo(
             IntPtr unit,
             out NvmlUnitInfo_Interop info);

        #else
        [DllImport(LibName,
            EntryPoint = "nvmlUnitGetUnitInfo"
            )]
        [DefaultDllImportSearchPaths(DllImportSearchPath.LegacyBehavior)]
        internal static extern
         NvmlReturn nvmlUnitGetUnitInfo(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info);

        #endif
        public sealed override NvmlReturn UnitGetUnitInfo_Interop(
            [In] IntPtr unit,
            [Out] out NvmlUnitInfo_Interop info) =>
            nvmlUnitGetUnitInfo(
                unit,
                out info);

        #endregion

    }

}


#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member