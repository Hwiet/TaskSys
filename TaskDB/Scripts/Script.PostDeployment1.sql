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


INSERT INTO [dbo].[Personnel] ([Id], [Role])
VALUES (1, 'Salesperson');
INSERT INTO [dbo].[Personnel] ([Id], [Role])
VALUES (2, 'Manager');

INSERT INTO [dbo].[Quotes] ([Id], [QuoteType], [TaskType], [TaskDescription], [ContactId], [DueDate])
VALUES ('00001', 1, 1, 'Some description about the task related to quote 00001', 1, '10/30/2022');