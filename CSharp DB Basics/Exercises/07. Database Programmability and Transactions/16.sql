CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	COMMIT