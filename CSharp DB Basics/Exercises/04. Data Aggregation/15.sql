SELECT * INTO TempEmployees
FROM Employees
WHERE Salary > 30000 

DELETE FROM TempEmployees WHERE ManagerId = 42

UPDATE TempEmployees
	SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
FROM TempEmployees
GROUP BY DepartmentID