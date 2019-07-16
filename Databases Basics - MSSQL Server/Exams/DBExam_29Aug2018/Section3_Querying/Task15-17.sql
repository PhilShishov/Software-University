
--SELECT 
--		 k.[Full Name]
--		,DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours 
--		,k.TotalSum
--FROM (
--SELECT   
--		 o.Id AS OrderId
--		,e.Id AS EmployeeId
--		,o.DateTime
--		,e.FirstName + ' ' + e.LastName AS [Full Name]
--		,SUM(oi.Quantity * i.Price) AS TotalSum 
--		,ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM
--		(oi.Quantity * i.Price) DESC) AS RowNumber
--  FROM Employees AS e
--  JOIN ORDERS AS O ON o.EmployeeId = e.Id
--  JOIN OrderItems AS oi ON oi.OrderId = o.Id
--  JOIN Items AS i ON i.Id = oi.ItemId
--GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.DateTime
--	  ) AS k
--  JOIN Shifts AS s ON s.EmployeeId = k.EmployeeId
--WHERE k.RowNumber = 1 AND k.DateTime BETWEEN s.CheckIn AND s.CheckOut
--ORDER BY k.[Full Name], WorkHours DESC, k.TotalSum DESC


--SELECT 
--		 DATEPART(DAY, o.DateTime) AS [Day]
--		,FORMAT(AVG(oi.Quantity * i.Price), 'N2') AS TotalProfit
--  FROM Orders AS o
--  JOIN OrderItems AS oi ON oi.OrderId = o.Id
--  JOIN Items AS i ON i.Id = oi.ItemId
--GROUP BY DATEPART(DAY, o.DateTime)
--ORDER BY [Day]

--Find information about all products. Select their name, category, 
--how many of them were sold and the total profit they produced.
--Sort them by total profit (descending) and their count (descending)



SELECT 
		 i.Name AS Item
		,c.Name AS Category
		,SUM(oi.Quantity) AS [Count]
		,SUM(oi.Quantity * i.Price) AS TotalPrice
  FROM Items AS i 
  JOIN Categories AS c ON c.Id = i.CategoryId
  LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
GROUP BY i.Name, c.Name  
ORDER BY TotalPrice DESC, [Count] DESC