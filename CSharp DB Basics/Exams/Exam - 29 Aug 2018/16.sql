SELECT DAY(O.DateTime) AS Day, SUM(OI.Quantity * I.Price)
FROM Orders O
JOIN OrderItems OI on O.Id = OI.OrderId
JOIN Items I on OI.ItemId = I.Id
GROUP BY DAY(O.DateTime)
ORDER BY Day
