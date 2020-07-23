using System;
using System.Threading;
using System.Windows.Forms;

namespace Coco_Z2
{
	// Token: 0x02000006 RID: 6
	internal class DLLFunc
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00003404 File Offset: 0x00001604
		public static void Inject()
		{
			bool flag = DLLPipe.NamedPipeExist(DLLPipe.luapipename);
			bool flag2 = flag;
			if (flag2)
			{
				MessageBox.Show("Already injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				bool flag3 = !DLLPipe.NamedPipeExist(DLLPipe.luapipename);
				bool flag4 = flag3;
				if (flag4)
				{
					switch (DLLInject.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + DLLFunc.exploitdllname))
					{
					case DLLInject.DllInjectionResult.DllNotFound:
						MessageBox.Show("Couldn't find " + DLLFunc.exploitdllname, "Dll was not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					case DLLInject.DllInjectionResult.GameProcessNotFound:
						MessageBox.Show("Couldn't find RobloxPlayerBeta.exe!", "Target process was not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					case DLLInject.DllInjectionResult.InjectionFailed:
						MessageBox.Show("Injection Failed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					default:
					{
						Thread.Sleep(7000);
						bool flag5 = !DLLPipe.NamedPipeExist(DLLPipe.luapipename);
						bool flag6 = flag5;
						if (flag6)
						{
							MessageBox.Show("Injection Failed!\nMaybe you are Missing something\nor took more time to check if was ready\nor other stuff", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						break;
					}
					}
				}
			}
		}

		// Token: 0x04000027 RID: 39
		public static string exploitdllname = "Coco.dll";
	}
}
