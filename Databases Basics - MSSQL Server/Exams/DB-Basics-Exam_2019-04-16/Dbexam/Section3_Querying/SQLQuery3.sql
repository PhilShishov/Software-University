--SELECT k.FirstName, k.LastName, 
--	   k.Destination, k.Price
--FROM
--(
--SELECT p.FirstName, p.LastName, 
--	   f.Destination, 
--	   DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) AS PriceRank
--	   ,t.Price
--FROM Passengers AS p
--JOIN Tickets AS t ON t.PassengerId = p.Id
--JOIN Flights AS f ON f.Id = t.FlightId
--) AS k
--WHERE k.PriceRank = 1
--ORDER BY k.Price DESC, k.FirstName, k.LastName, k.Destination


--SELECT f.Destination, COUNT(t.FlightId) 
--FROM Flights AS f
--LEFT JOIN Tickets AS t ON t.FlightId = f.Id 
--GROUP BY f.Destination, t.FlightId
--ORDER BY COUNT(t.FlightId) DESC, f.Destination


--Select all planes with their name, seats count and 
--passengers count. 
--Order the results by passengers count (descending), 
--plane name (ascending) and seats (ascending) 
--Examples
--Name	Seats	Passengers Count
--Jabberbean	56	3
--Jabberstorm	271	3
--Linkbuzz	230	3

SELECT pl.Name, pl.Seats, COUNT(t.PassengerId) AS [Passengers Count]
FROM Planes AS pl
FULL JOIN Flights AS f ON f.PlaneId = pl.Id
FULL JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY pl.Name, pl.Seats
ORDER BY [Passengers Count] DESC, pl.Name, pl.Seats
