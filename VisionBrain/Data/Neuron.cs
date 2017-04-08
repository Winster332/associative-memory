using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vec3 = FuckingNeuralNetwork.Neural.Vec3;

namespace VisionBrain.Data
{
	public class Neuron : FuckingNeuralNetwork.Neural.Neuron<String>, IObjectDataBase<Neuron>
	{
		
		public DataColor Color { get; set; }
		
		public Neuron(Vec3 position, String data, List<float> weight) : base(position, data, weight)
		{
			Color = new DataColor(255, 0, 0, 255);
			
		}
		public Neuron(int id, float radius, Vec3 position, String data, List<float> weight) : base(position, data, weight)
		{
			this.Radius = radius;
			Id = id;
			Color = new DataColor(255, 0, 0, 255);
			Radius = 1;
		}
		public Neuron Save()
		{
			DataBase.Instance.UpdateNeuron(this);
			return this;
		}
		public Neuron Delete()
		{
			DataBase.Instance.DeleteNeuron(this);
			return this;
		}
		public Neuron Get()
		{
			var n = DataBase.Instance.GetNeuron(this.Id);
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
		public static Neuron Load(int id)
		{
			var n = DataBase.Instance.GetNeuron(id);

			if (n.Id == -1)
				return null;
			else return n;
		}
		public static int Create(DataColor color, String data, float radius, List<Synapse> synapses, List<float> weight, Vec3 v)
		{
			Neuron n = new Neuron(v, data, weight);
			n.Radius = radius;
			n.Color = color;
			n.Synapses = synapses.ToList<FuckingNeuralNetwork.Neural.Synapse<String>>();

			return DataBase.Instance.InsertNeuron(n);
		}
	}
}
