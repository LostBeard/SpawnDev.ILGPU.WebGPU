// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CudaInstructionSet.Generated.tt/CudaInstructionSet.Generated.cs
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


namespace ILGPU.Runtime.Cuda
{
    partial struct CudaInstructionSet
    {
        #region Constants

        /// <summary>
        /// The 1.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_10 =
            new CudaInstructionSet(1, 0);

        /// <summary>
        /// The 1.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_11 =
            new CudaInstructionSet(1, 1);

        /// <summary>
        /// The 1.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_12 =
            new CudaInstructionSet(1, 2);

        /// <summary>
        /// The 1.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_13 =
            new CudaInstructionSet(1, 3);

        /// <summary>
        /// The 1.4 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_14 =
            new CudaInstructionSet(1, 4);

        /// <summary>
        /// The 2.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_20 =
            new CudaInstructionSet(2, 0);

        /// <summary>
        /// The 2.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_21 =
            new CudaInstructionSet(2, 1);

        /// <summary>
        /// The 2.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_22 =
            new CudaInstructionSet(2, 2);

        /// <summary>
        /// The 2.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_23 =
            new CudaInstructionSet(2, 3);

        /// <summary>
        /// The 3.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_30 =
            new CudaInstructionSet(3, 0);

        /// <summary>
        /// The 3.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_31 =
            new CudaInstructionSet(3, 1);

        /// <summary>
        /// The 3.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_32 =
            new CudaInstructionSet(3, 2);

        /// <summary>
        /// The 4.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_40 =
            new CudaInstructionSet(4, 0);

        /// <summary>
        /// The 4.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_41 =
            new CudaInstructionSet(4, 1);

        /// <summary>
        /// The 4.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_42 =
            new CudaInstructionSet(4, 2);

        /// <summary>
        /// The 4.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_43 =
            new CudaInstructionSet(4, 3);

        /// <summary>
        /// The 5.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_50 =
            new CudaInstructionSet(5, 0);

        /// <summary>
        /// The 6.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_60 =
            new CudaInstructionSet(6, 0);

        /// <summary>
        /// The 6.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_61 =
            new CudaInstructionSet(6, 1);

        /// <summary>
        /// The 6.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_62 =
            new CudaInstructionSet(6, 2);

        /// <summary>
        /// The 6.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_63 =
            new CudaInstructionSet(6, 3);

        /// <summary>
        /// The 6.4 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_64 =
            new CudaInstructionSet(6, 4);

        /// <summary>
        /// The 6.5 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_65 =
            new CudaInstructionSet(6, 5);

        /// <summary>
        /// The 7.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_70 =
            new CudaInstructionSet(7, 0);

        /// <summary>
        /// The 7.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_71 =
            new CudaInstructionSet(7, 1);

        /// <summary>
        /// The 7.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_72 =
            new CudaInstructionSet(7, 2);

        /// <summary>
        /// The 7.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_73 =
            new CudaInstructionSet(7, 3);

        /// <summary>
        /// The 7.4 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_74 =
            new CudaInstructionSet(7, 4);

        /// <summary>
        /// The 7.5 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_75 =
            new CudaInstructionSet(7, 5);

        /// <summary>
        /// The 7.6 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_76 =
            new CudaInstructionSet(7, 6);

        /// <summary>
        /// The 7.7 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_77 =
            new CudaInstructionSet(7, 7);

        /// <summary>
        /// The 7.8 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_78 =
            new CudaInstructionSet(7, 8);

        /// <summary>
        /// The 8.0 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_80 =
            new CudaInstructionSet(8, 0);

        /// <summary>
        /// The 8.1 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_81 =
            new CudaInstructionSet(8, 1);

        /// <summary>
        /// The 8.2 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_82 =
            new CudaInstructionSet(8, 2);

        /// <summary>
        /// The 8.3 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_83 =
            new CudaInstructionSet(8, 3);

        /// <summary>
        /// The 8.4 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_84 =
            new CudaInstructionSet(8, 4);

        /// <summary>
        /// The 8.5 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_85 =
            new CudaInstructionSet(8, 5);

        /// <summary>
        /// The 8.6 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_86 =
            new CudaInstructionSet(8, 6);

        /// <summary>
        /// The 8.7 ISA.
        /// </summary>
        public static readonly CudaInstructionSet ISA_87 =
            new CudaInstructionSet(8, 7);

        #endregion
    }
}