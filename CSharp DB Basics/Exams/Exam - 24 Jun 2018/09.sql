SELECT r.Id, r.Price, h.Name, c.Name
FROM Rooms r
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c ON c.Id = h.CityId
WHERE r.Type = 'First Class'
ORDER BY Price DESC, r.Id