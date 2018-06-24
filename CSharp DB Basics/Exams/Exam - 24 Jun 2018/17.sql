SELECT t.Id,
	a.FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
	f.Name AS [From],
	c.Name AS [To],
	CASE
		WHEN t.CancelDate IS NULL
			THEN CONVERT(NVARCHAR, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
		ELSE 'Canceled'
	END AS Duration
FROM Accounts a
JOIN Cities f ON f.Id = a.CityId
JOIN AccountsTrips at ON at.AccountId = a.Id
JOIN Trips t ON t.Id = at.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c ON c.Id = h.CityId
ORDER BY [Full Name], t.Id