CREATE PROC usp_GetHoldersWithBalanceHigherThan(@higherThan MONEY) AS
BEGIN
	SELECT h.FirstName, h.LastName
	FROM AccountHolders h
	JOIN Accounts a ON h.Id = a.AccountHolderId
	GROUP BY h.Id, h.FirstName, h.LastName
	HAVING SUM(a.Balance) > @higherThan
	ORDER BY h.LastName, h.FirstName
END