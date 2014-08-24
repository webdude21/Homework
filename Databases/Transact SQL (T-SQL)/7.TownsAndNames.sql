/* 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) 
and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
you can test with:
SELECT * FROM dbo.NamesAndTowns('oistmiahf')
*/

USE [TelerikAcademy]
GO

/****** Object:  UserDefinedFunction [dbo].[CheckForValidLetters]    Script Date: 23.8.2014 ã. 22:30:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CheckForValidLetters] (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
BEGIN

DECLARE @lettersLen int = LEN(@letters),
@matches int = 0,
@currentChar nvarchar(1)

WHILE(@lettersLen > 0)
BEGIN
	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
	IF(CHARINDEX(@currentChar, @word, 0) > 0)
		BEGIN
			SET @matches += 1
			SET @lettersLen -= 1
		END
	ELSE
		SET @lettersLen -= 1
END

IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
	RETURN 1

RETURN 0
END


GO

USE [TelerikAcademy]
GO

/****** Object:  UserDefinedFunction [dbo].[NamesAndTowns]    Script Date: 23.8.2014 ã. 22:31:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[NamesAndTowns](@letters nvarchar(20))
RETURNS @ResultTable TABLE
(Name varchar(50) NOT NULL)
AS
BEGIN

INSERT INTO @ResultTable
SELECT LastName  FROM Employees

INSERT INTO @ResultTable
SELECT FirstName FROM Employees

INSERT INTO @ResultTable
SELECT towns.Name FROM Towns towns

DELETE FROM @ResultTable
WHERE [dbo].[CheckForValidLetters](Name, @letters) = 0

RETURN
END
GO



