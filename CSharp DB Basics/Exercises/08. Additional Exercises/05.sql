WITH CTE_AverageStatistics AS
(SELECT AVG(Mind) AS Mind, AVG(Luck) AS Luck, AVG(Speed) AS Speed
FROM Items i
JOIN [Statistics] s ON i.StatisticId = s.Id)

SELECT i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind
FROM Items i
JOIN [Statistics] s ON i.StatisticId = s.Id
WHERE
	s.Mind > (SELECT Mind FROM CTE_AverageStatistics) AND
	s.Luck > (SELECT Luck FROM CTE_AverageStatistics) AND
	s.Speed > (SELECT Speed FROM CTE_AverageStatistics)
ORDER BY i.Name ASC