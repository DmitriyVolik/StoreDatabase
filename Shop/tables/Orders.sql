CREATE TABLE [dbo].[Orders] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [Status]     INT  DEFAULT ((0)) NULL,
    [ClosedDate] DATE NULL,
    [UpdatedAt] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [Orders_pk] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);

