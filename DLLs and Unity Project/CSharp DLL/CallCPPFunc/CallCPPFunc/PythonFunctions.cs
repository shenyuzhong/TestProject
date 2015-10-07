using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace GameMath
{
    public class PythonFunctions
    {
        // From C++ DLL
        [DllImport("PyCallFuncs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyCall(byte[] pyName, byte[] pyFunc, byte[] result, int varCount, byte[] Arg1 = null, byte[] Arg2 = null, byte[] Arg3 = null, byte[] Arg4 = null, byte[] Arg5 = null, byte[] Arg6 = null, byte[] Arg7 = null, byte[] Arg8 = null, byte[] Arg9 = null, byte[] Arg10 = null, byte[] Arg11 = null, byte[] Arg12 = null, byte[] Arg13 = null);

        [DllImport("PyCallFuncs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PyInit();

        [DllImport("PyCallFuncs", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PyFin();
    }
}
