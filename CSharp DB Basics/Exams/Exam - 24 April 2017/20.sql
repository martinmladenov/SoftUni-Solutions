WITH CTE_CountOfParts AS
(SELECT j.MechanicId, p.VendorId, SUM(op.Quantity) AS CountOfParts
FROM Jobs j
JOIN Orders o ON j.JobId = o.JobId
JOIN OrderParts op ON o.OrderId = op.OrderId
JOIN Parts p ON op.PartId = p.PartId
GROUP BY j.MechanicId, p.VendorId)

SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
	v.Name AS Vendor,
	c.CountOfParts AS Parts,
	(CONVERT(VARCHAR, 100 * c.CountOfParts / t.TotalParts) + '%') AS Preference
FROM Mechanics m
JOIN CTE_CountOfParts c ON m.MechanicId = c.MechanicId
JOIN Vendors v ON c.VendorId = v.VendorId
JOIN
(SELECT MechanicId, SUM(CountOfParts) AS TotalParts
FROM CTE_CountOfParts
GROUP BY MechanicId) AS t ON m.MechanicId = t.MechanicId
ORDER BY Mechanic ASC, Parts DESC, Vendor ASC