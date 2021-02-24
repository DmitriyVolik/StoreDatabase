/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Categories (Title) VALUES
(N'Фрукты'),
(N'Овощи'),
(N'Напитки'),
(N'Мясное'),
(N'Кисломолочное');

GO

INSERT INTO Products (CategoryId, Title, Price) VALUES
(1, N'Яблоко', 9.99),
(1, N'Груша',5.55);

GO
--Приход
--Яблоки
EXEC dbo.PerformIncomeProduct 1,8, 7.45, '2021-01-25';
EXEC dbo.PerformIncomeProduct 1,3, 7.6, '2021-01-26';
EXEC dbo.PerformIncomeProduct 1,12, 7.89, '2021-01-27';
EXEC dbo.PerformIncomeProduct 1,10, 8.35, '2021-01-29';
EXEC dbo.PerformIncomeProduct 1,5, 8.99, '2021-02-01';
--Груши
EXEC dbo.PerformIncomeProduct 2,8, 13.99, '2021-02-01';
EXEC dbo.PerformIncomeProduct 2,6, 14.99, '2021-02-02';

--Уход
--Яблоки
EXEC dbo.PerformOutcomeProduct 1,3, 10.99, '2021-02-02';
EXEC dbo.PerformOutcomeProduct 1,15, 12.99, '2021-02-03';

--Заказ 1
insert into Orders (Status) VALUES (0);
insert into OrderProducts (OrderId, ProductId, Quantity) 
VALUES 
(1, 1, 2), --apples
(1, 2, 3) -- grushi
;
--Закрітие заказа 1
EXEC dbo.CloseOrder 1, '2021-02-03'

--Заказ 2
insert into Orders (Status) VALUES (0);
insert into OrderProducts (OrderId, ProductId, Quantity) 
VALUES 
(2, 1, 5), --apples
(2, 2, 8) -- grushi
;
--Закрітие заказа 1
EXEC dbo.CloseOrder 2, '2021-02-05'