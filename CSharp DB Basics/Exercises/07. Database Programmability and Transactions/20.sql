DECLARE @UserGameId INT = 
(SELECT ug.Id
FROM UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
WHERE g.Name = 'Safflower' AND u.Username = 'Stamat')

DECLARE @TotalAmount MONEY
DECLARE @Cash MONEY

BEGIN TRANSACTION

SET @TotalAmount = 
(SELECT SUM(Price)
FROM Items
WHERE MinLevel BETWEEN 11 AND 12)

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT Id, @UserGameId
FROM Items
WHERE MinLevel BETWEEN 11 AND 12

SET @Cash =
(SELECT Cash
FROM UsersGames
WHERE Id = @UserGameId)

IF(@Cash - @TotalAmount < 0)
	ROLLBACK
ELSE BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalAmount
	WHERE Id = @UserGameId
	COMMIT
END

BEGIN TRANSACTION

SET @TotalAmount = 
(SELECT SUM(Price)
FROM Items
WHERE MinLevel BETWEEN 19 AND 21)

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT Id, @UserGameId
FROM Items
WHERE MinLevel BETWEEN 19 AND 21

SET @Cash =
(SELECT Cash
FROM UsersGames
WHERE Id = @UserGameId)
 
IF(@Cash - @TotalAmount < 0)
	ROLLBACK
ELSE BEGIN
	UPDATE UsersGames
	SET Cash -= @TotalAmount
	WHERE Id = @UserGameId
	COMMIT
END

SELECT i.Name
FROM UserGameItems AS ui
JOIN Items i ON i.Id = ui.ItemId
WHERE ui.UserGameId = @UserGameId
ORDER BY i.Name ASC