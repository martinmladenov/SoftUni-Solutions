CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) AS
BEGIN
	DECLARE @newManager INT = (SELECT e.ManagerID FROM Departments d JOIN Employees e ON d.ManagerID = e.EmployeeID WHERE d.DepartmentID = @departmentId)

	UPDATE d
	SET d.ManagerID = @newManager
	FROM Departments d JOIN Employees e ON d.ManagerID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	UPDATE e
	SET e.ManagerID = @newManager
	FROM Employees e JOIN Employees m ON e.ManagerID = m.EmployeeID
	WHERE e.DepartmentID != @departmentId AND m.DepartmentID = @departmentId

	DELETE FROM ep
	FROM EmployeesProjects ep JOIN Employees e ON ep.EmployeeID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	DELETE FROM Employees WHERE DepartmentID = @departmentId
	DELETE FROM Departments WHERE DepartmentID = @departmentId
	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId
END