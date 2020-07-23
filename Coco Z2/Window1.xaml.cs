using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Coco_Z2.Properties;

namespace Coco_Z2
{
	// Token: 0x02000002 RID: 2
	public partial class Window1 : Window
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x06000003 RID: 3 RVA: 0x000022E0 File Offset: 0x000004E0
		public void Fade(DependencyObject Object)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				From = new double?(0.0),
				To = new double?(1.0),
				Duration = new Duration(this.duration)
			};
			Storyboard.SetTarget(doubleAnimation, Object);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[]
			{
				1
			}));
			this.StoryBoard.Children.Add(doubleAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002378 File Offset: 0x00000578
		public void FadeOut(DependencyObject Object)
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				From = new double?(1.0),
				To = new double?(0.0),
				Duration = new Duration(this.duration)
			};
			Storyboard.SetTarget(doubleAnimation, Object);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[]
			{
				1
			}));
			this.StoryBoard.Children.Add(doubleAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002410 File Offset: 0x00000610
		public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
		{
			ThicknessAnimation thicknessAnimation = new ThicknessAnimation
			{
				From = new Thickness?(Get),
				To = new Thickness?(Set),
				Duration = this.duration2,
				EasingFunction = this.Smooth
			};
			Storyboard.SetTarget(thicknessAnimation, Object);
			Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(FrameworkElement.MarginProperty));
			this.StoryBoard.Children.Add(thicknessAnimation);
			this.StoryBoard.Begin();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002494 File Offset: 0x00000694
		public Window1()
		{
			this.InitializeComponent();
			this.LoadSettings();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002508 File Offset: 0x00000708
		private void LoadSettings()
		{
			bool dll = Settings.Default.DLL;
			if (dll)
			{
				string address = "https://gitlab.com/cococc/coco-dll-bootstrap/-/raw/master/Coco.dll";
				string fileName = "Coco.dll";
				WebClient webClient = new WebClient();
				webClient.DownloadFile(address, fileName);
			}
			string text = this.wc.DownloadString("https://gitlab.com/cococc/coco-dll-bootstrap/-/raw/master/CocoFrontEndChecker");
			bool flag = text.Contains("v2.0");
			if (flag)
			{
				Thread.Sleep(1);
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("There is a new update available! Please run the bootstrapper.", "Coco, Update Avaliable", MessageBoxButtons.OK);
				Process.Start("https://wearedevs.net/d/Coco%20Z");
				Environment.Exit(0);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000259C File Offset: 0x0000079C
		[DebuggerStepThrough]
		private void CocoZ2_Loaded(object sender, RoutedEventArgs e)
		{
			Window1.<CocoZ2_Loaded>d__13 <CocoZ2_Loaded>d__ = new Window1.<CocoZ2_Loaded>d__13();
			<CocoZ2_Loaded>d__.<>4__this = this;
			<CocoZ2_Loaded>d__.sender = sender;
			<CocoZ2_Loaded>d__.e = e;
			<CocoZ2_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<CocoZ2_Loaded>d__.<>1__state = -1;
			AsyncVoidMethodBuilder <>t__builder = <CocoZ2_Loaded>d__.<>t__builder;
			<>t__builder.Start<Window1.<CocoZ2_Loaded>d__13>(ref <CocoZ2_Loaded>d__);
		}

		// Token: 0x04000001 RID: 1
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000002 RID: 2
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000003 RID: 3
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		// Token: 0x04000005 RID: 5
		private WebClient wc = new WebClient();
	}
}
