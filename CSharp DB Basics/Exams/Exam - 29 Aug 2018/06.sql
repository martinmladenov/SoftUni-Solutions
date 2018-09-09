SELECT FirstName + ' ' + LastName AS [Full Name], Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone
