SELECT DepartmentID, Salary FROM
(SELECT DepartmentId,
MAX(Salary) AS Salary,
DENSE_RANK() OVER 
(PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
FROM Employees
GROUP BY DepartmentID, Salary) AS Salaries 
WHERE Rank = 3