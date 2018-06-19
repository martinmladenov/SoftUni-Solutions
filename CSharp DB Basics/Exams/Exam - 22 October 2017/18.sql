CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT) AS
BEGIN TRANSACTION

UPDATE Reports
SET EmployeeId = @employeeId
WHERE Id = @reportId

DECLARE @reportDepartmentId INT =
(SELECT c.DepartmentId
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
WHERE r.Id = @reportId)

DECLARE @employeeDepartmentId INT =
(SELECT DepartmentId
FROM Employees
WHERE Id = @employeeId)

IF @reportDepartmentId = @employeeDepartmentId
	COMMIT
ELSE BEGIN
	ROLLBACK
	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
END