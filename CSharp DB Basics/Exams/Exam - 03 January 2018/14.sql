SELECT O.Name, O.Email, O.Bill, T.Name AS Town
FROM
     (SELECT C.Id, C.FirstName + ' ' + C.LastName AS Name, C.Email, O.Bill, O.TownId,
             DENSE_RANK() OVER (PARTITION BY TownId ORDER BY Bill DESC) AS Rank
     FROM Orders O
     JOIN Clients C on O.ClientId = C.Id
     WHERE C.CardValidity < O.CollectionDate AND Bill IS NOT NULL) AS O
JOIN Towns T on O.TownId = T.Id
WHERE Rank <= 2
ORDER BY T.Name, O.Bill, O.Id