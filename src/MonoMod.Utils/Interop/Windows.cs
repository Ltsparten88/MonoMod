using MonoMod.Backports;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MonoMod.Utils.Interop
{
    internal static unsafe class Windows
    {
        // Definitions copied from source.terrafx.dev

        [Conditional("NEVER")]
        [AttributeUsage(AttributeTargets.All)]
        private sealed class SetsLastSystemErrorAttribute : Attribute { }
        [Conditional("NEVER")]
        [AttributeUsage(AttributeTargets.All)]
        private sealed class NativeTypeNameAttribute : Attribute
        {
            public NativeTypeNameAttribute(string x) { }
        }


        [DllImport("kernel32", ExactSpelling = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern void GetSystemInfo([NativeTypeName("LPSYSTEM_INFO")] SYSTEM_INFO* lpSystemInfo);

        [DllImport("kernel32", ExactSpelling = true)]
        [SetsLastSystemError]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern void* GetModuleHandleW([NativeTypeName("LPCWSTR")] ushort* lpModuleName);

        [DllImport("kernel32", ExactSpelling = true)]
        [SetsLastSystemError]
        [return: NativeTypeName("FARPROC")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [NativeTypeName("LPCSTR")] sbyte* lpProcName);

        [DllImport("kernel32", ExactSpelling = true)]
        [SetsLastSystemError]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern void* LoadLibraryW([NativeTypeName("LPCWSTR")] ushort* lpLibFileName);

        [DllImport("kernel32", ExactSpelling = true)]
        [SetsLastSystemError]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int FreeLibrary(IntPtr hLibModule);

        [DllImport("kernel32", ExactSpelling = true)]
        [return: NativeTypeName("DWORD")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern uint GetLastError();

        public unsafe partial struct SYSTEM_INFO
        {
            [NativeTypeName("_SYSTEM_INFO::(anonymous union at C:/Program Files (x86)/Windows Kits/10/include/10.0.22621.0/um/sysinfoapi.h:48:5)")]
            public _Anonymous_e__Union Anonymous;

            [NativeTypeName("DWORD")]
            public uint dwPageSize;
            [NativeTypeName("LPVOID")]
            public void* lpMinimumApplicationAddress;
            [NativeTypeName("LPVOID")]
            public void* lpMaximumApplicationAddress;
            [NativeTypeName("DWORD_PTR")]
            public nuint dwActiveProcessorMask;
            [NativeTypeName("DWORD")]
            public uint dwNumberOfProcessors;
            [NativeTypeName("DWORD")]
            public uint dwProcessorType;
            [NativeTypeName("DWORD")]
            public uint dwAllocationGranularity;
            [NativeTypeName("WORD")]
            public ushort wProcessorLevel;
            [NativeTypeName("WORD")]
            public ushort wProcessorRevision;

            [UnscopedRef]
            public ref uint dwOemId
            {
                [MethodImpl(MethodImplOptionsEx.AggressiveInlining)]
                get
                {
                    return ref Anonymous.dwOemId;
                }
            }

            [UnscopedRef]
            public ref ushort wProcessorArchitecture
            {
                [MethodImpl(MethodImplOptionsEx.AggressiveInlining)]
                get
                {
                    return ref Anonymous.Anonymous.wProcessorArchitecture;
                }
            }

            [UnscopedRef]
            public ref ushort wReserved
            {
                [MethodImpl(MethodImplOptionsEx.AggressiveInlining)]
                get
                {
                    return ref Anonymous.Anonymous.wReserved;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                [NativeTypeName("DWORD")]
                public uint dwOemId;
                [FieldOffset(0)]
                [NativeTypeName("_SYSTEM_INFO::(anonymous struct at C:/Program Files (x86)/Windows Kits/10/include/10.0.22621.0/um/sysinfoapi.h:50:9)")]
                public _Anonymous_e__Struct Anonymous;
                public partial struct _Anonymous_e__Struct
                {
                    [NativeTypeName("WORD")]
                    public ushort wProcessorArchitecture;
                    [NativeTypeName("WORD")]
                    public ushort wReserved;
                }
            }
        }

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_INTEL 0")]
        public const int PROCESSOR_ARCHITECTURE_INTEL = 0;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_MIPS 1")]
        public const int PROCESSOR_ARCHITECTURE_MIPS = 1;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_ALPHA 2")]
        public const int PROCESSOR_ARCHITECTURE_ALPHA = 2;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_PPC 3")]
        public const int PROCESSOR_ARCHITECTURE_PPC = 3;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_SHX 4")]
        public const int PROCESSOR_ARCHITECTURE_SHX = 4;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_ARM 5")]
        public const int PROCESSOR_ARCHITECTURE_ARM = 5;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_IA64 6")]
        public const int PROCESSOR_ARCHITECTURE_IA64 = 6;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_ALPHA64 7")]
        public const int PROCESSOR_ARCHITECTURE_ALPHA64 = 7;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_MSIL 8")]
        public const int PROCESSOR_ARCHITECTURE_MSIL = 8;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_AMD64 9")]
        public const int PROCESSOR_ARCHITECTURE_AMD64 = 9;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 10")]
        public const int PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 = 10;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_NEUTRAL 11")]
        public const int PROCESSOR_ARCHITECTURE_NEUTRAL = 11;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_ARM64 12")]
        public const int PROCESSOR_ARCHITECTURE_ARM64 = 12;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_ARM32_ON_WIN64 13")]
        public const int PROCESSOR_ARCHITECTURE_ARM32_ON_WIN64 = 13;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_IA32_ON_ARM64 14")]
        public const int PROCESSOR_ARCHITECTURE_IA32_ON_ARM64 = 14;

        [NativeTypeName("#define PROCESSOR_ARCHITECTURE_UNKNOWN 0xFFFF")]
        public const int PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF;

    }
}
