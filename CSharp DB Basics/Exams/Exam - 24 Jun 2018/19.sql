CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT) AS

DECLARE @TripHotelId INT = 
(SELECT h.Id
FROM Hotels h
JOIN Rooms r ON r.HotelId = h.Id
JOIN Trips t ON t.RoomId = r.Id
WHERE t.Id = @TripId)

DECLARE @BedsRequired INT =
(SELECT COUNT(*)
FROM AccountsTrips
WHERE TripId = @TripId)

DECLARE @TargetHotelId INT =
(SELECT h.Id
FROM Hotels h
JOIN Rooms r ON r.HotelId = h.Id
WHERE r.Id = @TargetRoomId)

DECLARE @TargetRoomBeds INT =
(SELECT Beds
FROM Rooms 
WHERE Id = @TargetRoomId)

IF @TargetHotelId != @TripHotelId
BEGIN
	RAISERROR('Target room is in another hotel!', 16, 1)
	RETURN
END
		
IF @BedsRequired > @TargetRoomBeds
BEGIN
	RAISERROR('Not enough beds in target room!', 16, 1)
	RETURN
END

UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId