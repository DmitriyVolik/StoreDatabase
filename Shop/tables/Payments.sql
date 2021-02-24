CREATE TABLE [dbo].[Payments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Date] date NOT NULL default GETDATE(),
	[Amount] money NOT NULL,
	[OrderId] int NULL,
)
