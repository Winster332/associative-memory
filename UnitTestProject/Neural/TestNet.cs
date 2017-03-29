using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuckingNeuralNetwork.Neural;

namespace UnitTestProject.Neural
{
	public class TestNet
	{
		public Net<String> net;
		
		[TestInitialize]		
		public void SetUp()
		{
			net = new Net<String>();
		}
		[TestMethod]
		public void Addneuron()
		{

		}
		[TestMethod]
		public void AddSynapse()
		{

		}
		[TestMethod]
		public void Train()
		{

		}
		[TestMethod]
		public void Reset()
		{

		}
	}
}
