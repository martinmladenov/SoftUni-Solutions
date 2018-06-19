SELECT r.OpenDate, r.Description, u.Email
FROM Reports r
JOIN Users u ON r.UserId = u.Id
JOIN Categories c ON r.CategoryId = c.Id
JOIN Departments d ON c.DepartmentId = d.Id
WHERE r.CloseDate IS NULL
	AND LEN(r.Description) > 20
	AND r.Description LIKE '%str%'
	AND d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate ASC, u.Email ASC, r.Id ASC