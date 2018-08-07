SELECT T.Name, O.Name, O.ParkingPlaces
FROM Offices O
JOIN Towns T ON T.Id = O.TownId
WHERE O.ParkingPlaces > 25
ORDER BY T.Name, O.Id