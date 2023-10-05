USE [PracticumV1]
GO

/****** Object: Table [dbo].[TestType] Script Date: 10/5/2023 11:14:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestType] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [TestType]  VARCHAR (50)  NOT NULL,
    [Language]  VARCHAR (50)  NOT NULL,
    [Status]    BIT           NOT NULL,
    [CreatedOn] SMALLDATETIME NOT NULL
);


