﻿CREATE TABLE [dbo].[Products] (
    [Id]           INT   IDENTITY (1, 1) NOT NULL,
Title NVARCHAR(100) NOT NULL,
    [Price] MONEY NOT NULL,
    [CategoryId]     INT   NOT NULL,
    CONSTRAINT [Products_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Products_ToCategory] FOREIGN KEY (CategoryId) REFERENCES [Categories]([Id])
   
);

