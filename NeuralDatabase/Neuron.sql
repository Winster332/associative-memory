CREATE TABLE [dbo].[Neuron]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Weights] TEXT NULL, 
    [Data] TEXT NULL, 
    [Radius] FLOAT NULL, 
    [Color] TEXT NULL, 
    [X] FLOAT NULL, 
    [Y] FLOAT NULL, 
    [Z] FLOAT NULL, 
    [Synapses] TEXT NULL
)
