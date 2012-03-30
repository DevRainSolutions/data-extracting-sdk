// ============================================================================
// <copyright file="IPersistStreamInit.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System;
    using System.Runtime.InteropServices;    
    public enum HRESULT : uint
    {
        S_OK = 0,
        S_FALSE = 1,
        E_PENDING = 2147483658,
        E_NOTIMPL = 2147500033,
        E_NOINTERFACE = 2147500034,
        E_POINTER = 2147500035,
        E_ABORT = 2147500036,
        E_FAIL = 2147500037,
        E_UNEXPECTED = 2147549183,
        CLASS_E_NOAGGREGATION = 2147746064,
        CLASS_E_CLASSNOTAVAILABLE = 2147746065,
        CLASS_E_NOTLICENSED = 2147746066,
        E_ACCESSDENIED = 2147942405,
        E_HANDLE = 2147942406,
        E_OUTOFMEMORY = 2147942414,
        E_INVALIDARG = 2147942487
    }

    [
     ComVisible(true), ComImport(),
     Guid("7FD52380-4E07-101B-AE2D-08002B2EC713"),
     InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)
    ]
    public interface IPersistStreamInit
    {
        void GetClassId([In, Out] ref Guid pClassID);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();
        void Load([In, MarshalAs(UnmanagedType.Interface)] UCOMIStream pstm);
        void Save([In, MarshalAs(UnmanagedType.Interface)] UCOMIStream pstm, [In, MarshalAs(UnmanagedType.I4)] int fClearDirty);
        void GetSizeMax([Out, MarshalAs(UnmanagedType.LPArray)] long pcbSize);
        void InitNew();
    }

}

