﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckingNeuralNetwork.Neural
{
	public class Neuron<NData> : Vec3
	{
		public virtual List<Synapse<NData>> Synapses { get; set; } = new List<Synapse<NData>>();
		public List<float> Weight { get; set; } = new List<float>();
		public float Power { get; set; } = 0;
		public NData Data { get; set; }
		public float Radius { get; set; }
		public int Id { get; set; }

		public Neuron(Vec3 position, NData data, List<float> weight) : base(position)
		{
			this.Id = -1;
			this.Data = data;
			this.Weight = weight;
			this.Radius = 1;
		}

		public Neuron(Vec3 position, int id, float radius, NData data, int lengthWeight, float valueWeight) : base(position)
		{
			this.Radius = radius;
			this.Id = id;
			this.Data = data;
			for (var i = 0; i < lengthWeight; i++)
				Weight.Add(valueWeight);
		}

		public Neuron<NData> Train(NData data, List<float> input, float desired, float velocity = 0.1f)
		{
			this.Data = data;

			for (var i = 0; i < Weight.Count; i++)
			{
				var error = input[i] * Weight[i];
				Weight[i] += error * desired *  input[i] * velocity;
			}

			return this;
		}

		public Neuron<NData> Active(List<float> input)
		{
			for (var i = 0; i < Weight.Count; i++)
			{
				Power += Weight[i] * input[i];
			}

			Synapses.ForEach(synapse =>
			{
				if (synapse.TypeIO == Synapse<NData>.TYPE_IO.Input)
					synapse.Send(DeformInput(synapse.InputNeuron.Weight, input, 1, 1));
			});
			return this;
		}

		public Neuron<NData> Reset(bool withSynapse = false)
		{
			Power = 0;

			if (withSynapse)
				Synapses.ForEach(s => s.Reset());

			return this;
		}
		public List<float> DeformInput(List<float> weight, List<float> input, float desired, float velocity)
		{
			var output = new List<float>();

			for (var i = 0; i < weight.Count; i++)
			{
				var error = input[i] * weight[i];
				output.Add(weight[i] + error * desired * input[i] * velocity);
			}

			return output;
		}
	}
}
