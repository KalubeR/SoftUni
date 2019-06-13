SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID
-----

SELECT TOP(50) FirstName, LastName, t.Name, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName
-----

SELECT EmployeeID, FirstName, LastName, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID
-----

SELECT TOP(5) EmployeeID, FirstName, Salary, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID
-----

SELECT TOP(3) e.EmployeeID, FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID
-----

SELECT FirstName, LastName, HireDate, d.Name
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE HireDate > '1.1.1999' AND d.Name IN ('Sales', 'Finance')
-----

SELECT TOP(5) e.EmployeeID, FirstName, p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > CONVERT(smalldatetime, '13.08.2002', 103) AND EndDate IS NULL
ORDER BY e.EmployeeID
-----

SELECT e.EmployeeID, e.FirstName,
IIF(YEAR(p.StartDate) >= 2005, NULL, p.Name)
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24
-----

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID
-----

SELECT TOP(50) e.EmployeeID,
	CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.Name
FROM Employees AS e 
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID
-----

SELECT MIN(k.AverageSalary) FROM
(SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentID) AS k
-----

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC
-----

SELECT c.CountryCode, COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN ('BG','RU','US')
GROUP BY c.CountryCode
-----

SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName
-----

SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
FROM
(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
, DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) As CurrencyRank
FROM Countries
GROUP BY ContinentCode, CurrencyCode
HAVING COUNT(CurrencyCode) > 1) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode
-----

SELECT COUNT(*)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL
-----

SELECT TOP(5) c.CountryName, MAX(p.Elevation), MAX(r.Length)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName
-----

