# Neural network platform
## This project is designed for convenient work with the associative neural network. The work is done with the help of the library of Neural Network, the client application on the WPF and the database of the MS SQL Server.

# How it works
## With the help of the external library of Neural Network, you can work directly with the neural network. This library uses an WPF application that is linked to a database. The client application combines a debugger, editor and visualizer of a neural network.

# Project structure
```
Project
|--AssociativeMemory--+
|                     |--Neural--+
|                                |--Neuron(C)
|                                |--Synapse(C)
|                                |--Net(C)
|                                |--Vec3(C)
|				 |--DataBase(C)
|				 |--DataColor(C)
|				 |--FactoryArray(C)
|				 |--IObjectDataBase(I)
|				 |--PoolConnection(C)
|                                +--AnalysNet(C)
|--VisionBrain--+
|		|--Data--+
|			 +--Project(C)
|               |--UI--+
|               |      |--LayoutProject(XML, C)
|               |      |--LeftBarContent(XML, C)
|               |      |--SmallInformPanel(XML, C)
|               |      +--TopBar(XML, C)
|               |--App(XML, C)
|               +--MainWindow(XML, C)
+--NeuralDatabase--+
                   |--Tables--+
                   |          |--Net(Id, NeuronId, SynapseId)
                   |          |--Neuron(Id, Weight, Data)
                   |          |--Synapse(Id, FromId, ToId, Type, Threshold)
                   |          +--Projects(Id, Name, Path, CountNeurons, CountSynapses, SettingId, NetId)
                   +--Stored procedures--+
					 |--deleteNet
                                         |--deleteNeuron
                                         |--deleteSynapse
                                         |--getNet
                                         |--getNeuron
                                         |--getSynapse
                                         |--getProjects
                                         |--insertNeuron
                                         |--insertSynapse
                                         |--insertProject
                                         |--insertNet
                                         |--updateNet
                                         |--updateNeuron
                                         +--updateSynapse
```
## Example
``

    public List<Neuron<String>> neurons;
		public List<float> input = new List<float>() { 0.1f, 0.5f, -0.3f, 0.6f };
		public List<float> errorInput = new List<float>() { 0.5f, 1f, -0.1f, 1f};
    
    public void Main(String[] args)
    {
      SetUp();
      Train();
      Actice();
      
      Console.ReadKey();
    }
		public void SetUp()
		{
			neurons = new List<Neuron<string>>();
			neurons.Add(new Neuron<string>(new Vec3(), "Hello", input));
			neurons.Add(new Neuron<string>(new Vec3(10, 10, 0), "No Hello", errorInput));
		}
		public void Active()
		{
			Console.WriteLine("neuron1[{0}], neuron2[{1}]", neurons[0].Active(input).Power, neurons[1].Active(input).Power);
		}
		public void Train()
		{
			for (var i = 0; i < 20; i++)
			{
				neurons[0].Train("hello", errorInput, 1, 0.1f).Active(errorInput);
				neurons[0].Reset();
			}

			Console.WriteLine(neurons[0].Active(input).Power < neurons[1].Active(input).Power);
		}
  ``
# Future plans
## Develop an intelligent, flexible and powerful system based on a neural network. This project is aimed at simulating the work of individual parts of the brain, testing and debugging.
