CREATE TABLE [dbo].[IncomeProduct] (
    [Id]        INT   IDENTITY (1, 1) NOT NULL,
    [Time]      DATE  DEFAULT (getdate()) NOT NULL,
    [ProductId] INT   NOT NULL,
    [Quantity]  INT   NOT NULL,
    [Price]     MONEY NOT NULL,
    CONSTRAINT [IncomeProduct_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CHECK ([Price]>(0)),
    CHECK ([Quantity]>(0))
);

