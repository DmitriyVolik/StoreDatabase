CREATE VIEW [dbo].[ProductQuantity]
	AS SELECT Title, dbo.GetProductQuantity(Id) as 'Quantity' from dbo.Products
