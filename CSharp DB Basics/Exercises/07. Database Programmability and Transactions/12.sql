CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT) AS
BEGIN
	SELECT a.Id, h.FirstName, h.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM Accounts a
	JOIN AccountHolders h ON a.AccountHolderId = h.Id
	WHERE a.Id = @accountId
END