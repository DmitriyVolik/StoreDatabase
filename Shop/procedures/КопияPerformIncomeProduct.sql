CREATE PROCEDURE [dbo].[PerformIncomeProduct]
	@productId int,
	@quantity int,
	@pricePerUnit money,
	@date date
AS
BEGIN

BEGIN TRANSACTION
BEGIN TRY
	INSERT INTO IncomeProduct (ProductId, Price, Quantity, Date) VALUES
	(@productId, @pricePerUnit, @quantity, @date);
	INSERT INTO Payments (Date, Amount) VALUES (@date, -(@pricePerUnit * @quantity));
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
RETURN 1;
END CATCH


RETURN 0;
END

