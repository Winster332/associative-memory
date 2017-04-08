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
	public class TestFactoryArray
	{
		[TestMethod]
		public void GenerateArrayString()
		{
			List<float> arr = new List<float>() { 1,2,3 };
			String res = FactoryArray.GenericArrayString(arr);

			Assert.AreEqual("[1,2,3]", res);
		}
		[TestMethod]
		public void GetFloatArray()
		{
			var ex = new List<float> { 1, 2, 3 };
			var act = FactoryArray.GetFloatArray("[1,2,3]");

			Assert.AreEqual(3, act.Count);

			for (int i = 0; i < act.Count; i++)
				Assert.AreEqual(ex[i], act[i]);
		}
	}
}
