USE [PracticumV1]
GO

/****** Object: Table [dbo].[UserTest] Script Date: 10/5/2023 11:14:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserTest] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [UserID]       INT           NOT NULL,
    [TestTypeID]   INT           NOT NULL,
    [TestMasterID] INT           NOT NULL,
    [IsCorrect]    BIT           NOT NULL,
    [CreatedOn]    SMALLDATETIME NOT NULL,
    [TestStartID]  VARCHAR (50)  NOT NULL
);


