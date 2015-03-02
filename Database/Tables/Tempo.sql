CREATE TABLE [dbo].[Tempo]
(
	[TempoId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Eccentric] INT NOT NULL, 
    [Pause] INT NOT NULL, 
    [Concentric] NCHAR(10) NOT NULL
)
