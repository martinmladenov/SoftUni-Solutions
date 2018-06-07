SELECT TOP 10 FirstName, LastName, DepartmentID
FROM Employees AS emp
WHERE
emp.Salary > (SELECT AVG(Salary)
FROM Employees AS department
WHERE emp.DepartmentID = department.DepartmentID)
ORDER BY DepartmentID