CREATE TABLE [dbo].[ProgramDay]
(
	[ProgramDayId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProgramId] INT NOT NULL, 
    [DayId] INT NOT NULL, 
    CONSTRAINT [FK_ProgramId_Program] FOREIGN KEY ([ProgramId]) REFERENCES [Program]([ProgramId]),
	CONSTRAINT [FK_DayId_Program] FOREIGN KEY ([DayId]) REFERENCES [Day]([DayId])
)
