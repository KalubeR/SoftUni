CREATE DATABASE Minions
------

CREATE TABLE Minions(
Id int NOT NULL PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Age int
)

CREATE TABLE Towns(
Id int NOT NULL PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)
-------

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)
------

INSERT INTO Towns(Id, [Name])
VALUES (1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId)
VALUES (1, 'Kevin', 22 , 1),
	(2, 'Bob', 15 , 3),
	(3, 'Steward', NULL, 2)
-------

TRUNCATE TABLE Minions
-------

DROP TABLE Minions
DROP TABLE Towns
-------

CREATE TABLE People(
Id INT PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX), 
[Height] DECIMAL(5,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
[Birthdate] DATE NOT NULL,
[Biography] NTEXT
)

INSERT INTO People(Id,[Name],[Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES (1, 'Gosho', NULL, 2.2, 2.3, 'm', '2019-01-20', 'asdasdasd'),
(2, 'Gosho', NULL, 2.2, 2.3, 'm', '2019-01-20', 'asdasdasd'),
(3, 'Gosho', NULL, 2.2, 2.3, 'f', '2019-01-20', 'asdasdasd'),
(4, 'Gosho', NULL, 2.2, 2.3, 'm', '2019-01-20', 'asdasdasd'),
(5, 'Gosho', NULL, 2.2, 2.3, 'f', '2019-01-20', 'asdasdasd')
---------

CREATE TABLE Users(
Id INT PRIMARY KEY,
[Username] NVARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
[LastLoginTime] DATE,
[IsDeleted] BIT
)

INSERT INTO Users(Id,[Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted])
VALUES (1,'Gosho','asd', NULL, NULL, 1),
(2,'Pesho','asd', NULL, NULL, 0),
(3,'Tosho','asd', NULL, NULL, 1),
(4,'Rosho','asd', NULL, NULL, 0),
(5,'Kosho','asd', NULL, NULL, 1)
-------

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07FF1BDB94]

ALTER TABLE Users
ADD CONSTRAINT PK_IdAndName
PRIMARY KEY(Id,Username)
--------

------Not working
ALTER TABLE Users
ADD CONSTRAINT Atleast5SymbolsLong
CHECK (Len([Password]) > 5)
--------

ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime
-------

ALTER TABLE Users
DROP CONSTRAINT [PK_IdAndName]

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT AtLeast3SymbolsLong
CHECK (Len([Username]) > 3)
-------



