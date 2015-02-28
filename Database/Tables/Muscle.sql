CREATE TABLE [dbo].[Muscle]
(
	[MuscleId] INT NOT NULL IDENTITY, 
    [MuscleName] NVARCHAR(50) NOT NULL, 
    [OtherNames] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_Muscle_Id] PRIMARY KEY CLUSTERED ([MuscleId] ASC),
)
