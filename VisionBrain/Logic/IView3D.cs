using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace VisionBrain.Logic
{
	public interface IView3D
	{
		PerspectiveCamera GetCamera();
		Viewport3D GetViewpoert();
	}
}
