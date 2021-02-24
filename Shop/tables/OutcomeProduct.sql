CREATE TABLE [dbo].[OutcomeProduct] (
    [Id]        INT   IDENTITY (1, 1) NOT NULL,
    [Date]      DATE  DEFAULT (getdate()) NOT NULL,
    [ProductId] INT   NOT NULL,
    [Quantity]  INT   NOT NULL,
    [Price]     MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Quantity]>(0)),
    CHECK ([Quantity]>(0)), 
    CONSTRAINT [FK_OutcomeProduct_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Products]([Id])
);

