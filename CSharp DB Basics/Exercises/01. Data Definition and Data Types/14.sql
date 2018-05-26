CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(6,2),
	WeeklyRate DECIMAL(6,2),
	MonthlyRate DECIMAL(6,2),
	WeekendRate DECIMAL(6,2)
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(50),
	Model VARCHAR(50),
	CarYear INT,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX),
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(20) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(100),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(20),
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(5, 2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL, 
	RateApplied DECIMAL(10, 2),
	TaxRate DECIMAL(10, 2),
	OrderStatus NVARCHAR(50),
	NOTES NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate) VALUES
('Category1', 100.00),
('Category2', 200.00),
('Category3', 300.00)

INSERT INTO Cars (PlateNumber, CategoryId) VALUES
('CA1234AA', 1),
('PB1324BA', 3),
('CA5678PP', 2)

INSERT INTO Employees (FirstName, LastName, Title) VALUES
('Pesho', 'Peshov', 'Receptionist'),
('Gosho', 'Goshov', 'Cleaner'),
('Ivanka', 'Ivanova', 'Owner')

INSERT INTO Customers (DriverLicenceNumber, FullName) VALUES
('123405', 'Ivan Ivanov'),
('876553', 'Pesho Goshov'),
('567202', 'Stoyanka Georgieva')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, StartDate, EndDate, TotalDays) VALUES
(1, 2, 3, '12-24-2017', '12-27-2017', 3),
(2, 3, 1, '11-13-2011', '11-17-2011', 4),
(3, 1, 2, '02-24-2017', '02-27-2018', 3)