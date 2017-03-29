using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Neuron<NData> : Vec3
	{
		private List<Synapse<NData>> Synapses { get; set; } = new List<Synapse<NData>>();
		public List<float> Weight { get; set; } = new List<float>();
		public float Power { get; set; } = 0;
		public NData Data { get; set; }
		
		public Neuron(Vec3 position, NData data, List<float> weight) : base(position)
		{
			this.Data = data;
			this.Weight = weight;
		}

		public Neuron(Vec3 position, NData data, int lengthWeight, float valueWeight) : base(position)
		{
			this.Data = data;
			for (var i = 0; i < lengthWeight; i++)
				Weight.Add(valueWeight);
		}

		public Neuron<NData> Train(NData data, List<float> input, float desired, float velocity = 0.1f)
		{
			this.Data = data;

			for (var i = 0; i < Weight.Count; i++)
			{
				var error = input[i] * Weight[i];
				Weight[i] += error * desired *  input[i] * velocity;
			}

			return this;
		}

		public Neuron<NData> Active(List<float> input)
		{
			for (var i = 0; i < Weight.Count; i++)
			{
				Power += Weight[i] * input[i];
			}
			return this;
		}

		public Neuron<NData> Reset()
		{
			Power = 0;
			return this;
		}
    }
}
