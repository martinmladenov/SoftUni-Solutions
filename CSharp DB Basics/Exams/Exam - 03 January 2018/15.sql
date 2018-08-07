WITH CTE_Genders (TownId, Gender) AS
(SELECT O.TownId, C.Gender
FROM Orders O
JOIN Clients C on O.ClientId = C.Id)

SELECT T.Name,
       Male.Count * 100 / (ISNULL(Male.Count, 0) + ISNULL(Female.Count, 0)) AS MalePercent,
       Female.Count * 100 / (ISNULL(Male.Count, 0) + ISNULL(Female.Count, 0)) AS FemalePercent
FROM Towns T
FULL JOIN
    (SELECT TownId, COUNT(Gender) AS Count
    FROM CTE_Genders
    WHERE Gender = 'M'
    GROUP BY TownId) AS Male ON T.Id = Male.TownId
FULL JOIN
    (SELECT TownId, COUNT(Gender) AS Count
    FROM CTE_Genders
    WHERE Gender = 'F'
    GROUP BY TownId) AS Female ON T.Id = Female.TownId
ORDER BY T.Name, T.Id
