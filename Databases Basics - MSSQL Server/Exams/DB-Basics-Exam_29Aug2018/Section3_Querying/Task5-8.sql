
SELECT Id, FirstName
  FROM Employees
 WHERE Salary > 6500
ORDER BY FirstName, Id

SELECT FirstName + ' ' + LastName AS [Full Name], Phone
  FROM Employees
 WHERE CHARINDEX('3', Phone) = 1
 --WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

SELECT e.FirstName, e.LastName, COUNT(o.EmployeeId) AS [Count]
  FROM Employees AS e
  JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [Count] DESC, e.FirstName

SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work Hours]
  FROM Employees AS e
  JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work Hours] DESC, e.Id