using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
	public static class Logger
	{
		public static void Run(Action runMethod)
		{
			DateTime runTime = DateTime.Now;
			runMethod();
			TimeSpan endTime = DateTime.Now - runTime;
			
			Console.WriteLine("[{0}]: {1}", endTime, runMethod.Method.Name);
		}
	}
}
