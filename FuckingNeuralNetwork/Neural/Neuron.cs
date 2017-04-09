using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Neuron<NData> : Vec3, IObjectDataBase<Neuron<NData>>
	{
		public virtual List<Synapse<NData>> Synapses { get; set; } = new List<Synapse<NData>>();
		public List<float> Weight { get; set; } = new List<float>();
		public float Power { get; set; } = 0;
		public NData Data { get; set; }
		public float Radius { get; set; }
		public int Id { get; set; }
		public DataColor Color { get; set; }

		public Neuron(Vec3 position, NData data, List<float> weight) : base(position)
		{
			this.Id = -1;
			this.Data = data;
			this.Weight = weight;
			this.Radius = 1;
			this.Color = new DataColor(255, 0, 0, 255);
		}
		public Neuron()
		{
			this.Id = -1;
			this.Weight = new List<float>();
			this.Radius = 1;
			this.Color = new DataColor(255, 0, 0, 255);
		}
		public Neuron(int id, float radius, Vec3 position, String data, List<float> weight) : base(position)
		{
			this.Radius = radius;
			Id = id;
			Color = new DataColor(255, 0, 0, 255);
			Radius = 1;
		}

		public Neuron(Vec3 position, int id, float radius, NData data, int lengthWeight, float valueWeight) : base(position)
		{
			this.Radius = radius;
			this.Id = id;
			this.Data = data;
			Color = new DataColor(255,25,55,55);
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

			Synapses.ForEach(synapse =>
			{
				if (synapse.TypeIO == Synapse<NData>.TYPE_IO.Input)
					synapse.Send(DeformInput(synapse.InputNeuron.Weight, input, 1, 1));
			});
			return this;
		}

		public Neuron<NData> Reset(bool withSynapse = false)
		{
			Power = 0;

			if (withSynapse)
				Synapses.ForEach(s => s.Reset());

			return this;
		}
		public List<float> DeformInput(List<float> weight, List<float> input, float desired, float velocity)
		{
			var output = new List<float>();

			for (var i = 0; i < weight.Count; i++)
			{
				var error = input[i] * weight[i];
				output.Add(weight[i] + error * desired * input[i] * velocity);
			}

			return output;
		}

		public Neuron<NData> Save()
		{
			DataBase<NData>.Instance.UpdateNeuron((this));
			return this;
		}
		public Neuron<NData> Delete()
		{
			DataBase<NData>.Instance.DeleteNeuron(this);
			return this;
		}
		public Neuron<NData> Get()
		{
			var n = DataBase<NData>.Instance.GetNeuron(this.Id);
			this.Color = n.Color;
			this.Data = n.Data;
			this.Id = n.Id;
			this.Power = n.Power;
			this.Radius = n.Radius;
			this.Synapses = n.Synapses;
			this.Weight = n.Weight;
			this.X = n.X;
			this.Y = n.Y;
			this.Z = n.Z;
			return this;
		}
		public static Neuron<NData> Load(int id)
		{
			var n = DataBase<NData>.Instance.GetNeuron(id);

			if (n.Id == -1)
				return null;
			else return n;
		}
		public static int Create(FuckingNeuralNetwork.Neural.DataColor color, NData data, float radius, List<Synapse<NData>> synapses, List<float> weight, Vec3 v)
		{
			var n = new Neuron<NData>(v, data, weight);
			n.Radius = radius;
			n.Color = color;
			n.Synapses = synapses.ToList<Synapse<NData>>();

			return DataBase<NData>.Instance.InsertNeuron(n);
		}
		public static int Create(Neuron<NData> neuron)
		{
			return DataBase<NData>.Instance.InsertNeuron(neuron);
		}
	}
}
