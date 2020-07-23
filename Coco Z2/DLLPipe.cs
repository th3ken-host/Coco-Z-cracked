using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Coco_Z2
{
	// Token: 0x02000008 RID: 8
	internal class DLLPipe
	{
		// Token: 0x06000032 RID: 50
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);

		// Token: 0x06000033 RID: 51 RVA: 0x00003518 File Offset: 0x00001718
		public static bool NamedPipeExist(string pipeName)
		{
			bool result;
			try
			{
				bool flag = !DLLPipe.WaitNamedPipe("\\\\.\\pipe\\" + pipeName, 0);
				bool flag2 = flag;
				if (flag2)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					bool flag3 = lastWin32Error == 0;
					bool flag4 = flag3;
					if (flag4)
					{
						return false;
					}
					bool flag5 = lastWin32Error == 2;
					bool flag6 = flag5;
					if (flag6)
					{
						return false;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003594 File Offset: 0x00001794
		public static void LuaPipe(string script)
		{
			bool flag = DLLPipe.NamedPipeExist(DLLPipe.luapipename);
			bool flag2 = flag;
			if (flag2)
			{
				new Thread(delegate()
				{
					try
					{
						using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", DLLPipe.luapipename, PipeDirection.Out))
						{
							namedPipeClientStream.Connect();
							using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999))
							{
								streamWriter.Write(script);
								streamWriter.Dispose();
							}
							namedPipeClientStream.Dispose();
						}
					}
					catch (IOException)
					{
						MessageBox.Show("Error occured connecting to the pipe.", "Connection Failed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString());
					}
				}).Start();
			}
			else
			{
				MessageBox.Show(" Please Inject Coco, Thank You", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x04000028 RID: 40
		public static string luapipename = "485tu97hyaefw9v87ugr4e5hyAAAegsrhredhrAAAAAeiafjjgsnogksjeoikgsemkongesonsonsgegsngoigesijngsriuAAfwafaAA";
	}
}
