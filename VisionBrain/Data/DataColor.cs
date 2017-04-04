using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Data
{
	public class DataColor
	{
		public int A { get; set; }
		public int R { get; set; }
		public int G { get; set; }
		public int B { get; set; }
		public DataColor()
		{
			A = 0;
			R = 0;
			G = 0;
			B = 0;
		}
		public DataColor(int a, int r, int g, int b)
		{
			this.A = a;
			this.R = r;
			this.G = g;
			this.B = b;
		}
	}
}
