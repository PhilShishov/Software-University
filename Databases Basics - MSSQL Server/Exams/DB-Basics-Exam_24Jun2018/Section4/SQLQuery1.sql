
--GO
--CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
--RETURNS VARCHAR(MAX)
--AS
--BEGIN	
--	DECLARE @AvailableRoom VARCHAR(MAX) = (SELECT TOP(1) CONCAT('Room ', r.Id, ': ', r.Type, 
--												' (', r.Beds, ' beds) - $', (h.BaseRate + r.Price) * @People) 
--													FROM Hotels AS h
--													JOIN Rooms AS r ON r.HotelId = h.Id
--													JOIN Trips AS t ON t.RoomId = r.Id
--												   WHERE h.Id = @HotelId 
--												     AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
--												     AND t.CancelDate IS NULL
--												     AND r.Beds > @People)
--	IF(@AvailableRoom IS NULL)
--	BEGIN
--		RETURN 'No rooms available' 
--	END

--RETURN @AvailableRoom
--END


--CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
--AS
--BEGIN
--	DECLARE @HotelId INT = (SELECT TOP(1) r.HotelId 
--							    FROM Trips AS t
--							    JOIN Rooms AS r ON r.Id = t.RoomId
--							   WHERE t.Id = @TripId)

--	DECLARE @TargetRoomHotelId INT = (SELECT TOP(1) r.HotelId 
--										FROM Rooms AS r
--									   WHERE r.Id = @TargetRoomId)

--	IF(@HotelId != @TargetRoomHotelId)
--	BEGIN
--		RAISERROR('Target room is in another hotel!', 16, 1)
--		RETURN
--	END

--	DECLARE @TripsAccountBeds INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)

--	IF(@TripsAccountBeds > (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId ))
--	BEGIN
--		RAISERROR('Not enough beds in target room!', 16, 2)
--		RETURN
--	END

--	UPDATE Trips 
--	SET RoomId = @TargetRoomId
--	WHERE Id = @TripId
--END


CREATE TRIGGER tr_CancelTrip ON Trips INSTEAD OF DELETE
AS
UPDATE Trips
SET CancelDate = GETDATE()
WHERE Id IN (SELECT Id FROM deleted WHERE CancelDate IS NULL)