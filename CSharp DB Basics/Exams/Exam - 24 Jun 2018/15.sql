SELECT Id, Email, CountryCode, Trips
FROM
(SELECT a.Id, a.Email, c.CountryCode, COUNT(t.Id) AS Trips,
	DENSE_RANK() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC, a.Id) AS Rank
FROM Accounts a
JOIN AccountsTrips at ON at.AccountId = a.Id
JOIN Trips t ON t.Id = at.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c ON c.Id = h.CityId
GROUP BY a.Id, a.Email, c.CountryCode) AS t
WHERE Rank = 1
ORDER BY Trips DESC, Id