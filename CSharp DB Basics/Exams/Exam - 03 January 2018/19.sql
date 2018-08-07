CREATE TRIGGER tr_UpdateOrders ON Orders AFTER UPDATE AS
  BEGIN
    UPDATE V
    SET Mileage += I.TotalMileage
    FROM Vehicles V
           JOIN inserted I ON I.VehicleId = V.Id
  END
