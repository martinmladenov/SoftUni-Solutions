SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY AddressId ASC