CREATE TRIGGER tr_EmployeesDelete ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary)
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
FROM deleted