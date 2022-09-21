/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF (EXISTS(SELECT * FROM [dbo].[Quotes]))
BEGIN
    DELETE FROM [dbo].[Quotes]
END

IF (EXISTS(SELECT * FROM [dbo].[Personnel]))
BEGIN
    DELETE FROM [dbo].[Personnel]
END

IF (EXISTS(SELECT * FROM [dbo].[TaskTypes]))
BEGIN
    DELETE FROM [dbo].[TaskTypes]
END

IF (EXISTS(SELECT * FROM [dbo].[QuoteTypes]))
BEGIN
    DELETE FROM [dbo].[QuoteTypes]
END

INSERT INTO [dbo].[Personnel] ([Id], [Role])
VALUES (1, 'Salesperson');
INSERT INTO [dbo].[Personnel] ([Id], [Role])
VALUES (2, 'Manager');

INSERT INTO [dbo].[TaskTypes] ([Id], [Name])
VALUES (1, 'Follow-up');
INSERT INTO [dbo].[TaskTypes] ([Id], [Name])
VALUES (2, 'New');

INSERT INTO [dbo].[QuoteTypes] ([Id], [Name])
VALUES (1, 'DYR');
INSERT INTO [dbo].[QuoteTypes] ([Id], [Name])
VALUES (2, 'BF');

INSERT INTO [dbo].[Quotes] ([Id], [QuoteTypeId], [TaskTypeId], [TaskDescription], [ContactId], [DueDate])
VALUES ('00001', 1, 1, 'Some description about the task related to quote 00001', 1, '10/30/2022');