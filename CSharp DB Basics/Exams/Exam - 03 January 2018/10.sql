SELECT M.Manufacturer, M.Model, COUNT(O.Id) AS TimesOrdered
FROM Models M
LEFT JOIN Vehicles V ON V.ModelId = M.Id
LEFT JOIN Orders O ON O.VehicleId = V.Id
GROUP BY M.Id, M.Manufacturer, M.Model
ORDER BY TimesOrdered DESC, Manufacturer DESC, Model