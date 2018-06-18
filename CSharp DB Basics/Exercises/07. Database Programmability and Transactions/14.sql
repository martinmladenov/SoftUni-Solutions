CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted i, deleted d
END