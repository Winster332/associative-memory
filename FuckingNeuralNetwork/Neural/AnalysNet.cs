using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class AnalysNet
	{
		/// <summary>
		/// Расчет позиции нейрона исходя из веса
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public Vec3 GetPosition(List<float> input)
		{
			return new Vec3(0, 0, 0);
		}
		/// <summary>
		/// Поиск нейрона исходя из веса
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public int GetNeuronFromWeight(List<float> input)
		{
			return 0;
		}
	}
}
