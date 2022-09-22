CREATE TABLE [dbo].[Quotes]
(
	[Id] NCHAR(5) NOT NULL PRIMARY KEY, 
    [QuoteTypeId] INT NOT NULL, 
    [TaskTypeId] INT NOT NULL, 
    [TaskDescription] VARCHAR(MAX) NULL, 
    [ContactId] INT NULL, 
    [DueDate] DATE NULL, 
    CONSTRAINT [FK_Quotes_QuoteTypes] FOREIGN KEY ([QuoteTypeId]) REFERENCES [QuoteTypes]([Id]), 
    CONSTRAINT [FK_Quotes_TaskTypes] FOREIGN KEY ([TaskTypeId]) REFERENCES [TaskTypes]([Id]), 
    CONSTRAINT [FK_Quotes_Personnel] FOREIGN KEY ([ContactId]) REFERENCES [Personnel]([Id]), 
    CONSTRAINT [CK_Quotes_IdValid] CHECK ([Id] LIKE '[0-9][0-9][0-9][0-9][0-9]') 
)
