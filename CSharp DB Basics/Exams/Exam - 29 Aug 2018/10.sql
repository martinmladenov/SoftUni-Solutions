SELECT TOP 10 OI.OrderId, MAX(I.Price) AS ExpensivePrice, MIN(I.Price) AS CheapPrice
FROM OrderItems OI
JOIN Items I on OI.ItemId = I.Id
GROUP BY OI.OrderId
ORDER BY ExpensivePrice DESC, OI.OrderId
