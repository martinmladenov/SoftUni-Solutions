SELECT M.Manufacturer + ' - ' + M.Model AS Vehicle,
       CASE
           WHEN Location.ReturnOfficeId IS NULL AND Location.CollectionOfficeId IS NULL THEN 'home'
           WHEN Location.ReturnOfficeId IS NULL THEN 'on a rent'
           WHEN Location.ReturnOfficeId != V.OfficeId THEN RT.Name + ' - ' + RO.Name
       END AS Location
FROM
     (SELECT VehicleId, CollectionOfficeId, ReturnOfficeId,
             DENSE_RANK() OVER (PARTITION BY VehicleId ORDER BY CollectionDate DESC) AS Rank
     FROM Orders) AS Location
RIGHT JOIN Vehicles V ON Location.VehicleId = V.Id
LEFT JOIN Models M on V.ModelId = M.Id
LEFT JOIN Offices RO on Location.ReturnOfficeId = RO.Id
LEFT JOIN Towns RT on RO.TownId = RT.Id
WHERE Location.Rank = 1 OR Location.Rank IS NULL
ORDER BY Vehicle, V.Id
