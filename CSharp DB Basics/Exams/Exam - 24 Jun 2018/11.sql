SELECT TOP 5 c.Id, c.Name, c.CountryCode, COUNT(a.Id) AS Accounts
FROM Cities c
JOIN Accounts a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC