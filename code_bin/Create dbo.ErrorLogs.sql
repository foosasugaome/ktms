USE [PracticumV1]
GO

/****** Object: Table [dbo].[ErrorLogs] Script Date: 10/5/2023 11:14:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ErrorLogs] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedOn]    SMALLDATETIME  NOT NULL,
    [ErrorMessage] VARCHAR (1000) NULL,
    [Custom1]      VARBINARY (50) NULL
);


