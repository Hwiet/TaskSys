CREATE TABLE [dbo].[Quotes]
(
	[Id] NCHAR(5) NOT NULL PRIMARY KEY, 
    [QuoteType] INT NOT NULL, 
    [TaskType] INT NOT NULL, 
    [TaskDescription] VARCHAR(MAX) NULL, 
    [ContactId] INT NULL, 
    [DueDate] DATE NULL, 
    CONSTRAINT [CK_Quotes_IdValid] CHECK ([Id] LIKE '[0-9][0-9][0-9][0-9][0-9]'), 
    CONSTRAINT [FK_Quotes_Personnel] FOREIGN KEY ([ContactId]) REFERENCES [Personnel]([Id]) 
)
