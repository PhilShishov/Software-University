
--SELECT p.FirstName + ' '  + p.LastName AS [Full Name], f.Origin, f.Destination
--FROM Passengers AS p
--JOIN Tickets AS t ON t.PassengerId = p.Id
--JOIN Flights AS f ON f.Id = t.FlightId
--ORDER BY [Full Name], f.Origin, f.Destination

--SELECT p.FirstName, p.LastName,p.Age
--FROM Passengers AS p
--LEFT JOIN Tickets AS t ON t.PassengerId =p.Id
--WHERE t.Id IS NULL
--ORDER BY p.Age DESC, p.FirstName, p.LastName 

--SELECT p.PassportId, p.Address
--FROM Passengers AS p
--LEFT JOIN Luggages AS l ON l.PassengerId = p.Id
--WHERE l.Id IS NULL
--ORDER BY p.PassportId, p.Address

--SELECT p.FirstName, p.LastName, COUNT(t.FlightId) AS [Total Trips]
--FROM Passengers AS p
--LEFT JOIN TICKETS AS t ON t.PassengerId = p.Id
--GROUP BY p.FirstName, p.LastName
--ORDER BY [Total Trips] DESC, p.FirstName, p.LastName

--SELECT p.FirstName + ' '  + p.LastName AS [Full Name], 
--	   pl.Name AS [Plane Name],
--	   f.Origin + ' - ' + f.Destination AS Trip,
--	   lt.Type AS [Luggage Type]
--FROM Passengers AS p
--JOIN Tickets AS t ON t.PassengerId = p.Id
--JOIN Flights AS f ON f.Id = t.FlightId
--JOIN Planes AS pl ON pl.Id = f.PlaneId
--JOIN Luggages AS l ON l.Id = t.LuggageId
--JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
--ORDER BY [Full Name], pl.Name, f.Origin, f.Destination, lt.Type