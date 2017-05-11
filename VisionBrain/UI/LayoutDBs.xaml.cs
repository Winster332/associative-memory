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
using System.IO;

namespace VisionBrain.UI
{
	/// <summary>
	/// Логика взаимодействия для LayoutDBs.xaml
	/// </summary>
	public partial class LayoutDBs : UserControl
	{
		private String Path = @"Data\dbs\";
        public LayoutDBs()
		{
			InitializeComponent();

			this.MouseDoubleClick += (o, e) =>
			{
				String pathDB = Path + listBoxDB.SelectedItem.ToString();


			};

			LoadDBs();
		}

		public void LoadDBs()
		{
			listBoxDB.Items.Clear();
            var nameFiles = Directory.GetFiles(Path);

			foreach (var name in nameFiles)
				listBoxDB.Items.Add(name.Replace(Path, ""));
		}
	}
}
