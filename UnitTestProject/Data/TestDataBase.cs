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
			try
			{
				DataBase.Instance.Connection.Open();
				DataBase.Instance.Connection.Close();
				isConnected = true;
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
				isConnected = false;
			}
			Assert.IsTrue(isConnected);
		}
		[TestMethod]
		public void InsertNeuron()
		{
			Console.WriteLine(Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12,32,12,4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3)));
		}
	}
}
