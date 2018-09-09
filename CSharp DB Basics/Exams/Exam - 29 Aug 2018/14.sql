SELECT E.FirstName + ' ' + E.LastName AS [Full Name],
       DATENAME(WEEKDAY, S.CheckIn) AS [Day of Week]
FROM Employees E
JOIN Shifts S on E.Id = S.EmployeeId
LEFT JOIN Orders O on E.Id = O.EmployeeId
WHERE DATEDIFF(HOUR, S.CheckIn, S.CheckOut) > 12
  AND O.Id IS NULL
ORDER BY E.Id
