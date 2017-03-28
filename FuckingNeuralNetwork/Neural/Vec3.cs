using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Vec3
	{
		public float X { get; set; }
		public float Y { get; set; }
		public float Z { get; set; }
		public Vec3()
		{
			this.X = 0;
			this.Y = 0;
			this.Z = 0;
		}
		public Vec3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
		public Vec3(Vec3 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
		}
		public static Vec3 operator+(Vec3 d, Vec3 v)
		{
			return new Vec3(d.X + v.X, d.Y + v.Y, d.Z + v.Z);
		}
		public static Vec3 operator-(Vec3 d, Vec3 v)
		{
			return new Vec3(d.X - v.X, d.Y - v.Y, d.Z - v.Z);
		}
		public static Vec3 operator/(Vec3 d, Vec3 v)
		{
			return new Vec3(d.X / v.X, d.Y / v.Y, d.Z / v.Z);
		}
		public static Vec3 operator *(Vec3 d, Vec3 v)
		{
			return new Vec3(d.X * v.X, d.Y * v.Y, d.Z * v.Z);
		}
		public static Vec3 operator *(Vec3 v, float s)
		{
			v.X *= s;
			v.Y *= s;
			v.Z *= s;

			return v;
		}
		public static Vec3 operator /(Vec3 v, float s)
		{
			v.X /= s;
			v.Y /= s;
			v.Z /= s;

			return v;
		}
		public static Vec3 operator +(Vec3 v, float s)
		{
			v.X += s;
			v.Y += s;
			v.Z += s;

			return v;
		}
		public static Vec3 operator -(Vec3 v, float s)
		{
			v.X -= s;
			v.Y -= s;
			v.Z -= s;

			return v;
		}
        public float GetDistance(Vec3 vec)
		{
			return (float)Math.Sqrt(Math.Pow(this.X - vec.X, 2) + Math.Pow(this.Y - vec.Y, 2) + Math.Pow(this.Z - vec.Z, 2));
		}
		public override bool Equals(object obj)
		{
			if (typeof(Vec3) != obj.GetType())
				return false;

			Vec3 v = (Vec3)obj;
			return v.X == this.X && v.Y == this.Y && v.Z == this.Z;
		}
		public override string ToString()
		{
			return "x[" + X + "] y[" + Y + "] z[" + Z + "]";
		}
	}
}
