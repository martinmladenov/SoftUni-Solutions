SELECT Manufacturer, AVG(Consumption) AS AverageConsumption
FROM
(SELECT TOP 7 m.Manufacturer, m.Consumption	
FROM Orders o
JOIN Vehicles v ON o.VehicleId = v.Id
JOIN Models m ON m.Id = v.ModelId
GROUP BY m.Id, m.Manufacturer, m.Consumption
ORDER BY COUNT(o.Id) DESC) AS M
GROUP BY Manufacturer
HAVING AVG(Consumption) BETWEEN 5 AND 15
ORDER BY Manufacturer, AverageConsumption 