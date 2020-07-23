using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Coco_Z2
{
	// Token: 0x02000007 RID: 7
	internal class DLLInject
	{
		// Token: 0x0200000F RID: 15
		public enum DllInjectionResult
		{
			// Token: 0x04000055 RID: 85
			DllNotFound,
			// Token: 0x04000056 RID: 86
			GameProcessNotFound,
			// Token: 0x04000057 RID: 87
			InjectionFailed,
			// Token: 0x04000058 RID: 88
			Success
		}

		// Token: 0x02000010 RID: 16
		public sealed class DllInjector
		{
			// Token: 0x0600006C RID: 108
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x0600006D RID: 109
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int CloseHandle(IntPtr hObject);

			// Token: 0x0600006E RID: 110
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

			// Token: 0x0600006F RID: 111
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);

			// Token: 0x06000070 RID: 112
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000071 RID: 113
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

			// Token: 0x06000072 RID: 114
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00004F20 File Offset: 0x00003120
			public static DLLInject.DllInjector GetInstance
			{
				get
				{
					bool flag = DLLInject.DllInjector._instance == null;
					bool flag2 = flag;
					if (flag2)
					{
						DLLInject.DllInjector._instance = new DLLInject.DllInjector();
					}
					return DLLInject.DllInjector._instance;
				}
			}

			// Token: 0x06000074 RID: 116 RVA: 0x0000225D File Offset: 0x0000045D
			private DllInjector()
			{
			}

			// Token: 0x06000075 RID: 117 RVA: 0x00004F54 File Offset: 0x00003154
			public DLLInject.DllInjectionResult Inject(string sProcName, string sDllPath)
			{
				bool flag = !File.Exists(sDllPath);
				bool flag2 = flag;
				DLLInject.DllInjectionResult result;
				if (flag2)
				{
					result = DLLInject.DllInjectionResult.DllNotFound;
				}
				else
				{
					uint num = 0U;
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						bool flag3 = processes[i].ProcessName == sProcName;
						bool flag4 = flag3;
						if (flag4)
						{
							num = (uint)processes[i].Id;
							break;
						}
					}
					bool flag5 = num == 0U;
					bool flag6 = flag5;
					if (flag6)
					{
						result = DLLInject.DllInjectionResult.GameProcessNotFound;
					}
					else
					{
						bool flag7 = !this.bInject(num, sDllPath);
						bool flag8 = flag7;
						if (flag8)
						{
							result = DLLInject.DllInjectionResult.InjectionFailed;
						}
						else
						{
							result = DLLInject.DllInjectionResult.Success;
						}
					}
				}
				return result;
			}

			// Token: 0x06000076 RID: 118 RVA: 0x00005004 File Offset: 0x00003204
			private bool bInject(uint pToBeInjected, string sDllPath)
			{
				IntPtr intPtr = DLLInject.DllInjector.OpenProcess(1082U, 1, pToBeInjected);
				bool flag = intPtr == DLLInject.DllInjector.INTPTR_ZERO;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					result = false;
				}
				else
				{
					IntPtr procAddress = DLLInject.DllInjector.GetProcAddress(DLLInject.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
					bool flag3 = procAddress == DLLInject.DllInjector.INTPTR_ZERO;
					bool flag4 = flag3;
					if (flag4)
					{
						result = false;
					}
					else
					{
						IntPtr intPtr2 = DLLInject.DllInjector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)sDllPath.Length, 12288U, 64U);
						bool flag5 = intPtr2 == DLLInject.DllInjector.INTPTR_ZERO;
						bool flag6 = flag5;
						if (flag6)
						{
							result = false;
						}
						else
						{
							byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
							bool flag7 = DLLInject.DllInjector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0;
							bool flag8 = flag7;
							if (flag8)
							{
								result = false;
							}
							else
							{
								bool flag9 = DLLInject.DllInjector.CreateRemoteThread(intPtr, (IntPtr)null, DLLInject.DllInjector.INTPTR_ZERO, procAddress, intPtr2, 0U, (IntPtr)null) == DLLInject.DllInjector.INTPTR_ZERO;
								bool flag10 = flag9;
								if (flag10)
								{
									result = false;
								}
								else
								{
									DLLInject.DllInjector.CloseHandle(intPtr);
									result = true;
								}
							}
						}
					}
				}
				return result;
			}

			// Token: 0x04000059 RID: 89
			private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

			// Token: 0x0400005A RID: 90
			private static DLLInject.DllInjector _instance;
		}
	}
}
