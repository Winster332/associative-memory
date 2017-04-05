using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Data
{
	public class Synapse : FuckingNeuralNetwork.Neural.Synapse<String>, IObjectDataBase<Synapse>
	{
		public DataColor Color { get; set; }
		public Synapse()
		{
			
		}
		public Synapse Delete()
		{
			//DataBase.Instance.DeleteSynapse(this);
			return this;
		}

		public Synapse Get(int id)
		{
			//var s = DataBase.Instance.GetSynapse(id);
			//this.Color = s.Color;
			//this.Id = s.Id;
			//this.InputNeuron = s.InputNeuron;
			//this.IsActive = s.IsActive;
			//this.OutputNeuron = s.OutputNeuron;
			//this.Threshold = s.Threshold;
			//this.TypeIO = s.TypeIO;
			return this;
		}

		public Synapse Save()
		{
			//DataBase.Instance.UpdateSynapse(this);
			return this;
		}
	}
}
