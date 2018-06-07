SELECT AgeGroup, COUNT(*) FROM
(SELECT
	CASE
		WHEN Age <= 10 THEN '[0-10]'
		WHEN Age <= 20 THEN '[11-20]'
		WHEN Age <= 30 THEN '[21-30]'
		WHEN Age <= 40 THEN '[31-40]'
		WHEN Age <= 50 THEN '[41-50]'
		WHEN Age <= 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS Groups
GROUP BY AgeGroup