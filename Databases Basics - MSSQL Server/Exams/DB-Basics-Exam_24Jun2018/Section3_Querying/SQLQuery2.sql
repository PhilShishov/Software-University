
--SELECT 
--		 a.Id
--		,a.FirstName + ' ' + a.LastName AS FullName
--		,MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip
--		,MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
--  FROM Accounts AS a
--  JOIN AccountsTrips AS act ON act.AccountId = a.Id
--  JOIN Trips AS t ON t.Id = act.TripId
-- WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
--GROUP BY a.Id, a.FirstName, a.LastName
--ORDER BY LongestTrip DESC, a.Id


--SELECT TOP(5) c.Id, c.Name AS City, c.CountryCode AS Country, COUNT(a.Id) AS Accounts
--  FROM Cities AS c
--  JOIN Accounts AS a ON a.CityId = c.Id
--GROUP BY c.Id, c.Name, c.CountryCode
--ORDER BY Accounts DESC

--SELECT a.Id, a.Email, c.Name AS City, COUNT(t.Id) AS Trips
--  FROM Accounts AS a
--  JOIN AccountsTrips AS act ON act.AccountId = a.Id
--  JOIN Trips AS t ON t.Id = act.TripId
--  JOIN Rooms AS r ON r.Id = t.RoomId
--  JOIN Hotels AS h ON h.Id = r.HotelId
--  JOIN Cities AS c ON c.Id = h.CityId
-- WHERE a.CityId = h.CityId
--GROUP BY a.Id, a.Email, c.Name
--ORDER BY Trips DESC, a.Id

--Find the top 10 cities’ Total Revenue Sum (Hotel Base Rate + Room Price) and trip count.
--Count only trips, which were booked in 2016.
--Order them by Total Revenue (descending), then by Trip count (descending)


--SELECT TOP(10) c.Id, c.Name, SUM(h.BaseRate + r.Price) AS [Total Revenue], COUNT(t.Id) AS Trips
--  FROM Cities AS c
--  JOIN Hotels AS h ON h.CityId = c.Id
--  JOIN Rooms AS r ON r.HotelId = h.Id
--  JOIN Trips AS t ON t.RoomId = r.Id
-- WHERE YEAR(t.BookDate) = '2016'
-- GROUP BY c.Id, c.Name
-- ORDER BY [Total Revenue] DESC, Trips DESC