USE [PracticumV1]
GO

/****** Object: Table [dbo].[Users] Script Date: 10/5/2023 11:13:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (50)  NOT NULL,
    [Password]  VARCHAR (100) NOT NULL,
    [Phone]     VARCHAR (15)  NOT NULL,
    [UserType]  VARCHAR (20)  NOT NULL,
    [UserImage] VARCHAR (50)  NOT NULL,
    [Status]    BIT           NOT NULL,
    [CreatedOn] SMALLDATETIME NOT NULL
);

-- INSERT statement to add a user
INSERT INTO [dbo].[Users] (FirstName, LastName, Email, Password, Phone, UserType, UserImage, Status, CreatedOn)
VALUES ('admin', 'admin', 'admin@admin.com', '$2a$11$YBe2HI56T3w6mDMlXjBv9OgOoEfL.7ENH02DKBzTr5X5H28avKVn2', '123-456-7890', 'Admin', 'default.jpg', 1, GETDATE());
