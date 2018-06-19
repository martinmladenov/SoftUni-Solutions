SELECT e.FirstName + ' ' + e.LastName AS Name,
	CAST(ISNULL(Closed.Count, 0) AS VARCHAR) + '/' +
	 CAST(ISNULL(Opened.Count, 0) AS VARCHAR)
FROM Employees e
JOIN
(SELECT EmployeeId, COUNT(Id) AS Count
FROM Reports
WHERE YEAR(OpenDate) = 2016 AND EmployeeId IS NOT NULL
GROUP BY EmployeeId) AS Opened ON Opened.EmployeeId = e.Id
LEFT JOIN
(SELECT EmployeeId, COUNT(Id) AS Count
FROM Reports
WHERE YEAR(CloseDate) = 2016 AND EmployeeId IS NOT NULL
GROUP BY EmployeeId) AS Closed ON  Closed.EmployeeId = e.Id
ORDER BY Name, e.Id