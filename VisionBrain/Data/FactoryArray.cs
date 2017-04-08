﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckingNeuralNetwork.Neural;

namespace VisionBrain.Data
{
	public static class FactoryArray
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
		public static String GenericArrayString(List<FuckingNeuralNetwork.Neural.Synapse<String>> list)
		{
			if (list.Count != 0)
			{
				String res = "[";
				list.ForEach(v => res += v.Id + ",");
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
				list.ForEach(v => res += v.Id + ",");
				res = res.Substring(0, res.Length - 2) + "]";
				return res;
			} else {
				return "[]";
			}
		}
		public static List<FuckingNeuralNetwork.Neural.Synapse<String>> GetSynapses(String text)
		{
			if (text != "[]")
			{
				text = text.Substring(1, text.Length);
				List<FuckingNeuralNetwork.Neural.Synapse<String>> res =
					new List<FuckingNeuralNetwork.Neural.Synapse<String>>();
				String timeoutSymbol = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i].ToString() != "," && text[i].ToString() != "]")
						timeoutSymbol += text[i];
					else
					{
						int id = int.Parse(timeoutSymbol);
						res.Add(Synapse.Load(id));
						timeoutSymbol = "";
					}
				}
				return res;
			} else return new List<FuckingNeuralNetwork.Neural.Synapse<string>>();
		}
		public static List<float> GetFloatArray(String text)
		{
			text = text.Substring(1, text.Length-1);
			List<float> res = new List<float>();
			String timeoutSymbol = "";
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i].ToString() != "," && text[i].ToString() != "]")
					timeoutSymbol += text[i];
				else
				{
					float w = float.Parse(timeoutSymbol);
					res.Add(w);
					timeoutSymbol = "";
				}
			}
			return res;
		}

		public static String GetNeurons(List<Neuron<string>> neurons)
		{
			return "";
		}

		public static List<FuckingNeuralNetwork.Neural.Neuron<String>> GetNeurons(String text)
		{
			return null;
		}
	}
}
