using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Net<NData> : AnalysNet, IObjectDataBase<Net<NData>>
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public List<Neuron<NData>> Neurons { get; set; }
		public Net()
		{
			Neurons = new List<Neuron<NData>>();
			Id = -1;
			Name = "NULL";
		}
		public Net(String name, List<Neuron<NData>> neurons) : base()
		{
			this.Name = name;
			this.Neurons = neurons;
		}
		public Neuron<NData> AddNeuron(NData data, List<float> input)
		{
			var neuron = new Neuron<NData>(GetPosition(input), data, input);
			Neurons.Add(neuron);
			return neuron;
		}
		public Synapse<NData> AddSynapse(Neuron<NData> from, Neuron<NData> to, Synapse<NData>.TYPE_IO type, float threshold)
		{
			var synapse = new Synapse<NData>(-1, from, to, type, threshold);
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
		public Net<NData> Delete()
		{
			DataBase<NData>.Instance.DeleteNet(this);
			return this;
		}

		public Net<NData> Get()
		{
			var n = DataBase<NData>.Instance.GetNet(this.Id);
			this.Id = n.Id;
			this.Name = n.Name;
			this.Neurons = n.Neurons;
			return this;
		}

		public static Net<NData> Load(int id)
		{
			return DataBase<NData>.Instance.GetNet(id);
		}

		public Net<NData> Save()
		{
			DataBase<NData>.Instance.UpdateNet(this);
			return this;
		}
		public static int Create(Net<NData> net)
		{
			return DataBase<NData>.Instance.InsertNet(net);
		}
	}
}
