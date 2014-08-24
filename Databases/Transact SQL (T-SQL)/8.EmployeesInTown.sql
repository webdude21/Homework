/* 8. Using database cursor write a T-SQL script that scans all employees and their addresses 
and prints all pairs of employees that live in the same town. 
*/

CREATE PROCEDURE uspEmployeesInTown @results CURSOR VARYING OUTPUT
AS
BEGIN

	SET @results = CURSOR FOR

	SELECT emp.LastName, towns.Name FROM Employees emp
	JOIN Addresses addr
	ON emp.AddressID = addr.AddressID
	JOIN Towns towns
	ON addr.TownID = towns.TownID
	GROUP BY towns.TownID, towns.Name, emp.LastName

	OPEN @results
END

GO

DECLARE @employeesInTowns CURSOR
DECLARE @LastName varchar(20), @TownName varchar(20)

EXEC uspEmployeesInTown @results = @employeesInTowns OUTPUT


WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @LastName + ' ' + @TownName
	FETCH NEXT FROM @employeesInTowns
	INTO @LastName, @TownName
END

CLOSE @employeesInTowns
DEALLOCATE @employeesInTowns

USE [TelerikAcademy]
GO

/****** Object:  StoredProcedure [dbo].[uspPrintEmployeesAndTowns]    Script Date: 24.8.2014 г. 8:50:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPrintEmployeesAndTowns]
AS
BEGIN
DECLARE @employeesInTowns CURSOR
DECLARE @LastName varchar(20), @TownName varchar(20)

EXEC uspEmployeesInTown @results = @employeesInTowns OUTPUT
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @LastName + ' ' + @TownName
	FETCH NEXT FROM @employeesInTowns
	INTO @LastName, @TownName
END

CLOSE @employeesInTowns
DEALLOCATE @employeesInTowns
END

GO

