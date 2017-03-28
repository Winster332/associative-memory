using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Neuron<NData> : Vec3
	{
		public List<float> Weight { get; set; } = new List<float>();
		public float Power { get; set; } = 0;
		public NData Data { get; set; }
		
		public void Active(List<float> input)
		{

		}

		public void Reset()
		{

		}
    }
}
