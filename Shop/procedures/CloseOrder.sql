CREATE PROCEDURE [dbo].[CloseOrder]
	@orderId int,
	@date date
AS
BEGIN
--Установить зкакзу статус 1 и дату закрытия
--Для всех продуктов запустить процедуру продажи

 if (SELECT COUNT(*) FROM Orders WHERE ID=@orderId AND STATUS = 0) = 0
	return 2

BEGIN TRANSACTION
BEGIN TRY
	UPDATE Orders SET Status=1, ClosedDate = @date;
	
	DECLARE product_order_cursor CURSOR FOR   
	SELECT ProductId, Quantity, p.Price
	FROM OrderProducts op JOIN Products p ON op.ProductId=p.Id
	WHERE OrderId = @orderId  

	OPEN product_order_cursor
	DECLARE @productId int;
	DECLARE @quantity int;
	DECLARE @price money;
	DECLARE @totalPaymentAmount money = 0;

	FETCH NEXT FROM product_order_cursor INTO @productId, @quantity, @price

	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			EXEC dbo.PerformOutcomeProduct @productId, @quantity, @price, @date, 1
			SET @totalPaymentAmount+= @price * @quantity;
			FETCH NEXT FROM product_order_cursor INTO @productId, @quantity, @price
		END

	CLOSE product_order_cursor;  
	DEALLOCATE product_order_cursor; 

	INSERT INTO Payments (Amount, [Date], OrderId) VALUES
	(@totalPaymentAmount, @date, @orderId);

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	print Error_message()
	ROLLBACK TRANSACTION
RETURN 1;
END CATCH


RETURN 0;
END

