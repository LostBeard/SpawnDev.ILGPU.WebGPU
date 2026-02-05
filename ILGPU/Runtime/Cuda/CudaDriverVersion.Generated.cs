// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CudaDriverVersion.Generated.tt/CudaDriverVersion.Generated.cs
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
//                           Copyright (c) 2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CudaVersions.ttinclude
//
// This file is part of ILGPU and is distributed under the University of Illinois Open
// Source License. See LICENSE.txt for details.
// ---------------------------------------------------------------------------------------


using System.Collections.Generic;

namespace ILGPU.Runtime.Cuda
{
    partial class CudaDriverVersionUtils
    {
        #region Static

        /// <summary>
        /// Maps PTX architecture to their corresponding minimum CUDA driver version.
        /// </summary>
        private static readonly Dictionary<
            CudaArchitecture,
            CudaDriverVersion> ArchitectureLookup =
            new Dictionary<CudaArchitecture, CudaDriverVersion>
        {
            {
                CudaArchitecture.SM_10,
                CudaDriverVersion.FromMajorMinor(1, 0)
            },
            {
                CudaArchitecture.SM_11,
                CudaDriverVersion.FromMajorMinor(1, 0)
            },
            {
                CudaArchitecture.SM_12,
                CudaDriverVersion.FromMajorMinor(2, 0)
            },
            {
                CudaArchitecture.SM_13,
                CudaDriverVersion.FromMajorMinor(2, 0)
            },
            {
                CudaArchitecture.SM_20,
                CudaDriverVersion.FromMajorMinor(3, 0)
            },
            {
                CudaArchitecture.SM_30,
                CudaDriverVersion.FromMajorMinor(4, 2)
            },
            {
                CudaArchitecture.SM_32,
                CudaDriverVersion.FromMajorMinor(6, 0)
            },
            {
                CudaArchitecture.SM_35,
                CudaDriverVersion.FromMajorMinor(5, 0)
            },
            {
                CudaArchitecture.SM_37,
                CudaDriverVersion.FromMajorMinor(6, 5)
            },
            {
                CudaArchitecture.SM_50,
                CudaDriverVersion.FromMajorMinor(6, 0)
            },
            {
                CudaArchitecture.SM_52,
                CudaDriverVersion.FromMajorMinor(6, 5)
            },
            {
                CudaArchitecture.SM_53,
                CudaDriverVersion.FromMajorMinor(7, 0)
            },
            {
                CudaArchitecture.SM_60,
                CudaDriverVersion.FromMajorMinor(8, 0)
            },
            {
                CudaArchitecture.SM_61,
                CudaDriverVersion.FromMajorMinor(8, 0)
            },
            {
                CudaArchitecture.SM_62,
                CudaDriverVersion.FromMajorMinor(8, 0)
            },
            {
                CudaArchitecture.SM_70,
                CudaDriverVersion.FromMajorMinor(9, 0)
            },
            {
                CudaArchitecture.SM_72,
                CudaDriverVersion.FromMajorMinor(9, 1)
            },
            {
                CudaArchitecture.SM_75,
                CudaDriverVersion.FromMajorMinor(10, 0)
            },
            {
                CudaArchitecture.SM_80,
                CudaDriverVersion.FromMajorMinor(11, 0)
            },
            {
                CudaArchitecture.SM_86,
                CudaDriverVersion.FromMajorMinor(11, 1)
            },
            {
                CudaArchitecture.SM_87,
                CudaDriverVersion.FromMajorMinor(11, 4)
            },
            {
                CudaArchitecture.SM_89,
                CudaDriverVersion.FromMajorMinor(11, 8)
            },
            {
                CudaArchitecture.SM_90,
                CudaDriverVersion.FromMajorMinor(11, 8)
            },
            {
                CudaArchitecture.SM_100,
                CudaDriverVersion.FromMajorMinor(12, 7)
            },
            {
                CudaArchitecture.SM_101,
                CudaDriverVersion.FromMajorMinor(12, 7)
            },
            {
                CudaArchitecture.SM_120,
                CudaDriverVersion.FromMajorMinor(12, 8)
            },
        };

        /// <summary>
        /// Maps PTX ISA to their corresponding minimum CUDA driver version.
        /// </summary>
        internal static readonly Dictionary<
            CudaInstructionSet,
            CudaDriverVersion> InstructionSetLookup =
            new Dictionary<CudaInstructionSet, CudaDriverVersion>
        {
            {
                CudaInstructionSet.ISA_10,
                CudaDriverVersion.FromMajorMinor(1, 0)
            },
            {
                CudaInstructionSet.ISA_11,
                CudaDriverVersion.FromMajorMinor(1, 1)
            },
            {
                CudaInstructionSet.ISA_12,
                CudaDriverVersion.FromMajorMinor(2, 0)
            },
            {
                CudaInstructionSet.ISA_13,
                CudaDriverVersion.FromMajorMinor(2, 1)
            },
            {
                CudaInstructionSet.ISA_14,
                CudaDriverVersion.FromMajorMinor(2, 2)
            },
            {
                CudaInstructionSet.ISA_20,
                CudaDriverVersion.FromMajorMinor(3, 0)
            },
            {
                CudaInstructionSet.ISA_21,
                CudaDriverVersion.FromMajorMinor(3, 1)
            },
            {
                CudaInstructionSet.ISA_22,
                CudaDriverVersion.FromMajorMinor(3, 2)
            },
            {
                CudaInstructionSet.ISA_23,
                CudaDriverVersion.FromMajorMinor(4, 0)
            },
            {
                CudaInstructionSet.ISA_30,
                CudaDriverVersion.FromMajorMinor(4, 1)
            },
            {
                CudaInstructionSet.ISA_31,
                CudaDriverVersion.FromMajorMinor(5, 0)
            },
            {
                CudaInstructionSet.ISA_32,
                CudaDriverVersion.FromMajorMinor(5, 5)
            },
            {
                CudaInstructionSet.ISA_40,
                CudaDriverVersion.FromMajorMinor(6, 0)
            },
            {
                CudaInstructionSet.ISA_41,
                CudaDriverVersion.FromMajorMinor(6, 5)
            },
            {
                CudaInstructionSet.ISA_42,
                CudaDriverVersion.FromMajorMinor(7, 0)
            },
            {
                CudaInstructionSet.ISA_43,
                CudaDriverVersion.FromMajorMinor(7, 5)
            },
            {
                CudaInstructionSet.ISA_50,
                CudaDriverVersion.FromMajorMinor(8, 0)
            },
            {
                CudaInstructionSet.ISA_60,
                CudaDriverVersion.FromMajorMinor(9, 0)
            },
            {
                CudaInstructionSet.ISA_61,
                CudaDriverVersion.FromMajorMinor(9, 1)
            },
            {
                CudaInstructionSet.ISA_62,
                CudaDriverVersion.FromMajorMinor(9, 2)
            },
            {
                CudaInstructionSet.ISA_63,
                CudaDriverVersion.FromMajorMinor(10, 0)
            },
            {
                CudaInstructionSet.ISA_64,
                CudaDriverVersion.FromMajorMinor(10, 1)
            },
            {
                CudaInstructionSet.ISA_65,
                CudaDriverVersion.FromMajorMinor(10, 2)
            },
            {
                CudaInstructionSet.ISA_70,
                CudaDriverVersion.FromMajorMinor(11, 0)
            },
            {
                CudaInstructionSet.ISA_71,
                CudaDriverVersion.FromMajorMinor(11, 1)
            },
            {
                CudaInstructionSet.ISA_72,
                CudaDriverVersion.FromMajorMinor(11, 2)
            },
            {
                CudaInstructionSet.ISA_73,
                CudaDriverVersion.FromMajorMinor(11, 3)
            },
            {
                CudaInstructionSet.ISA_74,
                CudaDriverVersion.FromMajorMinor(11, 4)
            },
            {
                CudaInstructionSet.ISA_75,
                CudaDriverVersion.FromMajorMinor(11, 5)
            },
            {
                CudaInstructionSet.ISA_76,
                CudaDriverVersion.FromMajorMinor(11, 6)
            },
            {
                CudaInstructionSet.ISA_77,
                CudaDriverVersion.FromMajorMinor(11, 7)
            },
            {
                CudaInstructionSet.ISA_78,
                CudaDriverVersion.FromMajorMinor(11, 8)
            },
            {
                CudaInstructionSet.ISA_80,
                CudaDriverVersion.FromMajorMinor(12, 0)
            },
            {
                CudaInstructionSet.ISA_81,
                CudaDriverVersion.FromMajorMinor(12, 1)
            },
            {
                CudaInstructionSet.ISA_82,
                CudaDriverVersion.FromMajorMinor(12, 2)
            },
            {
                CudaInstructionSet.ISA_83,
                CudaDriverVersion.FromMajorMinor(12, 3)
            },
            {
                CudaInstructionSet.ISA_84,
                CudaDriverVersion.FromMajorMinor(12, 4)
            },
            {
                CudaInstructionSet.ISA_85,
                CudaDriverVersion.FromMajorMinor(12, 5)
            },
            {
                CudaInstructionSet.ISA_86,
                CudaDriverVersion.FromMajorMinor(12, 7)
            },
            {
                CudaInstructionSet.ISA_87,
                CudaDriverVersion.FromMajorMinor(12, 8)
            },
        };


        #endregion
    }
}