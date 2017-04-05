using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuckingNeuralNetwork.Neural;

namespace UnitTestProject.Neural
{
	[TestClass]
	public class TestVec3
	{
		public Vec3 vec;
		[TestInitialize]
		public void SetUp()
		{
			vec = new Vec3(10, 15, -5);
		}
		[TestMethod]
		public void Plus()
		{
			Logger.Run(() =>
			{
				Vec3 v = new Vec3(10, 5, 25);
				Vec3 result = v + vec;
				Assert.AreEqual(new Vec3(20, 20, 20), result);
			});
		}
		[TestMethod]
		public void PlusScalar()
		{
			vec += 10;
			Assert.AreEqual(new Vec3(20, 25, 5), vec);
		}
		[TestMethod]
		public void Negative()
		{
			Vec3 v = new Vec3(10, 15, -5);
			Vec3 result = v - vec;

			Assert.AreEqual(new Vec3(), result);
		}
		[TestMethod]
		public void NegativeScalar()
		{
			vec -= 10;

			Assert.AreEqual(new Vec3(0, 5, -15), vec);
		}
		[TestMethod]
		public void MultiplyVec2()
		{
			Vec3 v = new Vec3(100, 100, 100);
			Vec3 result = v * vec;

			Assert.AreEqual(new Vec3(100 * 10, 100 * 15, 100 * -5), result);
		}
		[TestMethod]
		public void MultiplyScalar()
		{
			Vec3 result = vec * 2;

			Assert.AreEqual(new Vec3(20, 30, -10), result);

		}
		[TestMethod]
		public void Division()
		{
			Vec3 v = new Vec3(100, 100, 100);
			Vec3 result = v / vec;

			Assert.AreEqual(100 / 10, result.X);
			Assert.AreEqual(100 / 15, result.Y, 1);
			Assert.AreEqual(100 / -5, result.Z);
		}
		[TestMethod]
		public void DividionScalar()
		{
			Vec3 result = vec / 2;

			Assert.AreEqual(new Vec3(10 / 2, (float)15 / 2, (float)-5 / 2), result);
		}
		[TestMethod]
		public void GetDistance()
		{
			float distance = vec.GetDistance(new Vec3(10, 15, -6));
			Console.WriteLine(distance);
		}
	}
}
