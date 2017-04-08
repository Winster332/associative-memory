using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Data
{
	public class Synapse : FuckingNeuralNetwork.Neural.Synapse<String>, IObjectDataBase<Synapse>
	{
		public Synapse()
		{
		}
		public Synapse Delete()
		{
			DataBase.Instance.DeleteSynapse(this);
			return this;
		}

		public Synapse Get()
		{
			var s = DataBase.Instance.GetSynapse(this.Id);
			this.Color = s.Color;
			this.Id = s.Id;
			this.InputNeuron = s.InputNeuron;
			this.IsActive = s.IsActive;
			this.OutputNeuron = s.OutputNeuron;
			this.Threshold = s.Threshold;
			this.TypeIO = s.TypeIO;
			return this;
		}

		public Synapse Save()
		{
			DataBase.Instance.UpdateSynapse(this);
			return this;
		}

		public static int Create(Synapse synapse)
		{
			return DataBase.Instance.InsertSynapse(synapse);
		}

		public static Synapse Load(int id)
		{
			var s = DataBase.Instance.GetSynapse(id);
			return s;
		}
	}
}
