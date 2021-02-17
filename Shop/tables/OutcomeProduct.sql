CREATE TABLE [dbo].[OutcomeProduct]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Time] DATE NOT NULL DEFAULT GETDATE(),
	ProductId INT NOT NULL,
    [Quantity]  INT   NOT NULL CHECK (Quantity >0),
    [Price]     MONEY NOT NULL CHECK (Quantity >0),
)
