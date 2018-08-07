CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
  RETURNS NVARCHAR(100) AS
BEGIN
  DECLARE @vehicle NVARCHAR(100) =
  (SELECT TOP 1 O.Name + ' - ' + M.Model
  FROM Vehicles V
  JOIN Offices O on V.OfficeId = O.Id
  JOIN Towns T on O.TownId = T.Id
  JOIN Models M on V.ModelId = M.Id
  WHERE T.Name = @townName AND M.Seats = @seatsNumber
  ORDER BY O.Name)

  IF @vehicle IS NULL
    RETURN 'NO SUCH VEHICLE FOUND'

  RETURN @vehicle
END
