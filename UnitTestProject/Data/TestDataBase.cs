using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisionBrain.Data;

namespace UnitTestProject.Data
{
	[TestClass]
	public class TestDataBase
	{
		[TestInitialize]
		public void SetUp()
		{

		}
		[TestMethod]
		public void Connection()
		{
			bool isConnected = false;

			Logger.Run(() => 
			{
				try
				{
					DataBase.Instance.Open();
					DataBase.Instance.CloseLast();
					isConnected = true;
				} catch (Exception ex) {
					Console.WriteLine(ex.ToString());
					isConnected = false;
				}
				DataBase.Instance.Pool.CloseAll();
			});
			Assert.IsTrue(isConnected);
		}
		[TestMethod]
		public void InsertNeuron()
		{
			Logger.Run(() =>
			{
				Console.WriteLine(Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12, 32, 12, 4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3)));
			});
		}
	}
}
