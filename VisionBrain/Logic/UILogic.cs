using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase = FuckingNeuralNetwork.Neural.DataBase<string>;
using Project = FuckingNeuralNetwork.Neural.Project<string>;

namespace VisionBrain.Logic
{
	public class UILogic
	{
		public UIView View { get; set; }
		public UILogic()
		{
			View = new UIView();
		}
		public void CreateProject(FuckingNeuralNetwork.Neural.Project<String> project)
		{
			int id = Project.Create(project);
			if (id != -1)
				View.Projects.AddItem(project.Name);
		}
		public void DeleteProject(FuckingNeuralNetwork.Neural.Project<String> project)
		{
			DataBase.Instance.DeleteProject(project.Id);

			View.Projects.DeleteItem(project.Name);
		}
	}
}
