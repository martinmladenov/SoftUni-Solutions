SELECT TOP 10 E.FirstName + ' ' + E.LastName AS [Full Name],
       SUM(OI.Quantity  * I.Price) AS [Total Price],
       SUM(OI.Quantity) AS Items
FROM Orders O
JOIN Employees E on O.EmployeeId = E.Id
JOIN OrderItems OI on O.Id = OI.OrderId
JOIN Items I on OI.ItemId = I.Id
WHERE O.DateTime < '2018-06-15'
GROUP BY E.Id, E.FirstName, E.LastName
ORDER BY [Total Price] DESC, Items DESC
