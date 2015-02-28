CREATE TABLE [dbo].[Movement]
(
	[MovementId] INT NOT NULL IDENTITY, 
    [MovementName] NVARCHAR(50) NOT NULL, 
    [PrimaryMuscleId] INT NOT NULL, 
    [SecondaryMuscles] NVARCHAR(50) NULL, 
    [WeightTypeId] INT NOT NULL, 
    [DifficultyLevelId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Movement_PrimaryMuscleId] FOREIGN KEY ([PrimaryMuscleId]) REFERENCES [Muscle]([MuscleId]), 
    CONSTRAINT [PK_Movement] PRIMARY KEY ([MovementId])
)
