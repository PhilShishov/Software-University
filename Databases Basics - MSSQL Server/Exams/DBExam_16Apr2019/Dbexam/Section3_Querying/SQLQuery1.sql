
--SELECT Origin, Destination FROM Flights
--ORDER BY Origin, Destination

--SELECT * 
--FROM Planes
--WHERE [Name] LIKE '%tr%'
--ORDER BY Id, [Name], Seats, [Range]

--Select the total profit for each flight from database. Order them by total price (descending), flight id (ascending).

--SELECT FlightId, SUM(Price) AS TotalPrice
--FROM Tickets
--GROUP BY FlightId
--ORDER BY TotalPrice DESC, FlightId

--Select top 10 records from passengers along with the price for their tickets. 
--Order them by price (descending), first name (ascending) and last name (ascending).

--SELECT TOP(10) p.FirstName, p.LastName, t.Price
--FROM Passengers AS p
--JOIN Tickets AS t ON t.PassengerId  = p.Id
--ORDER BY t.Price DESC, p.FirstName, p.LastName

--SELECT lt.Type, COUNT(l.LuggageTypeId) AS MostUsedLuggage
--FROM Luggages AS l
--JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
--GROUP BY l.LuggageTypeId, lt.Type
--ORDER BY MostUsedLuggage DESC, lt.Type