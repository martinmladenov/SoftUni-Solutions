SELECT c.Name, COUNT(e.Id)
FROM Departments d
JOIN Categories c ON c.DepartmentId = d.Id
JOIN Employees e ON e.DepartmentId = d.Id
GROUP BY c.Name
ORDER BY c.Name ASC