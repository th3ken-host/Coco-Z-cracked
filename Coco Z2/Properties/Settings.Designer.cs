using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Coco_Z2.Properties
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000048B0 File Offset: 0x00002AB0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000048C8 File Offset: 0x00002AC8
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002270 File Offset: 0x00000470
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool DLL
		{
			get
			{
				return (bool)this["DLL"];
			}
			set
			{
				this["DLL"] = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000048EC File Offset: 0x00002AEC
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002285 File Offset: 0x00000485
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool TopMost
		{
			get
			{
				return (bool)this["TopMost"];
			}
			set
			{
				this["TopMost"] = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00004910 File Offset: 0x00002B10
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000229A File Offset: 0x0000049A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UI
		{
			get
			{
				return (bool)this["UI"];
			}
			set
			{
				this["UI"] = value;
			}
		}

		// Token: 0x04000046 RID: 70
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
