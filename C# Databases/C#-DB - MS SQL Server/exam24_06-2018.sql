CREATE TABLE Cities(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(15,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
Id INT PRIMARY KEY IDENTITY,
RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
BookDate Date NOT NULL,
ArrivalDate Date NOT NULL,
ReturnDate Date NOT NULL,
CancelDate Date
)

ALTER TABLE Trips
ADD CONSTRAINT CH_BookDate CHECK(BookDate < ArrivalDate),
CONSTRAINT CH_ArrivalDate CHECK(ArrivalDate < ReturnDate)

CREATE TABLE Accounts(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
BirthDate Date NOT NULL,
Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
Luggage INT NOT NULL 

CHECK(Luggage >= 0)

PRIMARY KEY(AccountId, TripId)
)

--2

INSERT INTO Accounts
VALUES ('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
		('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
		('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
		('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips
VALUES (101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
		(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
		(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
		(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
		(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--3

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)

--4

DELETE FROM AccountsTrips
WHERE AccountId = 47

--5

SELECT Id, Name
FROM Cities
WHERE CountryCode = 'BG'
ORDER BY Name

--6

SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName, YEAR(BirthDate) AS BirthYear
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY BirthYear DESC, FirstName

--7

SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy'), c.Name, Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name DESC

--8

SELECT c.Name, COUNT(h.Id) AS HotelCount
FROM Cities AS c
LEFT JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY HotelCount DESC, c.Name

--9

SELECT r.Id, r.Price, h.Name, c.Name
FROM Rooms AS r
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE r.Type = 'First Class'
ORDER BY r.Price DESC, r.Id

--10

SELECT a.Id, FirstName + ' ' + LastName, 
MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip, 
MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate))
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
JOIN Trips AS t ON t.Id = [at].TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, FirstName + ' ' + LastName
ORDER BY LongestTrip DESC, a.Id

--11

SELECT TOP(5) c.Id, c.Name, c.CountryCode, COUNT(a.Id) AccountCount
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY AccountCount DESC

--12

SELECT a.Id, a.Email, c.Name, COUNT(t.Id) AS TripCount
FROM Accounts AS a
JOIN AccountsTrips AS at ON at.AccountId = a.Id
JOIN Trips AS t ON t.Id = at.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE h.CityId = a.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY TripCount DESC, a.Id

--13

SELECT TOP(10) c.Id, c.Name, SUM(h.BaseRate + r.Price) AS TotalRevenue, COUNT(t.Id) AS TripCount
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
JOIN Rooms AS r ON r.HotelId = h.Id
JOIN Trips AS t ON t.RoomId = r.Id
WHERE YEAR(t.BookDate) = 2016
GROUP BY c.Id, c.Name
ORDER BY TotalRevenue DESC, TripCount DESC

--14

SELECT t.Id, h.Name, r.Type, 
CASE
WHEN t.CancelDate IS NULL THEN SUM(r.Price + h.BaseRate)
ELSE 0
END
FROM Trips AS t
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN AccountsTrips AS at ON at.TripId = t.Id
GROUP BY t.Id, h.Name, r.Type, t.CancelDate
ORDER BY r.[Type], t.Id

--15


SELECT k.Id, k.Email, k.CountryCode, k.TripCount
FROM
(SELECT a.Id, a.Email, c.CountryCode, COUNT(at.TripId) AS TripCount,
ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(at.TripId) DESC) MostTrips
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
JOIN Trips AS t ON t.Id = at.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
GROUP BY a.Id, a.Email, c.CountryCode) AS k
WHERE MostTrips = 1
ORDER BY k.TripCount DESC, k.Id

--16

SELECT t.Id, SUM(at.Luggage),
CASE
WHEN SUM(at.Luggage) > 5 THEN CONCAT('$', SUM(at.Luggage) * 5)
ELSE '$0'
END
FROM Trips AS t
JOIN AccountsTrips AS [at] ON [at].TripId = t.Id
GROUP BY t.Id
HAVING SUM(at.Luggage) > 0
ORDER BY SUM(at.Luggage) DESC

--17

SELECT t.Id, FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS FullName, ac.Name AS [From], c.Name [To],
CASE
WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
ELSE CONVERT(varchar, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
END
FROM Trips AS t
JOIN AccountsTrips AS at ON at.TripId = t.Id
JOIN Accounts AS a ON a.Id = at.AccountId
JOIN Cities AS ac ON ac.Id = a.CityId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
ORDER BY FullName, t.Id

--18
GO

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT , @Date DATETIME2, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @room NVARCHAR(MAX) = (SELECT TOP(1) CONCAT('Room ',r.Id,': ',r.Type,' (',r.Beds, ' beds', ') - $',
	(h.BaseRate + r.Price) * @People)
	FROM Hotels AS h
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE h.Id = @HotelId AND @Date NOT BETWEEN t.ArrivalDate AND t.BookDate AND t.CancelDate IS NULL AND
	r.Beds > @People
	ORDER BY r.Price DESC)
	

	IF(@room IS NULL)
	BEGIN
		RETURN 'No rooms available'
	END

	RETURN @room
END
GO
--SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
--SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--19
GO

CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @hotelId INT = (SELECT TOP(1) r.HotelId FROM Trips AS T
	JOIN Rooms AS r ON r.Id = t.RoomId
	WHERE t.Id = @TripId)

	DECLARE @targetRoomHotel INT = (SELECT TOP(1) r.HotelId FROM Rooms AS r
	WHERE r.Id = @TargetRoomId)

	IF(@hotelId != @targetRoomHotel)
	BEGIN
		RAISERROR('Target room is in another hotel!',16, 1)
		RETURN
	END

	DECLARE @targetRoomBeds INT = (SELECT TOP(1) r.Beds FROM Rooms AS r WHERE r.Id = @TargetRoomId)

	DECLARE @tripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips AS at WHERE at.TripId = @TripId)

	IF(@targetRoomBeds < @tripAccounts)
	BEGIN
		RAISERROR('Not enough beds in target room!',16,2)
		RETURN
	END

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId

--EXEC usp_SwitchRoom 10, 11
--SELECT RoomId FROM Trips WHERE Id = 10

--EXEC usp_SwitchRoom 10, 7

--EXEC usp_SwitchRoom 10, 8

--20
GO

CREATE OR ALTER TRIGGER tg_DeleteTrip ON Trips
INSTEAD OF DELETE
AS
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE Id IN (SELECT Id FROM deleted WHERE CancelDate IS NULL)


	DELETE FROM Trips
WHERE Id IN (48, 49, 50)
