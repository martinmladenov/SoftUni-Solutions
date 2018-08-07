CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT) AS
  BEGIN
    DECLARE @officeParkingPlaces INT =
    (SELECT ParkingPlaces
    FROM Offices
    WHERE Id = @officeId)

    DECLARE @vehiclesInOffice INT =
    (SELECT COUNT(Id)
    FROM Vehicles
    WHERE OfficeId = @officeId)

    BEGIN TRANSACTION

    UPDATE Vehicles
    SET OfficeId = @officeId
    WHERE Id = @vehicleId

    IF @vehiclesInOffice >= @officeParkingPlaces
      BEGIN
        RAISERROR('Not enough room in this office!', 16, 1)
        ROLLBACK
        RETURN
      END

    COMMIT
  END
