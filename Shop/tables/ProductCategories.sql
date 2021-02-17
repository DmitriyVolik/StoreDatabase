CREATE TABLE [dbo].[ProductCategories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [ProductCategories_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);

