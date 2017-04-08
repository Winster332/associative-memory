using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Data
{
	public class Net : FuckingNeuralNetwork.Neural.Net<String>, IObjectDataBase<Net>
	{
		
		public Net() : base()
		{
		
		}
		public Net(String name, List<FuckingNeuralNetwork.Neural.Neuron<string>> neurons) : base()
		{
			this.Name = name;
			this.Neurons = neurons;
		}
		public Net Delete()
		{
			DataBase.Instance.DeleteNet(this);
			return this;
		}

		public Net Get()
		{
			var n = DataBase.Instance.GetNet(this.Id);
			this.Id = n.Id;
			this.Name = n.Name;
			this.Neurons = n.Neurons;
			return this;
		}

		public static Net Load(int id)
		{
			return null;
		}

		public Net Save()
		{
			DataBase.Instance.UpdateNet(this);
			return this;
		}
		public static int Create(Net net)
		{
			return DataBase.Instance.InsertNet(net);
		}
	}
}
