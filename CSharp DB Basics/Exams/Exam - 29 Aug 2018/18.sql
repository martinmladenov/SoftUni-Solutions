CREATE FUNCTION udf_GetPromotedProducts
  (@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME,
   @Discount    INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
  RETURNS NVARCHAR(100) AS
  BEGIN

    DECLARE @FirstName NVARCHAR(30) =
    (SELECT Name FROM Items WHERE Id = @FirstItemId)

    DECLARE @SecondName NVARCHAR(30) =
    (SELECT Name FROM Items WHERE Id = @SecondItemId)

    DECLARE @ThirdName NVARCHAR(30) =
    (SELECT Name FROM Items WHERE Id = @ThirdItemId)

    IF @FirstName IS NULL
       OR @SecondName IS NULL
       OR @ThirdName IS NULL
      BEGIN
        RETURN 'One of the items does not exists!'
      END

    IF NOT @CurrentDate BETWEEN @StartDate AND @EndDate
      BEGIN
        RETURN 'The current date is not within the promotion dates!'
      END

    DECLARE @FirstPrice DECIMAL(15, 2) =
    (SELECT Price FROM Items WHERE Id = @FirstItemId)
    * (1 - @Discount / 100.0)

    DECLARE @SecondPrice DECIMAL(15, 2) =
    (SELECT Price FROM Items WHERE Id = @SecondItemId)
    * (1 - @Discount / 100.0)

    DECLARE @ThirdPrice DECIMAL(15, 2) =
    (SELECT Price FROM Items WHERE Id = @ThirdItemId)
    * (1 - @Discount / 100.0)

    RETURN @FirstName + ' price: ' + CONVERT(NVARCHAR, @FirstPrice) + ' <-> ' +
           @SecondName + ' price: ' + CONVERT(NVARCHAR, @SecondPrice) + ' <-> ' +
           @ThirdName + ' price: ' + CONVERT(NVARCHAR, @ThirdPrice)
  END
