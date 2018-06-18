CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) AS
BEGIN TRANSACTION
INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
(@emloyeeId, @projectID)

DECLARE @Count INT =
(SELECT COUNT(*)
FROM EmployeesProjects
WHERE EmployeeID = @emloyeeId)

IF @Count > 3
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

COMMIT