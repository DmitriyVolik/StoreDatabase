CREATE TRIGGER [UpdateOrder]
ON [dbo].[OrderProducts]
FOR INSERT, UPDATE
as
    begin
        UPDATE Orders Set UpdatedAt=getdate() where Id in (SELECT distinct Id from inserted)
    end
