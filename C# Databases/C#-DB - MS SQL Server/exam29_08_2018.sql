CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL,
Price DECIMAL(15,2) NOT NULL,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL,
Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY,
DateTime DATETIME NOT NULL,
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id)
)

CREATE TABLE OrderItems(
OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id),
ItemId INT NOT NULL FOREIGN KEY REFERENCES Items(Id),
Quantity INT NOT NULL CHECK(Quantity >= 1)

PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts(
Id INT IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CheckIn DATETIME NOT NULL,
CheckOut DATETIME NOT NULL 

PRIMARY KEY(Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CHECK(CheckOut > CheckIn)

--2

--3

--4

--5

SELECT Id, FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id

--6

SELECT FirstName + ' ' + LastName, Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

--7

SELECT FirstName, LastName, COUNT(o.Id)
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName
ORDER BY COUNT(o.Id) DESC, FirstName

--8

SELECT FirstName, LastName, AVG(DATEDIFF(HOUR, CheckIn, CheckOut)) AS WorkHours
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, CheckIn, CheckOut)) > 7
ORDER BY WorkHours DESC, e.Id

--9

SELECT TOP(1) o.Id, SUM(i.Price * ot.Quantity) AS MaxSum
FROM Orders AS o
JOIN OrderItems AS ot ON ot.OrderId = o.Id
JOIN Items AS i ON i.Id = ot.ItemId
GROUP BY o.Id
ORDER BY MaxSum DESC

--10

SELECT TOP(10) o.Id, MAX(i.Price) AS MaxPrice, MIN(i.Price)
FROM Orders AS o
JOIN OrderItems AS ot ON ot.OrderId = o.Id
JOIN Items AS i ON i.Id = ot.ItemId
GROUP BY o.Id
ORDER BY MaxPrice DESC, o.Id

--11

SELECT DISTINCT e.Id, e.FirstName, e.LastName
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS ot ON ot.OrderId = o.Id
ORDER BY e.Id

--12

SELECT DISTINCT e.Id, FirstName + ' ' + LastName
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE DATEDIFF(HOUR, CheckIn, CheckOut) < 4
ORDER BY e.Id

--13

SELECT FirstName + ' ' + LastName AS FullName, SUM(i.Price * oi.Quantity) AS TotalSum, SUM(oi.Quantity) AS ItemCount
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.DateTime < '2018-06-15'
GROUP BY FirstName, LastName
ORDER BY TotalSum DESC, ItemCount DESC

--14

SELECT FirstName + ' ' + LastName
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
LEFT JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE oi.OrderId IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id