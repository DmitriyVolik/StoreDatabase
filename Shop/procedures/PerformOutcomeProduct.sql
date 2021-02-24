CREATE PROCEDURE [dbo].[PerformOutcomeProduct]
	@productId int,
	@quantity int,
	@pricePerUnit money,
	@date date,
	@isOrder bit = 0
AS
BEGIN

BEGIN TRANSACTION
BEGIN TRY
	INSERT INTO OutcomeProduct (ProductId, Price, Quantity, Date) VALUES
	(@productId, @pricePerUnit, @quantity, @date);
	IF @isOrder = 0
		INSERT INTO Payments (Date, Amount) VALUES (@date, @pricePerUnit * @quantity);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
RETURN 1;
END CATCH


RETURN 0;
END

