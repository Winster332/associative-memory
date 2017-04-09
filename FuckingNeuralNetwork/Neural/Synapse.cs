using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Synapse<NData> : IObjectDataBase<Synapse<NData>>
	{
		public int Id { get; set; }
		public Neuron<NData> OutputNeuron { get; set; }
		public Neuron<NData> InputNeuron { get; set; }
		public enum TYPE_IO { Input = 1, Output = 2, None = 0 }
		public TYPE_IO TypeIO { get; set; }
		public bool IsActive { get; set; }
		public float Threshold { get; set; }
		public DataColor Color { get; set; }
        public Synapse()
		{
			TypeIO = TYPE_IO.None;
			IsActive = false;
			Id = -1;
			Color = new DataColor(255, 0, 0, 0);
		}
		public Synapse(int id, Neuron<NData> output, Neuron<NData> input, TYPE_IO type, float threshold)
		{
			this.Id = id;
			this.InputNeuron = input;
			this.OutputNeuron = output;
			this.TypeIO = type;
			this.Threshold = threshold;
			this.IsActive = false;
			this.Color = new DataColor(255, 0, 0, 0);
		}
		public Synapse<NData> Send(List<float> input)
		{
			if (InputNeuron != null)
			{
				Console.WriteLine(OutputNeuron.Power);
				if (OutputNeuron.Power <= Threshold)
				{
					IsActive = true;
					InputNeuron.Active(input);
				}
			}
			Console.WriteLine(this.ToString());

			return this;
		}

		public void Reset()
		{
			IsActive = false;
		}

		public override string ToString()
		{
			return "Output[" + OutputNeuron.GetHashCode() + "] Input[" + InputNeuron.GetHashCode() +
				"] Type[" + TypeIO + "] IsActive[" + IsActive + "] Threshold[" + Threshold + "]";
		}

		public Synapse<NData> Delete()
		{
			DataBase<NData>.Instance.DeleteSynapse(this);
			return this;
		}

		public Synapse<NData> Get()
		{
			var s = DataBase<NData>.Instance.GetSynapse(this.Id);
			this.Color = s.Color;
			this.Id = s.Id;
			this.InputNeuron = s.InputNeuron;
			this.IsActive = s.IsActive;
			this.OutputNeuron = s.OutputNeuron;
			this.Threshold = s.Threshold;
			this.TypeIO = s.TypeIO;
			return this;
		}

		public Synapse<NData> Save()
		{
			DataBase<NData>.Instance.UpdateSynapse(this);
			return this;
		}

		public static int Create(Synapse<NData> synapse)
		{
			return DataBase<NData>.Instance.InsertSynapse(synapse);
		}

		public static Synapse<NData> Load(int id)
		{
			var s = DataBase<NData>.Instance.GetSynapse(id);
			return s;
		}
	}
}
