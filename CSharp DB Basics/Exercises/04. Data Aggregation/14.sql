SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND YEAR(HireDate) >= 2000
GROUP BY DepartmentID