
--SELECT Id, Name
--  FROM Cities
-- WHERE CountryCode = 'BG'
--ORDER BY Name

--SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name], YEAR(BirthDate) AS BirthYear
--  FROM Accounts
-- WHERE YEAR(BirthDate) > '1991'
--ORDER BY BirthYear DESC, FirstName

--SELECT e.FirstName, e.LastName, FORMAT(e.BirthDate, 'MM-dd-yyyy'), c.Name AS Hometown, e.Email
--  FROM Accounts AS e
--  JOIN Cities AS c ON c.Id = e.CityId
-- WHERE e.Email LIKE 'e%'
--ORDER BY Hometown DESC

--SELECT c.Name AS City, COUNT(h.CityId) AS Hotels
--  FROM Cities AS c
--  LEFT JOIN Hotels AS h ON h.CityId = c.Id
--GROUP BY c.Name
--ORDER BY Hotels DESC, City

--SELECT r.Id, r.Price, h.Name AS Hotel, c.Name AS City
--  FROM Rooms AS r
--  JOIN Hotels AS h ON h.Id = r.HotelId
--  JOIN Cities AS c ON c.Id = h.CityId
-- WHERE r.Type = 'FIrst Class' 
--ORDER BY r.Price DESC, r.Id







