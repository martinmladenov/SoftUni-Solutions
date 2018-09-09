SELECT E.FirstName, E.LastName, AVG(DATEDIFF(HOUR, S.CheckIn, S.CheckOut)) AS [Work Hours]
FROM Employees E
JOIN Shifts S on E.Id = S.EmployeeId
GROUP BY E.Id, E.FirstName, E.LastName
HAVING AVG(DATEDIFF(HOUR, S.CheckIn, S.CheckOut)) > 7
ORDER BY [Work Hours] DESC, E.Id
