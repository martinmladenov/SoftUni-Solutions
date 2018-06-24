CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

	DECLARE @Room TABLE (
		Id INT NOT NULL,
		Price DECIMAL(20, 2) NOT NULL,
		Type NVARCHAR(20) NOT NULL,
		Beds INT NOT NULL
	)

	INSERT INTO @Room
	SELECT TOP 1 r.Id, (r.Price + h.BaseRate) * @People AS Price, r.Type, r.Beds
	FROM Rooms r
	JOIN Hotels h ON h.Id = r.HotelId
	WHERE r.HotelId = @HotelId
		AND r.Beds >= @People
		AND r.Id NOT IN
		(SELECT r.Id
		FROM Rooms r
		JOIN Trips t ON t.RoomId = r.Id
		WHERE @Date BETWEEN t.ArrivalDate AND t.ReturnDate)
	ORDER BY Price DESC

	DECLARE @RoomId INT =
		(SELECT Id FROM @Room)

	IF @RoomId IS NULL
		RETURN 'No rooms available'

	DECLARE @Price DECIMAL(20, 2) =
		(SELECT Price FROM @Room)

	DECLARE @Type NVARCHAR(20) =
		(SELECT Type FROM @Room)

	DECLARE @Beds INT =
		(SELECT Beds FROM @Room)

	RETURN FORMATMESSAGE('Room %d: %s (%d beds) - $%s', @RoomId, @Type, @Beds, CONVERT(NVARCHAR, @Price))

END