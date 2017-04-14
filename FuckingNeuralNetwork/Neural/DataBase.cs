using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataColor = FuckingNeuralNetwork.Neural.DataColor;
 
namespace FuckingNeuralNetwork.Neural
{
	public class DataBase<T>
	{
		public static DataBase<T> Instance
		{
			get
			{
				if (_instance == null)
					_instance = new DataBase<T>();
				return _instance;
			}
			private set { _instance = value; }
		}

		public void UpdateProject(Project<T> project)
		{
			Open();

			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[updateProject]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = project.Id;
			cmd.Parameters.Add("@name", SqlDbType.Text).Value = project.Name;
			cmd.Parameters.Add("@settingsId", SqlDbType.Int).Value = project.SettingsId;
			cmd.Parameters.Add("@netIds", SqlDbType.Text).Value = FactoryArray<String>.GenericArrayString(project.NetIds);

			var reader = cmd.ExecuteNonQuery();
			CloseLast();
		}
		public void DeleteProject(int id)
		{
			Open();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[deleteProject]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
			cmd.ExecuteNonQuery();
			CloseLast();
		}
		public Project<T> GetProject(int id)
		{
			Open();
			var p = new Project<T>();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getProjects]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				p.Id = reader.GetInt32(0);
				p.Name = reader.GetString(1);
				p.SettingsId = reader.GetInt32(2);
				p.NetIds = FactoryArray<T>.GetIntegerArray(reader.GetString(3));
			}
			CloseLast();
			return p;
		}
		public List<Project<T>> GetProjects()
		{
			var list = new List<Project<T>>();
			Open();

			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getAllProjects]";

			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				Project<T> project = new Project<T>();
				project.Id = reader.GetInt32(0);
				project.Name = reader.GetString(1);
				project.SettingsId = reader.GetInt32(2);
				project.NetIds = FactoryArray<String>.GetIntegerArray(reader.GetString(3));

				list.Add(project);
			}
			CloseLast();
			return list;
		}
		public int InsertProject(Project<T> project)
		{
			var newId = -1;
			Open();

			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertProject]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = project.Id; 
			cmd.Parameters.Add("@name", SqlDbType.Text).Value = project.Name;
			cmd.Parameters.Add("@settingsId", SqlDbType.Int).Value = project.SettingsId;
			cmd.Parameters.Add("@netIds", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(project.NetIds);

			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			CloseLast();

			return newId;
		}

		private static DataBase<T> _instance;
		public PoolConnection Pool { get; set; }
		private String stringConnection = @"Data Source=(localdb)\ProjectsV12;AttachDbFilename=C:\Users\stas-\AppData\Local\Microsoft\VisualStudio\SSDT\Associative-Memory\NeuralDatabase.mdf;Initial Catalog=NeuralDatabase;Integrated Security=True";

		private DataBase()
		{
			this.Pool = new PoolConnection(stringConnection);
		}
	
		public void Open()
		{
			Pool.Open(stringConnection);
		}
		public void CloseLast()
		{
			Pool.Close(Pool.LastConnection);
		}
		#region Neuron
		public int InsertNeuron(Neuron<T> neuron)
		{
			var newId = -1;
			Open();

			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertNeuron]";
			cmd.Parameters.Add("@weights", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(neuron.Weight);
			cmd.Parameters.Add("@neuronData", SqlDbType.Text).Value = neuron.Data;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = neuron.Radius;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = neuron.Color.ToString();
			cmd.Parameters.Add("@x", SqlDbType.Float).Value = neuron.X;
			cmd.Parameters.Add("@y", SqlDbType.Float).Value = neuron.Y;
			cmd.Parameters.Add("@z", SqlDbType.Float).Value = neuron.Z;
			cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(neuron.Synapses);
			
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			CloseLast();

			return newId;
		}
		public void UpdateNeuron(Neuron<T> neuron)
		{
			Open();

            var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[updateNeuron]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = neuron.Id;
			cmd.Parameters.Add("@weights", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(neuron.Weight);
			cmd.Parameters.Add("@neuronData", SqlDbType.Text).Value = neuron.Data;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = neuron.Radius;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = neuron.Color.ToString();
			cmd.Parameters.Add("@x", SqlDbType.Float).Value = neuron.X;
			cmd.Parameters.Add("@y", SqlDbType.Float).Value = neuron.Y;
			cmd.Parameters.Add("@z", SqlDbType.Float).Value = neuron.Z;
			cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(neuron.Synapses);
			
			var reader = cmd.ExecuteNonQuery();
			CloseLast();
		}
		public void DeleteNeuron(Neuron<T> neuron)
		{
			Open();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[deleteNeuron]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = neuron.Id;
			cmd.ExecuteNonQuery();
			CloseLast();
		}
		public Neuron<T> GetNeuron(int id)
		{
			Open();
			var n = new Neuron<T>();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getNeuron]";
			cmd.Parameters.Add("@findId", SqlDbType.Int).Value = id;

			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				var aColor = FactoryArray<T>.GetFloatArray(reader.GetString(4));
                n.Id = reader.GetInt32(0);
				n.Weight = FactoryArray<T>.GetFloatArray(reader.GetString(1));
				n.Data = reader.GetFieldValue<T>(2);//.GetString(2);
				n.Radius = (float)reader.GetDouble(3);
				n.Color = new DataColor((int)aColor[0], (int)aColor[1], (int)aColor[2], (int)aColor[3]);
				n.X = (float)reader.GetDouble(5);
				n.Y = (float)reader.GetDouble(6);
				n.Z = (float)reader.GetDouble(7);
				n.Synapses = FactoryArray<T>.GetSynapses(reader.GetString(8));
			}
			CloseLast();
			return n;
		}
		#endregion
		#region Synapse
		public int InsertSynapse(Synapse<T> synapse)
		{
			Open();

			var type = 0;
			switch(synapse.TypeIO)
			{
				case Synapse<T>.TYPE_IO.None: type = 0; break;
				case Synapse<T>.TYPE_IO.Input: type = 1; break;
				case Synapse<T>.TYPE_IO.Output: type = 2; break;
			}
			var newId = -1;
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertSynapse]";
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = synapse.Color.ToString();

			if (synapse.OutputNeuron != null)
				cmd.Parameters.Add("@fromId", SqlDbType.Int).Value = synapse.OutputNeuron.Id;
			else cmd.Parameters.Add("@fromId", SqlDbType.Int).Value = -1;
			if (synapse.InputNeuron != null)
				cmd.Parameters.Add("@toId", SqlDbType.Int).Value = synapse.InputNeuron.Id;
			else cmd.Parameters.Add("@toId", SqlDbType.Int).Value = -1;

			cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
			cmd.Parameters.Add("@Threshold", SqlDbType.Float).Value = synapse.Threshold;

			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}

			CloseLast();
			return newId;
		}
		public void UpdateSynapse(Synapse<T> synapse)
		{
			Open();
			var type = 0;
			switch (synapse.TypeIO)
			{
				case FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.None: type = 0; break;
				case FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.Input: type = 1; break;
				case FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.Output: type = 2; break;
			}
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[updateSynapse]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = synapse.Id;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = synapse.Color.ToString();
			cmd.Parameters.Add("@fromId", SqlDbType.Int).Value = synapse.OutputNeuron.Id;
			cmd.Parameters.Add("@toId", SqlDbType.Int).Value = synapse.InputNeuron.Id;
			cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
			cmd.Parameters.Add("@Threshold", SqlDbType.Float).Value = synapse.Threshold;

			cmd.ExecuteNonQuery();

			CloseLast();
		}
		public void DeleteSynapse(Synapse<T> synapse)
		{
			Open();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[deleteSynapse]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = synapse.Id;
			cmd.ExecuteNonQuery();
			CloseLast();
		}
		public Synapse<T> GetSynapse(int id)
		{
			var connection = Pool.Open(stringConnection);
			var n = new Synapse<T>();
			var cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getSynapse]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				var aColor = FactoryArray<T>.GetFloatArray(reader.GetString(5));
				n.Id = reader.GetInt32(0);
				n.Color = new DataColor((int)aColor[0], (int)aColor[1], (int)aColor[2], (int)aColor[3]);
				n.InputNeuron = Neuron<T>.Load(reader.GetInt32(2));
				n.OutputNeuron = Neuron<T>.Load(reader.GetInt32(1));

				switch(reader.GetInt32(3))
				{
					case 0: n.TypeIO = FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.None; break;
					case 1: n.TypeIO = FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.Input; break;
					case 2: n.TypeIO = FuckingNeuralNetwork.Neural.Synapse<T>.TYPE_IO.Output; break;
				}

				n.Threshold = (float)reader.GetDouble(4);
				n.Color = new DataColor((int)aColor[0], (int)aColor[1], (int)aColor[2], (int)aColor[3]);
			}
			Pool.Close(Pool.Connections[Pool.Connections.Count-1]);

			return n;
		}
		#endregion
		#region Net
		public int InsertNet(Net<T> net)
		{
			Open();
			var newId = -1;
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertNet]";
			cmd.Parameters.Add("@name", SqlDbType.Text).Value = net.Name;
			cmd.Parameters.Add("@neuronIds", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(net.Neurons);

			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}

			CloseLast();
			return newId;
		}
		public void DeleteNet(Net<T> net)
		{
			Open();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[deleteNet]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = net.Id;
			cmd.ExecuteNonQuery();
			CloseLast();
		}
		public void UpdateNet(Net<T> net)
		{
			Open();
			var cmd = Pool.LastConnection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[updateNet]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = net.Id;
			cmd.Parameters.Add("@name", SqlDbType.Text).Value = net.Name;
			cmd.Parameters.Add("@ids", SqlDbType.Text).Value = FactoryArray<T>.GenericArrayString(net.Neurons);

			cmd.ExecuteNonQuery();

			CloseLast();
		}
		public Net<T> GetNet(int id)
		{
			var connection = Pool.Open(stringConnection);
			Net<T> net = new Net<T>();
			var cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getNet]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				net.Id = reader.GetInt32(0);
				net.Name = reader.GetString(2);
				net.Neurons = FactoryArray<T>.GetNeurons(reader.GetString(1));
			}

			Pool.Close(connection);
			return net;
		}
		#endregion
		//	public int InsertProject(Project project)
		//	{
		//		var newId = -1;
		//		var cmd = Connection.CreateCommand();
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.CommandText = "[NeuralDatabase].[dbo].[insertProject]";
		//		//cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = neuron.Synapses.ToString();

		//		Connection.Open();
		//		var reader = cmd.ExecuteReader();
		//		while (reader.Read())
		//		{
		//			newId = reader.GetInt32(0);
		//		}
		//		Connection.Close();

		//		return newId;
		//	}
		//	public void UpdateProject(Project project)
		//	{

		//	}
		//	public void DeleteProject(Project project)
		//	{

		//	}
		//	public Project GetProject(int id)
		//	{
		//		return null;
		//	}
		//	public Project[] GetAllProjects()
		//	{
		//		return null;
		//	}
	}
}
