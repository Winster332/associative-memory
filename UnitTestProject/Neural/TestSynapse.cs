using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckingNeuralNetwork.Neural;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Neural
{
	[TestClass]
	public class TestSynapse
	{
		Synapse<String> synapse;
		Neuron<String> neuronInput;
		Neuron<String> neuronOutput;

		[TestInitialize]
		public void SetUp()
		{
			neuronInput = new Neuron<string>(new Vec3(-10, 0, 0), "one", new List<float> { 0.1f, -0.3f, 0.8f, 0.3f, -0.8f });
			neuronOutput = new Neuron<string>(new Vec3(-10, 0, 0), "two", new List<float> { 0.5f, 0.8f, -0.2f, -0.7f, 0.3f });
			neuronOutput.Active(new List<float> { 0.1f, -0.3f, 0.8f, 0.3f, -0.8f });
			neuronInput.Active(new List<float> { 0.5f, 0.8f, -0.2f, -0.7f, 0.3f });
			synapse = new Synapse<string>(-1, neuronOutput, neuronInput, Synapse<string>.TYPE_IO.Input, 0f);
		}
		[TestMethod]
		public void Send()
		{
			Assert.IsTrue(synapse.Send(new List<float> { 0.1f, -0.3f, 0.8f, 0.3f, -0.8f }).IsActive);
		}
	}
}
