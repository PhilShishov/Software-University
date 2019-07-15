
--CREATE PROCEDURE usp_CancelFlights
--AS 
--BEGIN
--	UPDATE Flights
--	SET DepartureTime = NULL, ArrivalTime = NULL
--	WHERE Id IN (SELECT Id FROM Flights WHERE ArrivalTime > DepartureTime)
												
--END

--EXEC usp_CancelFlights

--SELECT * FROM Flights
--WHERE ArrivalTime > DepartureTime

--UPDATE Flights
--SET DepartureTime = NULL, ArrivalTime = NULL
--WHERE Id IN (SELECT Id FROM Flights WHERE ArrivalTime > DepartureTime)

--CREATE TABLE DeletedPlanes
--(
--	Id INT PRIMARY KEY,
--	[Name] VARCHAR(30) NOT NULL,
--	Seats INT NOT NULL,
--	[Range] INT NOT NULL
--)

--GO
--CREATE TRIGGER tr_DeletedPlanes ON Planes AFTER DELETE
--AS
--INSERT INTO DeletedPlanes(Id, Name, Seats, Range)
--SELECT Id, Name, Seats, Range FROM deleted
--GO

--DELETE Tickets
--WHERE FlightId IN (SELECT Id FROM Flights WHERE PlaneId = 8)

--DELETE FROM Flights
--WHERE PlaneId = 8

--DELETE FROM Planes
--WHERE Id = 8

--SELECT * FROM DeletedPlanes