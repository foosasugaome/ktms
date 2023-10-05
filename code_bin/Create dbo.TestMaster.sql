USE [PracticumV1]
GO

/****** Object: Table [dbo].[TestMaster] Script Date: 10/5/2023 11:14:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestMaster] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [TestTypeID]    INT           NOT NULL,
    [Question]      VARCHAR (500) NOT NULL,
    [QuestionImage] VARCHAR (50)  NOT NULL,
    [AnswerA]       VARCHAR (500) NOT NULL,
    [AnswerB]       VARCHAR (500) NOT NULL,
    [AnswerC]       VARCHAR (500) NOT NULL,
    [AnswerD]       VARCHAR (500) NOT NULL,
    [CorrectAnswer] VARCHAR (1)   NOT NULL,
    [CreatedBy]     INT           NOT NULL,
    [Status]        BIT           NOT NULL,
    [CreatedOn]     SMALLDATETIME NOT NULL
);


