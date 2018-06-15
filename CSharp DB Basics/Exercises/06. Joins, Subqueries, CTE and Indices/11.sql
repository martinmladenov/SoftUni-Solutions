SELECT TOP 1 AVG(Salary) as MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary ASC