SELECT Id, FirstName, LastName
FROM Employees
WHERE Id IN
      (SELECT EmployeeId FROM Orders)
ORDER BY Id
