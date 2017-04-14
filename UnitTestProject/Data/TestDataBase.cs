using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neuron = FuckingNeuralNetwork.Neural.Neuron<System.String>;
using Synapse = FuckingNeuralNetwork.Neural.Synapse<System.String>;
using Net = FuckingNeuralNetwork.Neural.Net<System.String>;
using Project = FuckingNeuralNetwork.Neural.Project<string>;
using DataColor = FuckingNeuralNetwork.Neural.DataColor;
using DataBase = FuckingNeuralNetwork.Neural.DataBase<System.String>;

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
		#region neuron
		[TestMethod]
		public void InsertNeuron()
		{
			int id = -1;
			Logger.Run(() =>
			{
				id = Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12, 32, 12, 4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3));
                Console.WriteLine(id);
			});

			Assert.AreNotEqual(-1, id);

			if (id != -1)
				Neuron.Load(id).Delete();
		}
		[TestMethod]
		public void GetNeuron()
		{
			var id = Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12, 32, 12, 4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3));
			Neuron n = null;
			Logger.Run(() =>
			{
				n = Neuron.Load(id);
				Console.WriteLine(n.ToString());
			});
			Assert.AreEqual(id, n.Id);

			if (n != null)
				n.Delete();
		}
		[TestMethod]
		public void DeleteNeuron()
		{
			var id = Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12, 32, 12, 4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3));
			Neuron neuron = null;
			Logger.Run(() =>
			{
				neuron = Neuron.Load(id);
				neuron.Delete();
			});

			Assert.IsNull(Neuron.Load(id));
		}
		[TestMethod]
		public void UpdateNeuron()
		{
			var id = Neuron.Create(new DataColor(10, 20, 30, 10), "data", 12, new List<Synapse>(), new List<float>() { 12, 32, 12, 4 }, new FuckingNeuralNetwork.Neural.Vec3(10, 10, -3));
			Neuron neuron = Neuron.Load(id);
			neuron.Color = new DataColor(12, 32, 33, 4);
			neuron.Data = "Test";
			neuron.Radius = 1.23f;
			neuron.X = 12;
			neuron.Y = 33;
			neuron.Z = 53;
			neuron.Save();

			Neuron newNeuron = Neuron.Load(neuron.Id);

			Assert.IsNotNull(newNeuron);
			Assert.AreEqual(neuron.Id, newNeuron.Id);
			Assert.AreEqual(neuron.Color.ToString(), newNeuron.Color.ToString());
			Assert.AreEqual(neuron.Data, newNeuron.Data);
			Assert.AreEqual(neuron.Radius, newNeuron.Radius);
			Assert.AreEqual(neuron.X, newNeuron.X);
			Assert.AreEqual(neuron.Y, newNeuron.Y);
			Assert.AreEqual(neuron.Z, newNeuron.Z);

			neuron.Delete();
		}
		#endregion
		#region synapse
		[TestMethod]
		public void InsertSynapse()
		{
			int id = Synapse.Create(new Synapse());

			Assert.AreNotEqual(-1, id);

			var synapse = new Synapse();
			synapse.Id = id;
			synapse.Delete();
		}
		[TestMethod]
		public void DeleteSynapse()
		{
			int id = Synapse.Create(new Synapse());
			var synapse = new Synapse();
			synapse.Id = id;
			synapse.Delete();
			var newSynapse = Synapse.Load(id);

			Assert.AreEqual(newSynapse.Id, -1);
		}
		[TestMethod]
		public void GetSynapse()
		{
			int id = Synapse.Create(new Synapse());
			var synapse = Synapse.Load(id);

			Assert.AreEqual(id, synapse.Id);
			synapse.Delete();
		}
		[TestMethod]
		public void UpdateSynapse()
		{
			Neuron neuron1 = Neuron.Load(Neuron.Create(new Neuron(new FuckingNeuralNetwork.Neural.Vec3(), 34, 21, "Fuck all", 121, 34)));
			Neuron neuron2 = Neuron.Load(Neuron.Create(new Neuron(new FuckingNeuralNetwork.Neural.Vec3(), 12, 122, "Fuck world", 93, 12)));

			int id = Synapse.Create(new Synapse());
			var synapse = Synapse.Load(id);
			synapse.Color = new DataColor(1,2,3,4);
			synapse.Threshold = 21;
			synapse.TypeIO = FuckingNeuralNetwork.Neural.Synapse<string>.TYPE_IO.Output;
			synapse.InputNeuron = neuron1;
			synapse.OutputNeuron = neuron2;
			synapse.Save();

			var newSynapse = Synapse.Load(synapse.Id);

			Assert.IsNotNull(newSynapse);
			Assert.AreEqual(synapse.Id, newSynapse.Id);
			Assert.AreEqual(synapse.Color.ToString(), newSynapse.Color.ToString());
			Assert.AreEqual(synapse.InputNeuron.Id, newSynapse.InputNeuron.Id);
			Assert.AreEqual(synapse.OutputNeuron.Id, newSynapse.OutputNeuron.Id);
			Assert.AreEqual(synapse.Threshold, newSynapse.Threshold);
			Assert.AreEqual(synapse.TypeIO, newSynapse.TypeIO);

			synapse.Delete();

			neuron1.Delete();
			neuron2.Delete();
		}
		#endregion
		#region net
		[TestMethod]
		public void InsertNet()
		{
			int id = Net.Create(new Net("one net test", new List<FuckingNeuralNetwork.Neural.Neuron<String>>
			{
				new Neuron(21, 23, new FuckingNeuralNetwork.Neural.Vec3(12,39,43), "16", new List<float>()),
				new Neuron(12, 312, new FuckingNeuralNetwork.Neural.Vec3(2,73,22), "14", new List<float>()),
				new Neuron(25, 212, new FuckingNeuralNetwork.Neural.Vec3(32,53,12), "12", new List<float>())
			}));
			var net = Net.Load(id);

			Assert.IsNotNull(net);
			Assert.AreEqual(id, net.Id);

			net.Delete();
		}
		[TestMethod]
		public void DeleteNet()
		{
			int id = Net.Create(new Net("one net test", new List<FuckingNeuralNetwork.Neural.Neuron<String>>
			{
				new Neuron(21, 23, new FuckingNeuralNetwork.Neural.Vec3(12,39,43), "16", new List<float>()),
				new Neuron(12, 312, new FuckingNeuralNetwork.Neural.Vec3(2,73,22), "14", new List<float>()),
				new Neuron(25, 212, new FuckingNeuralNetwork.Neural.Vec3(32,53,12), "12", new List<float>())
			}));
			var net = Net.Load(id);

			net.Delete();

			var newNet = Net.Load(net.Id);
			Assert.AreEqual(-1, newNet.Id);
		}
		[TestMethod]
		public void UpdateNet()
		{
			var net = new Net("one net test", new List<FuckingNeuralNetwork.Neural.Neuron<String>>
			{
				new Neuron(21, 23, new FuckingNeuralNetwork.Neural.Vec3(12,39,43), "16", new List<float>()),
				new Neuron(12, 312, new FuckingNeuralNetwork.Neural.Vec3(2,73,22), "14", new List<float>()),
				new Neuron(25, 212, new FuckingNeuralNetwork.Neural.Vec3(32,53,12), "12", new List<float>())
			});
			int id = Net.Create(net);
			net.Id = id;
			net.Name = "other test";
			net.Save();

			var netNew = Net.Load(net.Id);

			Assert.IsNotNull(netNew);
			Assert.AreEqual(id, netNew.Id);
			Assert.AreEqual(net.Name, netNew.Name);
			Assert.AreEqual(net.Neurons.Count, netNew.Neurons.Count);

			net.Delete();
		}
		[TestMethod]
		public void GetNet()
		{
			var net = new Net("one net test", new List<FuckingNeuralNetwork.Neural.Neuron<String>>
			{
				new Neuron(21, 23, new FuckingNeuralNetwork.Neural.Vec3(12,39,43), "16", new List<float>()),
				new Neuron(12, 312, new FuckingNeuralNetwork.Neural.Vec3(2,73,22), "14", new List<float>()),
				new Neuron(25, 212, new FuckingNeuralNetwork.Neural.Vec3(32,53,12), "12", new List<float>())
			});
            int id = Net.Create(net);
			var netNew = Net.Load(id);

			Assert.IsNotNull(net);
			Assert.AreEqual(id, netNew.Id);
			Assert.AreEqual(net.Name, netNew.Name);
			Assert.AreEqual(net.Neurons.Count, netNew.Neurons.Count);

			net.Delete();
		}
		#endregion
		#region project
		[TestMethod]
		public void InsertProject()
		{
			var project = Project.Load(Project.Create(new FuckingNeuralNetwork.Neural.Project<string>("First project test", 1, new int[] { 2,3 })));

			Assert.AreNotEqual(-1, project.Id);
			project.Delete();
		}
		[TestMethod]
		public void UpdateProject()
		{
			var project = Project.Load(Project.Create(new FuckingNeuralNetwork.Neural.Project<string>("First project test", 1, new int[] { 2, 3 })));
			project.Name = "new name";
			project.NetIds = new int[] { 2, 4 };
			project.Save();
			var newProject = Project.Load(project.Id);

			Assert.AreEqual(project.Id, newProject.Id);
			Assert.AreEqual(project.Name, newProject.Name);
			Assert.AreEqual(project.NetIds.Length, newProject.NetIds.Length);

			project.Delete();
		}
		#endregion
	}
}
