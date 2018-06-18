CREATE TRIGGER tr_LogsUpdate ON Logs FOR INSERT AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
	SELECT AccountId,
		CONCAT('Balance change for account: ', AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ',
			OldSum, ' to ', NewSum, '.')
	FROM inserted
END