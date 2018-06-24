CREATE TABLE Monasteries (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode) NOT NULL
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN
(SELECT c.CountryCode
FROM Countries c
JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryCode
HAVING COUNT(r.Id) > 3)

SELECT m.Name, c.CountryName
FROM Monasteries m
JOIN Countries c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted != 1
ORDER BY m.Name