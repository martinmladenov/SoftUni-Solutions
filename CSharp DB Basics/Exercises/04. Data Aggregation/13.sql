SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID