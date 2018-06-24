DECLARE @UserGameId INT =
(SELECT ug.Id
FROM UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
WHERE g.Name = 'Edinburgh' AND u.Username = 'Alex')

DECLARE @ItemsToBuy TABLE (
	Id INT PRIMARY KEY NOT NULL,
	Price MONEY NOT NULL
)

INSERT INTO @ItemsToBuy
SELECT Id, Price
FROM Items
WHERE Name IN('Blackguard', 'Bottomless Potion of Amplification',
	'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin',
	'Golden Gorget of Leoric', 'Hellfire Amulet')

INSERT INTO UserGameItems
SELECT Id, @UserGameId
FROM @ItemsToBuy

UPDATE UsersGames
SET Cash -= (SELECT SUM(Price) FROM @ItemsToBuy)
WHERE Id = @UserGameId

SELECT u.Username, g.Name, ug.Cash, i.Name
FROM UsersGames ug
JOIN Users u ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
JOIN Items i ON ugi.ItemId = i.Id
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name