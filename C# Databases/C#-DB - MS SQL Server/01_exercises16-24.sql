CREATE DATABASE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY,
AddressText TEXT,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY,
[FirstName] NVARCHAR(20),
[MiddleName] NVARCHAR(20),
[LastName] NVARCHAR(20),
[JobTitle] NVARCHAR(20),
[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id),
[HireDate] DATETIME,
[Salary] MONEY,
[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns(Id, Name)
VALUES (1,'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna'),
(4, 'Burgas')

INSERT INTO Departments(Id, Name)
VALUES (1, 'Engineering'),
(2, 'Sales'),
(3, 'Marketing'),
(4, 'Software Development'),
(5, 'Quality Assurance')

INSERT INTO Employees(Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES (1,'Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00,null),
(2,'Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00,null),
(3,'Ivan','Ivanov','Ivanov','Intern',5,'2016-08-26',525.25,null),
(4,'Ivan','Ivanov','Ivanov','CEO',2,'2007-12-09',3000.00,null),
(5,'Ivan','Ivanov','Ivanov','Intern',3,'2016-08-26',599.88,null)
------

SELECT [Name] FROM Towns ORDER BY Name
SELECT [Name] FROM Departments ORDER BY Name
SELECT [FirstName],[LastName],[JobTitle],Salary FROM Employees ORDER BY Salary DESC
------

UPDATE Employees
SET Salary = Salary * 1.10

SELECT Salary FROM Employees
------

USE Hotel

UPDATE Payments
SET TaxRate = TaxRate * 0.97

SELECT TaxRate FROM Payments
------

TRUNCATE TABLE Occupancies