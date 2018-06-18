CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	DECLARE @NewBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF(@NewBalance < 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT