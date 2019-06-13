CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY,
[DirectorName] NVARCHAR(20) NOT NULL,
[Notes] NTEXT 
)

CREATE TABLE Genres(
Id INT PRIMARY KEY,
[GenreName] NVARCHAR(20) NOT NULL,
[Notes] NTEXT 
)

CREATE TABLE Categories(
Id INT PRIMARY KEY,
[CategoryName] NVARCHAR(20) NOT NULL,
[Notes] NTEXT 
)

CREATE TABLE Movies(
Id INT PRIMARY KEY,
[Title] NVARCHAR(50),
[DirectorId] INT NOT NULL,
[CopyrightYear] DATE NOT NULL,
[Length] TIME NOT NULL,
[GenreId] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Rating] INT,
[Notes] NTEXT
)

INSERT INTO Directors(Id,[DirectorName],[Notes])
VALUES (1, 'Gosho', 'asd'),
(2, 'Gosho', 'asd'),
(3, 'Gosho', 'asd'),
(4, 'Gosho', 'asd'),
(5, 'Gosho', 'asd')

INSERT INTO Genres(Id,[GenreName],[Notes])
VALUES (1, 'trilur', 'asd'),
(2, 'ekshun', 'asd'),
(3, 'drama', 'asd'),
(4, 'romantichen', 'asd'),
(5, 'biografichen', 'asd')

INSERT INTO Categories(Id,CategoryName,[Notes])
VALUES (1, 'trilur', 'asd'),
(2, 'ekshun', 'asd'),
(3, 'drama', 'asd'),
(4, 'romantichen', 'asd'),
(5, 'biografichen', 'asd')

INSERT INTO Movies(Id,[Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating],[Notes])
VALUES (1,'asd',1,'2008-11-11','12:15:04.1237',1,1,2,'asd'),
(2,'asd',2,'2008-11-1','12:15:04.1237',2,1,2,'asd'),
(3,'asd',3,'2008-11-11','12:15:04.1237',3,1,2,'asd'),
(4,'asd',4,'2008-11-11','12:15:04.1237',4,1,2,'asd'),
(5,'asd',5,'2008-11-11','12:15:04.1237',5,1,2,'asd')
----------------

CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY,
[CategoryName] NVARCHAR(50),
[DailyRate] FLOAT,
[WeeklyRate] FLOAT,
[MonthlyRate] FLOAT,
[WeekendRate] FLOAT 
)

CREATE TABLE Cars(
Id INT PRIMARY KEY,
[PlateNumber] INT,
[Manufacter] NVARCHAR(50),
[Model] NVARCHAR(50),
[CarYear] DATE,
[CategoryId] INT,
[Doors] INT,
[Picture] VARBINARY(MAX),
[Condition] NVARCHAR(50),
[Available] BIT
)

CREATE TABLE Employees(
Id INT PRIMARY KEY,
[FirstName] NVARCHAR(50),
[LastName] NVARCHAR(50),
[Title] NVARCHAR(50),
[Notes] TEXT
)

CREATE TABLE Customers(
Id INT PRIMARY KEY,
[DriverLicenceNumber] NVARCHAR(50),
[FullName] NVARCHAR(50),
[Address] NVARCHAR(50),
[City] NVARCHAR(50),
[ZIPCode] NVARCHAR(50),
[Notes] TEXT
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY,
EmployeeId INT,
CustomerId INT,
CarId INT,
TankLevel INT,
KilometrageStart BIGINT,
KilometrageEnd BIGINT,
TotalKilometrage BIGINT,
StartDate DATETIME,
EndDate DATETIME,
TotalDays INT,
RateApplied INT,
TaxRate FLOAT,
OrderStatus BIT,
Notes TEXT
)

INSERT INTO Categories(Id, CategoryName, [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES (1,'asd', 3,4,5,6),
(2,'asd', 3,4,5,6),
(3,'asd', 3,4,5,6)

INSERT INTO Cars(Id, PlateNumber, Manufacter, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES (1,1,'asd','asd','2012-10-10',1,2,null,'good',1),
(2,1,'asd','asd','2012-10-10',1,2,null,'good',1),
(3,1,'asd','asd','2012-10-10',1,2,null,'good',1)

INSERT INTO Employees(Id, FirstName, LastName, Title, Notes)
VALUES (1,'asd','asd','asd','asdasdasd'),
(2,'asd','asd','asd','asdasdasd'),
(3,'asd','asd','asd','asdasdasd')

INSERT INTO Customers(Id, DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES (1,'asd','asd','asd','asd','asdasd','asd'),
(2,'asd','asd','asd','asd','asdasd','asd'),
(3,'asd','asd','asd','asd','asdasd','asd')

INSERT INTO RentalOrders(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1,2,3,4,5,123,1245,124,'2020-10-12','2020-10-12',1,1,1,1,'asd'),
(2,2,3,4,5,123,1245,124,'2020-10-12','2020-10-12',1,1,1,1,'asd'),
(3,2,3,4,5,123,1245,124,'2020-10-12','2020-10-12',1,1,1,1,'asd')
------------


CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees (
	Id int IDENTITY,
	FirstName nvarchar(200) NOT NULL, 
	LastName nvarchar(200) NOT NULL, 
	Title nvarchar(200) NOT NULL, 
	Notes nvarchar(max),
	PRIMARY KEY (Id)
)

CREATE TABLE Customers (
	AccountNumber int IDENTITY,
	FirstName nvarchar(200) NOT NULL, 
	LastName nvarchar(200) NOT NULL, 
	PhoneNumber bigint NOT NULL,
	EmergencyName nvarchar(200),
	EmergencyNumber bigint,
	Notes nvarchar(max),
	PRIMARY KEY (AccountNumber),
	CHECK (PhoneNumber > 0)
)

CREATE TABLE RoomStatus (
	RoomStatus nvarchar(200) NOT NULL UNIQUE, 
	Notes nvarchar(max),
	PRIMARY KEY (RoomStatus)
)

CREATE TABLE RoomTypes (
	RoomType nvarchar(200) NOT NULL UNIQUE, 
	Notes nvarchar(max),
	PRIMARY KEY (RoomType)
)

CREATE TABLE BedTypes (
	BedType nvarchar(200) NOT NULL UNIQUE, 
	Notes nvarchar(max),
	PRIMARY KEY (BedType)
)

CREATE TABLE Rooms (
	RoomNumber int IDENTITY,
	RoomType nvarchar(200) NOT NULL,
	BedType nvarchar(200) NOT NULL,
	Rate money NOT NULL,
	RoomStatus nvarchar(200) NOT NULL,
	Note nvarchar(max),
	PRIMARY KEY (RoomNumber),
	FOREIGN KEY (RoomType) REFERENCES RoomTypes (RoomType),
	FOREIGN KEY (BedType) REFERENCES BedTypes (BedType),
	FOREIGN KEY (RoomStatus) REFERENCES RoomStatus (RoomStatus),
	CHECK (Rate >= 0)	
)

CREATE TABLE Payments (
	Id int IDENTITY, 
	EmployeeId int NOT NULL, 
	PaymentDate date NOT NULL, 
	AccountNumber int NOT NULL, 
	FirstDateOccupied date NOT NULL, 
	LastDateOccupied date NOT NULL, 
	TotalDays int NOT NULL, 
	AmountCharged money NOT NULL, 
	TaxRate money NOT NULL, 
	TaxAmount money NOT NULL, 
	PaymentTotal money NOT NULL, 
	Notes nvarchar(max),
	PRIMARY KEY (Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
	FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
	CHECK (TotalDays = DATEDIFF(day, FirstDateOccupied, LastDateOccupied)),
	--drop the next 2 TaxRate ralated constraints before a TaxRate update (Problem 23)
	CONSTRAINT CK_Payments_TaxAmount CHECK (TaxAmount = AmountCharged * TaxRate), 
	CONSTRAINT CK_Payments_PaymentTotal CHECK (PaymentTotal = AmountCharged + TaxAmount)
)

CREATE TABLE Occupancies (
	Id int IDENTITY, 
	EmployeeId int NOT NULL, 
	DateOccupied date NOT NULL, 
	AccountNumber int NOT NULL, 
	RoomNumber int NOT NULL, 
	RateApplied money NOT NULL, 
	PhoneCharge money NOT NULL DEFAULT 0, 
	Notes nvarchar(max),
	PRIMARY KEY (Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
	FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
	FOREIGN KEY (RoomNumber) REFERENCES Rooms (RoomNumber),
	CHECK (PhoneCharge >= 0)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
	('Tom', 'Barnes', 'Hotel Manager', NULL),
	('David', 'Jones', 'CEO', NULL),
	('Eva', 'Michado', 'Chambermaid', 'Late for work')
	
INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
	('Angela','Merkel', 49123456789, 'Barroso', 32987654321),
	('Barack','Obama', 1123456789, NULL, NULL),
	('Margaret','Thacher', 41987654321, NULL, NULL)

INSERT INTO RoomStatus (RoomStatus)
VALUES
	('Reserved'), ('Occupied'), ('Available')

INSERT INTO RoomTypes (RoomType)
VALUES
	('Single'), ('Double'), ('Suite')

INSERT INTO BedTypes (BedType)
VALUES
	('Single'), ('Twin'), ('Double')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus)
VALUES
	('Single', 'Single', 70, 'Reserved'),
	('Double', 'Twin', 100, 'Occupied'),
	('Suite', 'Double', 110, 'Available')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES
	(1, '2017-01-22', 1, '2017-01-21', '2017-01-22', 1, 100, 0.20, 20, 120),
	(1, '2017-01-22', 2, '2017-01-20', '2017-01-22', 2, 200, 0.20, 40, 240),
	(1, '2017-01-22', 3, '2017-01-19', '2017-01-22', 3, 300, 0.20, 60, 360)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES
	(1, '2014-01-22', 1, 1, 70, 0),
	(2, '2014-01-22', 2, 2, 100, 0),
	(3, '2014-01-22', 3, 3, 110, 10)