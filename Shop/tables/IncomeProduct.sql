CREATE TABLE [dbo].[IncomeProduct] (
    [Id]        INT   IDENTITY (1, 1) NOT NULL,
    [Date]      DATE  DEFAULT (getdate()) NOT NULL,
    [ProductId] INT   NOT NULL,
    [Quantity]  INT   NOT NULL,
    [Price]     MONEY NOT NULL,
    CONSTRAINT [IncomeProduct_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CHECK ([Price]>(0)),
    CHECK ([Quantity]>(0)), 
    CONSTRAINT [FK_IncomeProduct_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Products]([Id])
);

