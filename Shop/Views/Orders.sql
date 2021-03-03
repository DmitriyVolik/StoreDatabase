CREATE VIEW [dbo].[OrderAmounts]
	AS 
    SELECT o.Id, o.Status,
        SUM([op].[Quantity] * [p].[Price]) as 'Amount'
from Orders o
         join OrderProducts op on o.Id = op.OrderId
         join Products p on p.Id = op.ProductId
group by o.Id, o.Status


