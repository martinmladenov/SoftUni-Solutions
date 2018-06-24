SELECT u.Username, g.Name AS Game, COUNT(*) AS [Items Count], SUM(i.Price) AS [Items Price]
FROM UsersGames ug
JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
JOIN Items i ON ugi.ItemId = i.Id
JOIN Users u ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
GROUP BY ug.UserId, ug.GameId, u.Username, g.Name
HAVING COUNT(*) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC