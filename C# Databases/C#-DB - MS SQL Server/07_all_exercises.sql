CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000

	EXEC usp_GetEmployeesSalaryAbove35000 

-----
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number decimal(18,4)	
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @number

	EXEC usp_GetEmployeesSalaryAboveNumber 48100
-----
GO

CREATE PROCEDURE usp_GetTownsStartingWith (@input VARCHAR(10))
AS
	SELECT [Name] AS [Town]
	FROM Towns
	WHERE [Name] LIKE @input + '%'

	EXEC usp_GetTownsStartingWith 'k'
-----
GO

CREATE PROCEDURE usp_GetEmployeesFromTown @town NVARCHAR(10)
AS
	SELECT FirstName,LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @town
	
EXEC usp_GetEmployeesFromTown 'Sofia'
-----
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	IF(@salary < 30000)
	RETURN 'Low'

	ELSE IF(@salary BETWEEN 30000 and 50000)
	RETURN 'Average'

	RETURN 'High'
END

-----
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel CHAR(10)
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

	EXEC usp_EmployeesBySalaryLevel 'High'
-----
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters CHAR(15), @word CHAR(15))
RETURNS BIT
BEGIN

	DECLARE @index INT = 1
	WHILE(@index <= LEN(@word))
	BEGIN
	DECLARE @currChar CHAR(1) = SUBSTRING(@word, @index, 1)
	
	DECLARE @isContained INT = CHARINDEX(@currChar, @setOfLetters)
	IF(@isContained = 0)
	BEGIN 
	RETURN 0
	END

	SET @index +=1
	END

	RETURN 1
END
-----
GO

--8ма
-----
GO

CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName
	FROM AccountHolders

	EXEC usp_GetHoldersFullName 
-----
GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,2))
AS
	SELECT k.FirstName, k.LastName FROM
	(SELECT ah.Id,ah.FirstName, ah.LastName, SUM(a.Balance) AS TotalSum
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY ah.Id,ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @number) AS k
	ORDER BY k.FirstName, k.LastName

	EXEC usp_GetHoldersWithBalanceHigherThan 20000
-----
GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyRate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
BEGIN
	
	RETURN @sum * POWER((1 + @yearlyRate), @years)

END
-----

