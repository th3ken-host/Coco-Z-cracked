using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Coco_Z2
{
	// Token: 0x02000004 RID: 4
	public partial class Window3 : Window
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002134 File Offset: 0x00000334
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000213C File Offset: 0x0000033C
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x06000024 RID: 36 RVA: 0x00003094 File Offset: 0x00001294
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

		// Token: 0x06000025 RID: 37 RVA: 0x0000312C File Offset: 0x0000132C
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

		// Token: 0x06000026 RID: 38 RVA: 0x000031C4 File Offset: 0x000013C4
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

		// Token: 0x06000027 RID: 39 RVA: 0x00003248 File Offset: 0x00001448
		public Window3()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000032AC File Offset: 0x000014AC
		private async void CocoZ2_Loaded(object sender, RoutedEventArgs e)
		{
			this.Fade(this.CocoCircle);
			this.Fade(this.CocoBigSur);
			this.ObjectShift(this.CocoCircle, this.CocoCircle.Margin, new Thickness(0.0, 0.0, 0.0, 0.0));
			this.ObjectShift(this.CocoBigSur, this.CocoCircle.Margin, new Thickness(0.0, 0.0, 0.0, 0.0));
			await Task.Delay(2000);
			this.FadeOut(this.CocoCircle);
			this.FadeOut(this.CocoBigSur);
			this.ObjectShift(this.CocoCircle, this.CocoCircle.Margin, new Thickness(0.0, 260.0, 0.0, 0.0));
			this.ObjectShift(this.CocoBigSur, this.CocoCircle.Margin, new Thickness(0.0, 260.0, 0.0, 0.0));
			await Task.Delay(1000);
			Environment.Exit(0);
		}

		// Token: 0x0400001F RID: 31
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x04000020 RID: 32
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x04000021 RID: 33
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
