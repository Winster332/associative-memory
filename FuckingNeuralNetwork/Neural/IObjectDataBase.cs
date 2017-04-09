using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public interface IObjectDataBase<T>
	{
		T Save();
		T Delete();
		T Get();
	}
}
