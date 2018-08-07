SELECT M.Model, M.Seats, V.Mileage
FROM Vehicles V
JOIN Models M ON V.ModelId = M.Id
WHERE V.Id NOT IN
(SELECT VehicleId
FROM Orders
WHERE ReturnDate IS NULL)
ORDER BY V.Mileage, M.Seats DESC, M.Id