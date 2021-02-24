CREATE FUNCTION [dbo].[GetOrderAmount]
(
	@orederId int
)
RETURNS MONEY
AS
BEGIN
	RETURN (select SUM(Quantity*Price)
	from OrderProducts
         join dbo.Products on OrderProducts.ProductId = Products.Id
	WHERE OrderId = @orederId
	group by OrderId)
	
END
