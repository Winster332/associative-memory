CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NULL, 
    [Path] TEXT NULL, 
    [CountNeurons] INT NULL, 
    [CountSynapses] INT NULL, 
    [SettingsId] INT NULL, 
    [NetId] INT NULL
)
