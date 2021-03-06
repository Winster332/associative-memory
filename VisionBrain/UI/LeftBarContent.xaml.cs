﻿using System;
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
	/// Логика взаимодействия для LeftBarContent.xaml
	/// </summary>
	public partial class LeftBarContent : UserControl
	{
		public LeftBarContent()
		{
			InitializeComponent();
		}

		public ListBoxItem AddItem(String text, bool enable = true)
		{
			ListBoxItem Content = new ListBoxItem();
			Content.Content = text;
			Content.IsEnabled = enable;
			listBox.Items.Add(Content);
			return Content;
		}

		private void ListBoxItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
		}
	}
}
