USE [YOUR_SQL_DATABASE]
GO

/****** Object: Table [dbo].[MOVIES] Script Date: 10/30/2017 8:56:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MOVIES] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [TITLE] NVARCHAR (250) NOT NULL
);


