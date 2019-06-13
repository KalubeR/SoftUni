SELECT CardNumber, JobDuringJourney
FROM TravelCards
ORDER BY CardNumber
-----

SELECT Id, FirstName + ' ' + LastName, Ucn
FROM Colonists
ORDER BY FirstName, LastName, Id
-----

SELECT Id, FORMAT ( JourneyStart, 'd', 'en-gb' ), FORMAT ( JourneyEnd, 'd', 'en-gb' )
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart
-----

SELECT c.Id, c.FirstName + ' ' + c.LastName
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY Id
-----

SELECT COUNT(*)
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON j.Id = tc.JourneyId
WHERE j.Purpose = 'Technical'
-----

SELECT TOP(1) s.[Name], sp.Name
FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId = s.Id
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
ORDER BY LightSpeedRate DESC
-----

SELECT sh.Name, sh.Manufacturer
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
JOIN Journeys AS j ON j.Id = tc.JourneyId
JOIN Spaceships AS sh ON sh.Id = j.SpaceshipId
WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
GROUP BY sh.Name, sh.Manufacturer
ORDER BY sh.[Name]


SELECT * --ss.Name, ss.Manufacturer
FROM Spaceships AS ss
JOIN Journeys AS j ON j.SpaceshipId = ss.Id
JOIN TravelCards AS tc ON tc.JourneyId = j.Id
JOIN Colonists As c ON c.Id = tc.ColonistId
WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
GROUP BY ss.Name, ss.Manufacturer
ORDER BY ss.Name
-----

SELECT p.Name, sp.Name
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
WHERE j.Purpose = 'Educational'
ORDER BY sp.Name DESC
----

SELECT p.Name,COUNT(j.Id)
FROM Planets AS p
JOIN Spaceports AS sp ON sp.PlanetId = p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.Name
ORDER BY COUNT(j.Id) DESC, p.Name
-----

SELECT TOP(1) j.Id, p.Name, sp.Name, j.Purpose
FROM Journeys AS j
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
JOIN Planets AS p ON p.Id = sp.PlanetId
ORDER BY DATEDIFF(MONTH, JourneyStart, JourneyEnd)
-----

SELECT TOP(1) k.Id, k.JobDuringJourney FROM

(SELECT j.Id, tc.JobDuringJourney, COUNT(tc.ColonistId) AS CountOfColonists, j.JourneyStart, j.JourneyEnd
FROM TravelCards AS tc
JOIN Journeys AS j ON j.Id = tc.JourneyId
GROUP BY j.Id, tc.JobDuringJourney, j.JourneyStart, j.JourneyEnd
) AS k
ORDER BY DATEDIFF(MONTH, k.JourneyStart, k.JourneyEnd) DESC, k.CountOfColonists
-----

SELECT k.JobDuringJourney, k.FirstName + ' ' + k.LastName, k.JobRank
FROM 
(SELECT c.Id, c.FirstName, c.LastName, tc.JobDuringJourney, ROW_NUMBER() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate) AS JobRank
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
GROUP BY JobDuringJourney, c.Id,c.FirstName, c.LastName, c.BirthDate) As k
WHERE JobRank = 2
------

SELECT p.Name, COUNT(sp.Name)
FROM Planets AS p
LEFT JOIN Spaceports AS sp ON sp.PlanetId = p.Id
GROUP BY p.Name
ORDER BY COUNT(sp.Name) DESC, p.Name
-----
GO

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @count INT
	SELECT @count = COUNT(c.Id)
	FROM Planets AS p
	JOIN Spaceports As sp ON sp.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
	JOIN TravelCards As tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
	WHERE p.[Name] = @PlanetName
	RETURN @count
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')
-----
GO

CREATE OR ALTER PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
	DECLARE @journey INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

	IF(@journey IS NULL)
	BEGIN
	RAISERROR('The journey does not exist!', 16, 1)
	RETURN
	END

	DECLARE @name VARCHAR(MAX) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

	IF(@NewPurpose = @name)
	BEGIN
	RAISERROR('You cannot change the purpose!', 16, 2)
	RETURN
	END

	SET @name = @NewPurpose


	EXEC usp_ChangeJourneyPurpose 2, 'Educational'
	EXEC usp_ChangeJourneyPurpose 1, 'Technical'
	SELECT * FROM Journeys
	EXEC usp_ChangeJourneyPurpose 196, 'Technical'
-----
GO

CREATE TABLE DeletedJourneys(
Id INT PRIMARY KEY,
JourneyStart DATETIME,
JourneyEnd DATETIME,
Purpose VARCHAR(20),
DestinationSpaceportId INT,
SpaceshipId INT
)
GO

CREATE TRIGGER tr_DeletedJourneys ON Journeys FOR DELETE
AS
	INSERT INTO DeletedJourneys(Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
	SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted


	DELETE FROM TravelCards
WHERE JourneyId =  1

DELETE FROM Journeys
WHERE Id =  1
