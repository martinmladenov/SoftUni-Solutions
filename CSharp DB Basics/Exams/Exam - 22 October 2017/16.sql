SELECT d.Name AS [Department Name], c.Name AS [Category Name],
	CONVERT(INT, ROUND(CountPerCategory.Count * 100.0 / CountPerDepartment.Count, 0)) AS Percentage
FROM Departments d
JOIN Categories c ON c.DepartmentId = d.Id
JOIN
(SELECT CategoryId, COUNT(*) AS Count
FROM Reports
GROUP BY CategoryId) CountPerCategory ON CountPerCategory.CategoryId = c.Id
JOIN
(SELECT c.DepartmentId, COUNT(*) AS Count
FROM Reports r
JOIN Categories c ON c.Id = r.CategoryId
GROUP BY c.DepartmentId) CountPerDepartment ON CountPerDepartment.DepartmentId = c.DepartmentId
ORDER BY d.Name, c.Name, Percentage