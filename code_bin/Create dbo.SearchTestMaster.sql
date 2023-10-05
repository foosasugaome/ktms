USE [PracticumV1]
GO

/****** Object: SqlProcedure [dbo].[SearchTestMaster] Script Date: 10/5/2023 11:15:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SearchTestMaster
    @SearchText NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @strPath NVARCHAR(100)
    SET @strPath = '~/Files/Question/'

    SELECT 
        dbo.TestMaster.ID, 
        dbo.TestType.TestType + ' - ' + dbo.TestType.Language AS TMTestType, 
        dbo.TestMaster.Question, 
        @strPath + dbo.TestMaster.QuestionImage AS QuestionImg, 
        dbo.TestMaster.AnswerB, 
        dbo.TestMaster.AnswerA, 
        dbo.TestMaster.AnswerC, 
        dbo.TestMaster.AnswerD, 
        dbo.TestMaster.CorrectAnswer, 
        FORMAT(dbo.TestMaster.CreatedOn, 'MMM dd yyyy') AS CreatedDate, 
        dbo.Users.FirstName + ' ' + dbo.Users.LastName AS CreatedBy, 
        dbo.TestMaster.Status 
    FROM 
        dbo.TestMaster 
    INNER JOIN 
        dbo.TestType ON dbo.TestMaster.TestTypeID = dbo.TestType.ID 
    INNER JOIN 
        dbo.Users ON dbo.TestMaster.CreatedBy = dbo.Users.ID 
    WHERE 
        dbo.TestType.TestType LIKE @SearchText 
        OR dbo.TestType.Language LIKE @SearchText 
        OR dbo.TestMaster.Question LIKE @SearchText 
        OR dbo.TestMaster.AnswerB LIKE @SearchText 
        OR dbo.TestMaster.AnswerA LIKE @SearchText 
        OR dbo.TestMaster.AnswerC LIKE @SearchText 
        OR dbo.TestMaster.AnswerD LIKE @SearchText 
        OR dbo.Users.FirstName + ' ' + dbo.Users.LastName LIKE @SearchText 
    ORDER BY 
        dbo.TestMaster.ID DESC;
END
