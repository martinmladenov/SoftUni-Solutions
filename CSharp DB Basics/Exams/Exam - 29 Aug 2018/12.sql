SELECT DISTINCT E.Id, E.FirstName + ' ' + E.LastName AS [Full Name]
FROM Employees E
JOIN Shifts S on E.Id = S.EmployeeId
WHERE DATEDIFF(HOUR, S.CheckIn, S.CheckOut) < 4
ORDER BY E.Id
