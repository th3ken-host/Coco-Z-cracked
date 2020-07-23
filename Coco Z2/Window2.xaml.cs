using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Coco_Z2.Properties;

namespace Coco_Z2
{
	// Token: 0x02000003 RID: 3
	public partial class Window2 : Window
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002069 File Offset: 0x00000269
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x0600000D RID: 13 RVA: 0x00002688 File Offset: 0x00000888
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

		// Token: 0x0600000E RID: 14 RVA: 0x00002720 File Offset: 0x00000920
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

		// Token: 0x0600000F RID: 15 RVA: 0x000027B8 File Offset: 0x000009B8
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

		// Token: 0x06000010 RID: 16 RVA: 0x0000283C File Offset: 0x00000A3C
		public Window2()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028A0 File Offset: 0x00000AA0
		private void LoadSettings()
		{
			bool topMost = Settings.Default.TopMost;
			if (topMost)
			{
				base.Topmost = true;
			}
			else
			{
				base.Topmost = false;
			}
			this.Fade(this.Button1);
			this.Fade(this.Button2);
			this.Fade(this.Button3);
			this.Fade(this.Button4);
			this.Fade(this.Button5);
			this.Fade(this.Button6);
			this.Fade(this.Button7);
			this.Fade(this.Button8);
			this.Fade(this.Button9);
			this.Fade(this.Button10);
			this.Fade(this.Label2);
			this.Fade(this.Label3);
			this.Fade(this.Label4);
			this.ObjectShift(this.Button1, this.Button1.Margin, new Thickness(206.0, 71.0, 0.0, 299.0));
			this.ObjectShift(this.Button2, this.Button2.Margin, new Thickness(338.0, 71.0, 0.0, 299.0));
			this.ObjectShift(this.Button3, this.Button3.Margin, new Thickness(206.0, 106.0, 0.0, 264.0));
			this.ObjectShift(this.Button4, this.Button4.Margin, new Thickness(338.0, 106.0, 0.0, 264.0));
			this.ObjectShift(this.Button5, this.Button5.Margin, new Thickness(206.0, 179.0, 0.0, 191.0));
			this.ObjectShift(this.Button6, this.Button6.Margin, new Thickness(338.0, 179.0, 0.0, 191.0));
			this.ObjectShift(this.Button7, this.Button7.Margin, new Thickness(206.0, 250.0, 0.0, 120.0));
			this.ObjectShift(this.Button8, this.Button8.Margin, new Thickness(338.0, 250.0, 0.0, 120.0));
			this.ObjectShift(this.Button9, this.Button9.Margin, new Thickness(206.0, 322.0, 0.0, 48.0));
			this.ObjectShift(this.Button10, this.Button10.Margin, new Thickness(338.0, 322.0, 0.0, 48.0));
			this.ObjectShift(this.Label2, this.Label2.Margin, new Thickness(5.0, 115.0, 0.0, 0.0));
			this.ObjectShift(this.Label3, this.Label3.Margin, new Thickness(199.0, 215.0, 0.0, 0.0));
			this.ObjectShift(this.Label4, this.Label4.Margin, new Thickness(199.0, 285.0, 0.0, 0.0));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002CC8 File Offset: 0x00000EC8
		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			foreach (Process process in Process.GetProcessesByName("RobloxPlayerBeta"))
			{
				process.Kill();
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002072 File Offset: 0x00000272
		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(".\\execprg\\RobloxPlayerLauncher.exe");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002CFC File Offset: 0x00000EFC
		private void Button3_Click(object sender, RoutedEventArgs e)
		{
			Mutex mutex = new Mutex(true, "ROBLOX_singletonMutex");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002080 File Offset: 0x00000280
		private void Button4_Click(object sender, RoutedEventArgs e)
		{
			DLLPipe.LuaPipe("loadstring(game:HttpGet(('https://raw.githubusercontent.com/MarsQQ/ScriptHubScripts/master/FPS%20Boost'),true))()");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002D18 File Offset: 0x00000F18
		private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000208E File Offset: 0x0000028E
		private void CocoZ2_Loaded(object sender, RoutedEventArgs e)
		{
			this.LoadSettings();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002D3C File Offset: 0x00000F3C
		private void ExitBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				base.Hide();
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002D60 File Offset: 0x00000F60
		private void MinimizeBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				base.WindowState = WindowState.Minimized;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002098 File Offset: 0x00000298
		private void Button5_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.TopMost = true;
			Settings.Default.Save();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000020B2 File Offset: 0x000002B2
		private void Button6_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.TopMost = false;
			Settings.Default.Save();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000020CC File Offset: 0x000002CC
		private void Button7_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.DLL = true;
			Settings.Default.Save();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000020E6 File Offset: 0x000002E6
		private void Button8_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.DLL = false;
			Settings.Default.Save();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002100 File Offset: 0x00000300
		private void Button9_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.UI = false;
			Settings.Default.Save();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000211A File Offset: 0x0000031A
		private void Button10_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.UI = true;
			Settings.Default.Save();
		}

		// Token: 0x04000009 RID: 9
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x0400000A RID: 10
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x0400000B RID: 11
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
