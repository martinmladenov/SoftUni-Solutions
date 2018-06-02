SELECT Name AS Game,
	CASE
		WHEN DATEPART(HOUR, Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration IS NULL THEN 'Extra Long'
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration <= 6 THEN 'Short'
		ELSE 'Long'
	END AS Duration
FROM Games
ORDER BY Name, Duration