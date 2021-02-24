CREATE FUNCTION [dbo].[GetProductQuantity]
(
	@productId int
)
RETURNS INT
AS
BEGIN
    return (
	SELECT SUM(result.Quantity)
    FROM (
         SELECT ProductId, Quantity
         FROM IncomeProduct WHERE ProductId=@productId
         UNION
         SELECT ProductId, -Quantity
         FROM OutcomeProduct WHERE ProductId=@productId
     ) result
     )
 END
