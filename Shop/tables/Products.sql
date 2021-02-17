CREATE TABLE [dbo].[Products] (
    [Id]           INT   IDENTITY (1, 1) NOT NULL,
    [SellingPrice] MONEY NOT NULL,
    [Category]     INT   NOT NULL,
    CONSTRAINT [Products_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);

