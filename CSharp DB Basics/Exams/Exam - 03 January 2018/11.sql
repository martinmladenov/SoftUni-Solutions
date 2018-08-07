SELECT C.FirstName + ' ' + C.LastName AS Name, O.Class
FROM Clients C
JOIN
(SELECT O.ClientId, M.Class, 
	DENSE_RANK() OVER(PARTITION BY O.ClientId ORDER BY COUNT(M.Class) DESC) AS Rank
FROM Orders O
JOIN Vehicles V ON V.Id = O.VehicleId
JOIN Models M ON M.Id = V.ModelId
GROUP BY O.ClientId, M.Class) AS O ON C.Id = O.ClientId
WHERE O.Rank = 1
ORDER BY Name, O.Class, C.Id