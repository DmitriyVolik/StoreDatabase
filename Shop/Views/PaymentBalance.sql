CREATE VIEW [dbo].[PaymentBalance]
	AS SELECT YEAR(Date) as 'Year', MONTH(Date) as 'Month',
       sum(iif(Amount >0,Amount,0)) as 'Income',
       sum(iif(Amount <0,Amount,0)) as 'Outcome',
       sum(Amount) as 'Balance'
from Payments
group by YEAR(Date), MONTH(Date)
