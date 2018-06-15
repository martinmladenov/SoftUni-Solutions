SELECT TOP 5 c.CountryName,
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(peakElevation.[Highest Peak Elevation], 0) AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain
FROM
(SELECT c.CountryCode, MAX(p.Elevation) AS [Highest Peak Elevation]
FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
GROUP BY c.CountryCode) AS peakElevation
LEFT JOIN Countries c ON c.CountryCode = peakElevation.CountryCode
LEFT JOIN Peaks p ON p.Elevation = peakElevation.[Highest Peak Elevation]
LEFT JOIN MountainsCountries mc ON p.MountainId = mc.MountainId AND mc.CountryCode = peakElevation.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
ORDER BY c.CountryName, p.PeakName