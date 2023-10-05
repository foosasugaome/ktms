USE [PracticumV1]
GO

/****** Object: SqlProcedure [dbo].[ChangeTestTypeStatus] Script Date: 10/5/2023 11:15:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE ChangeTestTypeStatus
    @TestTypeID INT
AS
BEGIN
    UPDATE [dbo].[TestType]
    SET [Status] = CASE WHEN [Status] = 0 THEN 1 ELSE 0 END
    WHERE [ID] = @TestTypeID;
END
