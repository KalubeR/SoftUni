SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits
------

SELECT TOP(1) MagicWandSize AS [LongestMagicWand]
FROM WizzardDeposits
ORDER BY MagicWandSize DESC
-----

SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup
-----

SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
-----

SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
GROUP BY DepositGroup
----

SELECT DepositGroup, SUM(DepositAmount)
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
------

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC
-----

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup
-----

SELECT 
CASE
WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
ELSE '[61+]'
END AS [AgeGroup],
COUNT(*)
FROM WizzardDeposits
GROUP BY 
CASE
WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
ELSE '[61+]'
END
-----

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
-----

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired
-----

SELECT SUM(k.Diff) * -1
FROM(
SELECT wd.DepositAmount - (SELECT w.DepositAmount FROM WizzardDeposits AS w WHERE wd.Id = w.Id + 1) AS Diff
FROM WizzardDeposits AS wd) AS k
-----

SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
-----

SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID
-----

SELECT * INTO AnotherTable
FROM Employees
WHERE Salary > 30000

DELETE FROM AnotherTable
WHERE ManagerID = 42

UPDATE AnotherTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentId, AVG(Salary)
FROM AnotherTable
GROUP BY DepartmentID
-----

SELECT DepartmentID, MAX(Salary)
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
-----

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL
GROUP BY ManagerID
-----

SELECT DISTINCT k.DepartmentID, k.Salary
FROM
(SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RankSalary
FROM Employees) AS k
WHERE RankSalary = 3
-----

SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) FROM Employees AS em WHERE em.DepartmentID = e.DepartmentID)
ORDER BY DepartmentID
