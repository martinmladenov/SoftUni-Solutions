CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2097152),
	Height DECIMAL(3, 2),
	Weight DECIMAL (5, 2),
	Gender CHAR CHECK(Gender IN ('m', 'f')) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Gender, Birthdate) VALUES
('Person1', 'm', '01-01-1991'),
('Person2', 'f', '05-07-1997'),
('Person3', 'm', '10-13-2017'),
('Person4', 'f', '10-09-1930'),
('Person5', 'f', '01-04-1955')