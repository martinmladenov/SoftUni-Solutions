SELECT e.FirstName, e.LastName, e.HireDate, d.Name
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1/1/1999' AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY e.HireDate ASC