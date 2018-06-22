SELECT FirstName + ' ' + LastName AS Mechanic
FROM Mechanics
WHERE MechanicId NOT IN
(SELECT MechanicId
FROM Jobs
WHERE Status != 'Finished' AND MechanicId IS NOT NULL)
ORDER BY MechanicId