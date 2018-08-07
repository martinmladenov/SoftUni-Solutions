SELECT T.Name, COUNT(O.Id) AS Count
FROM Towns T
LEFT JOIN Offices O ON O.TownId = T.Id
GROUP BY T.Id, T.Name
ORDER BY Count DESC, T.Name