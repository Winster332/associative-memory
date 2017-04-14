using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Project<T> : IObjectDataBase<Project<T>>
	{
		public int Id { get; set; }
		public String Name { get; set; }
		public int SettingsId { get; set; }
		public int[] NetIds { get; set; }

		public Project()
		{
			Id = -1;
			Name = "NONE";
			SettingsId = -1;
			NetIds = null;
		}

		public Project(String name, int settingsId, int[] netIds)
		{
			this.Id = -1;
			this.Name = name;
			this.SettingsId = settingsId;
			this.NetIds = netIds;
		}

		public Project<T> Save()
		{
			DataBase<T>.Instance.UpdateProject(this);
			return this;
		}

		public Project<T> Delete()
		{
			DataBase<T>.Instance.DeleteProject(this.Id);
			return this;
		}

		public Project<T> Get()
		{
			var p = DataBase<T>.Instance.GetProject(this.Id);

			this.Id = p.Id;
			this.Name = p.Name;
			this.NetIds = p.NetIds;
			this.SettingsId = p.SettingsId;

			return this;
		}
		public static Project<T> Load(int id)
		{
			var n = DataBase<T>.Instance.GetProject(id);

			if (n.Id == -1)
				return null;
			else return n;
		}
		public static int Create(Project<T> project)
		{
			return DataBase<T>.Instance.InsertProject(project);
		}
	}
}
