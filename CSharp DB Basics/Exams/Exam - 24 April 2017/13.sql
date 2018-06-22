SELECT j.JobId, ISNULL(SUM(op.Quantity * p.Price), 0) AS Total
FROM Orders o
JOIN OrderParts op ON o.OrderId = op.OrderId
JOIN Parts p ON p.PartId = op.PartId
RIGHT JOIN Jobs j ON o.JobId = j.JobId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC