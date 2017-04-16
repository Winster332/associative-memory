using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisionBrain.UI
{
	/// <summary>
	/// Логика взаимодействия для LayoutProjects.xaml
	/// </summary>
	public partial class LayoutProjects : UserControl
	{
		public Logic.UILogic Logic { get; set; }
		public LayoutProjects()
		{
			InitializeComponent();

			FuckingNeuralNetwork.Neural.DataBase<string>.Instance.GetProjects().ForEach(p => AddItem(p.Name));

			listBox.MouseDoubleClick += (o, ee) =>
			{
				Windows.WindowWorkspace window = new Windows.WindowWorkspace(Logic, GetActiveProject());
				Logic.View.WindowWorkspace = window;
				window.Show();
				Logic.View.MainWindow.Close();

			};
		}
		public void OpenProject(String name)
		{

		}

		public void AddItem(String name)
		{
			ListBoxItem itme = new ListBoxItem();
			itme.Content = name;
			listBox.Items.Add(name);
		}

		public void DeleteItem(String name)
		{
			for (int i = 0; i < listBox.Items.Count; i++)
				if ((listBox.Items[i]).ToString().Equals(name))
					listBox.Items.RemoveAt(i);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var window = new Windows.WindowCreateProject(Logic);
			window.ShowDialog();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			var project = GetActiveProject();
			Logic.DeleteProject(project);
		}

		public FuckingNeuralNetwork.Neural.Project<String> GetActiveProject()
		{
			var item = listBox.SelectedItem;
			var projects = FuckingNeuralNetwork.Neural.DataBase<String>.Instance.GetProjects();
			FuckingNeuralNetwork.Neural.Project<string> project = null;
			projects.ForEach(p =>
			{
				if (p.Name.Equals(item.ToString()))
					project = p;
			});
			return project;
		}
	}
}
