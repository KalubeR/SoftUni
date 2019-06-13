SELECT FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
-----

SELECT Firstname, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'
------

SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]
-------

SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]
-------

SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]
-------

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE YEAR(HireDate) > 2000

SELECT *
FROM V_EmployeesHiredAfter2000
-------

SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5
-------

SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId)
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC
-------

SELECT *
FROM
(SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
) AS E
WHERE E.Rank = 2
ORDER BY E.Salary DESC
--------

SELECT CountryName AS 'Country Name', IsoCode AS 'ISO Code'
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode
-------

SELECT PeakName, RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

------

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS Start
FROM Games
WHERE YEAR(Start) IN (2011,2012)
ORDER BY [Start], [Name]
------

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username
------

SELECT Username, [IpAddress]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username
------

SELECT [Name] AS Game, 
 CASE
WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
WHEN DATEPART(HOUR, Start) >= 18 AND DATEPART(HOUR, Start) < 24 THEN 'Evening'
 END,
 CASE
WHEN Duration <= 3 THEN 'Extra Short'
WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
WHEN Duration > 6 THEN 'Long'
WHEN Duration IS NULL THEN 'Extra Long'
 END AS [Duration1]
FROM Games
ORDER BY [Name], Duration1
------


SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders
------

