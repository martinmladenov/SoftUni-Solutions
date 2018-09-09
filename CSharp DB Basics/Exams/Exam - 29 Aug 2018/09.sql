SELECT TOP 1 OI.OrderId, SUM(OI.Quantity * I.Price) AS TotalPrice
FROM OrderItems OI
JOIN Items I on OI.ItemId = I.Id
GROUP BY OI.OrderId
ORDER BY TotalPrice DESC
