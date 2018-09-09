CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME) AS
  BEGIN

    DECLARE @IssueDate DATETIME =
    (SELECT DateTime FROM Orders WHERE Id = @OrderId)

    IF @IssueDate IS NULL
      BEGIN
        RAISERROR ('The order does not exist!', 16, 1)
        RETURN
      END

    IF DATEDIFF(DAY, @IssueDate, @CancelDate) >= 3
      BEGIN
        RAISERROR ('You cannot cancel the order!', 16, 1)
        RETURN
      END

    DELETE FROM OrderItems WHERE OrderId = @OrderId
    DELETE FROM Orders WHERE Id = @OrderId

  END

