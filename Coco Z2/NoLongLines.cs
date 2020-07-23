using System;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace Coco_Z2
{
	// Token: 0x02000009 RID: 9
	public class NoLongLines : VisualLineElementGenerator
	{
		// Token: 0x06000037 RID: 55 RVA: 0x000035F0 File Offset: 0x000017F0
		public override int GetFirstInterestedOffset(int startOffset)
		{
			DocumentLine lastDocumentLine = base.CurrentContext.VisualLine.LastDocumentLine;
			bool flag = lastDocumentLine.Length > 2000;
			bool flag2 = flag;
			if (flag2)
			{
				int num = lastDocumentLine.Offset + 2000 - 100 - "< Expand >".Length;
				bool flag3 = startOffset <= num;
				bool flag4 = flag3;
				if (flag4)
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003660 File Offset: 0x00001860
		public override VisualLineElement ConstructElement(int offset)
		{
			return new FormattedTextElement("< Expand >", base.CurrentContext.VisualLine.LastDocumentLine.EndOffset - offset - 100);
		}

		// Token: 0x04000029 RID: 41
		private const int maxLength = 2000;

		// Token: 0x0400002A RID: 42
		private const string ellipsis = "< Expand >";

		// Token: 0x0400002B RID: 43
		private const int charactersAfterEllipsis = 100;
	}
}
