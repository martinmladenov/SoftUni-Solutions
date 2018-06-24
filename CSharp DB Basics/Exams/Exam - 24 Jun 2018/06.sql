SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
YEAR(BirthDate) AS BirthYear
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY BirthYear DESC, FirstName