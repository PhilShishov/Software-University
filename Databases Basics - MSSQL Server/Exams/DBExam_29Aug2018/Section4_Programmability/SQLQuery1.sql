

--CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, 
--										@Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
--RETURNS VARCHAR(MAX)
--AS
--BEGIN
--		DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
--		DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
--		DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

--		DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
--		DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
--		DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

--		IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
--		BEGIN
--			RETURN 'One of the items does not exists!'
--		END

--		IF (@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
--		BEGIN
--			RETURN 'The current date is not within the promotion dates!'
--		END

--		SET @FirstItemPrice =  (@FirstItemPrice - (@FirstItemPrice * @Discount / 100))
--		SET @SecondItemPrice =  (@SecondItemPrice - (@SecondItemPrice * @Discount / 100))
--		SET @ThirdItemPrice =  (@ThirdItemPrice - (@ThirdItemPrice * @Discount / 100))


--		RETURN	@FirstItemName + ' price: ' + CAST(@FirstItemPrice AS varchar) + ' <-> ' +
--				@SecondItemName + ' price: ' + CAST(@SecondItemPrice AS varchar)+ ' <-> ' +
--				@ThirdItemName + ' price: ' + CAST(@ThirdItemPrice AS varchar)

--END

--SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)



--CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
--AS
--	DECLARE @Order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

--	IF (@Order IS NULL)
--	BEGIN
--		RAISERROR('The order does not exist!', 16, 1)
--		RETURN 
--	END

--	DECLARE @OrderDateTime DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

--	IF (DATEDIFF(DAY, @OrderDateTime, @CancelDate) > 3)
--	BEGIN
--		RAISERROR('You cannot cancel the order!', 16, 2)
--		RETURN
--	END

--	DELETE FROM OrderItems
--	WHERE OrderId = @OrderId

--	DELETE FROM Orders
--	WHERE Id = @OrderId

--CREATE TABLE DeletedOrders
--(
--OrderId INT, ItemId INT, ItemQuantity INT
--)


--CREATE TRIGGER tr_DeletedOrders ON OrderItems AFTER DELETE
--AS
--INSERT INTO DeletedOrders(ItemId, OrderId, ItemQuantity)
--	 SELECT ItemId, OrderId, Quantity FROM deleted

--DELETE FROM OrderItems
--WHERE OrderId = 5

--DELETE FROM Orders
--WHERE Id = 5 
