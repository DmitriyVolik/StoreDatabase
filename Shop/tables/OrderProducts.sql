CREATE TABLE [dbo].[OrderProducts] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [OrderProducts_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [OrderProducts_Orders_Id_fk] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [OrderProducts_Products_Id_fk] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

