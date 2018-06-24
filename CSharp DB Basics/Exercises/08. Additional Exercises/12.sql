SELECT con.ContinentName, SUM(CAST(c.AreaInSqKm AS BIGINT)) AS CountriesArea, SUM(CAST(c.Population AS BIGINT)) As CountriesPopulation
FROM Countries c
JOIN Continents con ON c.ContinentCode = con.ContinentCode
GROUP BY con.ContinentCode, con.ContinentName
ORDER BY CountriesPopulation DESC