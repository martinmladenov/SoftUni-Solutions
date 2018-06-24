SELECT a.Id, a.Email, c.Name, COUNT(t.Id) AS Trips
FROM Accounts a
JOIN Cities c ON c.Id = a.CityId
JOIN AccountsTrips at ON at.AccountId = a.Id
JOIN Trips t ON t.Id = at.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
WHERE h.CityId = a.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id