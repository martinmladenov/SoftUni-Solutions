CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @MoneyAmount MONEY) AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @SenderId

	DECLARE @NewBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @SenderId)

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @ReceiverId

	IF(@NewBalance < 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT