SELECT DISTINCT c.Name
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
JOIN Users u ON r.UserId = u.Id
WHERE DAY(u.BirthDate) = DAY(r.OpenDate)
	AND MONTH(u.BirthDate) = MONTH(r.OpenDate)
ORDER BY c.Name ASC