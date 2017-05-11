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
using System.IO;

namespace VisionBrain.Windows
{
	/// <summary>
	/// Логика взаимодействия для WindowCreateDBConnectins.xaml
	/// </summary>
	public partial class WindowCreateDBConnectins : Window
	{
		private Logic.UILogic Logic;
		public WindowCreateDBConnectins(Logic.UILogic logic)
		{
			this.Logic = logic;
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			CheckConnection(GetStringConnection());
		}

		public void CreateConnection(String text)
		{
			if (CheckConnection(text))
			{
				try {
					String jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(text);

					using (Stream stream = new FileStream(@"Data\dbs\" + TextName.Text, FileMode.Create))
					{
						StreamWriter writer = new StreamWriter(stream);
						writer.Write(jsonString);
						writer.Close();
					}

					Logic.View.ListDBs.LoadDBs();
					this.Close();
				} catch (Exception ex) {
					MessageBox.Show("ERROR: " + ex.Message);
				}
			}
		}

		public String GetStringConnection()
		{
			return @"Data Source=" + TextDataSource.Text + ";AttachDbFilename=" + TextAttachDb.Text + ";Initial Catalog=" + TextInitialCatalog.Text + ";Integrated Security=" + CBSecurity.Text + "";
		}

		public bool CheckConnection(String text)
		{
			FuckingNeuralNetwork.Neural.DataBase<String>.SetStringConnection(text);

			try
			{
				FuckingNeuralNetwork.Neural.DataBase<String>.Instance.Open();
				FuckingNeuralNetwork.Neural.DataBase<String>.Instance.CloseLast();

				MessageBox.Show("OK");
				return true;
			} catch (Exception ex)
			{
				MessageBox.Show("ERROR: " + ex.Message);
			}
			return false;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			CreateConnection(GetStringConnection());
		}
	}
}
