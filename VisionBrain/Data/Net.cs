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
			Id = -1;
			Name = "NULL";
		}
		public Net Delete()
		{
			//DataBase.Instance.DeleteNet(this);
			return this;
		}

		public Net Get(int id)
		{
			//var n = DataBase.Instance.GetNet(id);
			//this.Id = n.Id;
			//this.Name = n.Name;
			//this.Neurons = n.Neurons;
			return this;
		}

		public Net Save()
		{
			//DataBase.Instance.UpdateNet(this);
			return this;
		}
	}
}
