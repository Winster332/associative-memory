using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisionBrain.UI
{
	/// <summary>
	/// Логика взаимодействия для TopBar.xaml
	/// </summary>
	public partial class TopBar : UserControl
	{
		private bool isVisible = false;
		private UIElement leftPanel;

		public TopBar()
		{
			InitializeComponent();
		}

		public void SetLeftPanel(UIElement element)
		{
			this.leftPanel = element;
		}

		private void buttonLeftPanel_Click(object sender, RoutedEventArgs e)
		{
			var animation = new System.Windows.Media.Animation.ThicknessAnimation();

			if (!isVisible)
			{
				animation.From = new Thickness(-200, 0, 0, 0);
				animation.To = new Thickness(0, 0, 0, 0);
			} else {
				animation.From = new Thickness(0, 0, 0, 0);
				animation.To = new Thickness(-200, 0, 0, 0);
			}
			animation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
			animation.EasingFunction = new System.Windows.Media.Animation.PowerEase()
			{
				EasingMode = System.Windows.Media.Animation.EasingMode.EaseInOut,
				Power = 3
			};
			System.Windows.Media.Animation.Storyboard.SetTarget(animation, leftPanel);
			System.Windows.Media.Animation.Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

			System.Windows.Media.Animation.Storyboard s = new System.Windows.Media.Animation.Storyboard();
			s.Children.Add(animation);
			s.Begin();

			isVisible = !isVisible;
		}
	}
}
