using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Net<NData> : AnalysNet
	{
		public List<Neuron<NData>> Neurons { get; set; }
		public Net()
		{
			Neurons = new List<Neuron<NData>>();
		}
		public Neuron<NData> AddNeuron(NData data, List<float> input)
		{
			var neuron = new Neuron<NData>(GetPosition(input), data, input);
			Neurons.Add(neuron);
			return neuron;
		}
		public Synapse<NData> AddSynapse(Neuron<NData> from, Neuron<NData> to, Synapse<NData>.TYPE_IO type, float threshold)
		{
			var synapse = new Synapse<NData>(from, to, type, threshold);
			from.Synapses.Add(synapse);
			return synapse;
		}
		public Net<NData> Active(int index, List<float> input)
		{
			Neurons[index].Active(input);
			return this;
		}
		public Net<NData> Active(Neuron<NData> neuron, List<float> input)
		{
			neuron.Active(input);
			return this;
		}
		public Net<NData> Active(List<float> input)
		{
			Neurons[GetNeuronFromWeight(input)].Active(input);
			return this;
		}
		public Neuron<NData> Train(int index, List<float> input, float desired, float velocity = 1)
		{
			return Neurons[index].Train(Neurons[index].Data, input, desired, velocity);
		}
		public void Reset(bool withSynapse = false) => Neurons.ForEach(n => n.Reset(withSynapse));
	}
}
