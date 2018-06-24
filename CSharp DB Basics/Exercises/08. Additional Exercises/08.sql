SELECT p.PeakName, m.MountainRange, p.Elevation
FROM Peaks p
JOIN Mountains m ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, p.PeakName ASC