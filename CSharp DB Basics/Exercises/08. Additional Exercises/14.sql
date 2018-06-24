UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Hanga Abbey', CountryCode
FROM Countries
WHERE CountryName = 'Tanzania'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Myin-Tin-Daik', CountryCode
FROM Countries
WHERE CountryName = 'Myanmar'

SELECT con.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents con
RIGHT JOIN Countries c ON con.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries m ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted != 1
GROUP BY con.ContinentName, c.CountryCode, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName