CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4)) AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @minSalary
END