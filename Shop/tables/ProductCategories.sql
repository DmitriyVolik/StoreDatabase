CREATE TABLE [dbo].[Categories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (50) NOT NULL,
    CONSTRAINT [ProductCategories_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);

