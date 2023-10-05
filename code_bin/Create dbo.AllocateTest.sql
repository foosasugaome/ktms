USE [PracticumV1]
GO

/****** Object: Table [dbo].[AllocateTest] Script Date: 10/5/2023 11:14:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AllocateTest] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [UserID]     INT           NOT NULL,
    [TestTypeID] INT           NOT NULL,
    [Status]     BIT           NOT NULL,
    [CreatedOn]  SMALLDATETIME NOT NULL
);


