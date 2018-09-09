SELECT I.Name, C.Name, SUM(OI.Quantity) AS Count, SUM(OI.Quantity * I.Price) AS TotalPrice
FROM Items I
JOIN Categories C on I.CategoryId = C.Id
LEFT JOIN OrderItems OI on I.Id = OI.ItemId
LEFT JOIN Orders O on OI.OrderId = O.Id
GROUP BY I.Id, I.Name, C.Name
ORDER BY TotalPrice DESC, Count DESC
