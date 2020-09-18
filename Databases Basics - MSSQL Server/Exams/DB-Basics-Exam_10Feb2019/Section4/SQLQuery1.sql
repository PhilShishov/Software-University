
--CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30)) 
--RETURNS INT
--AS
--BEGIN
--	DECLARE @CountColonists INT = (SELECT COUNT(c.Id) 
--									 FROM Colonists AS c
--									 JOIN TravelCards AS tc ON tc.ColonistId = c.Id
--									 JOIN Journeys AS j ON j.Id = tc.JourneyId
--									 JOIN Spaceports AS spp ON spp.Id = j.DestinationSpaceportId
--									 JOIN Planets AS p ON p.Id  = spp.PlanetId
--									 WHERE p.Name = @PlanetName) 

--	RETURN @CountColonists
--END

--CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
--AS
--BEGIN
--	DECLARE @Journey INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

--	IF(@Journey IS NULL)
--	BEGIN
--		RAISERROR('The journey does not exist!', 16, 1)
--		RETURN
--	END

--	DECLARE @Purpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

--	IF(@Purpose = @NewPurpose)
--	BEGIN
--		RAISERROR('You cannot change the purpose!', 16, 2)
--		RETURN
--	END

--	UPDATE Journeys
--	SET Purpose = @NewPurpose
--END


CREATE TABLE DeletedJourneys
(
 Id INT 
,JourneyStart DATETIME
,JourneyEnd DATETIME
,Purpose VARCHAR(11)
,DestinationSpaceportId INT
,SpaceshipId INT
)

GO
CREATE TRIGGER tr_DeletedJourneys ON Journeys AFTER DELETE
AS
INSERT INTO DeletedJourneys(Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted


