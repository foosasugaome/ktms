USE [PracticumV1]
GO

/****** Object: SqlProcedure [dbo].[GetTestTypes] Script Date: 10/5/2023 11:15:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetTestTypes
    @Status INT = -1,
    @SearchText NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [ID], [TestType], [Language], FORMAT([CreatedOn], 'MM dd yyyy') AS [CreatedOn],
        CASE WHEN [Status] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status]
    FROM [dbo].[TestType]
    WHERE (@Status = -1 OR [Status] = @Status)
        AND ([TestType] LIKE '%' + @SearchText + '%' OR [Language] LIKE '%' + @SearchText + '%');
END
