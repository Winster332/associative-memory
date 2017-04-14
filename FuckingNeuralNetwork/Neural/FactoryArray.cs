using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckingNeuralNetwork.Neural;

namespace FuckingNeuralNetwork.Neural
{
	public static class FactoryArray<T>
	{
		public static String GenericArrayString(List<float> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v + ",");
				res = res.Substring(0, res.Length - 1) + "]";
				return res;
			} else return "[]";
		}
		public static String GenericArrayString(int[] list)
		{
			if (list.Length != 0)
			{
				String res = "[";
				foreach (var v in list)
					res += v + ",";
				res = res.Substring(0, res.Length - 1) + "]";
				return res;
			} else return "[]";
		}
		public static String GenericArrayString(List<Synapse<T>> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v.Id + ",");
				res = res.Substring(0, res.Length - 1) + "]";
				return res;
			} else {
				return "[]";
			}
		}
		public static String GenericArrayString(List<Neuron<T>> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v.Id + ",");
				res = res.Substring(0, res.Length - 1) + "]";
				return res;
			} else {
				return "[]";
			}
		}

		public static int[] GetIntegerArray(string text)
		{
			List<int> res = new List<int>();

			if (!text.Equals("[]"))
			{
				text = text.Replace("[", "");
				String timeoutSymbol = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i].ToString() != "," && text[i].ToString() != "]" && text[i].ToString() != "")
						timeoutSymbol += text[i];
					else
					{
						int w = int.Parse(timeoutSymbol);
						res.Add(w);
						timeoutSymbol = "";
					}
				}
			}
			return res.ToArray();
		}

		public static List<Synapse<T>> GetSynapses(String text)
		{
			if (text != "[]")
			{
				text = text.Substring(1, text.Length-1);
				List<FuckingNeuralNetwork.Neural.Synapse<T>> res =
					new List<FuckingNeuralNetwork.Neural.Synapse<T>>();
				String timeoutSymbol = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i].ToString() != "," && text[i].ToString() != "]")
						timeoutSymbol += text[i];
					else
					{
						int id = int.Parse(timeoutSymbol);
						res.Add(Synapse<T>.Load(id));
						timeoutSymbol = "";
					}
				}
				return res;
			} else return new List<Synapse<T>>();
		}
		public static List<float> GetFloatArray(String text)
		{
			List<float> res = new List<float>();

			if (!text.Equals("[]"))
			{
				text = text.Replace("[", "");
				String timeoutSymbol = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i].ToString() != "," && text[i].ToString() != "]" && text[i].ToString() != "")
						timeoutSymbol += text[i];
					else
					{
						float w = float.Parse(timeoutSymbol);
						res.Add(w);
						timeoutSymbol = "";
					}
				}
			}
			return res;
		}

		public static List<Neuron<T>> GetNeurons(string text)
		{
			List<Neuron<T>> neurons = new List<Neuron<T>>();

			if (text != "[]")
			{
				text = text.Replace("[", "");
				String timeoutSymbol = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i].ToString() != "," && text[i].ToString() != "]")
						timeoutSymbol += text[i];
					else
					{
						int id = int.Parse(timeoutSymbol);
						neurons.Add(Neuron<T>.Load(id));
						timeoutSymbol = "";
					}
				}
			}
			return neurons;
		}
	}
}
