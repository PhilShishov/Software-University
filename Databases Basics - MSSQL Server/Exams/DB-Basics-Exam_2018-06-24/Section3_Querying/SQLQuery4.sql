
--SELECT TripId, SUM(Luggage) AS Luggage, 
--		CASE 
--			WHEN SUM(Luggage) > 5 THEN '$' + CAST(SUM(5 * Luggage) AS varchar)			
--			ELSE '$0' 
--		END AS Fee
--  FROM AccountsTrips
--GROUP BY TripId
--HAVING SUM(Luggage) > 0
--ORDER BY Luggage DESC

--Retrieve the following information about each trip:
--•	Trip ID
--•	Account Full Name
--•	From – Account hometown
--•	To – Hotel city
--•	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
--Order the results by full name, then by Trip ID.

--Examples
--Id	Full Name	From	To	Duration
--273	Adah Douglass Lathaye	Stara Zagora	Cardiff	Canceled
--491	Adah Douglass Lathaye	Stara Zagora	Houston	4 days
--776	Adah Douglass Lathaye	Stara Zagora	Chelyabinsk	3 days

SELECT 
		 t.Id
		,a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name]
		,cFrom.Name AS [From]
		,cTo.Name AS [To],
CASE 
		WHEN CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS varchar) + ' days'
END AS Duration
  FROM Trips AS t
  JOIN AccountsTrips AS act ON act.TripId = t.Id
  JOIN Accounts AS a ON a.Id = act.AccountId
  JOIN Cities AS cFrom ON cFrom.Id = a.CityId
  JOIN Rooms AS r ON r.Id = t.RoomId
  JOIN Hotels AS h ON h.Id = r.HotelId
  JOIN Cities AS cTo ON cTo.Id = h.CityId
ORDER BY [Full Name], t.Id
