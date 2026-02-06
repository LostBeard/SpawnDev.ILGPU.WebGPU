// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2019-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: ILContext.Generated.tt/ILContext.Generated.cs
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------
//                                   ILGPU Algorithms
//                        Copyright (c) 2020-2021 ILGPU Project
//                                    www.ilgpu.net
//
// File: TypeInformation.ttinclude
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

using ILGPU.IR.Intrinsics;

namespace ILGPU.Algorithms.IL
{
    partial class ILContext
    {
        public static void EnableILAlgorithms(IntrinsicImplementationManager manager)
        {
            // Register group intrinsics
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "Reduce");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "AllReduce");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "ExclusiveScan");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "InclusiveScan");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "ExclusiveScanWithBoundaries");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "InclusiveScanWithBoundaries");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "ExclusiveScanNextIteration");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.GroupExtensionsType,
                CPUGroupExtensionsType,
                "InclusiveScanNextIteration");

            // Register warp intrinsics
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.WarpExtensionsType,
                CPUWarpExtensionsType,
                "Reduce");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.WarpExtensionsType,
                CPUWarpExtensionsType,
                "AllReduce");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.WarpExtensionsType,
                CPUWarpExtensionsType,
                "ExclusiveScan");
            RegisterIntrinsicMapping(
                manager,
                AlgorithmContext.WarpExtensionsType,
                CPUWarpExtensionsType,
                "InclusiveScan");
        }
    }
}