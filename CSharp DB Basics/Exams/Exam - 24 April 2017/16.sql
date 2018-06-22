SELECT *
FROM 
(SELECT p.PartId,
	p.Description,
	SUM(pn.Quantity) AS [Required],
	p.StockQty AS [In Stock],
	(SELECT ISNULL(SUM(op.Quantity), 0)
	FROM OrderParts op
	JOIN Orders o ON o.OrderId = op.OrderId
	WHERE o.Delivered = 0 AND op.PartId = p.PartId) AS Ordered
FROM PartsNeeded pn
JOIN Parts p ON p.PartId = pn.PartId
JOIN Jobs j ON j.JobId = pn.JobId
WHERE j.Status != 'Finished'
GROUP BY p.PartId, p.Description, p.StockQty) AS p
WHERE Required > [In Stock] + Ordered
ORDER BY PartId