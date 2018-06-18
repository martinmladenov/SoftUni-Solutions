CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(7)) AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @level
END