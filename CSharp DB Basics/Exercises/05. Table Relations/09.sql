SELECT MountainRange, PeakName, Elevation
FROM Peaks
JOIN Mountains ON Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC