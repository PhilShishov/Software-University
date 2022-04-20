

--SELECT TOP(1) oi.OrderId, SUM(i.Price * oi.Quantity) AS TotalPrice
--  FROM OrderItems AS oi
--  JOIN Items AS i ON i.Id = oi.ItemId
--GROUP BY oi.OrderId
--ORDER BY TotalPrice DESC


--SELECT TOP(10)
--		 o.Id
--		,MAX(i.Price) AS [ExpensivePrice]
--		,MIN(i.Price) AS [CheapPrice]
--  FROM Orders AS o
--  JOIN OrderItems AS oi ON oi.OrderId = o.Id
--  JOIN Items AS i ON i.Id = oi.ItemId
--GROUP BY o.Id
--ORDER BY ExpensivePrice DESC, o.Id


--SELECT DISTINCT 
--		 e.Id
--		,e.FirstName
--		,e.LastName
--  FROM Employees AS e
--  JOIN Orders AS o ON o.EmployeeId = e.Id
--ORDER BY e.Id

--SELECT DISTINCT
--		 e.Id
--		,e.FirstName + ' ' + e.LastName AS [Full Name]
--  FROM Employees AS e
--  JOIN Shifts AS s ON s.EmployeeId = e.Id
--WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
--ORDER BY e.Id

--SELECT  TOP(10)
--		 e.FirstName + ' ' + e.LastName AS [Full Name]
--		,SUM(i.Price * oi.Quantity) AS TotalSum
--		,SUM(oi.Quantity) AS [Count]
--  FROM Employees AS e
--  JOIN Orders AS o ON o.EmployeeId = e.Id
--  JOIN OrderItems AS oi ON oi.OrderId = o.Id
--  JOIN Items AS i ON i.Id = oi.ItemId
--WHERE o.DateTime < '2018-06-15'
--GROUP BY e.FirstName, e.LastName
--ORDER BY TotalSum DESC, [Count] DESC

--SELECT   e.FirstName + ' ' + e.LastName AS [Full Name]
--		,DATENAME(WEEKDAY, s.CheckIn) AS [Day of week]
--  FROM Employees AS e
--  LEFT JOIN ORDERS AS O ON o.EmployeeId = e.Id
--  JOIN Shifts AS s ON s.EmployeeId = e.Id
--  WHERE o.EmployeeId IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
--  ORDER BY e.Id