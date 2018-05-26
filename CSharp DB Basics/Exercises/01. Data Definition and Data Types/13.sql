CREATE DATABASE Movies
GO

USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT,
	Length NVARCHAR(50),
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName) VALUES
('DName1'),
('DName2'),
('DName3'),
('DName4'),
('DName5')

INSERT INTO Genres (GenreName) VALUES
('GName1'),
('GName2'),
('GName3'),
('GName4'),
('GName5')

INSERT INTO Categories(CategoryName) VALUES
('CName1'),
('CName2'),
('CName3'),
('CName4'),
('CName5')

INSERT INTO Movies (Title, DirectorId, GenreId, CategoryId) VALUES
('Title1', 1, 2, 5),
('Title2', 2, 3, 4),
('Title3', 4, 1, 1),
('Title4', 5, 4, 3),
('Title5', 3, 5, 2)