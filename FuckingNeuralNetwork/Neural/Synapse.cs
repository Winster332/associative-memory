using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Synapse<NData>
	{
		public int Id { get; set; }
		public Neuron<NData> OutputNeuron { get; set; }
		public Neuron<NData> InputNeuron { get; set; }
		public enum TYPE_IO { Input = 1, Output = 2, None = 0 }
		public TYPE_IO TypeIO { get; set; }
		public bool IsActive { get; set; }
		public float Threshold { get; set; }
        public Synapse()
		{
			TypeIO = TYPE_IO.None;
			IsActive = false;
			Id = -1;
		}
		public Synapse(int id, Neuron<NData> output, Neuron<NData> input, TYPE_IO type, float threshold)
		{
			this.Id = id;
			this.InputNeuron = input;
			this.OutputNeuron = output;
			this.TypeIO = type;
			this.Threshold = threshold;
			this.IsActive = false;
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
	}
}
