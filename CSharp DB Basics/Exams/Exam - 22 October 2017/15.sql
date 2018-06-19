SELECT d.Name, ISNULL(CONVERT(VARCHAR, AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate))), 'no info') AS [Average Duration]
FROM Departments d
JOIN Categories c ON c.DepartmentId = d.Id
LEFT JOIN Reports r ON c.Id = r.CategoryId
GROUP BY d.Name
ORDER BY d.Name