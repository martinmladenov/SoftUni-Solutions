SELECT t.Id, h.Name, r.Type,
	CASE
		WHEN t.CancelDate IS NOT NULL THEN 0
		ELSE COUNT(at.AccountId) * (r.Price + h.BaseRate)
	END AS Revenue
FROM Trips t
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN AccountsTrips at ON at.TripId = t.Id
GROUP BY t.Id, h.Name, r.Type, t.CancelDate, r.Price, h.BaseRate
ORDER BY r.Type, t.Id