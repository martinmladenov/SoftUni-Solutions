SELECT FirstName, LastName, COUNT(O.Id) AS Count
FROM Employees E
JOIN Orders O on E.Id = O.EmployeeId
GROUP BY E.Id, E.FirstName, E.LastName
ORDER BY Count DESC, FirstName
