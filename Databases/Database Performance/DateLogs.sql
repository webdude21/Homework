CREATE TABLE [dbo].[DateLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[LogDate] [date] NOT NULL
) ON [PRIMARY]

GO

CREATE PROCEDURE [dbo].[uspAddLogs](@count int = 10000, @text nvarchar(50) = 'SeedText')
AS
DECLARE @index int = 0;
WHILE (@index < @count)
	BEGIN
		INSERT INTO [dbo].[DateLogs] ([LogDate], [Text])
		VALUES (DATEADD(day, @index, getdate()), @text + CAST(@index AS nvarchar))
		SET @index += 1
	END
GO

EXECUTE [dbo].[uspAddLogs] 10000000 , N'Testis'

--This clears the cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
 
-- 1.Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).
SELECT * FROM DateLogs as dt
WHERE YEAR(dt.LogDate) > 2002 AND YEAR(dt.LogDate) < 2015

-- 2.Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
--creates index
CREATE INDEX IDX_Logs_LogDate ON DateLogs(LogDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT * FROM DateLogs as dt
WHERE YEAR(dt.LogDate) > 2002 AND YEAR(dt.LogDate) < 2015

-- 3. Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
CREATE FULLTEXT CATALOG FullTextForLogMessages
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON DateLogs(Text)
KEY INDEX PK_Logs
ON FullTextForLogMessages
WITH CHANGE_TRACKING AUTO

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT * FROM DateLogs
WHERE LogMessage LIKE 'test'

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT * FROM DateLogs
WHERE CONTAINS(LogMessage, 'test')

SELECT dt.[Text]
FROM DateLogs dt
WHERE YEAR(dt.LogDate) > 2002 AND YEAR(dt.LogDate) < 2015