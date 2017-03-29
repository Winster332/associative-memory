using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Synapse<NData>
	{
		public Neuron<NData> InputNeuron { get; set; }
		public Neuron<NData> OutputNeuron { get; set; }
		public enum TYPE_IO { Input, Output, None }
		public TYPE_IO TypeIO { get; set; }
		public bool IsActive { get; set; }
		public Synapse()
		{
			TypeIO = TYPE_IO.None;
			IsActive = false;
		}
		public Synapse<NData> Send(List<float> input)
		{
			
			return this;
		}
	}
}
