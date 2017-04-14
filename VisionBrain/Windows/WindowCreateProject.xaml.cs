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
using System.Windows.Shapes;

namespace VisionBrain.Windows
{
	/// <summary>
	/// Логика взаимодействия для WindowCreateProject.xaml
	/// </summary>
	public partial class WindowCreateProject : Window
	{
		private Logic.UILogic Logic { get; set; }
		public WindowCreateProject(Logic.UILogic logic)
		{
			this.Logic = logic;
			InitializeComponent();
		}

		public FuckingNeuralNetwork.Neural.Project<String> GetProject()
		{
			var project = new FuckingNeuralNetwork.Neural.Project<string>(textName.Text, -1, 
				FuckingNeuralNetwork.Neural.FactoryArray<string>.GetIntegerArray("[" + textNets.Text + "]"));
			return project;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var project = GetProject();
			Logic.CreateProject(project);
			this.Close();
		}
	}
}
