CREATE TRIGGER [DeleteOrder]
	ON [dbo].[OrderProducts]
	FOR DELETE
	AS
	BEGIN
		UPDATE Orders Set UpdatedAt=getdate() where Id in (SELECT distinct Id from deleted)
	END
