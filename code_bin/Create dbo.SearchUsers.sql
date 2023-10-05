USE [PracticumV1]
GO

/****** Object: SqlProcedure [dbo].[SearchUsers] Script Date: 10/5/2023 11:15:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SearchUsers
    @SearchText NVARCHAR(100),
    @Status INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @strPath NVARCHAR(100)
    SET @strPath = '~/Files/UserPicture/'

    SELECT
        [ID],
        [FirstName],
        [LastName],
        [Email],
        [Password],
        [Phone],
        [UserType],
        @strPath + [UserImage] AS UserImage,
        CASE WHEN [Status] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status],
        FORMAT([CreatedOn], 'MMM dd yyyy') AS [CreatedOn]
    FROM
        [Users]
    WHERE
        (@SearchText = '' OR [FirstName] LIKE @SearchText OR [LastName] LIKE @SearchText OR [Email] LIKE @SearchText OR [Phone] LIKE @SearchText)
        AND (@Status = -1 OR [Status] = @Status)
END
