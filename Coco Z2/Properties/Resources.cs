using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Coco_Z2.Properties
{
	// Token: 0x0200000B RID: 11
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000225D File Offset: 0x0000045D
		internal Resources()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00004850 File Offset: 0x00002A50
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Coco_Z2.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00004898 File Offset: 0x00002A98
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002267 File Offset: 0x00000467
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000044 RID: 68
		private static ResourceManager resourceMan;

		// Token: 0x04000045 RID: 69
		private static CultureInfo resourceCulture;
	}
}
