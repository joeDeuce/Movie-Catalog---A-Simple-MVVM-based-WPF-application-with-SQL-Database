USE [master]
GO

/****** Object: SqlProcedure [dbo].[addRecord] Script Date: 5/15/2024 9:24:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[addRecord]
	@pGDCNum int,
	@pFirstName varchar(40),
	@pLastName varchar(100),
	@pDorm int
AS
	INSERT INTO tBaseline(GDCNum, FirstName, LastName, Dorm) VALUES (@pGDCNum,@pFirstName,@pLastName,@pDorm);
