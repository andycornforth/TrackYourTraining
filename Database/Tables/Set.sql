CREATE TABLE [dbo].[Set]
(
	[SetId] INT NOT NULL PRIMARY KEY IDENTITY, 
	[MovementId] INT NOT NULL,
    [SetNumber] INT NOT NULL, 
    [Reps] INT NOT NULL, 
    [Weight] FLOAT NOT NULL, 
    [TempoId] INT NULL, 
    CONSTRAINT [FK_Movement] FOREIGN KEY ([MovementId]) REFERENCES [Movement]([MovementId])
)
