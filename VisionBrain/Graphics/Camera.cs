﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionBrain.Graphics
{
	public class Camera : FuckingNeuralNetwork.Neural.Vec3
	{
		public float Far { get; set; }
		public float Near { get; set; }
		public Camera()
		{

		}
	}
}
