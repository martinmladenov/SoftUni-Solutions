SELECT SUM(Difference)
FROM (SELECT DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference	
FROM WizzardDeposits) AS Differencses