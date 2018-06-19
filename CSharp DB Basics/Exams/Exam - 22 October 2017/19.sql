CREATE TRIGGER tr_ReportsUpdate ON Reports FOR UPDATE AS
UPDATE Reports
SET StatusId = 3
WHERE Id IN
(SELECT Id
FROM inserted
WHERE CloseDate IS NOT NULL)