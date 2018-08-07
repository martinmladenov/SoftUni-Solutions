SELECT FirstName, LastName
FROM Clients
WHERE YEAR(BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName, LastName, Id