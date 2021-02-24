CREATE VIEW [dbo].[CategoryBalance]
	AS select r.Title                   as 'Category',
       (SELECT SUM(ip.Price * ip.Quantity)
        from IncomeProduct ip
                 Join Products p on p.Id = ip.ProductId
                 JOIN Categories c ON c.Id = p.CategoryId
        where c.Id = r.CatId
        group by c.Id)           as 'Outcome',
       (SELECT SUM(op.Price * op.Quantity)
        from OutcomeProduct op
                 Join Products p on p.Id = op.ProductId
                 JOIN Categories c ON c.Id = p.CategoryId
        where c.Id = r.CatId
        group by c.Id)           as 'Income',
       SUM(r.Quantity * r.Price) as 'Balance'
from (select c.Title, c.Id as CatId, p.Id, ip.Quantity, (ip.Price * -1) as Price
      from IncomeProduct ip
               Join Products p on p.Id = ip.ProductId
               JOIN Categories c ON c.Id = p.CategoryId
      UNION
      select c.Title, c.Id, p.Id, op.Quantity, op.Price
      from OutcomeProduct op
               Join Products p on p.Id = op.ProductId
               JOIN Categories c ON c.Id = p.CategoryId) r
GROUP BY r.Title, r.CatId


