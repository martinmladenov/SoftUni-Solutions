SELECT AgeGroup,
	SUM(Bill) AS Revenue,
	AVG(TotalMileage) AS AverageMileage
FROM
(SELECT 
	CASE
		WHEN YEAR(C.BirthDate) BETWEEN 1970 AND 1979
			THEN '70''s'
		WHEN YEAR(C.BirthDate) BETWEEN 1980 AND 1989
			THEN '80''s'
		WHEN YEAR(C.BirthDate) BETWEEN 1990 AND 1999
			THEN '90''s'
		ELSE 'Others'
	END AS AgeGroup,
	o.Bill,
	o.TotalMileage
FROM Clients C
JOIN Orders O On O.ClientId = C.Id) AS a
GROUP BY AgeGroup
ORDER BY AgeGroup