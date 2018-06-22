SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
COUNT(j.JobId) AS Jobs
FROM Jobs j
JOIN Mechanics m ON m.MechanicId = j.MechanicId
WHERE j.Status != 'Finished'
GROUP BY m.MechanicId, m.FirstName, m.LastName
HAVING COUNT(j.JobId) > 1
ORDER BY Jobs DESC, m.MechanicId ASC