
--SELECT 
--		 t.Id
--		,h.Name
--		,r.Type AS RoomType,
--CASE
--	WHEN t.CancelDate IS NOT NULL THEN 0
--	ELSE SUM(h.BaseRate + r.Price)  
--END AS Revenue
--  FROM Trips AS t
--  JOIN AccountsTrips AS act ON act.TripId = t.Id
--  JOIN Rooms AS r ON r.Id = t.RoomId
--  JOIN Hotels AS h ON h.Id = r.HotelId
--GROUP BY t.Id, h.Name, r.Type, t.CancelDate  
--ORDER BY RoomType, t.Id


--Find the top traveler for each country. The top traveler is the account, which has the most trips to that country.
--Order the results by the count of trips (descending), then by Account ID.


--AccountId	Email	CountryCode	Trips
--80	a_flucks@gmail.com	RU	6


SELECT *
  FROM Accounts AS a
  JOIN AccountsTrips AS act ON act.AccountId = a.Id
  JOIN Trips AS t ON t.Id = act.TripId
  JOIN ROOMS AS r ON r.Id = t.RoomId
  JOIN Hotels AS h ON h.Id = r.HotelId
  JOIN Cities AS c ON c.Id = h.CityId
WHERE a.Id IN (14, 32, 80)



SELECT	
		 k.Id
		,k.Email
		,k.CountryCode
		,k.Trips
  FROM
  (

SELECT
		 a.Id
		,a.Email
		,c.CountryCode
		,COUNT(c.CountryCode) AS Trips
		,ROW_NUMBER() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(c.CountryCode) DESC) AS RowNumber
  FROM Accounts AS a
  JOIN AccountsTrips AS act ON act.AccountId = a.Id
  JOIN Trips AS t ON t.Id = act.TripId
  JOIN ROOMS AS r ON r.Id = t.RoomId
  JOIN Hotels AS h ON h.Id = r.HotelId
  JOIN Cities AS c ON c.Id = h.CityId
GROUP BY a.Id, a.Email, c.CountryCode
  ) AS k
WHERE k.RowNumber = 1
ORDER BY k.Trips DESC, k.Id