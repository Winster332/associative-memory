using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisionBrain.Data;

namespace UnitTestProject.Data
{
	[TestClass]
	public class TestDataBase
	{
		[TestInitialize]
		public void SetUp()
		{

		}
		[TestMethod]
		public void Connection()
		{
			bool isConnected = false;
			try
			{
				DataBase.Instance.Connection.Open();
				DataBase.Instance.Connection.Close();
				isConnected = true;
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
				isConnected = false;
			}
			Assert.IsTrue(isConnected);
		}
	}
}
