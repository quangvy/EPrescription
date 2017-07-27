
USE [EPrescription]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the UserRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_Get_List

AS


				
				SELECT
					[RoleID],
					[RoleName],
					[Remark]
				FROM
					[dbo].[UserRoles]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the UserRoles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [RoleID] nvarchar(50)  
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([RoleID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [RoleID]'
				SET @SQL = @SQL + ' FROM [dbo].[UserRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[RoleID], O.[RoleName], O.[Remark]
				FROM
				    [dbo].[UserRoles] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[RoleID] = PageIndex.[RoleID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[UserRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the UserRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_Insert
(

	@RoleId nvarchar (50)  ,

	@RoleName nvarchar (100)  ,

	@Remark nvarchar (250)  
)
AS


				
				INSERT INTO [dbo].[UserRoles]
					(
					[RoleID]
					,[RoleName]
					,[Remark]
					)
				VALUES
					(
					@RoleId
					,@RoleName
					,@Remark
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the UserRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_Update
(

	@RoleId nvarchar (50)  ,

	@OriginalRoleId nvarchar (50)  ,

	@RoleName nvarchar (100)  ,

	@Remark nvarchar (250)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[UserRoles]
				SET
					[RoleID] = @RoleId
					,[RoleName] = @RoleName
					,[Remark] = @Remark
				WHERE
[RoleID] = @OriginalRoleId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the UserRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_Delete
(

	@RoleId nvarchar (50)  
)
AS


				DELETE FROM [dbo].[UserRoles] WITH (ROWLOCK) 
				WHERE
					[RoleID] = @RoleId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_GetByRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_GetByRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_GetByRoleId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the UserRoles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_GetByRoleId
(

	@RoleId nvarchar (50)  
)
AS


				SELECT
					[RoleID],
					[RoleName],
					[Remark]
				FROM
					[dbo].[UserRoles]
				WHERE
                        
                            ISNULL([RoleID],0) = ISNULL(@RoleId,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserRoles_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserRoles_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserRoles_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the UserRoles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserRoles_Find
(

	@SearchUsingOR bit   = null ,

	@RoleId nvarchar (50)  = null ,

	@RoleName nvarchar (100)  = null ,

	@Remark nvarchar (250)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RoleID]
	, [RoleName]
	, [Remark]
    FROM
	[dbo].[UserRoles]
    WHERE 
	 ([RoleID] = @RoleId OR @RoleId IS NULL)
	AND ([RoleName] = @RoleName OR @RoleName IS NULL)
	AND ([Remark] = @Remark OR @Remark IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RoleID]
	, [RoleName]
	, [Remark]
    FROM
	[dbo].[UserRoles]
    WHERE 
	 ([RoleID] = @RoleId AND @RoleId is not null)
	OR ([RoleName] = @RoleName AND @RoleName is not null)
	OR ([Remark] = @Remark AND @Remark is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the ePrescription table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_Get_List

AS


				
				SELECT
					[PrescriptionID],
					[TransactionID],
					[PatientCode],
					[FirstName],
					[LastName],
					[DeliveryDate],
					[CreateDate],
					[Address],
					[DateOfBirth],
					[Age],
					[Weight],
					[Diagnosis],
					[DiagnosisVN],
					[PrescribingDoctor],
					[Sex],
					[Remark],
					[IsComplete]
				FROM
					[dbo].[ePrescription]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the ePrescription table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [PrescriptionID] nvarchar(20)  
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([PrescriptionID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [PrescriptionID]'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescription]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[PrescriptionID], O.[TransactionID], O.[PatientCode], O.[FirstName], O.[LastName], O.[DeliveryDate], O.[CreateDate], O.[Address], O.[DateOfBirth], O.[Age], O.[Weight], O.[Diagnosis], O.[DiagnosisVN], O.[PrescribingDoctor], O.[Sex], O.[Remark], O.[IsComplete]
				FROM
				    [dbo].[ePrescription] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[PrescriptionID] = PageIndex.[PrescriptionID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescription]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the ePrescription table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_Insert
(

	@PrescriptionId nvarchar (20)  ,

	@TransactionId nvarchar (15)  ,

	@PatientCode nvarchar (50)  ,

	@FirstName nvarchar (30)  ,

	@LastName nvarchar (30)  ,

	@DeliveryDate datetime   ,

	@CreateDate datetime   ,

	@Address nvarchar (150)  ,

	@DateOfBirth datetime   ,

	@Age nvarchar (20)  ,

	@Weight nvarchar (20)  ,

	@Diagnosis nvarchar (500)  ,

	@DiagnosisVn nvarchar (500)  ,

	@PrescribingDoctor nvarchar (100)  ,

	@Sex nvarchar (10)  ,

	@Remark nvarchar (250)  ,

	@IsComplete bit   
)
AS


				
				INSERT INTO [dbo].[ePrescription]
					(
					[PrescriptionID]
					,[TransactionID]
					,[PatientCode]
					,[FirstName]
					,[LastName]
					,[DeliveryDate]
					,[CreateDate]
					,[Address]
					,[DateOfBirth]
					,[Age]
					,[Weight]
					,[Diagnosis]
					,[DiagnosisVN]
					,[PrescribingDoctor]
					,[Sex]
					,[Remark]
					,[IsComplete]
					)
				VALUES
					(
					@PrescriptionId
					,@TransactionId
					,@PatientCode
					,@FirstName
					,@LastName
					,@DeliveryDate
					,@CreateDate
					,@Address
					,@DateOfBirth
					,@Age
					,@Weight
					,@Diagnosis
					,@DiagnosisVn
					,@PrescribingDoctor
					,@Sex
					,@Remark
					,@IsComplete
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the ePrescription table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_Update
(

	@PrescriptionId nvarchar (20)  ,

	@OriginalPrescriptionId nvarchar (20)  ,

	@TransactionId nvarchar (15)  ,

	@PatientCode nvarchar (50)  ,

	@FirstName nvarchar (30)  ,

	@LastName nvarchar (30)  ,

	@DeliveryDate datetime   ,

	@CreateDate datetime   ,

	@Address nvarchar (150)  ,

	@DateOfBirth datetime   ,

	@Age nvarchar (20)  ,

	@Weight nvarchar (20)  ,

	@Diagnosis nvarchar (500)  ,

	@DiagnosisVn nvarchar (500)  ,

	@PrescribingDoctor nvarchar (100)  ,

	@Sex nvarchar (10)  ,

	@Remark nvarchar (250)  ,

	@IsComplete bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ePrescription]
				SET
					[PrescriptionID] = @PrescriptionId
					,[TransactionID] = @TransactionId
					,[PatientCode] = @PatientCode
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[DeliveryDate] = @DeliveryDate
					,[CreateDate] = @CreateDate
					,[Address] = @Address
					,[DateOfBirth] = @DateOfBirth
					,[Age] = @Age
					,[Weight] = @Weight
					,[Diagnosis] = @Diagnosis
					,[DiagnosisVN] = @DiagnosisVn
					,[PrescribingDoctor] = @PrescribingDoctor
					,[Sex] = @Sex
					,[Remark] = @Remark
					,[IsComplete] = @IsComplete
				WHERE
[PrescriptionID] = @OriginalPrescriptionId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the ePrescription table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_Delete
(

	@PrescriptionId nvarchar (20)  
)
AS


				DELETE FROM [dbo].[ePrescription] WITH (ROWLOCK) 
				WHERE
					[PrescriptionID] = @PrescriptionId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_GetByPrescriptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_GetByPrescriptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_GetByPrescriptionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the ePrescription table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_GetByPrescriptionId
(

	@PrescriptionId nvarchar (20)  
)
AS


				SELECT
					[PrescriptionID],
					[TransactionID],
					[PatientCode],
					[FirstName],
					[LastName],
					[DeliveryDate],
					[CreateDate],
					[Address],
					[DateOfBirth],
					[Age],
					[Weight],
					[Diagnosis],
					[DiagnosisVN],
					[PrescribingDoctor],
					[Sex],
					[Remark],
					[IsComplete]
				FROM
					[dbo].[ePrescription]
				WHERE
                        
                            ISNULL([PrescriptionID],0) = ISNULL(@PrescriptionId,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescription_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescription_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescription_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the ePrescription table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescription_Find
(

	@SearchUsingOR bit   = null ,

	@PrescriptionId nvarchar (20)  = null ,

	@TransactionId nvarchar (15)  = null ,

	@PatientCode nvarchar (50)  = null ,

	@FirstName nvarchar (30)  = null ,

	@LastName nvarchar (30)  = null ,

	@DeliveryDate datetime   = null ,

	@CreateDate datetime   = null ,

	@Address nvarchar (150)  = null ,

	@DateOfBirth datetime   = null ,

	@Age nvarchar (20)  = null ,

	@Weight nvarchar (20)  = null ,

	@Diagnosis nvarchar (500)  = null ,

	@DiagnosisVn nvarchar (500)  = null ,

	@PrescribingDoctor nvarchar (100)  = null ,

	@Sex nvarchar (10)  = null ,

	@Remark nvarchar (250)  = null ,

	@IsComplete bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PrescriptionID]
	, [TransactionID]
	, [PatientCode]
	, [FirstName]
	, [LastName]
	, [DeliveryDate]
	, [CreateDate]
	, [Address]
	, [DateOfBirth]
	, [Age]
	, [Weight]
	, [Diagnosis]
	, [DiagnosisVN]
	, [PrescribingDoctor]
	, [Sex]
	, [Remark]
	, [IsComplete]
    FROM
	[dbo].[ePrescription]
    WHERE 
	 ([PrescriptionID] = @PrescriptionId OR @PrescriptionId IS NULL)
	AND ([TransactionID] = @TransactionId OR @TransactionId IS NULL)
	AND ([PatientCode] = @PatientCode OR @PatientCode IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([DeliveryDate] = @DeliveryDate OR @DeliveryDate IS NULL)
	AND ([CreateDate] = @CreateDate OR @CreateDate IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([DateOfBirth] = @DateOfBirth OR @DateOfBirth IS NULL)
	AND ([Age] = @Age OR @Age IS NULL)
	AND ([Weight] = @Weight OR @Weight IS NULL)
	AND ([Diagnosis] = @Diagnosis OR @Diagnosis IS NULL)
	AND ([DiagnosisVN] = @DiagnosisVn OR @DiagnosisVn IS NULL)
	AND ([PrescribingDoctor] = @PrescribingDoctor OR @PrescribingDoctor IS NULL)
	AND ([Sex] = @Sex OR @Sex IS NULL)
	AND ([Remark] = @Remark OR @Remark IS NULL)
	AND ([IsComplete] = @IsComplete OR @IsComplete IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PrescriptionID]
	, [TransactionID]
	, [PatientCode]
	, [FirstName]
	, [LastName]
	, [DeliveryDate]
	, [CreateDate]
	, [Address]
	, [DateOfBirth]
	, [Age]
	, [Weight]
	, [Diagnosis]
	, [DiagnosisVN]
	, [PrescribingDoctor]
	, [Sex]
	, [Remark]
	, [IsComplete]
    FROM
	[dbo].[ePrescription]
    WHERE 
	 ([PrescriptionID] = @PrescriptionId AND @PrescriptionId is not null)
	OR ([TransactionID] = @TransactionId AND @TransactionId is not null)
	OR ([PatientCode] = @PatientCode AND @PatientCode is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([DeliveryDate] = @DeliveryDate AND @DeliveryDate is not null)
	OR ([CreateDate] = @CreateDate AND @CreateDate is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([DateOfBirth] = @DateOfBirth AND @DateOfBirth is not null)
	OR ([Age] = @Age AND @Age is not null)
	OR ([Weight] = @Weight AND @Weight is not null)
	OR ([Diagnosis] = @Diagnosis AND @Diagnosis is not null)
	OR ([DiagnosisVN] = @DiagnosisVn AND @DiagnosisVn is not null)
	OR ([PrescribingDoctor] = @PrescribingDoctor AND @PrescribingDoctor is not null)
	OR ([Sex] = @Sex AND @Sex is not null)
	OR ([Remark] = @Remark AND @Remark is not null)
	OR ([IsComplete] = @IsComplete AND @IsComplete is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the FavoritMaster table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_Get_List

AS


				
				SELECT
					[ID],
					[DiceaseName],
					[CreateBy],
					[Diagnosis],
					[DiagnosisVN],
					[IsPrivate]
				FROM
					[dbo].[FavoritMaster]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the FavoritMaster table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[FavoritMaster]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[DiceaseName], O.[CreateBy], O.[Diagnosis], O.[DiagnosisVN], O.[IsPrivate]
				FROM
				    [dbo].[FavoritMaster] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[FavoritMaster]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the FavoritMaster table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_Insert
(

	@Id int   ,

	@DiceaseName nvarchar (50)  ,

	@CreateBy nvarchar (50)  ,

	@Diagnosis nvarchar (500)  ,

	@DiagnosisVn nvarchar (500)  ,

	@IsPrivate bit   
)
AS


				
				INSERT INTO [dbo].[FavoritMaster]
					(
					[ID]
					,[DiceaseName]
					,[CreateBy]
					,[Diagnosis]
					,[DiagnosisVN]
					,[IsPrivate]
					)
				VALUES
					(
					@Id
					,@DiceaseName
					,@CreateBy
					,@Diagnosis
					,@DiagnosisVn
					,@IsPrivate
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the FavoritMaster table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_Update
(

	@Id int   ,

	@OriginalId int   ,

	@DiceaseName nvarchar (50)  ,

	@CreateBy nvarchar (50)  ,

	@Diagnosis nvarchar (500)  ,

	@DiagnosisVn nvarchar (500)  ,

	@IsPrivate bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[FavoritMaster]
				SET
					[ID] = @Id
					,[DiceaseName] = @DiceaseName
					,[CreateBy] = @CreateBy
					,[Diagnosis] = @Diagnosis
					,[DiagnosisVN] = @DiagnosisVn
					,[IsPrivate] = @IsPrivate
				WHERE
[ID] = @OriginalId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the FavoritMaster table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[FavoritMaster] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the FavoritMaster table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[DiceaseName],
					[CreateBy],
					[Diagnosis],
					[DiagnosisVN],
					[IsPrivate]
				FROM
					[dbo].[FavoritMaster]
				WHERE
                        
                            ISNULL([ID],0) = ISNULL(@Id,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the FavoritMaster table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@DiceaseName nvarchar (50)  = null ,

	@CreateBy nvarchar (50)  = null ,

	@Diagnosis nvarchar (500)  = null ,

	@DiagnosisVn nvarchar (500)  = null ,

	@IsPrivate bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [DiceaseName]
	, [CreateBy]
	, [Diagnosis]
	, [DiagnosisVN]
	, [IsPrivate]
    FROM
	[dbo].[FavoritMaster]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([DiceaseName] = @DiceaseName OR @DiceaseName IS NULL)
	AND ([CreateBy] = @CreateBy OR @CreateBy IS NULL)
	AND ([Diagnosis] = @Diagnosis OR @Diagnosis IS NULL)
	AND ([DiagnosisVN] = @DiagnosisVn OR @DiagnosisVn IS NULL)
	AND ([IsPrivate] = @IsPrivate OR @IsPrivate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [DiceaseName]
	, [CreateBy]
	, [Diagnosis]
	, [DiagnosisVN]
	, [IsPrivate]
    FROM
	[dbo].[FavoritMaster]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([DiceaseName] = @DiceaseName AND @DiceaseName is not null)
	OR ([CreateBy] = @CreateBy AND @CreateBy is not null)
	OR ([Diagnosis] = @Diagnosis AND @Diagnosis is not null)
	OR ([DiagnosisVN] = @DiagnosisVn AND @DiagnosisVn is not null)
	OR ([IsPrivate] = @IsPrivate AND @IsPrivate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Get_List

AS


				
				SELECT
					[UserName],
					[Password],
					[UserRole],
					[FullName],
					[Email],
					[DisplayName],
					[Signature],
					[Location],
					[IsDisabled],
					[Avatar],
					[MobilePhone]
				FROM
					[dbo].[Users]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the Users table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [UserName] nvarchar(50)  
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([UserName])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [UserName]'
				SET @SQL = @SQL + ' FROM [dbo].[Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[UserName], O.[Password], O.[UserRole], O.[FullName], O.[Email], O.[DisplayName], O.[Signature], O.[Location], O.[IsDisabled], O.[Avatar], O.[MobilePhone]
				FROM
				    [dbo].[Users] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[UserName] = PageIndex.[UserName]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Insert
(

	@UserName nvarchar (50)  ,

	@Password nvarchar (200)  ,

	@UserRole nvarchar (50)  ,

	@FullName nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@DisplayName nvarchar (50)  ,

	@Signature varbinary (MAX)  ,

	@Location nvarchar (10)  ,

	@IsDisabled bit   ,

	@Avatar varbinary (MAX)  ,

	@MobilePhone nvarchar (20)  
)
AS


				
				INSERT INTO [dbo].[Users]
					(
					[UserName]
					,[Password]
					,[UserRole]
					,[FullName]
					,[Email]
					,[DisplayName]
					,[Signature]
					,[Location]
					,[IsDisabled]
					,[Avatar]
					,[MobilePhone]
					)
				VALUES
					(
					@UserName
					,@Password
					,@UserRole
					,@FullName
					,@Email
					,@DisplayName
					,@Signature
					,@Location
					,@IsDisabled
					,@Avatar
					,@MobilePhone
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Update
(

	@UserName nvarchar (50)  ,

	@OriginalUserName nvarchar (50)  ,

	@Password nvarchar (200)  ,

	@UserRole nvarchar (50)  ,

	@FullName nvarchar (50)  ,

	@Email nvarchar (50)  ,

	@DisplayName nvarchar (50)  ,

	@Signature varbinary (MAX)  ,

	@Location nvarchar (10)  ,

	@IsDisabled bit   ,

	@Avatar varbinary (MAX)  ,

	@MobilePhone nvarchar (20)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Users]
				SET
					[UserName] = @UserName
					,[Password] = @Password
					,[UserRole] = @UserRole
					,[FullName] = @FullName
					,[Email] = @Email
					,[DisplayName] = @DisplayName
					,[Signature] = @Signature
					,[Location] = @Location
					,[IsDisabled] = @IsDisabled
					,[Avatar] = @Avatar
					,[MobilePhone] = @MobilePhone
				WHERE
[UserName] = @OriginalUserName 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the Users table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Delete
(

	@UserName nvarchar (50)  
)
AS


				DELETE FROM [dbo].[Users] WITH (ROWLOCK) 
				WHERE
					[UserName] = @UserName
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_GetByUserName procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_GetByUserName') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_GetByUserName
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the Users table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_GetByUserName
(

	@UserName nvarchar (50)  
)
AS


				SELECT
					[UserName],
					[Password],
					[UserRole],
					[FullName],
					[Email],
					[DisplayName],
					[Signature],
					[Location],
					[IsDisabled],
					[Avatar],
					[MobilePhone]
				FROM
					[dbo].[Users]
				WHERE
                        
                            ISNULL([UserName],0) = ISNULL(@UserName,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Users_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Users_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Users_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the Users table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Users_Find
(

	@SearchUsingOR bit   = null ,

	@UserName nvarchar (50)  = null ,

	@Password nvarchar (200)  = null ,

	@UserRole nvarchar (50)  = null ,

	@FullName nvarchar (50)  = null ,

	@Email nvarchar (50)  = null ,

	@DisplayName nvarchar (50)  = null ,

	@Signature varbinary (MAX)  = null ,

	@Location nvarchar (10)  = null ,

	@IsDisabled bit   = null ,

	@Avatar varbinary (MAX)  = null ,

	@MobilePhone nvarchar (20)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [UserName]
	, [Password]
	, [UserRole]
	, [FullName]
	, [Email]
	, [DisplayName]
	, [Signature]
	, [Location]
	, [IsDisabled]
	, [Avatar]
	, [MobilePhone]
    FROM
	[dbo].[Users]
    WHERE 
	 ([UserName] = @UserName OR @UserName IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([UserRole] = @UserRole OR @UserRole IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([DisplayName] = @DisplayName OR @DisplayName IS NULL)
	AND ([Location] = @Location OR @Location IS NULL)
	AND ([IsDisabled] = @IsDisabled OR @IsDisabled IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [UserName]
	, [Password]
	, [UserRole]
	, [FullName]
	, [Email]
	, [DisplayName]
	, [Signature]
	, [Location]
	, [IsDisabled]
	, [Avatar]
	, [MobilePhone]
    FROM
	[dbo].[Users]
    WHERE 
	 ([UserName] = @UserName AND @UserName is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([UserRole] = @UserRole AND @UserRole is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([DisplayName] = @DisplayName AND @DisplayName is not null)
	OR ([Location] = @Location AND @Location is not null)
	OR ([IsDisabled] = @IsDisabled AND @IsDisabled is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the ePrescriptionDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_Get_List

AS


				
				SELECT
					[PrescriptionDetailId],
					[PrescriptionID],
					[Sq],
					[DrugId],
					[DrugName],
					[Unit],
					[UnitVN],
					[Remark],
					[RouteType],
					[RouteTypeVN],
					[Dosage],
					[DosageUnit],
					[DosageUnitVN],
					[Frequency],
					[FrequencyVN],
					[Duration],
					[DurationUnit],
					[DurationUnitVN],
					[TotalUnit]
				FROM
					[dbo].[ePrescriptionDetail]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the ePrescriptionDetail table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [PrescriptionDetailId] bigint 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([PrescriptionDetailId])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [PrescriptionDetailId]'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescriptionDetail]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[PrescriptionDetailId], O.[PrescriptionID], O.[Sq], O.[DrugId], O.[DrugName], O.[Unit], O.[UnitVN], O.[Remark], O.[RouteType], O.[RouteTypeVN], O.[Dosage], O.[DosageUnit], O.[DosageUnitVN], O.[Frequency], O.[FrequencyVN], O.[Duration], O.[DurationUnit], O.[DurationUnitVN], O.[TotalUnit]
				FROM
				    [dbo].[ePrescriptionDetail] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[PrescriptionDetailId] = PageIndex.[PrescriptionDetailId]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescriptionDetail]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the ePrescriptionDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_Insert
(

	@PrescriptionDetailId bigint    OUTPUT,

	@PrescriptionId nvarchar (20)  ,

	@Sq int   ,

	@DrugId nvarchar (20)  ,

	@DrugName nvarchar (250)  ,

	@Unit nvarchar (50)  ,

	@UnitVn nvarchar (50)  ,

	@Remark nvarchar (250)  ,

	@RouteType nvarchar (50)  ,

	@RouteTypeVn nvarchar (50)  ,

	@Dosage nvarchar (20)  ,

	@DosageUnit nvarchar (50)  ,

	@DosageUnitVn nvarchar (50)  ,

	@Frequency nvarchar (150)  ,

	@FrequencyVn nvarchar (150)  ,

	@Duration nvarchar (50)  ,

	@DurationUnit nvarchar (50)  ,

	@DurationUnitVn nvarchar (50)  ,

	@TotalUnit nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[ePrescriptionDetail]
					(
					[PrescriptionID]
					,[Sq]
					,[DrugId]
					,[DrugName]
					,[Unit]
					,[UnitVN]
					,[Remark]
					,[RouteType]
					,[RouteTypeVN]
					,[Dosage]
					,[DosageUnit]
					,[DosageUnitVN]
					,[Frequency]
					,[FrequencyVN]
					,[Duration]
					,[DurationUnit]
					,[DurationUnitVN]
					,[TotalUnit]
					)
				VALUES
					(
					@PrescriptionId
					,@Sq
					,@DrugId
					,@DrugName
					,@Unit
					,@UnitVn
					,@Remark
					,@RouteType
					,@RouteTypeVn
					,@Dosage
					,@DosageUnit
					,@DosageUnitVn
					,@Frequency
					,@FrequencyVn
					,@Duration
					,@DurationUnit
					,@DurationUnitVn
					,@TotalUnit
					)
				-- Get the identity value
				SET @PrescriptionDetailId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the ePrescriptionDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_Update
(

	@PrescriptionDetailId bigint   ,

	@PrescriptionId nvarchar (20)  ,

	@Sq int   ,

	@DrugId nvarchar (20)  ,

	@DrugName nvarchar (250)  ,

	@Unit nvarchar (50)  ,

	@UnitVn nvarchar (50)  ,

	@Remark nvarchar (250)  ,

	@RouteType nvarchar (50)  ,

	@RouteTypeVn nvarchar (50)  ,

	@Dosage nvarchar (20)  ,

	@DosageUnit nvarchar (50)  ,

	@DosageUnitVn nvarchar (50)  ,

	@Frequency nvarchar (150)  ,

	@FrequencyVn nvarchar (150)  ,

	@Duration nvarchar (50)  ,

	@DurationUnit nvarchar (50)  ,

	@DurationUnitVn nvarchar (50)  ,

	@TotalUnit nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ePrescriptionDetail]
				SET
					[PrescriptionID] = @PrescriptionId
					,[Sq] = @Sq
					,[DrugId] = @DrugId
					,[DrugName] = @DrugName
					,[Unit] = @Unit
					,[UnitVN] = @UnitVn
					,[Remark] = @Remark
					,[RouteType] = @RouteType
					,[RouteTypeVN] = @RouteTypeVn
					,[Dosage] = @Dosage
					,[DosageUnit] = @DosageUnit
					,[DosageUnitVN] = @DosageUnitVn
					,[Frequency] = @Frequency
					,[FrequencyVN] = @FrequencyVn
					,[Duration] = @Duration
					,[DurationUnit] = @DurationUnit
					,[DurationUnitVN] = @DurationUnitVn
					,[TotalUnit] = @TotalUnit
				WHERE
[PrescriptionDetailId] = @PrescriptionDetailId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the ePrescriptionDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_Delete
(

	@PrescriptionDetailId bigint   
)
AS


				DELETE FROM [dbo].[ePrescriptionDetail] WITH (ROWLOCK) 
				WHERE
					[PrescriptionDetailId] = @PrescriptionDetailId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_GetByPrescriptionId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_GetByPrescriptionId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_GetByPrescriptionId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the ePrescriptionDetail table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_GetByPrescriptionId
(

	@PrescriptionId nvarchar (20)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[PrescriptionDetailId],
					[PrescriptionID],
					[Sq],
					[DrugId],
					[DrugName],
					[Unit],
					[UnitVN],
					[Remark],
					[RouteType],
					[RouteTypeVN],
					[Dosage],
					[DosageUnit],
					[DosageUnitVN],
					[Frequency],
					[FrequencyVN],
					[Duration],
					[DurationUnit],
					[DurationUnitVN],
					[TotalUnit]
				FROM
					[dbo].[ePrescriptionDetail]
				WHERE
					[PrescriptionID] = @PrescriptionId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_GetByPrescriptionDetailId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_GetByPrescriptionDetailId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_GetByPrescriptionDetailId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the ePrescriptionDetail table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_GetByPrescriptionDetailId
(

	@PrescriptionDetailId bigint   
)
AS


				SELECT
					[PrescriptionDetailId],
					[PrescriptionID],
					[Sq],
					[DrugId],
					[DrugName],
					[Unit],
					[UnitVN],
					[Remark],
					[RouteType],
					[RouteTypeVN],
					[Dosage],
					[DosageUnit],
					[DosageUnitVN],
					[Frequency],
					[FrequencyVN],
					[Duration],
					[DurationUnit],
					[DurationUnitVN],
					[TotalUnit]
				FROM
					[dbo].[ePrescriptionDetail]
				WHERE
                        
                            ISNULL([PrescriptionDetailId],0) = ISNULL(@PrescriptionDetailId,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ePrescriptionDetail_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ePrescriptionDetail_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ePrescriptionDetail_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the ePrescriptionDetail table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ePrescriptionDetail_Find
(

	@SearchUsingOR bit   = null ,

	@PrescriptionDetailId bigint   = null ,

	@PrescriptionId nvarchar (20)  = null ,

	@Sq int   = null ,

	@DrugId nvarchar (20)  = null ,

	@DrugName nvarchar (250)  = null ,

	@Unit nvarchar (50)  = null ,

	@UnitVn nvarchar (50)  = null ,

	@Remark nvarchar (250)  = null ,

	@RouteType nvarchar (50)  = null ,

	@RouteTypeVn nvarchar (50)  = null ,

	@Dosage nvarchar (20)  = null ,

	@DosageUnit nvarchar (50)  = null ,

	@DosageUnitVn nvarchar (50)  = null ,

	@Frequency nvarchar (150)  = null ,

	@FrequencyVn nvarchar (150)  = null ,

	@Duration nvarchar (50)  = null ,

	@DurationUnit nvarchar (50)  = null ,

	@DurationUnitVn nvarchar (50)  = null ,

	@TotalUnit nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [PrescriptionDetailId]
	, [PrescriptionID]
	, [Sq]
	, [DrugId]
	, [DrugName]
	, [Unit]
	, [UnitVN]
	, [Remark]
	, [RouteType]
	, [RouteTypeVN]
	, [Dosage]
	, [DosageUnit]
	, [DosageUnitVN]
	, [Frequency]
	, [FrequencyVN]
	, [Duration]
	, [DurationUnit]
	, [DurationUnitVN]
	, [TotalUnit]
    FROM
	[dbo].[ePrescriptionDetail]
    WHERE 
	 ([PrescriptionDetailId] = @PrescriptionDetailId OR @PrescriptionDetailId IS NULL)
	AND ([PrescriptionID] = @PrescriptionId OR @PrescriptionId IS NULL)
	AND ([Sq] = @Sq OR @Sq IS NULL)
	AND ([DrugId] = @DrugId OR @DrugId IS NULL)
	AND ([DrugName] = @DrugName OR @DrugName IS NULL)
	AND ([Unit] = @Unit OR @Unit IS NULL)
	AND ([UnitVN] = @UnitVn OR @UnitVn IS NULL)
	AND ([Remark] = @Remark OR @Remark IS NULL)
	AND ([RouteType] = @RouteType OR @RouteType IS NULL)
	AND ([RouteTypeVN] = @RouteTypeVn OR @RouteTypeVn IS NULL)
	AND ([Dosage] = @Dosage OR @Dosage IS NULL)
	AND ([DosageUnit] = @DosageUnit OR @DosageUnit IS NULL)
	AND ([DosageUnitVN] = @DosageUnitVn OR @DosageUnitVn IS NULL)
	AND ([Frequency] = @Frequency OR @Frequency IS NULL)
	AND ([FrequencyVN] = @FrequencyVn OR @FrequencyVn IS NULL)
	AND ([Duration] = @Duration OR @Duration IS NULL)
	AND ([DurationUnit] = @DurationUnit OR @DurationUnit IS NULL)
	AND ([DurationUnitVN] = @DurationUnitVn OR @DurationUnitVn IS NULL)
	AND ([TotalUnit] = @TotalUnit OR @TotalUnit IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [PrescriptionDetailId]
	, [PrescriptionID]
	, [Sq]
	, [DrugId]
	, [DrugName]
	, [Unit]
	, [UnitVN]
	, [Remark]
	, [RouteType]
	, [RouteTypeVN]
	, [Dosage]
	, [DosageUnit]
	, [DosageUnitVN]
	, [Frequency]
	, [FrequencyVN]
	, [Duration]
	, [DurationUnit]
	, [DurationUnitVN]
	, [TotalUnit]
    FROM
	[dbo].[ePrescriptionDetail]
    WHERE 
	 ([PrescriptionDetailId] = @PrescriptionDetailId AND @PrescriptionDetailId is not null)
	OR ([PrescriptionID] = @PrescriptionId AND @PrescriptionId is not null)
	OR ([Sq] = @Sq AND @Sq is not null)
	OR ([DrugId] = @DrugId AND @DrugId is not null)
	OR ([DrugName] = @DrugName AND @DrugName is not null)
	OR ([Unit] = @Unit AND @Unit is not null)
	OR ([UnitVN] = @UnitVn AND @UnitVn is not null)
	OR ([Remark] = @Remark AND @Remark is not null)
	OR ([RouteType] = @RouteType AND @RouteType is not null)
	OR ([RouteTypeVN] = @RouteTypeVn AND @RouteTypeVn is not null)
	OR ([Dosage] = @Dosage AND @Dosage is not null)
	OR ([DosageUnit] = @DosageUnit AND @DosageUnit is not null)
	OR ([DosageUnitVN] = @DosageUnitVn AND @DosageUnitVn is not null)
	OR ([Frequency] = @Frequency AND @Frequency is not null)
	OR ([FrequencyVN] = @FrequencyVn AND @FrequencyVn is not null)
	OR ([Duration] = @Duration AND @Duration is not null)
	OR ([DurationUnit] = @DurationUnit AND @DurationUnit is not null)
	OR ([DurationUnitVN] = @DurationUnitVn AND @DurationUnitVn is not null)
	OR ([TotalUnit] = @TotalUnit AND @TotalUnit is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.VR_ePresDetail_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.VR_ePresDetail_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.VR_ePresDetail_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the VR_ePresDetail view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.VR_ePresDetail_Get_List

AS


                    
                    SELECT
                        [PrescriptionDetailId],
                        [PrescriptionID],
                        [Sq],
                        [DrugId],
                        [DrugName],
                        [Unit],
                        [UnitVN],
                        [Remark],
                        [Dosage],
                        [Frequency],
                        [VN_meaning],
                        [Duration],
                        [TotalUnit],
                        [Expr1],
                        [meaning],
                        [abbre]
                    FROM
                        [dbo].[VR_ePresDetail]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.VR_ePresDetail_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.VR_ePresDetail_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.VR_ePresDetail_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the VR_ePresDetail view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.VR_ePresDetail_Get
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  
)
AS


                    
                    BEGIN
    
                    -- Build the sql query
                    DECLARE @SQL AS nvarchar(4000)
                    SET @SQL = ' SELECT * FROM [dbo].[VR_ePresDetail]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    
                    -- Execution the query
                    EXEC sp_executesql @SQL
                    
                    -- Return total count
                    SELECT @@ROWCOUNT AS TotalRowCount
                    
                    END
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

