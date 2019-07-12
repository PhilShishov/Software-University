
SELECT TOP(1)
		 j.Id
		,p.Name AS PlanetName
		,spp.Name AS SpaceportName
		,j.Purpose AS JourneyPurpose
  FROM Journeys AS j
  JOIN Spaceports AS spp ON spp.Id = j.DestinationSpaceportId
  JOIN Planets AS p ON p.Id = spp.PlanetId
GROUP BY j.Id, p.Name, spp.Name, j.Purpose
ORDER BY MIN(DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd ))

SELECT TOP(1) k.Id, k.JobName
  FROM
(
SELECT DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd) AS LongestJourney, j.Id, tc.JobDuringJourney AS JobName
  FROM  Colonists AS c
  JOIN TravelCards AS tc ON tc.ColonistId = c.Id
  JOIN Journeys AS j ON j.Id = tc.JourneyId
) AS k
ORDER BY k.LongestJourney DESC


SELECT k.JobDuringJourney, k.FullName, k.JobRank
  FROM
	(
	   SELECT 
			 tc.JobDuringJourney 
			,FirstName + ' ' + LastName AS FullName
			,DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
			,c.BirthDate
	   FROM Colonists AS c
	   JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	) AS k
WHERE k.JobRank = 2 


SELECT p.Name, COUNT(spp.Id) AS [Count]
  FROM Planets AS p
  LEFT JOIN Spaceports AS spp ON spp.PlanetId = p.Id
GROUP BY p.Name
ORDER BY [Count] DESC, p.Name