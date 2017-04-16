using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Logic
{
	public class UIView
	{
		public VisionBrain.MainWindow MainWindow { get; set; }
		public VisionBrain.UI.LayoutProjects Projects { get; set; }
		public Windows.WindowWorkspace WindowWorkspace { get; set; }
		public IView3D View3D { get; set; }
	}
}
