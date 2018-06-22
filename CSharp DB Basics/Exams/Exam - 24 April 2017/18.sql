CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @partSN VARCHAR(50), @quantity INT) AS

IF @quantity <= 0
	THROW 50012, 'Part quantity must be more than zero!', 1

ELSE IF
(SELECT COUNT(*)
FROM Jobs
WHERE JobId = @jobId) <> 1
	THROW 50013, 'Job not found!', 1

ELSE IF
(SELECT Status
FROM Jobs
WHERE JobId = @jobId) = 'Finished'
	THROW 50011, 'This job is not active!', 1

ELSE IF
(SELECT COUNT(*)
FROM Parts
WHERE SerialNumber = @partSN) <> 1
	THROW 50014, 'Part not found!', 1

ELSE
BEGIN
	IF
	(SELECT COUNT(*)
	FROM Orders
	WHERE JobId = @jobId AND IssueDate IS NULL) <> 1
	BEGIN
		INSERT INTO Orders (JobId, IssueDate) VALUES
		(@jobId, NULL)
	END

	DECLARE @orderId INT =
		(SELECT OrderId
		FROM Orders
		WHERE JobId = @jobId AND IssueDate IS NULL)


	DECLARE @partId INT =
		(SELECT PartId
		FROM Parts
		WHERE SerialNumber = @partSN)
	IF
	(SELECT COUNT(*)
	FROM OrderParts
	WHERE OrderId = @orderId AND PartId = @partId) <> 1
	BEGIN
		INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
		(@orderId, @partId, @quantity)
	END
	ELSE BEGIN
		UPDATE OrderParts
		SET Quantity += @quantity
		WHERE OrderId = @orderId AND PartId = @partId 
	END
END