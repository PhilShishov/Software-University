

SELECT CardNumber, JobDuringJourney FROM TravelCards
ORDER BY CardNumber

SELECT Id, FirstName + ' ' + LastName AS FullName, Ucn FROM Colonists
ORDER BY FirstName, LastName, Id

SELECT Id, FORMAT(JourneyStart, 'd', 'en-gb'),  FORMAT(JourneyEnd, 'd', 'en-gb')  FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

SELECT c.Id, c.FirstName + ' ' + c.LastName AS FullName 
  FROM Colonists AS c
  JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY Id

SELECT COUNT(j.Id) AS [Count]
  FROM Colonists AS c
  JOIN TravelCards AS tc ON tc.ColonistId = c.Id
  JOIN Journeys AS j ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'

SELECT TOP(1) sps.Name AS SpaceshipName,  spp.Name AS SpaceportName
  FROM Spaceships AS sps
  JOIN Journeys AS j ON j.SpaceshipId = sps.Id
  JOIN Spaceports AS spp ON spp.Id = j.DestinationSpaceportId
ORDER BY sps.LightSpeedRate DESC

SELECT sps.Name, sps.Manufacturer 
  FROM Spaceships AS sps
  JOIN Journeys AS j ON j.SpaceshipId = sps.Id
  JOIN TravelCards AS tc ON tc.JourneyId = j.Id
  JOIN Colonists AS c ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot' AND (DATEDIFF(YEAR, c.BirthDate, '01/01/2019' ) < 30)
ORDER BY sps.Name

SELECT p.Name AS PlanetName, spp.Name AS SpaceportName
  FROM Planets AS p
  JOIN  Spaceports AS spp ON spp.PlanetId = p.Id
  JOIN Journeys AS j ON j.DestinationSpaceportId = spp.Id
 WHERE j.Purpose = 'Educational'
 ORDER BY spp.Name DESC

SELECT p.Name AS PlanetName, COUNT(spp.Id) AS JourneysCount
  FROM Planets AS p
  JOIN Spaceports AS spp ON spp.PlanetId = p.Id
  JOIN Journeys AS j ON j.DestinationSpaceportId = spp.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC, p.Name