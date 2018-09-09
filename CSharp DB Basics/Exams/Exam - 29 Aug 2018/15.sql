SELECT E.FirstName + ' ' + e.LastName AS FullName,
       DATEDIFF(HOUR, S.CheckIn, S.CheckOut) AS WorkHours,
       O.TotalPrice
FROM Employees E
JOIN (SELECT O.EmployeeId, O.DateTime,
       SUM(OI.Quantity * I.Price) AS TotalPrice,
       DENSE_RANK() OVER
          (PARTITION BY O.EmployeeId
          ORDER BY SUM(OI.Quantity * I.Price) DESC) AS Rank
  FROM Orders O
  JOIN OrderItems OI on O.Id = OI.OrderId
  JOIN Items I on OI.ItemId = I.Id
  GROUP BY O.Id, O.EmployeeId, O.DateTime) O ON E.Id = O.EmployeeId
JOIN Shifts S ON S.EmployeeId = E.Id AND O.DateTime BETWEEN S.CheckIn AND S.CheckOut
WHERE O.Rank = 1
ORDER BY FullName, WorkHours DESC, TotalPrice DESC
