CREATE TABLE [dbo].[Synapse]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FromId] INT NULL, 
    [ToId] INT NULL, 
    [Type] TEXT NULL, 
    [Threshold] FLOAT NULL
)
