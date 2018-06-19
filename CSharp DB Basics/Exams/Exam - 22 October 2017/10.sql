SELECT e.FirstName + ' ' + e.LastName AS Name, Count(DISTINCT r.UserId) AS [Users Number]
FROM Reports r
RIGHT JOIN Employees e ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [Users Number] DESC, Name