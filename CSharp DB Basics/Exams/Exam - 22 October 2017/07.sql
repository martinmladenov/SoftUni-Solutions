SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate
FROM Employees e
JOIN Reports r ON e.Id = r.EmployeeId
ORDER BY e.Id, r.OpenDate, r.Id