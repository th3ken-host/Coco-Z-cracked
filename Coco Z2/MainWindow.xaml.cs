using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml;
using Coco_Z2.Properties;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace Coco_Z2
{
	// Token: 0x0200000A RID: 10
	public partial class MainWindow : Window
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002178 File Offset: 0x00000378
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002180 File Offset: 0x00000380
		private IEasingFunction Smooth { get; set; } = new QuarticEase
		{
			EasingMode = EasingMode.EaseInOut
		};

		// Token: 0x0600003C RID: 60 RVA: 0x00003698 File Offset: 0x00001898
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

		// Token: 0x0600003D RID: 61 RVA: 0x00003730 File Offset: 0x00001930
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

		// Token: 0x0600003E RID: 62 RVA: 0x000037C8 File Offset: 0x000019C8
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

		// Token: 0x0600003F RID: 63 RVA: 0x0000384C File Offset: 0x00001A4C
		public MainWindow()
		{
			this.InitializeComponent();
			MainWindow.StartScriptList(this.ListBox, "./scripts", "*.txt");
			MainWindow.StartScriptList(this.ListBox, "./scripts", "*.lua");
			this.CocoTextEditor.ShowLineNumbers = true;
			this.CocoTextEditor.Options.EnableHyperlinks = false;
			this.CocoTextEditor.Options.ShowSpaces = false;
			this.CocoTextEditor.Options.ShowTabs = false;
			Stream input = File.OpenRead("./bin/lua.xshd");
			XmlTextReader reader = new XmlTextReader(input);
			this.CocoTextEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
			this.CocoTextEditor.TextArea.TextView.ElementGenerators.Add(new NoLongLines());
			this.CocoTextEditor.Text = "--[[\r\nWelcome WeAreDevs!\r\nhttps://wearedevs.net/\r\n---\r\nThank you for using Coco!\r\nCoco Z is made by N4ri x MCGamin1738,\r\nwith Help from dozens of amazing people,\r\nThank you so much everyone!\r\n- CocoCC\r\n]]--";
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003984 File Offset: 0x00001B84
		public void TimerSystem(object sender, EventArgs e)
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
			bool ui = Settings.Default.UI;
			if (ui)
			{
				this.ExecuteButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
				this.OpenButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
				this.SaveButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
				this.EraseButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
				bool flag = DLLPipe.NamedPipeExist(DLLPipe.luapipename);
				if (flag)
				{
					this.InjectButton.Background = new SolidColorBrush(Color.FromRgb(63, 184, 44));
				}
				else
				{
					this.InjectButton.Background = new SolidColorBrush(Color.FromRgb(50, 50, 50));
				}
			}
			else
			{
				this.ExecuteButton.Background = new SolidColorBrush(Color.FromRgb(byte.MaxValue, 63, 185));
				this.OpenButton.Background = new SolidColorBrush(Color.FromRgb(63, 98, byte.MaxValue));
				this.SaveButton.Background = new SolidColorBrush(Color.FromRgb(63, 184, 44));
				this.EraseButton.Background = new SolidColorBrush(Color.FromRgb(236, 183, 42));
				bool flag2 = DLLPipe.NamedPipeExist(DLLPipe.luapipename);
				if (flag2)
				{
					this.InjectButton.Background = new SolidColorBrush(Color.FromRgb(63, 184, 44));
				}
				else
				{
					this.InjectButton.Background = new SolidColorBrush(Color.FromRgb(byte.MaxValue, 63, 63));
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003B64 File Offset: 0x00001D64
		public static void StartScriptList(System.Windows.Controls.ListBox ListBox, string Folder, string FileType)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
			FileInfo[] files = directoryInfo.GetFiles(FileType);
			foreach (FileInfo fileInfo in files)
			{
				ListBox.Items.Add(fileInfo.Name);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003BAC File Offset: 0x00001DAC
		private void CocoZ2_Loaded(object sender, RoutedEventArgs e)
		{
			this.Fade(this.CocoLogo);
			this.Fade(this.InjectButton);
			this.Fade(this.ExecuteButton);
			this.Fade(this.OpenButton);
			this.Fade(this.SaveButton);
			this.Fade(this.EraseButton);
			this.Fade(this.SettingsButton);
			this.Fade(this.GameButton);
			this.Fade(this.DiscordButton);
			this.Fade(this.MultiTabAvalon);
			this.Fade(this.ExitBorder);
			this.Fade(this.MinimizeBorder);
			this.Fade(this.AddTab);
			this.Fade(this.DelTab);
			this.Fade(this.ListBox);
			this.ObjectShift(this.InjectButton, this.InjectButton.Margin, new Thickness(33.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.ExecuteButton, this.ExecuteButton.Margin, new Thickness(63.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.OpenButton, this.OpenButton.Margin, new Thickness(93.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.SaveButton, this.SaveButton.Margin, new Thickness(123.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.EraseButton, this.EraseButton.Margin, new Thickness(153.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.SettingsButton, this.SettingsButton.Margin, new Thickness(553.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.GameButton, this.GameButton.Margin, new Thickness(583.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.DiscordButton, this.DiscordButton.Margin, new Thickness(613.0, 331.0, 0.0, 44.0));
			this.ObjectShift(this.CocoLogo, this.CocoLogo.Margin, new Thickness(28.0, 36.0, 612.0, 334.0));
			this.InjectChecker.Interval = new TimeSpan(0, 0, 0, 1);
			this.InjectChecker.Tick += this.TimerSystem;
			this.InjectChecker.Start();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003F00 File Offset: 0x00002100
		private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
		{
			int i = 0;
			while (i < VisualTreeHelper.GetChildrenCount(parent))
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				bool flag = child != null && child is T;
				bool flag2 = flag;
				T result;
				if (flag2)
				{
					result = (T)((object)child);
				}
				else
				{
					T t = MainWindow.FindVisualChild<T>(child);
					bool flag3 = t != null;
					bool flag4 = !flag3;
					if (flag4)
					{
						i++;
						continue;
					}
					result = t;
				}
				return result;
			}
			return default(T);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003F8C File Offset: 0x0000218C
		private void AddTab_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.MultiTabAvalon.Items.Count < 6;
			bool flag2 = flag;
			if (flag2)
			{
				TabItem tabItem = new TabItem();
				this.MultiTabAvalon.Items.Add(tabItem);
				TextEditor textEditor = new TextEditor();
				textEditor.FontFamily = new FontFamily("Consolas");
				textEditor.FontSize = 13.333;
				textEditor.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25));
				textEditor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(150, 150, 150));
				textEditor.Foreground = new SolidColorBrush(Color.FromRgb(235, 235, 235));
				textEditor.ShowLineNumbers = true;
				textEditor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
				textEditor.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
				tabItem.Content = textEditor;
				tabItem.Header = "New Tab";
				tabItem.IsSelected = true;
				Stream input = File.OpenRead("./bin/lua.xshd");
				XmlTextReader reader = new XmlTextReader(input);
				textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
				textEditor.Options.EnableHyperlinks = false;
				textEditor.Options.ShowSpaces = false;
				textEditor.Options.ShowTabs = false;
				textEditor.TextArea.TextView.ElementGenerators.Add(new NoLongLines());
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000040EC File Offset: 0x000022EC
		private void DelTab_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.MultiTabAvalon.Items.Count > 1;
			bool flag2 = flag;
			if (flag2)
			{
				this.MultiTabAvalon.Items.RemoveAt(this.MultiTabAvalon.SelectedIndex);
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002189 File Offset: 0x00000389
		private void InjectButton_Click(object sender, RoutedEventArgs e)
		{
			DLLFunc.Inject();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002192 File Offset: 0x00000392
		private void ExecuteButton_Click(object sender, RoutedEventArgs e)
		{
			this.MultiTabAvalon.Dispatcher.BeginInvoke(new Action(delegate()
			{
				TextEditor textEditor = MainWindow.FindVisualChild<TextEditor>(this.MultiTabAvalon);
				DLLPipe.LuaPipe(textEditor.Text);
			}), Array.Empty<object>());
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004134 File Offset: 0x00002334
		private void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Lua Scripts (*.lua)|*.lua|Txt Scripts (*.txt)|*.txt";
			ofd.Title = "Apex v3 | OpenFileDialog";
			ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			bool flag = this.MultiTabAvalon.Items.Count < 6;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK;
				bool flag4 = flag3;
				if (flag4)
				{
					DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Do you wish to open the file in a new tab?", "Apex v3| OpenFileDialog", MessageBoxButtons.YesNo);
					bool flag5 = dialogResult == System.Windows.Forms.DialogResult.Yes;
					bool flag6 = flag5;
					if (flag6)
					{
						TabItem tabItem = new TabItem();
						this.MultiTabAvalon.Items.Add(tabItem);
						TextEditor textEditor = new TextEditor();
						textEditor.FontFamily = new FontFamily("Consolas");
						textEditor.FontSize = 13.333;
						textEditor.Background = new SolidColorBrush(Color.FromRgb(25, 25, 25));
						textEditor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(150, 150, 150));
						textEditor.Foreground = new SolidColorBrush(Color.FromRgb(235, 235, 235));
						textEditor.ShowLineNumbers = true;
						textEditor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
						textEditor.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
						tabItem.Content = textEditor;
						tabItem.Header = ofd.SafeFileName;
						tabItem.IsSelected = true;
						textEditor.Options.EnableHyperlinks = false;
						textEditor.Options.ShowSpaces = false;
						textEditor.Options.ShowTabs = false;
						textEditor.Text = File.ReadAllText(ofd.FileName);
						Stream input = File.OpenRead("./bin/lua.xshd");
						XmlTextReader reader = new XmlTextReader(input);
						textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
					}
					else
					{
						bool flag7 = this.MultiTabAvalon.SelectedIndex != 0;
						bool flag8 = flag7;
						if (flag8)
						{
							this.MultiTabAvalon.Dispatcher.BeginInvoke(new Action(delegate()
							{
								TextEditor textEditor2 = MainWindow.FindVisualChild<TextEditor>(this.MultiTabAvalon);
								textEditor2.Text = File.ReadAllText(ofd.FileName);
							}), Array.Empty<object>());
						}
					}
				}
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004378 File Offset: 0x00002578
		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog ofd = new SaveFileDialog();
			ofd.Filter = "Lua Scripts (*.lua)|*.lua|Txt Scripts (*.txt)|*.txt";
			ofd.Title = "Apex v3 | SaveFileDialog";
			ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			this.MultiTabAvalon.Dispatcher.BeginInvoke(new Action(delegate()
			{
				bool flag = this.MultiTabAvalon.SelectedIndex != 0;
				bool flag2 = flag;
				if (flag2)
				{
					TextEditor textEditor = MainWindow.FindVisualChild<TextEditor>(this.MultiTabAvalon);
					bool flag3 = ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK;
					bool flag4 = flag3;
					if (flag4)
					{
						File.WriteAllText(ofd.FileName, textEditor.Text);
					}
				}
			}), Array.Empty<object>());
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000021B7 File Offset: 0x000003B7
		private void EraseButton_Click(object sender, RoutedEventArgs e)
		{
			this.MultiTabAvalon.Dispatcher.BeginInvoke(new Action(delegate()
			{
				TextEditor textEditor = MainWindow.FindVisualChild<TextEditor>(this.MultiTabAvalon);
				textEditor.Text = "";
			}), Array.Empty<object>());
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000021DC File Offset: 0x000003DC
		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.MultiTabAvalon.Dispatcher.BeginInvoke(new Action(delegate()
			{
				TextEditor textEditor = MainWindow.FindVisualChild<TextEditor>(this.MultiTabAvalon);
				textEditor.Text = File.ReadAllText("scripts\\" + this.ListBox.SelectedItem.ToString());
			}), Array.Empty<object>());
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002201 File Offset: 0x00000401
		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			this.ListBox.Items.Clear();
			MainWindow.StartScriptList(this.ListBox, "./scripts", "*.txt");
			MainWindow.StartScriptList(this.ListBox, "./scripts", "*.lua");
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002241 File Offset: 0x00000441
		private void DiscordButton_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://discord.gg/MvXATzM");
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000224F File Offset: 0x0000044F
		private void GameButton_Click(object sender, RoutedEventArgs e)
		{
			DLLPipe.LuaPipe("loadstring(game:HttpGet(('https://raw.githubusercontent.com/MarsQQ/CocoHub/master/CocoZHub'), true))()");
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000043F4 File Offset: 0x000025F4
		private void WeAreDevsLabel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				Process.Start("https://wearedevs.net/");
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002D18 File Offset: 0x00000F18
		private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000441C File Offset: 0x0000261C
		private void ExitBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				Window3 window = new Window3();
				window.Show();
				base.Hide();
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002D60 File Offset: 0x00000F60
		private void MinimizeBorder_MouseDown(object sender, MouseButtonEventArgs e)
		{
			bool flag = Mouse.LeftButton == MouseButtonState.Pressed;
			if (flag)
			{
				base.WindowState = WindowState.Minimized;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000444C File Offset: 0x0000264C
		private void SettingsButton_Click(object sender, RoutedEventArgs e)
		{
			Window2 window = new Window2();
			window.Show();
		}

		// Token: 0x0400002C RID: 44
		private DispatcherTimer InjectChecker = new DispatcherTimer();

		// Token: 0x0400002D RID: 45
		private Storyboard StoryBoard = new Storyboard();

		// Token: 0x0400002E RID: 46
		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		// Token: 0x0400002F RID: 47
		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);
	}
}
