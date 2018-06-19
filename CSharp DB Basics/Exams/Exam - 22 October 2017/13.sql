SELECT DISTINCT u.Username
FROM Users u
JOIN Reports r ON r.UserId = u.Id
WHERE (u.Username LIKE '%[0-9]' AND RIGHT(u.Username, 1) = CAST(r.CategoryId AS VARCHAR))
	OR (u.Username LIKE '[0-9]%' AND LEFT(u.Username, 1) = CAST(r.CategoryId AS VARCHAR))
ORDER BY u.Username ASC