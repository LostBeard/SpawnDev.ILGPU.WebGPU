// ---------------------------------------------------------------------------------------
//                                        ILGPU
//                           Copyright (c) 2023 ILGPU Project
//                                    www.ilgpu.net
//
// File: CudaArchitecture.Generated.tt/CudaArchitecture.Generated.cs
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
    partial struct CudaArchitecture
    {
        #region Constants

        /// <summary>
        /// The 1.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_10 =
            new CudaArchitecture(1, 0);

        /// <summary>
        /// The 1.1 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_11 =
            new CudaArchitecture(1, 1);

        /// <summary>
        /// The 1.2 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_12 =
            new CudaArchitecture(1, 2);

        /// <summary>
        /// The 1.3 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_13 =
            new CudaArchitecture(1, 3);

        /// <summary>
        /// The 2.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_20 =
            new CudaArchitecture(2, 0);

        /// <summary>
        /// The 3.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_30 =
            new CudaArchitecture(3, 0);

        /// <summary>
        /// The 3.2 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_32 =
            new CudaArchitecture(3, 2);

        /// <summary>
        /// The 3.5 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_35 =
            new CudaArchitecture(3, 5);

        /// <summary>
        /// The 3.7 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_37 =
            new CudaArchitecture(3, 7);

        /// <summary>
        /// The 5.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_50 =
            new CudaArchitecture(5, 0);

        /// <summary>
        /// The 5.2 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_52 =
            new CudaArchitecture(5, 2);

        /// <summary>
        /// The 5.3 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_53 =
            new CudaArchitecture(5, 3);

        /// <summary>
        /// The 6.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_60 =
            new CudaArchitecture(6, 0);

        /// <summary>
        /// The 6.1 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_61 =
            new CudaArchitecture(6, 1);

        /// <summary>
        /// The 6.2 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_62 =
            new CudaArchitecture(6, 2);

        /// <summary>
        /// The 7.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_70 =
            new CudaArchitecture(7, 0);

        /// <summary>
        /// The 7.2 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_72 =
            new CudaArchitecture(7, 2);

        /// <summary>
        /// The 7.5 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_75 =
            new CudaArchitecture(7, 5);

        /// <summary>
        /// The 8.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_80 =
            new CudaArchitecture(8, 0);

        /// <summary>
        /// The 8.6 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_86 =
            new CudaArchitecture(8, 6);

        /// <summary>
        /// The 8.7 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_87 =
            new CudaArchitecture(8, 7);

        /// <summary>
        /// The 8.9 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_89 =
            new CudaArchitecture(8, 9);

        /// <summary>
        /// The 9.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_90 =
            new CudaArchitecture(9, 0);

        /// <summary>
        /// The 10.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_100 =
            new CudaArchitecture(10, 0);

        /// <summary>
        /// The 10.1 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_101 =
            new CudaArchitecture(10, 1);

        /// <summary>
        /// The 12.0 architecture.
        /// </summary>
        public static readonly CudaArchitecture SM_120 =
            new CudaArchitecture(12, 0);

        #endregion
    }
}