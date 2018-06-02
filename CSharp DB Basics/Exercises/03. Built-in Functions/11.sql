SELECT PeakName,
 RiverName,
 CONCAT(LOWER(PeakName), SUBSTRING(LOWER(RiverName), 2, LEN(RiverName))) AS Mix 
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix ASC