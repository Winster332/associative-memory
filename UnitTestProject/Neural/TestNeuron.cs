using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuckingNeuralNetwork.Neural;

namespace UnitTestProject.Neural
{
	[TestClass]
	public class TestNeuron
	{
		public List<Neuron<String>> neurons;
		public List<float> input = new List<float>() { 0.1f, 0.5f, -0.3f, 0.6f };
		public List<float> errorInput = new List<float>() { 0.5f, 1f, -0.1f, 1f};
		[TestInitialize]
		public void SetUp()
		{
			neurons = new List<Neuron<string>>();
			neurons.Add(new Neuron<string>(new Vec3(), "Hello", input));
			neurons.Add(new Neuron<string>(new Vec3(10, 10, 0), "No Hello", errorInput));
		}
		[TestMethod]
		public void TestActive()
		{
			Assert.IsTrue(neurons[0].Active(input).Power < neurons[1].Active(input).Power);
		}
		[TestMethod]
		public void TestTrain()
		{
			for (var i = 0; i < 20; i++)
			{
				neurons[0].Train("hello", errorInput, 1, 0.1f).Active(errorInput);
				neurons[0].Reset();
			}

			Assert.IsFalse(neurons[0].Active(input).Power < neurons[1].Active(input).Power);
		}
	}
}
