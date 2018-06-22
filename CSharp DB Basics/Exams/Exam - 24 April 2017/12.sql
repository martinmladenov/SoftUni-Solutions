SELECT ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total]
FROM Orders o
JOIN OrderParts op ON o.OrderId = op.OrderId
JOIN Parts p ON p.PartId = op.PartId
WHERE DATEDIFF(WEEK, o.IssueDate, '2017-04-24') <= 3