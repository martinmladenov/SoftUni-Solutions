SELECT m.Name AS Model, j.[Times Serviced],
	(SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
	FROM Orders o
	JOIN Jobs j ON o.JobId = j.JobId
	JOIN OrderParts op ON o.OrderId = op.OrderId
	JOIN Parts p ON p.PartId = op.PartId
	WHERE j.ModelId = m.ModelId) AS [Parts Total]
FROM
(SELECT ModelId, COUNT(*) AS [Times Serviced], 
	DENSE_RANK() OVER(ORDER BY COUNT(*) DESC) AS Rank
FROM Jobs
GROUP BY ModelId) AS j
JOIN Models m ON j.ModelId = m.ModelId
WHERE Rank = 1