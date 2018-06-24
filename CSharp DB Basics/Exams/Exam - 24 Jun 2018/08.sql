SELECT c.Name AS City, COUNT(h.Id) AS Hotels
FROM Cities c
LEFT JOIN Hotels h ON h.CityId = c.Id
GROUP BY c.Id, c.Name
ORDER BY Hotels DESC, c.Name