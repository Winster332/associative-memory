using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Data
{
	public static class FactoryArray
	{
		public static String GenericArrayString(List<float> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v + ", ");
				res = res.Substring(0, res.Length - 2) + "]";
				return res;
			} else return "[]";
		}
		public static String GenericArrayString(List<FuckingNeuralNetwork.Neural.Synapse<String>> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v.Id + ", ");
				res = res.Substring(0, res.Length - 2) + "]";
				return res;
			} else {
				return "[]";
			}
		}
		public static String GenericArrayString(List<FuckingNeuralNetwork.Neural.Neuron<String>> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v.Id + ", ");
				res = res.Substring(0, res.Length - 2) + "]";
				return res;
			} else {
				return "[]";
			}
		}
	}
}
