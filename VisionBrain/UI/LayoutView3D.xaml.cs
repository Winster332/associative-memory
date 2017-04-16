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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisionBrain.UI
{
	/// <summary>
	/// Логика взаимодействия для LayoutView3D.xaml
	/// </summary>
	public partial class LayoutView3D : UserControl, Logic.IView3D
	{
		public LayoutView3D()
		{
			InitializeComponent();
		}

		public PerspectiveCamera GetCamera()
		{
			return this.Camera;
		}

		public Viewport3D GetViewpoert()
		{
			return Viewport;
		}
	}
}
