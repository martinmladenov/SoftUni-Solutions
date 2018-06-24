SELECT t.Id, SUM(at.Luggage) AS Luggage,
	CASE
		WHEN SUM(at.Luggage) > 5 THEN '$' + CONVERT(NVARCHAR, 5 * SUM(at.Luggage))
		ELSE '$0'
	END AS Fee
FROM Trips t
JOIN AccountsTrips at ON at.TripId = t.Id
GROUP BY t.Id
HAVING SUM(at.Luggage) > 0
ORDER BY Luggage DESC