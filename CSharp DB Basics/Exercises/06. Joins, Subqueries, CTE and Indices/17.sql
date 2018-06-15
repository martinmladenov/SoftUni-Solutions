SELECT TOP 5 c.CountryName, pe.HighestPeakElevation, rl.LongestRiverLength
FROM Countries c
JOIN (SELECT CountryCode, MAX(p.Elevation) AS HighestPeakElevation
FROM Peaks p
JOIN MountainsCountries mc ON p.MountainId = mc.MountainId
GROUP BY mc.CountryCode) pe ON c.CountryCode = pe.CountryCode
JOIN (SELECT CountryCode, MAX(r.Length) AS LongestRiverLength
FROM Rivers r
JOIN CountriesRivers cr ON r.Id = cr.RiverId
GROUP BY cr.CountryCode) rl ON c.CountryCode = rl.CountryCode
ORDER BY pe.HighestPeakElevation DESC, rl.LongestRiverLength DESC, c.CountryName ASC