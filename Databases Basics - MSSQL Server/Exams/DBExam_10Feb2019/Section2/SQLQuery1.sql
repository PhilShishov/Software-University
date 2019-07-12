

INSERT INTO Planets([Name]) VALUES
 ('Mars')
,('Earth')
,('Jupiter')
,('Saturn')

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate) VALUES
 ('Golf',	'VW',	3)
,('WakaWaka', 'Wakanda', 4)
,('Falcon9', 'SpaceX',	1)
,('Bed','Vidolov',	6)


--Update all spaceships light speed rate with 1 where the Id is between 8 and 12.\\

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--Delete first three inserted Journeys (be careful with the relationships).

DELETE FROM TravelCards
WHERE JourneyId IN (1,2,3)

DELETE FROM Journeys
WHERE Id IN (1,2,3)
