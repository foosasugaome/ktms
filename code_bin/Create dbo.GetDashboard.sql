USE [PracticumV1]
GO

/****** Object: SqlProcedure [dbo].[GetDashboard] Script Date: 10/5/2023 11:15:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE         PROCEDURE [dbo].[GetDashboard]    
AS
BEGIN

--Total number of users
SELECT COUNT(ID) TotalUsers FROM [dbo].[Users] WHERE STATUS = 1;

--Total number of new students. Counts from the start of the current month.
SELECT COUNT(ID) NewStudents FROM [dbo].[Users] WHERE CAST(CreatedOn AS date) >= CAST(DATEADD(month, DATEDIFF(month, 0, GETDATE()),0) AS DATE);

--Total number of test types
SELECT COUNT(ID) TotalTestType FROM [dbo].[TestType] WHERE STATUS = 1;

--Total number of attempts
SELECT COUNT(DISTINCT(TestStartID))TotalAttempts FROM [dbo].[UserTest];

--Total number of passed attempts
SELECT COUNT(Result) PassedAttempts
FROM (
    SELECT CASE WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) >= 0.75 THEN 1 ELSE 0 END Result
    FROM [UserTest]
    GROUP BY TestStartID
) Temp
WHERE Result = 1;

--Total number of failed attempts
SELECT COUNT(Result) FailedAttempts
FROM (
    SELECT CASE WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) > 0.75 THEN 1 ELSE 0 END Result
    FROM [UserTest]
    GROUP BY TestStartID
) Temp
WHERE Result = 0;

--Fill Chart
SELECT TOP 7 COUNT(CreatedOn) TotalAttempts FROM [UserTest] WHERE CreatedOn > DATEADD(MM,-6, GETDATE()) GROUP BY CreatedOn;

--Fill Pie
SELECT [ID],[TestType] + ' - ' + [Language] [TestType] FROM [dbo].[TestType];

--Fill Bar Chart
WITH AllMonths AS (
    SELECT 1 AS MonthValue, 'Jan' AS MonthName
    UNION ALL SELECT 2, 'Feb'
    UNION ALL SELECT 3, 'Mar'
    UNION ALL SELECT 4, 'Apr'
    UNION ALL SELECT 5, 'May'
    UNION ALL SELECT 6, 'Jun'
    UNION ALL SELECT 7, 'Jul'
    UNION ALL SELECT 8, 'Aug'
    UNION ALL SELECT 9, 'Sep'
    UNION ALL SELECT 10, 'Oct'
    UNION ALL SELECT 11, 'Nov'
    UNION ALL SELECT 12, 'Dec'
)
SELECT COALESCE(SUM(Result), 0) AS TotalPassed, -- Use COALESCE here
    COALESCE(AllMonths.MonthName, 'Unknown') AS CreatedOnMo,
    AllMonths.MonthValue AS CreatedOn
FROM AllMonths
LEFT JOIN (
    SELECT CASE
            WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) >= 0.5 THEN 1
            ELSE 0
        END AS Result,
        MONTH(CreatedOn) AS CreatedOn
    FROM [UserTest]
    GROUP BY TestStartID, MONTH(CreatedOn)
) Temp ON AllMonths.MonthValue = Temp.CreatedOn
GROUP BY AllMonths.MonthName, AllMonths.MonthValue
ORDER BY AllMonths.MonthValue;

WITH AllMonths AS (
    SELECT 1 AS MonthValue, 'Jan' AS MonthName
    UNION ALL SELECT 2, 'Feb'
    UNION ALL SELECT 3, 'Mar'
    UNION ALL SELECT 4, 'Apr'
    UNION ALL SELECT 5, 'May'
    UNION ALL SELECT 6, 'Jun'
    UNION ALL SELECT 7, 'Jul'
    UNION ALL SELECT 8, 'Aug'
    UNION ALL SELECT 9, 'Sep'
    UNION ALL SELECT 10, 'Oct'
    UNION ALL SELECT 11, 'Nov'
    UNION ALL SELECT 12, 'Dec'
)
SELECT COALESCE(SUM(Result), 0) AS TotalFailed, -- Use COALESCE here
    COALESCE(AllMonths.MonthName, 'Unknown') AS CreatedOnMo,
    AllMonths.MonthValue AS CreatedOn
FROM AllMonths
LEFT JOIN (
    SELECT CASE
            WHEN CAST(SUM(CAST(IsCorrect AS INT)) AS FLOAT) / CAST(COUNT(*) AS FLOAT) < 0.5 THEN 1
            ELSE 0
        END AS Result,
        MONTH(CreatedOn) AS CreatedOn
    FROM [UserTest]
    GROUP BY TestStartID, MONTH(CreatedOn)
) Temp ON AllMonths.MonthValue = Temp.CreatedOn
GROUP BY AllMonths.MonthName, AllMonths.MonthValue
ORDER BY AllMonths.MonthValue;
END;
