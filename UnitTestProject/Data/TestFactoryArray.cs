using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisionBrain.Data;
using FactoryArray = FuckingNeuralNetwork.Neural.FactoryArray<string>;
using DataBase = FuckingNeuralNetwork.Neural.DataBase<string>;
using Neuron = FuckingNeuralNetwork.Neural.Neuron<string>;
using Synapse = FuckingNeuralNetwork.Neural.Synapse<string>;
using Net = FuckingNeuralNetwork.Neural.Net<string>;

namespace UnitTestProject.Data
{
	[TestClass]
	public class TestFactoryArray
	{
		[TestMethod]
		public void GenerateArrayString()
		{
			List<float> arr = new List<float>() { 1,2,3 };
			String res = FactoryArray.GenericArrayString(arr);

			Assert.AreEqual("[1,2,3]", res);
		}
		[TestMethod]
		public void GenerateArrayStringWithSynapse()
		{
			var synapses = new List<FuckingNeuralNetwork.Neural.Synapse<String>>()
			{
				new FuckingNeuralNetwork.Neural.Synapse<string>(1, new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()), FuckingNeuralNetwork.Neural.Synapse<string>.TYPE_IO.Input, 1),
				new FuckingNeuralNetwork.Neural.Synapse<string>(3, new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()), FuckingNeuralNetwork.Neural.Synapse<string>.TYPE_IO.Input, 1),
				new FuckingNeuralNetwork.Neural.Synapse<string>(2, new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new FuckingNeuralNetwork.Neural.Neuron<string>(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()), FuckingNeuralNetwork.Neural.Synapse<string>.TYPE_IO.Input, 1)
			};

			var textArray = FactoryArray.GenericArrayString(synapses);
			Assert.AreEqual("[1,3,2]", textArray);
		}
		[TestMethod]
		public void GenerateArrayStringNeuron()
		{
			List<FuckingNeuralNetwork.Neural.Neuron<String>> neurons = new List<FuckingNeuralNetwork.Neural.Neuron<String>>()
			{
				new Neuron(1, 12, new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new Neuron(4, 12, new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new Neuron(2, 12, new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
				new Neuron(3, 12, new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>()),
			};
			var textArray = FactoryArray.GenericArrayString(neurons);
			Assert.AreEqual("[1,4,2,3]", textArray);
		}
		[TestMethod]
		public void GetSynapses()
		{
			List<int> ids = new List<int>();
			ids.Add(DataBase.Instance.InsertSynapse(new Synapse()));
			ids.Add(DataBase.Instance.InsertSynapse(new Synapse()));
			ids.Add(DataBase.Instance.InsertSynapse(new Synapse()));

			String targetText = "[" + ids[0] + "," + ids[1] + "," + ids[2] + "]";
			var synapses = FactoryArray.GetSynapses(targetText);

			synapses.ForEach(s => DataBase.Instance.DeleteSynapse((Synapse)s));

			Assert.AreEqual(ids.Count, synapses.Count);

			for (int i = 0; i < ids.Count; i++)
				Assert.AreEqual(synapses[i].Id, ids[i]);
		}
		[TestMethod]
		public void GetNeurons()
		{
			List<int> ids = new List<int>();
			ids.Add(DataBase.Instance.InsertNeuron(new Neuron(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>())));
			ids.Add(DataBase.Instance.InsertNeuron(new Neuron(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>())));
			ids.Add(DataBase.Instance.InsertNeuron(new Neuron(new FuckingNeuralNetwork.Neural.Vec3(), "", new List<float>())));

			String targetText = "[" + ids[0] + "," + ids[1] + "," + ids[2] + "]";

			var neurons = FactoryArray.GetNeurons(targetText);
		
			neurons.ForEach(n => DataBase.Instance.DeleteNeuron((Neuron)n));

			Assert.AreEqual(ids.Count, neurons.Count);

			for (int i = 0; i < ids.Count; i++)
				Assert.AreEqual(neurons[i].Id, ids[i]);
		}
		[TestMethod]
		public void GetFloatArray()
		{
			var ex = new List<float> { 1, 2, 3 };
			var act = FactoryArray.GetFloatArray("[1,2,3]");

			Assert.AreEqual(3, act.Count);

			for (int i = 0; i < act.Count; i++)
				Assert.AreEqual(ex[i], act[i]);
		}
	}
}
