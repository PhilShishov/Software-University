

INSERT INTO Employees(FirstName, LastName, Phone, Salary) VALUES
 ('Stoyan',	 'Petrov',	'888-785-8573',	500.25)
,('Stamat',	 'Nikolov', '789-613-1122',	999995.25)
,('Evgeni',	 'Petkov',  '645-369-9517',	1234.51)
,('Krasimir', 'Vidolov', '321-471-9982',	50.25)


INSERT INTO Items ([Name], Price, CategoryId) VALUES

 ('Tesla battery', 154.25, 8)
,('Chess',	30.25, 8)
,('Juice',	5.32, 1)
,('Glasses', 10, 8)
,('Bottle of water', 1, 1)

UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2, 3) 

DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48