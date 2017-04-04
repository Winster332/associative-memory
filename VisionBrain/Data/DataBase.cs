using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VisionBrain.Data
{
	public class DataBase
	{
		public static DataBase Instance
		{
			get
			{
				if (_instance == null)
					_instance = new DataBase();
				return _instance;
			}
			private set { _instance = value; }
		}
		private static DataBase _instance;
		public SqlConnection Connection { get; set; }
		private String stringConnection = @"Data Source=(localdb)\ProjectsV12;AttachDbFilename=C:\Users\stas-\AppData\Local\Microsoft\VisualStudio\SSDT\Associative-Memory\NeuralDatabase.mdf;Initial Catalog=NeuralDatabase;Integrated Security=True";
		private DataBase()
		{
			Connection = new SqlConnection(stringConnection);
		}
		public int InsertNeuron(Neuron neuron)
		{
			var newId = -1;
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertNeuron]";
			cmd.Parameters.Add("@weights", SqlDbType.Text).Value = neuron.Weight.ToArray().ToString();
			cmd.Parameters.Add("@neuronData", SqlDbType.Text).Value = neuron.Data;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = neuron.Radius;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = neuron.Color.ToString();
			cmd.Parameters.Add("@x", SqlDbType.Float).Value = neuron.X;
			cmd.Parameters.Add("@y", SqlDbType.Float).Value = neuron.Y;
			cmd.Parameters.Add("@z", SqlDbType.Float).Value = neuron.Z;
			cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = neuron.Synapses.ToString();

			Connection.Open();
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			Connection.Close();

			return newId;
		}
		public void UpdateNeuron(Neuron neuron)
		{
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[updateNeuron]";
			cmd.Parameters.Add("@weights", SqlDbType.Text).Value = neuron.Weight.ToArray().ToString();
			cmd.Parameters.Add("@neuronData", SqlDbType.Text).Value = neuron.Data;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = neuron.Radius;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = neuron.Color.ToString();
			cmd.Parameters.Add("@x", SqlDbType.Float).Value = neuron.X;
			cmd.Parameters.Add("@y", SqlDbType.Float).Value = neuron.Y;
			cmd.Parameters.Add("@z", SqlDbType.Float).Value = neuron.Z;
			cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = neuron.Synapses.ToString();

			Connection.Open();
			var reader = cmd.ExecuteNonQuery();
			Connection.Close();
		}
		public void DeleteNeuron(Neuron neuron)
		{
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[deleteNeuron]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = neuron.Id;

			Connection.Open();
			var reader = cmd.ExecuteNonQuery();
			Connection.Close();
		}
		public Neuron GetNeuron(int id)
		{
			var n = new Neuron(null, "", null);
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[getNeuron]";
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

			Connection.Open();
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				// TODO: getter
			}
			Connection.Close();
			return n;
		}
		public int InsertSynapse(Synapse synapse)
		{
			var newId = -1;
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[synapseNeuron]";
			cmd.Parameters.Add("@fromId", SqlDbType.Text).Value = synapse.OutputNeuron.Id;
			cmd.Parameters.Add("@toId", SqlDbType.Text).Value = synapse.InputNeuron.Id;
			cmd.Parameters.Add("@type", SqlDbType.Float).Value = synapse.TypeIO;
			cmd.Parameters.Add("@Threshold", SqlDbType.Text).Value = synapse.Threshold;

			Connection.Open();
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			Connection.Close();

			return newId;
		}
		public void UpdateSynapse(Synapse synapse)
		{

		}
		public void DeleteSynapse(Synapse synapse)
		{

		}
		public Synapse GetSynapse(int id)
		{
			return null;
		}
		public int InsertNet(Net net)
		{
			var newId = -1;
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[inserNet]";
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = net.Id;
			cmd.Parameters.Add("@name", SqlDbType.Text).Value = net.Name;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = net.Neurons;

			Connection.Open();
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			Connection.Close();

			return newId;
		}
		public void DeleteNet(Net net)
		{
		}
		public void UpdateNet(Net net)
		{
		}
		public Net GetNet(int id)
		{
			return null;
		}
		public void InsertProject(Project project)
		{
			var newId = -1;
			var cmd = Connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[NeuralDatabase].[dbo].[insertProject]";
			cmd.Parameters.Add("@weights", SqlDbType.Text).Value = neuron.Weight.ToArray().ToString();
			cmd.Parameters.Add("@neuronData", SqlDbType.Text).Value = neuron.Data;
			cmd.Parameters.Add("@radius", SqlDbType.Float).Value = neuron.Radius;
			cmd.Parameters.Add("@color", SqlDbType.Text).Value = neuron.Color.ToString();
			cmd.Parameters.Add("@x", SqlDbType.Float).Value = neuron.X;
			cmd.Parameters.Add("@y", SqlDbType.Float).Value = neuron.Y;
			cmd.Parameters.Add("@z", SqlDbType.Float).Value = neuron.Z;
			cmd.Parameters.Add("@synaoses", SqlDbType.Text).Value = neuron.Synapses.ToString();

			Connection.Open();
			var reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				newId = reader.GetInt32(0);
			}
			Connection.Close();

			return newId;
		}
		public void UpdateProject(Project project)
		{

		}
		public void DeleteProject(Project project)
		{

		}
		public Project GetProject(int id)
		{
			return null;
		}
		public Project[] GetAllProjects()
		{
			return null;
		}
		public void InsertSetUpApp()
		{

		}
		public void UpdateSetUpApp()
		{

		}
		public void DeleteSetUp()
		{

		}
		public SetUpApp GetSetUp(int id)
		{
			return null;
		}
	}
}
