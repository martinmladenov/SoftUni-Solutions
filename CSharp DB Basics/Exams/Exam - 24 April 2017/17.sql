CREATE FUNCTION udf_GetCost (@jobId INT) RETURNS DECIMAL(15, 2) AS
BEGIN
	DECLARE @sum DECIMAL(15, 2) =
	(SELECT ISNULL(SUM(op.Quantity * p.Price), 0)
	FROM Orders o
	JOIN OrderParts op ON o.OrderId = op.OrderId
	JOIN Parts p ON op.PartId = p.PartId
	WHERE o.JobId = @jobId)
	RETURN @sum
END