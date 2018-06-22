SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Jobs j
JOIN Mechanics m ON m.MechanicId = j.MechanicId
WHERE j.Status = 'Finished'
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId