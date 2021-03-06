USE [master]
GO
/****** Object:  Database [CropManager]    Script Date: 2/14/2013 10:17:28 AM ******/
CREATE DATABASE [CropManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CropManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLENT\MSSQL\DATA\CropManager.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CropManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLENT\MSSQL\DATA\CropManager_log.ldf' , SIZE = 6912KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CropManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CropManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CropManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CropManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CropManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CropManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CropManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [CropManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CropManager] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CropManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CropManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CropManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CropManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CropManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CropManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CropManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CropManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CropManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CropManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CropManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CropManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CropManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CropManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CropManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CropManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CropManager] SET RECOVERY FULL 
GO
ALTER DATABASE [CropManager] SET  MULTI_USER 
GO
ALTER DATABASE [CropManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CropManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CropManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CropManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CropManager', N'ON'
GO
USE [CropManager]
GO
/****** Object:  User [cropdbuser]    Script Date: 2/14/2013 10:17:28 AM ******/
CREATE USER [cropdbuser] FOR LOGIN [cropdbuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [cropdbuser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [cropdbuser]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCrop]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Deletes specific Crop
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCrop]
	-- Add the parameters for the stored procedure here
	@crop_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--DELETE FROM Fields WHERE FK_crop_id = @crop_id
	UPDATE Fields SET FK_crop_id = 0 WHERE FK_crop_id = @crop_id
	DELETE FROM Illnesses WHERE FK_crop_id = @crop_id
	DELETE FROM Journal WHERE FK_crop_id = @crop_id
	DELETE FROM [dbo].[Crops] WHERE id_crop = @crop_id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic	
-- Create date: 2013-01-08
-- Description:	Remove specific Field
-- =============================================
CREATE PROCEDURE [dbo].[DeleteField]
	-- Add the parameters for the stored procedure here
	@field_id int = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Fields WHERE field_id = @field_id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteIllness]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Remove Illness
-- =============================================
CREATE PROCEDURE [dbo].[DeleteIllness]
	-- Add the parameters for the stored procedure here
	@illness_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Illnesses WHERE illness_id = @illness_id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteJournal]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Deletes Journal record
-- =============================================
Create PROCEDURE [dbo].[DeleteJournal]
	-- Add the parameters for the stored procedure here
	@journal_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Journal WHERE journal_id = @journal_id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteMap]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Delete specific Map record
-- =============================================
Create PROCEDURE [dbo].[DeleteMap]
	-- Add the parameters for the stored procedure here
	@map_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Maps WHERE map_id = @map_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteMapField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Delete specific MapField record
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMapField]
	-- Add the parameters for the stored procedure here
	@field_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM MapField WHERE FK_field_id = @field_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[InsertCrop]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Marinkovic Vladimir>
-- Create date: <2013-01-03>
-- Description:	<Used for inserting Crop records.>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCrop] 
	-- Add the parameters for the stored procedure here
	@name nvarchar(50) = NULL, 
	@crop_type nvarchar(50) = NULL,
	@time_of_planting datetime = NULL,
	@avatar_image varbinary(max) = NULL,
	@watering_frequency int = NULL,
	@watering_period nvarchar(50) = NULL,
	@harvest_time datetime = NULL,
	@hilling_time datetime = NULL,
	@fertillizing_time datetime = NULL,
	@field_coverage real = NULL,
	@field_fk_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Crops (
		name, 
		crop_type, 
		time_of_planting, 
		avatar_image, 
		watering_frequency,
		watering_period,
		harvest_time,
		hilling_time,
		fertillizing_time,
		field_coverage,
		field_fk_id
	) VALUES
	(
		@name,
		@crop_type,
		@time_of_planting,
		@avatar_image,
		@watering_frequency,
		@watering_period,
		@harvest_time,
		@hilling_time,
		@fertillizing_time,
		@field_coverage,
		@field_fk_id
	)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[InsertField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Inserts one Field record
-- =============================================
CREATE PROCEDURE [dbo].[InsertField] 
	-- Add the parameters for the stored procedure here
	@name nvarchar(50) = NULL, 
	@altitude real = NULL,
	@area_size real = NULL,
	@area_size_measure nvarchar(50) = NULL
	--@map_id_fk int = NULL,
	--@crop_id_fk int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT into Fields (name, altitude, area_size, area_size_measure)
	VALUES 
	( 
		@name,
		@altitude,
		@area_size,
		@area_size_measure
	)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[InsertIllness]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Insert Journal Record
-- =============================================
CREATE PROCEDURE [dbo].[InsertIllness]
	-- Add the parameters for the stored procedure here
	@name nvarchar(50) = NULL,
	@type nvarchar(50) = NULL,
	@date_from datetime = NULL,
	@date_to datetime = NULL,
	@percentage_effected real = NULL,
	@image nvarchar(50) = NULL,
	@diagnose nvarchar(255) = NULL,
	@crop_id_fk int = NULL,
	@journal_id_fk int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Illnesses (name, type, date_from, date_to, percentage_effected, image, diagnose, FK_crop_id, FK_journal_id)
	VALUES 
	(
		@name,
		@type,
		@date_from,
		@date_to,
		@percentage_effected,
		@image,
		@diagnose,
		@crop_id_fk,
		@journal_id_fk
	)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[InsertJournal]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Inserts Journal record
-- =============================================
CREATE PROCEDURE [dbo].[InsertJournal]
	-- Add the parameters for the stored procedure here
	@date_entered DATETIME = NULL,
	@description NVARCHAR(255) = NULL,
	@image varbinary(MAX) = NULL,
	@crop_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Journal (date_entered, description, image, FK_crop_id)
	VALUES (
		@date_entered,
		@description,
		@image,
		@crop_id_fk)

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[InsertMap]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Insert specific Map record
-- =============================================
CREATE PROCEDURE [dbo].[InsertMap]
	-- Add the parameters for the stored procedure here
	@longitude REAL = NULL,
	@latitude REAL = NULL,
	@field_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Maps (longitude, latitude, FK_field_id) 
	VALUES (@longitude, @latitude, @field_id_fk)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[InsertMapField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Insert specific MapField record
-- =============================================
CREATE PROCEDURE [dbo].[InsertMapField]
	-- Add the parameters for the stored procedure here
	@field_id_fk INT = NULL,
	@map_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO MapField (FK_field_id, FK_map_id) VALUES (@field_id_fk, @map_id_fk)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[SelectAllMeasures]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marinkovic Vladimir
-- Create date: 2013-01-08
-- Description:	Returns all measures
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllMeasures] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Measures
END

GO
/****** Object:  StoredProcedure [dbo].[SelectAllTimePeriods]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marinkovic Vladimir	
-- Create date: 2013-01-08
-- Description:	Returns all TimePeriods
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllTimePeriods]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TimePeriods
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCropById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-06
-- Description:	Method returns specific Crop 
-- =============================================
CREATE PROCEDURE [dbo].[SelectCropById] 
	-- Add the parameters for the stored procedure here
	@id_crop int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP(1) 
		id_crop,
		name,
		crop_type,
		time_of_planting,
		avatar_image,
		watering_frequency,
			(SELECT type FROM TimePeriods WHERE time_period_id = 
			(SELECT TOP(1) watering_period FROM Crops WHERE id_crop = @id_crop ) ) as watering_period,
		harvest_time,
		hilling_time,
		fertillizing_time,
		field_coverage,
		field_fk_id
	FROM Crops WHERE id_crop = @id_crop
	--SELECT TOP(1) * FROM Crops WHERE id_crop = @id_crop 
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCrops]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-06
-- Description:	Returns the list of all Crops (Ids, Names, Types)
-- =============================================
CREATE PROCEDURE [dbo].[SelectCrops] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT id_crop, name, crop_type FROM Crops 
	SELECT 
	id_crop,
	name,
	crop_type,
	time_of_planting,
	harvest_time,
	hilling_time,
	fertillizing_time

	FROM Crops  
END

GO
/****** Object:  StoredProcedure [dbo].[SelectFieldById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic	
-- Create date: 2013-01-08
-- Description:	Select specific Field by Id
-- =============================================
CREATE PROCEDURE [dbo].[SelectFieldById]
	-- Add the parameters for the stored procedure here
	@field_id int = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Fields WHERE field_id = @field_id
END

GO
/****** Object:  StoredProcedure [dbo].[SelectFields]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic	
-- Create date: 2013-01-08
-- Description:	Select all Fields
-- =============================================
CREATE PROCEDURE [dbo].[SelectFields]
	-- Add the parameters for the stored procedure here
	@field_id int = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT field_id, name FROM Fields
END

GO
/****** Object:  StoredProcedure [dbo].[SelectIllnessByCropId]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Select specific Illness Record
-- =============================================
CREATE PROCEDURE [dbo].[SelectIllnessByCropId]
	-- Add the parameters for the stored procedure here
	@crop_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Illnesses WHERE FK_crop_id = @crop_id
END

GO
/****** Object:  StoredProcedure [dbo].[SelectIllnessById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Select specific Illness Record
-- =============================================
CREATE PROCEDURE [dbo].[SelectIllnessById]
	-- Add the parameters for the stored procedure here
	@illness_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Illnesses WHERE illness_id = @illness_id
END

GO
/****** Object:  StoredProcedure [dbo].[SelectIllnesses]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Select all Illnesses
-- =============================================
CREATE PROCEDURE [dbo].[SelectIllnesses]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT illness_id, name FROM Illnesses 
END

GO
/****** Object:  StoredProcedure [dbo].[SelectJournalByCropId]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select specific Journal record
-- =============================================
CREATE PROCEDURE [dbo].[SelectJournalByCropId]
	-- Add the parameters for the stored procedure here
	@crop_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Journal WHERE FK_crop_id = @crop_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectJournalById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select specific Journal record
-- =============================================
Create PROCEDURE [dbo].[SelectJournalById]
	-- Add the parameters for the stored procedure here
	@journal_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Journal WHERE journal_id = @journal_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectJournals]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select all Journal records
-- =============================================
CREATE PROCEDURE [dbo].[SelectJournals]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT journal_id, date_entered, description FROM Journal
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectMapById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Sslect specific Map record
-- =============================================
Create PROCEDURE [dbo].[SelectMapById]
	-- Add the parameters for the stored procedure here
	@map_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * FROM Maps WHERE map_id = @map_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectMapFieldById]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select specific MapField record
-- =============================================
Create PROCEDURE [dbo].[SelectMapFieldById]
	-- Add the parameters for the stored procedure here
	@fieldmap_id INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM MapField WHERE fieldmap_id = @fieldmap_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectMapFields]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select all MapField records
-- =============================================
Create PROCEDURE [dbo].[SelectMapFields]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM MapField 
	
END

GO
/****** Object:  StoredProcedure [dbo].[SelectMapRecordsByFieldId]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Returns all map records (long, lat) for specific field
-- =============================================
CREATE PROCEDURE [dbo].[SelectMapRecordsByFieldId] 
	-- Add the parameters for the stored procedure here
	@field_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT FK_map_id FROM MapField WHERE FK_field_id = @field_id
END

GO
/****** Object:  StoredProcedure [dbo].[SelectMaps]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Select all Map records
-- =============================================
Create PROCEDURE [dbo].[SelectMaps]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * FROM Maps 
	
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCrop]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-06
-- Description:	Updates specific Crop
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCrop]
	-- Add the parameters for the stored procedure here
	@crop_id int = NULL,
	@name nvarchar(50) = NULL, 
	@crop_type nvarchar(50) = NULL,
	@time_of_planting datetime = NULL,
	@avatar_image varbinary(max) = NULL,
	@watering_frequency int = NULL,
	@watering_period nvarchar(50) = NULL,
	@harvest_time datetime = NULL,
	@hilling_time datetime = NULL,
	@fertillizing_time datetime = NULL,
	@field_coverage real = NULL,
	@field_fk_id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Crops]
	SET [name] = @name
      ,[crop_type] = @crop_type
      ,[time_of_planting] = @time_of_planting
      ,[avatar_image] = @avatar_image
      ,[watering_frequency] = @watering_frequency
      ,[watering_period] = @watering_period
      ,[harvest_time] = @harvest_time
      ,[hilling_time] = @hilling_time
      ,[fertillizing_time] = @fertillizing_time
	  ,[field_coverage] = @field_coverage
	  ,[field_fk_id] = @field_fk_id
	WHERE id_crop = @crop_id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic	
-- Create date: 2013-01-08
-- Description:	Remove specific Field
-- =============================================
CREATE PROCEDURE [dbo].[UpdateField]
	-- Add the parameters for the stored procedure here
	@name nvarchar(50) = NULL, 
	@altitude nvarchar(50) = NULL,
	@area_size real = NULL,
	@area_size_measure real = NULL,
	@map_id_fk int = NULL,
	@crop_id_fk int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Fields]
	SET [name] = @name,
		[altitude] =@altitude,
		[area_size] = @area_size,
		[area_size_measure] = @area_size_measure,
		[FK_map_id] = @map_id_fk,
		[FK_crop_id] = @crop_id_fk

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateIllness]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2013-01-08
-- Description:	Update Illness Record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateIllness]
	-- Add the parameters for the stored procedure here
	@name nvarchar(50) = NULL,
	@type nvarchar(50) = NULL,
	@date_from datetime = NULL,
	@date_to datetime = NULL,
	@percentage_effected real = NULL,
	@image nvarchar(50) = NULL,
	@diagnose nvarchar(255) = NULL,
	@crop_id_fk int = NULL,
	@journal_id_fk int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Illnesses 
	SET 
		name = @name,
		type = @type,
		date_from = @date_from,
		date_to = @date_to,
		percentage_effected = @percentage_effected,
		image = @image,
		diagnose = @diagnose,
		FK_crop_id = @crop_id_fk,
		FK_journal_id = @journal_id_fk
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateJournal]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Updates Journal record
-- =============================================
CREATE PROCEDURE [dbo].[UpdateJournal]
	-- Add the parameters for the stored procedure here
	@journal_id INT = NULL,
	@date_entered DATETIME = NULL,
	@description NVARCHAR(255) = NULL,
	@image VARBINARY(MAX) = NULL,
	@crop_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Journal
	SET
	date_entered = @date_entered,
	description = @description,
	image = @image,
	FK_crop_id = @crop_id_fk
	WHERE journal_id = @journal_id
	
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateMap]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Update specific Map record
-- =============================================
Create PROCEDURE [dbo].[UpdateMap]
	-- Add the parameters for the stored procedure here
	@longitude REAL = NULL,
	@latitude REAL = NULL,
	@field_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Maps SET 
		longitude=@longitude, 
		latitude=@latitude, 
		FK_field_id=@field_id_fk
	
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateMapField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vladimir Marinkovic
-- Create date: 2012-01-08
-- Description:	Update specific MapField record
-- =============================================
Create PROCEDURE [dbo].[UpdateMapField]
	-- Add the parameters for the stored procedure here
	@field_id_fk INT = NULL,
	@map_id_fk INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MapField 
	SET 
	FK_field_id = @field_id_fk,
	FK_map_id = @map_id_fk
	
END

GO
/****** Object:  Table [dbo].[Crops]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Crops](
	[id_crop] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[crop_type] [nvarchar](50) NULL,
	[time_of_planting] [datetime] NULL,
	[avatar_image] [varbinary](max) NULL,
	[watering_frequency] [int] NULL,
	[watering_period] [nvarchar](50) NULL,
	[harvest_time] [datetime] NULL,
	[hilling_time] [datetime] NULL,
	[fertillizing_time] [datetime] NULL,
	[field_coverage] [real] NULL,
	[field_fk_id] [int] NULL,
 CONSTRAINT [PK_Crops] PRIMARY KEY CLUSTERED 
(
	[id_crop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[field_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[altitude] [real] NULL,
	[area_size] [real] NULL,
	[area_size_measure] [nvarchar](50) NULL,
	[FK_map_id] [int] NULL,
	[FK_crop_id] [int] NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[field_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Illnesses]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Illnesses](
	[illness_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[date_from] [datetime] NULL,
	[date_to] [datetime] NULL,
	[percentage_effected] [real] NULL,
	[image] [nvarchar](50) NULL,
	[diagnose] [nvarchar](255) NULL,
	[FK_crop_id] [int] NULL,
	[FK_journal_id] [int] NULL,
 CONSTRAINT [PK_Illnesses] PRIMARY KEY CLUSTERED 
(
	[illness_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journal]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Journal](
	[journal_id] [int] IDENTITY(1,1) NOT NULL,
	[date_entered] [datetime] NULL,
	[description] [nvarchar](255) NULL,
	[image] [varbinary](max) NULL,
	[FK_crop_id] [int] NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[journal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MapField]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MapField](
	[fieldmap_id] [int] IDENTITY(1,1) NOT NULL,
	[FK_field_id] [int] NOT NULL,
	[FK_map_id] [int] NOT NULL,
 CONSTRAINT [PK_MapField] PRIMARY KEY CLUSTERED 
(
	[fieldmap_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Maps]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maps](
	[map_id] [int] IDENTITY(1,1) NOT NULL,
	[longitude] [real] NULL,
	[latitude] [real] NULL,
	[FK_field_id] [int] NULL,
 CONSTRAINT [PK_Maps] PRIMARY KEY CLUSTERED 
(
	[map_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Measures]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[measure_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[measure_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimePeriods]    Script Date: 2/14/2013 10:17:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimePeriods](
	[time_period_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](255) NULL,
 CONSTRAINT [PK_TimePeriods] PRIMARY KEY CLUSTERED 
(
	[time_period_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Fields]  WITH CHECK ADD  CONSTRAINT [FK_Fields_Crops] FOREIGN KEY([FK_crop_id])
REFERENCES [dbo].[Crops] ([id_crop])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Fields] CHECK CONSTRAINT [FK_Fields_Crops]
GO
ALTER TABLE [dbo].[Illnesses]  WITH CHECK ADD  CONSTRAINT [FK_Illnesses_Crops] FOREIGN KEY([FK_crop_id])
REFERENCES [dbo].[Crops] ([id_crop])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Illnesses] CHECK CONSTRAINT [FK_Illnesses_Crops]
GO
ALTER TABLE [dbo].[Illnesses]  WITH CHECK ADD  CONSTRAINT [FK_Illnesses_Journal] FOREIGN KEY([FK_journal_id])
REFERENCES [dbo].[Journal] ([journal_id])
GO
ALTER TABLE [dbo].[Illnesses] CHECK CONSTRAINT [FK_Illnesses_Journal]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Crops] FOREIGN KEY([FK_crop_id])
REFERENCES [dbo].[Crops] ([id_crop])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Crops]
GO
ALTER TABLE [dbo].[MapField]  WITH CHECK ADD  CONSTRAINT [FK_MapField_Fields] FOREIGN KEY([FK_field_id])
REFERENCES [dbo].[Fields] ([field_id])
GO
ALTER TABLE [dbo].[MapField] CHECK CONSTRAINT [FK_MapField_Fields]
GO
ALTER TABLE [dbo].[MapField]  WITH CHECK ADD  CONSTRAINT [FK_MapField_Maps] FOREIGN KEY([FK_map_id])
REFERENCES [dbo].[Maps] ([map_id])
GO
ALTER TABLE [dbo].[MapField] CHECK CONSTRAINT [FK_MapField_Maps]
GO
USE [master]
GO
ALTER DATABASE [CropManager] SET  READ_WRITE 
GO
