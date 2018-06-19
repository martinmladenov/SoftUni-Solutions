SELECT c.Name, COUNT(r.Id)
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY COUNT(r.Id) DESC, c.Name ASC