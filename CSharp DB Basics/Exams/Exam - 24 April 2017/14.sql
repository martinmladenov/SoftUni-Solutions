SELECT m.ModelId, m.Name,
	CONVERT(VARCHAR, AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)))
	 + ' days' AS [Average Service Time]
FROM Models m
JOIN Jobs j ON m.ModelId = j.ModelId
WHERE j.FinishDate IS NOT NULL
GROUP BY m.ModelId, m.Name
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) ASC