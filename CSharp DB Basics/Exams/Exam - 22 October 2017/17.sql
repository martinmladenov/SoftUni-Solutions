CREATE FUNCTION udf_GetReportsCount (@employeeId INT, @statusId INT)
RETURNS INT AS
BEGIN
	RETURN 
	(SELECT COUNT(*)
	FROM Reports
	WHERE EmployeeId = @employeeId AND StatusId = @statusId)
END