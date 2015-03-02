CREATE TABLE [dbo].[Program]
(
	[ProgramId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProgramName] NVARCHAR(50) NOT NULL, 
    [FitnessGoalId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL
)
