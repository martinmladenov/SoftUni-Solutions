WITH CTE_Reports AS
(SELECT StatusId, CategoryId
FROM Reports
WHERE StatusId IN (1, 2))

SELECT
c.Name AS [Category Name],
COUNT(*) AS [Reports Number],
CASE
	WHEN
	(SELECT COUNT(*)
	FROM CTE_Reports
	WHERE CategoryId = r.CategoryId AND StatusId = 1) >
	(SELECT COUNT(*)
	FROM CTE_Reports
	WHERE CategoryId = r.CategoryId AND StatusId = 2)
	THEN 'waiting'
	WHEN
	(SELECT COUNT(*)
	FROM CTE_Reports
	WHERE CategoryId = r.CategoryId AND StatusId = 1) <
	(SELECT COUNT(*)
	FROM CTE_Reports
	WHERE CategoryId = r.CategoryId AND StatusId = 2)
	THEN 'in progress'
	ELSE 'equal'
END AS [Main Status]
FROM CTE_Reports r
JOIN Categories c ON r.CategoryId = c.Id
GROUP BY r.CategoryId, c.Name
ORDER BY [Category Name], [Reports Number], [Main Status]