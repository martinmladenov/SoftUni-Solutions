SELECT Description, OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC