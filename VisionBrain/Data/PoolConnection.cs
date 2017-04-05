using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace VisionBrain.Data
{
	public class PoolConnection
	{
		public List<SqlConnection> Connections { get; set; } = new List<SqlConnection>();
		public SqlConnection LastConnection { get; set; } = null;
		public PoolConnection(String stringConnection)
		{
			var connection = new SqlConnection(stringConnection);
			Connections.Add(connection);
			LastConnection = connection;
		}
		public SqlConnection Open(String stringConnection)
		{
			var connection = new SqlConnection(stringConnection);
			connection.Open();
            Connections.Add(connection);
			LastConnection = connection;
			return connection;
		}
		public void Close(SqlConnection connection)
		{
			Connections.ForEach(findConnection =>
			{
				if (findConnection.Equals(connection))
					findConnection.Close();
			});
			Connections.Remove(connection);
			LastConnection = null;
		}
		public void Close(int index)
		{
			Connections[index].Close();
			Connections.RemoveAt(index);
			LastConnection = null;
		}
		public void CloseAll()
		{
			Connections.ForEach(connection => connection.Close());
			Connections.Clear();
			LastConnection = null;
		}
	}
}
