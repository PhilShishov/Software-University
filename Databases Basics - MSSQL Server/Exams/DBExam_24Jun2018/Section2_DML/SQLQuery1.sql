

--INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
-- ('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com')
--,('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com')
--,('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg')
--,('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

--INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
-- (101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02')
--,(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29')
--,(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL)
--,(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10')
--,(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)


--Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

DELETE FROM AccountsTrips
WHERE AccountId = 47 

SELECT *
  FROM Accounts
  WHERE Id = 47