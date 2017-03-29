using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FuckingNeuralNetwork.Neural;

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
		private String stringConnection = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		private DataBase()
		{
			Connection = new SqlConnection(stringConnection);
		}
		public void SaveNeuron()
		{
			
		}
	}
}
