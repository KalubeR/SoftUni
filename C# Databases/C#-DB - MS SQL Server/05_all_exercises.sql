CREATE TABLE Passports(
PassportID INT PRIMARY KEY IDENTITY,
PassportNumber NVARCHAR(20) UNIQUE
)


CREATE TABLE Persons(
[PersonId] INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
Salary MONEY NOT NULL,
PassportID INT NOT NULL UNIQUE,
CONSTRAINT FK_Persons_Passports 
FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)
)
-----

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101,1),
Name NVARCHAR(20) NOT NULL,
ManufacturerID INT,
CONSTRAINT FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)
)
-----

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(10) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101,1),
Name NVARCHAR(20) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentsExams
PRIMARY KEY (StudentID,ExamID),
CONSTRAINT FK_StudentsExams_Students
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID)
)
-----

CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101,1),
Name NVARCHAR(20) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)
-----

USE Geography
SELECT MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC