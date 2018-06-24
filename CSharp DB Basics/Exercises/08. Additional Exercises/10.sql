SELECT c.CountryName, con.ContinentName,
	COUNT(r.Id) AS RiversCount, ISNULL(SUM(r.Length), 0) AS TotalLength
FROM Rivers r
JOIN CountriesRivers cr ON r.Id = cr.RiverId
RIGHT JOIN Countries c ON cr.CountryCode = c.CountryCode
LEFT JOIN Continents con ON c.ContinentCode = con.ContinentCode
GROUP BY c.CountryCode, c.CountryName, con.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName