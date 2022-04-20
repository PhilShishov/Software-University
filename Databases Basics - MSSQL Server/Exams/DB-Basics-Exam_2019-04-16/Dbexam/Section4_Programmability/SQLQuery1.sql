
--Create a user defined function, named udf_CalculateTickets
--(@origin, @destination, @peopleCount) that receives an origin (town name), 
--destination (town name) and people count.
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"

GO
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!'
	END

	IF(@origin = 'Invalid' OR @destination = 'Invalid')
	BEGIN
		RETURN 'Invalid flight!'
	END

	DECLARE @TotalPrice DECIMAL(15,2) = (SELECT t.Price * @peopleCount
										   FROM Tickets AS t
										   JOIN Flights AS f ON f.Id = t.FlightId
										  WHERE f.Destination = @destination AND f.Origin = @origin) 

RETURN 'Total price ' + CAST(@TotalPrice AS varchar)
END
GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT t.Price * 33
FROM Tickets AS t
JOIN Flights AS f ON f.Id = t.FlightId
WHERE f.Destination = 'Rancabolang'



