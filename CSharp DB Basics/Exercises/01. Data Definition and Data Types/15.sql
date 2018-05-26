CREATE DATABASE Hotel
GO

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(255) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title) VALUES
('Pesho', 'Peshov', 'Receptionist'),
('Gosho', 'Goshov', 'Cleaner'),
('Ivanka', 'Ivanova', 'Owner')

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(50),
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber INT NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO Customers(FirstName, LastName, EmergencyName, EmergencyNumber) VALUES
('Pesho', 'Peshov', 'Name1', 12343),
('Gosho', 'Peshov', 'Name2', 12334),
('Ivan', 'Peshov', 'Name3', 12434)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes	NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus) VALUES
('Status1'),
('Status2'),
('Status3')

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType) VALUES
('Type1'),
('Type2'),
('Type3')

CREATE TABLE BedTypes
(
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType) VALUES
('Small'),
('Medium'),
('Large')

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate DECIMAL(10, 2) NOT NULL,
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(101, 'Type1', 'Small', 100, 'Status1'),
(102, 'Type2', 'Medium', 200, 'Status2'),
(103, 'Type3', 'Large', 300, 'Status3')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10, 2) NOT NULL,
	TaxRate DECIMAL(10, 2) NOT NULL,
	TaxAmount DECIMAL(10, 2) NOT NULL,
	PaymentTotal DECIMAL(10, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal) VALUES
(1, '10-05-2015', 1, '10-05-2015', '10-10-2015', 5, 75, 50, 250, 75 ),
(3, '10-11-2015', 1, '12-15-2015', '12-25-2015', 10, 100, 50, 500, 100),
(2, '12-23-2015', 1, '12-23-2015', '12-24-2015', 1, 75, 75, 75, 75)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(10, 2),
	PhoneCharge VARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, PhoneCharge) VALUES
(2, '01-14-2011', 3, 1, '1234657891'),
(3, '05-16-2014', 2, 3, '1234657892'),
(1, '05-26-2018', 1, 2, '1234657893')