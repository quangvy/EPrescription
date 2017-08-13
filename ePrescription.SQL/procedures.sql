
USE [EPrescription]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the Route table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_Get_List

AS


				
				SELECT
					[RouteId],
					[Route],
					[RouteVN]
				FROM
					[dbo].[Route]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the Route table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_GetPaged
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RouteId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RouteId]'
				SET @SQL = @SQL + ', [Route]'
				SET @SQL = @SQL + ', [RouteVN]'
				SET @SQL = @SQL + ' FROM [dbo].[Route]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RouteId],'
				SET @SQL = @SQL + ' [Route],'
				SET @SQL = @SQL + ' [RouteVN]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Route]'
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

	

-- Drop the dbo.Route_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the Route table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_Insert
(

	@RouteId bigint    OUTPUT,

	@Route nvarchar (50)  ,

	@RouteVn nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Route]
					(
					[Route]
					,[RouteVN]
					)
				VALUES
					(
					@Route
					,@RouteVn
					)
				-- Get the identity value
				SET @RouteId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the Route table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_Update
(

	@RouteId bigint   ,

	@Route nvarchar (50)  ,

	@RouteVn nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Route]
				SET
					[Route] = @Route
					,[RouteVN] = @RouteVn
				WHERE
[RouteId] = @RouteId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the Route table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_Delete
(

	@RouteId bigint   
)
AS


				DELETE FROM [dbo].[Route] WITH (ROWLOCK) 
				WHERE
					[RouteId] = @RouteId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_GetByRouteId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_GetByRouteId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_GetByRouteId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the Route table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_GetByRouteId
(

	@RouteId bigint   
)
AS


				SELECT
					[RouteId],
					[Route],
					[RouteVN]
				FROM
					[dbo].[Route]
				WHERE
                        
                            ISNULL([RouteId],0) = ISNULL(@RouteId,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Route_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Route_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Route_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the Route table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Route_Find
(

	@SearchUsingOR bit   = null ,

	@RouteId bigint   = null ,

	@Route nvarchar (50)  = null ,

	@RouteVn nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [RouteId]
	, [Route]
	, [RouteVN]
    FROM
	[dbo].[Route]
    WHERE 
	 ([RouteId] = @RouteId OR @RouteId IS NULL)
	AND ([Route] = @Route OR @Route IS NULL)
	AND ([RouteVN] = @RouteVn OR @RouteVn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [RouteId]
	, [Route]
	, [RouteVN]
    FROM
	[dbo].[Route]
    WHERE 
	 ([RouteId] = @RouteId AND @RouteId is not null)
	OR ([Route] = @Route AND @Route is not null)
	OR ([RouteVN] = @RouteVn AND @RouteVn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the Diaglist table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_Get_List

AS


				
				SELECT
					[CATEGORY],
					[DIAG_CODE],
					[DIAG_NAME],
					[DIAG_NAME_VN],
					[IsDisabled]
				FROM
					[dbo].[Diaglist]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the Diaglist table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_GetPaged
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CATEGORY]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CATEGORY]'
				SET @SQL = @SQL + ', [DIAG_CODE]'
				SET @SQL = @SQL + ', [DIAG_NAME]'
				SET @SQL = @SQL + ', [DIAG_NAME_VN]'
				SET @SQL = @SQL + ', [IsDisabled]'
				SET @SQL = @SQL + ' FROM [dbo].[Diaglist]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CATEGORY],'
				SET @SQL = @SQL + ' [DIAG_CODE],'
				SET @SQL = @SQL + ' [DIAG_NAME],'
				SET @SQL = @SQL + ' [DIAG_NAME_VN],'
				SET @SQL = @SQL + ' [IsDisabled]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Diaglist]'
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

	

-- Drop the dbo.Diaglist_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the Diaglist table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_Insert
(

	@Category nvarchar (50)  ,

	@DiagCode nvarchar (15)  ,

	@DiagName nvarchar (500)  ,

	@DiagNameVn nvarchar (500)  ,

	@IsDisabled bit   
)
AS


				
				INSERT INTO [dbo].[Diaglist]
					(
					[CATEGORY]
					,[DIAG_CODE]
					,[DIAG_NAME]
					,[DIAG_NAME_VN]
					,[IsDisabled]
					)
				VALUES
					(
					@Category
					,@DiagCode
					,@DiagName
					,@DiagNameVn
					,@IsDisabled
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the Diaglist table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_Update
(

	@Category nvarchar (50)  ,

	@DiagCode nvarchar (15)  ,

	@OriginalDiagCode nvarchar (15)  ,

	@DiagName nvarchar (500)  ,

	@DiagNameVn nvarchar (500)  ,

	@IsDisabled bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Diaglist]
				SET
					[CATEGORY] = @Category
					,[DIAG_CODE] = @DiagCode
					,[DIAG_NAME] = @DiagName
					,[DIAG_NAME_VN] = @DiagNameVn
					,[IsDisabled] = @IsDisabled
				WHERE
[DIAG_CODE] = @OriginalDiagCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the Diaglist table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_Delete
(

	@DiagCode nvarchar (15)  
)
AS


				DELETE FROM [dbo].[Diaglist] WITH (ROWLOCK) 
				WHERE
					[DIAG_CODE] = @DiagCode
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_GetByDiagCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_GetByDiagCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_GetByDiagCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the Diaglist table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_GetByDiagCode
(

	@DiagCode nvarchar (15)  
)
AS


				SELECT
					[CATEGORY],
					[DIAG_CODE],
					[DIAG_NAME],
					[DIAG_NAME_VN],
					[IsDisabled]
				FROM
					[dbo].[Diaglist]
				WHERE
                        
                            ISNULL([DIAG_CODE],0) = ISNULL(@DiagCode,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Diaglist_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Diaglist_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Diaglist_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the Diaglist table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Diaglist_Find
(

	@SearchUsingOR bit   = null ,

	@Category nvarchar (50)  = null ,

	@DiagCode nvarchar (15)  = null ,

	@DiagName nvarchar (500)  = null ,

	@DiagNameVn nvarchar (500)  = null ,

	@IsDisabled bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CATEGORY]
	, [DIAG_CODE]
	, [DIAG_NAME]
	, [DIAG_NAME_VN]
	, [IsDisabled]
    FROM
	[dbo].[Diaglist]
    WHERE 
	 ([CATEGORY] = @Category OR @Category IS NULL)
	AND ([DIAG_CODE] = @DiagCode OR @DiagCode IS NULL)
	AND ([DIAG_NAME] = @DiagName OR @DiagName IS NULL)
	AND ([DIAG_NAME_VN] = @DiagNameVn OR @DiagNameVn IS NULL)
	AND ([IsDisabled] = @IsDisabled OR @IsDisabled IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CATEGORY]
	, [DIAG_CODE]
	, [DIAG_NAME]
	, [DIAG_NAME_VN]
	, [IsDisabled]
    FROM
	[dbo].[Diaglist]
    WHERE 
	 ([CATEGORY] = @Category AND @Category is not null)
	OR ([DIAG_CODE] = @DiagCode AND @DiagCode is not null)
	OR ([DIAG_NAME] = @DiagName AND @DiagName is not null)
	OR ([DIAG_NAME_VN] = @DiagNameVn AND @DiagNameVn is not null)
	OR ([IsDisabled] = @IsDisabled AND @IsDisabled is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the Frequency table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_Get_List

AS


				
				SELECT
					[FrequencyId],
					[abbre],
					[meaning],
					[VN_meaning]
				FROM
					[dbo].[Frequency]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the Frequency table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_GetPaged
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FrequencyId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FrequencyId]'
				SET @SQL = @SQL + ', [abbre]'
				SET @SQL = @SQL + ', [meaning]'
				SET @SQL = @SQL + ', [VN_meaning]'
				SET @SQL = @SQL + ' FROM [dbo].[Frequency]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FrequencyId],'
				SET @SQL = @SQL + ' [abbre],'
				SET @SQL = @SQL + ' [meaning],'
				SET @SQL = @SQL + ' [VN_meaning]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Frequency]'
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

	

-- Drop the dbo.Frequency_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the Frequency table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_Insert
(

	@FrequencyId bigint    OUTPUT,

	@Abbre nvarchar (50)  ,

	@Meaning nvarchar (250)  ,

	@VnMeaning nvarchar (250)  
)
AS


				
				INSERT INTO [dbo].[Frequency]
					(
					[abbre]
					,[meaning]
					,[VN_meaning]
					)
				VALUES
					(
					@Abbre
					,@Meaning
					,@VnMeaning
					)
				-- Get the identity value
				SET @FrequencyId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the Frequency table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_Update
(

	@FrequencyId bigint   ,

	@Abbre nvarchar (50)  ,

	@Meaning nvarchar (250)  ,

	@VnMeaning nvarchar (250)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Frequency]
				SET
					[abbre] = @Abbre
					,[meaning] = @Meaning
					,[VN_meaning] = @VnMeaning
				WHERE
[FrequencyId] = @FrequencyId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the Frequency table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_Delete
(

	@FrequencyId bigint   
)
AS


				DELETE FROM [dbo].[Frequency] WITH (ROWLOCK) 
				WHERE
					[FrequencyId] = @FrequencyId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_GetByFrequencyId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_GetByFrequencyId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_GetByFrequencyId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the Frequency table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_GetByFrequencyId
(

	@FrequencyId bigint   
)
AS


				SELECT
					[FrequencyId],
					[abbre],
					[meaning],
					[VN_meaning]
				FROM
					[dbo].[Frequency]
				WHERE
                        
                            ISNULL([FrequencyId],0) = ISNULL(@FrequencyId,0)
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Frequency_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Frequency_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Frequency_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the Frequency table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Frequency_Find
(

	@SearchUsingOR bit   = null ,

	@FrequencyId bigint   = null ,

	@Abbre nvarchar (50)  = null ,

	@Meaning nvarchar (250)  = null ,

	@VnMeaning nvarchar (250)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FrequencyId]
	, [abbre]
	, [meaning]
	, [VN_meaning]
    FROM
	[dbo].[Frequency]
    WHERE 
	 ([FrequencyId] = @FrequencyId OR @FrequencyId IS NULL)
	AND ([abbre] = @Abbre OR @Abbre IS NULL)
	AND ([meaning] = @Meaning OR @Meaning IS NULL)
	AND ([VN_meaning] = @VnMeaning OR @VnMeaning IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FrequencyId]
	, [abbre]
	, [meaning]
	, [VN_meaning]
    FROM
	[dbo].[Frequency]
    WHERE 
	 ([FrequencyId] = @FrequencyId AND @FrequencyId is not null)
	OR ([abbre] = @Abbre AND @Abbre is not null)
	OR ([meaning] = @Meaning AND @Meaning is not null)
	OR ([VN_meaning] = @VnMeaning AND @VnMeaning is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[RoleID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [RoleID]'
				SET @SQL = @SQL + ', [RoleName]'
				SET @SQL = @SQL + ', [Remark]'
				SET @SQL = @SQL + ' FROM [dbo].[UserRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [RoleID],'
				SET @SQL = @SQL + ' [RoleName],'
				SET @SQL = @SQL + ' [Remark]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
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
					[FavouriteID],
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FavouriteID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FavouriteID]'
				SET @SQL = @SQL + ', [DiceaseName]'
				SET @SQL = @SQL + ', [CreateBy]'
				SET @SQL = @SQL + ', [Diagnosis]'
				SET @SQL = @SQL + ', [DiagnosisVN]'
				SET @SQL = @SQL + ', [IsPrivate]'
				SET @SQL = @SQL + ' FROM [dbo].[FavoritMaster]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FavouriteID],'
				SET @SQL = @SQL + ' [DiceaseName],'
				SET @SQL = @SQL + ' [CreateBy],'
				SET @SQL = @SQL + ' [Diagnosis],'
				SET @SQL = @SQL + ' [DiagnosisVN],'
				SET @SQL = @SQL + ' [IsPrivate]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
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

	@FavouriteId nvarchar (10)  ,

	@DiceaseName nvarchar (50)  ,

	@CreateBy nvarchar (50)  ,

	@Diagnosis nvarchar (500)  ,

	@DiagnosisVn nvarchar (500)  ,

	@IsPrivate bit   
)
AS


				
				INSERT INTO [dbo].[FavoritMaster]
					(
					[FavouriteID]
					,[DiceaseName]
					,[CreateBy]
					,[Diagnosis]
					,[DiagnosisVN]
					,[IsPrivate]
					)
				VALUES
					(
					@FavouriteId
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

	@FavouriteId nvarchar (10)  ,

	@OriginalFavouriteId nvarchar (10)  ,

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
					[FavouriteID] = @FavouriteId
					,[DiceaseName] = @DiceaseName
					,[CreateBy] = @CreateBy
					,[Diagnosis] = @Diagnosis
					,[DiagnosisVN] = @DiagnosisVn
					,[IsPrivate] = @IsPrivate
				WHERE
[FavouriteID] = @OriginalFavouriteId 
				
			

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

	@FavouriteId nvarchar (10)  
)
AS


				DELETE FROM [dbo].[FavoritMaster] WITH (ROWLOCK) 
				WHERE
					[FavouriteID] = @FavouriteId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritMaster_GetByFavouriteId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritMaster_GetByFavouriteId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritMaster_GetByFavouriteId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the FavoritMaster table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritMaster_GetByFavouriteId
(

	@FavouriteId nvarchar (10)  
)
AS


				SELECT
					[FavouriteID],
					[DiceaseName],
					[CreateBy],
					[Diagnosis],
					[DiagnosisVN],
					[IsPrivate]
				FROM
					[dbo].[FavoritMaster]
				WHERE
                        
                            ISNULL([FavouriteID],0) = ISNULL(@FavouriteId,0)
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

	@FavouriteId nvarchar (10)  = null ,

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
	  [FavouriteID]
	, [DiceaseName]
	, [CreateBy]
	, [Diagnosis]
	, [DiagnosisVN]
	, [IsPrivate]
    FROM
	[dbo].[FavoritMaster]
    WHERE 
	 ([FavouriteID] = @FavouriteId OR @FavouriteId IS NULL)
	AND ([DiceaseName] = @DiceaseName OR @DiceaseName IS NULL)
	AND ([CreateBy] = @CreateBy OR @CreateBy IS NULL)
	AND ([Diagnosis] = @Diagnosis OR @Diagnosis IS NULL)
	AND ([DiagnosisVN] = @DiagnosisVn OR @DiagnosisVn IS NULL)
	AND ([IsPrivate] = @IsPrivate OR @IsPrivate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FavouriteID]
	, [DiceaseName]
	, [CreateBy]
	, [Diagnosis]
	, [DiagnosisVN]
	, [IsPrivate]
    FROM
	[dbo].[FavoritMaster]
    WHERE 
	 ([FavouriteID] = @FavouriteId AND @FavouriteId is not null)
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PrescriptionID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PrescriptionID]'
				SET @SQL = @SQL + ', [TransactionID]'
				SET @SQL = @SQL + ', [PatientCode]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [DeliveryDate]'
				SET @SQL = @SQL + ', [CreateDate]'
				SET @SQL = @SQL + ', [Address]'
				SET @SQL = @SQL + ', [DateOfBirth]'
				SET @SQL = @SQL + ', [Age]'
				SET @SQL = @SQL + ', [Weight]'
				SET @SQL = @SQL + ', [Diagnosis]'
				SET @SQL = @SQL + ', [DiagnosisVN]'
				SET @SQL = @SQL + ', [PrescribingDoctor]'
				SET @SQL = @SQL + ', [Sex]'
				SET @SQL = @SQL + ', [Remark]'
				SET @SQL = @SQL + ', [IsComplete]'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescription]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PrescriptionID],'
				SET @SQL = @SQL + ' [TransactionID],'
				SET @SQL = @SQL + ' [PatientCode],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [DeliveryDate],'
				SET @SQL = @SQL + ' [CreateDate],'
				SET @SQL = @SQL + ' [Address],'
				SET @SQL = @SQL + ' [DateOfBirth],'
				SET @SQL = @SQL + ' [Age],'
				SET @SQL = @SQL + ' [Weight],'
				SET @SQL = @SQL + ' [Diagnosis],'
				SET @SQL = @SQL + ' [DiagnosisVN],'
				SET @SQL = @SQL + ' [PrescribingDoctor],'
				SET @SQL = @SQL + ' [Sex],'
				SET @SQL = @SQL + ' [Remark],'
				SET @SQL = @SQL + ' [IsComplete]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
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

	

-- Drop the dbo.FavoritDetail_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the FavoritDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_Get_List

AS


				
				SELECT
					[ID],
					[FavouriteID],
					[DrugID],
					[DrugName],
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
					[dbo].[FavoritDetail]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritDetail_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the FavoritDetail table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_GetPaged
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[ID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [ID]'
				SET @SQL = @SQL + ', [FavouriteID]'
				SET @SQL = @SQL + ', [DrugID]'
				SET @SQL = @SQL + ', [DrugName]'
				SET @SQL = @SQL + ', [RouteType]'
				SET @SQL = @SQL + ', [RouteTypeVN]'
				SET @SQL = @SQL + ', [Dosage]'
				SET @SQL = @SQL + ', [DosageUnit]'
				SET @SQL = @SQL + ', [DosageUnitVN]'
				SET @SQL = @SQL + ', [Frequency]'
				SET @SQL = @SQL + ', [FrequencyVN]'
				SET @SQL = @SQL + ', [Duration]'
				SET @SQL = @SQL + ', [DurationUnit]'
				SET @SQL = @SQL + ', [DurationUnitVN]'
				SET @SQL = @SQL + ', [TotalUnit]'
				SET @SQL = @SQL + ' FROM [dbo].[FavoritDetail]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [ID],'
				SET @SQL = @SQL + ' [FavouriteID],'
				SET @SQL = @SQL + ' [DrugID],'
				SET @SQL = @SQL + ' [DrugName],'
				SET @SQL = @SQL + ' [RouteType],'
				SET @SQL = @SQL + ' [RouteTypeVN],'
				SET @SQL = @SQL + ' [Dosage],'
				SET @SQL = @SQL + ' [DosageUnit],'
				SET @SQL = @SQL + ' [DosageUnitVN],'
				SET @SQL = @SQL + ' [Frequency],'
				SET @SQL = @SQL + ' [FrequencyVN],'
				SET @SQL = @SQL + ' [Duration],'
				SET @SQL = @SQL + ' [DurationUnit],'
				SET @SQL = @SQL + ' [DurationUnitVN],'
				SET @SQL = @SQL + ' [TotalUnit]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[FavoritDetail]'
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

	

-- Drop the dbo.FavoritDetail_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Inserts a record into the FavoritDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_Insert
(

	@Id bigint    OUTPUT,

	@FavouriteId nvarchar (10)  ,

	@DrugId nvarchar (20)  ,

	@DrugName nvarchar (250)  ,

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


				
				INSERT INTO [dbo].[FavoritDetail]
					(
					[FavouriteID]
					,[DrugID]
					,[DrugName]
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
					@FavouriteId
					,@DrugId
					,@DrugName
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
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritDetail_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Updates a record in the FavoritDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_Update
(

	@Id bigint   ,

	@FavouriteId nvarchar (10)  ,

	@DrugId nvarchar (20)  ,

	@DrugName nvarchar (250)  ,

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
					[dbo].[FavoritDetail]
				SET
					[FavouriteID] = @FavouriteId
					,[DrugID] = @DrugId
					,[DrugName] = @DrugName
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
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritDetail_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Deletes a record in the FavoritDetail table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_Delete
(

	@Id bigint   
)
AS


				DELETE FROM [dbo].[FavoritDetail] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritDetail_GetByFavouriteId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_GetByFavouriteId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_GetByFavouriteId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the FavoritDetail table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_GetByFavouriteId
(

	@FavouriteId nvarchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[FavouriteID],
					[DrugID],
					[DrugName],
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
					[dbo].[FavoritDetail]
				WHERE
					[FavouriteID] = @FavouriteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.FavoritDetail_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Select records from the FavoritDetail table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_GetById
(

	@Id bigint   
)
AS


				SELECT
					[ID],
					[FavouriteID],
					[DrugID],
					[DrugName],
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
					[dbo].[FavoritDetail]
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

	

-- Drop the dbo.FavoritDetail_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.FavoritDetail_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.FavoritDetail_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Finds records in the FavoritDetail table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.FavoritDetail_Find
(

	@SearchUsingOR bit   = null ,

	@Id bigint   = null ,

	@FavouriteId nvarchar (10)  = null ,

	@DrugId nvarchar (20)  = null ,

	@DrugName nvarchar (250)  = null ,

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
	  [ID]
	, [FavouriteID]
	, [DrugID]
	, [DrugName]
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
	[dbo].[FavoritDetail]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([FavouriteID] = @FavouriteId OR @FavouriteId IS NULL)
	AND ([DrugID] = @DrugId OR @DrugId IS NULL)
	AND ([DrugName] = @DrugName OR @DrugName IS NULL)
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
	  [ID]
	, [FavouriteID]
	, [DrugID]
	, [DrugName]
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
	[dbo].[FavoritDetail]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([FavouriteID] = @FavouriteId AND @FavouriteId is not null)
	OR ([DrugID] = @DrugId AND @DrugId is not null)
	OR ([DrugName] = @DrugName AND @DrugName is not null)
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[UserName]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [UserName]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [UserRole]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [DisplayName]'
				SET @SQL = @SQL + ', [Signature]'
				SET @SQL = @SQL + ', [Location]'
				SET @SQL = @SQL + ', [IsDisabled]'
				SET @SQL = @SQL + ', [Avatar]'
				SET @SQL = @SQL + ', [MobilePhone]'
				SET @SQL = @SQL + ' FROM [dbo].[Users]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [UserName],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [UserRole],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [DisplayName],'
				SET @SQL = @SQL + ' [Signature],'
				SET @SQL = @SQL + ' [Location],'
				SET @SQL = @SQL + ' [IsDisabled],'
				SET @SQL = @SQL + ' [Avatar],'
				SET @SQL = @SQL + ' [MobilePhone]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
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

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[PrescriptionDetailId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [PrescriptionDetailId]'
				SET @SQL = @SQL + ', [PrescriptionID]'
				SET @SQL = @SQL + ', [Sq]'
				SET @SQL = @SQL + ', [DrugId]'
				SET @SQL = @SQL + ', [DrugName]'
				SET @SQL = @SQL + ', [Unit]'
				SET @SQL = @SQL + ', [UnitVN]'
				SET @SQL = @SQL + ', [Remark]'
				SET @SQL = @SQL + ', [RouteType]'
				SET @SQL = @SQL + ', [RouteTypeVN]'
				SET @SQL = @SQL + ', [Dosage]'
				SET @SQL = @SQL + ', [DosageUnit]'
				SET @SQL = @SQL + ', [DosageUnitVN]'
				SET @SQL = @SQL + ', [Frequency]'
				SET @SQL = @SQL + ', [FrequencyVN]'
				SET @SQL = @SQL + ', [Duration]'
				SET @SQL = @SQL + ', [DurationUnit]'
				SET @SQL = @SQL + ', [DurationUnitVN]'
				SET @SQL = @SQL + ', [TotalUnit]'
				SET @SQL = @SQL + ' FROM [dbo].[ePrescriptionDetail]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [PrescriptionDetailId],'
				SET @SQL = @SQL + ' [PrescriptionID],'
				SET @SQL = @SQL + ' [Sq],'
				SET @SQL = @SQL + ' [DrugId],'
				SET @SQL = @SQL + ' [DrugName],'
				SET @SQL = @SQL + ' [Unit],'
				SET @SQL = @SQL + ' [UnitVN],'
				SET @SQL = @SQL + ' [Remark],'
				SET @SQL = @SQL + ' [RouteType],'
				SET @SQL = @SQL + ' [RouteTypeVN],'
				SET @SQL = @SQL + ' [Dosage],'
				SET @SQL = @SQL + ' [DosageUnit],'
				SET @SQL = @SQL + ' [DosageUnitVN],'
				SET @SQL = @SQL + ' [Frequency],'
				SET @SQL = @SQL + ' [FrequencyVN],'
				SET @SQL = @SQL + ' [Duration],'
				SET @SQL = @SQL + ' [DurationUnit],'
				SET @SQL = @SQL + ' [DurationUnitVN],'
				SET @SQL = @SQL + ' [TotalUnit]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
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
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[PrescriptionDetailId]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [PrescriptionDetailId]'
                    SET @SQL = @SQL + ', [PrescriptionID]'
                    SET @SQL = @SQL + ', [Sq]'
                    SET @SQL = @SQL + ', [DrugId]'
                    SET @SQL = @SQL + ', [DrugName]'
                    SET @SQL = @SQL + ', [Unit]'
                    SET @SQL = @SQL + ', [UnitVN]'
                    SET @SQL = @SQL + ', [Remark]'
                    SET @SQL = @SQL + ', [Dosage]'
                    SET @SQL = @SQL + ', [Frequency]'
                    SET @SQL = @SQL + ', [VN_meaning]'
                    SET @SQL = @SQL + ', [Duration]'
                    SET @SQL = @SQL + ', [TotalUnit]'
                    SET @SQL = @SQL + ', [meaning]'
                    SET @SQL = @SQL + ', [abbre]'
                    SET @SQL = @SQL + ' FROM [dbo].[VR_ePresDetail]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [PrescriptionDetailId],'
                    SET @SQL = @SQL + ' [PrescriptionID],'
                    SET @SQL = @SQL + ' [Sq],'
                    SET @SQL = @SQL + ' [DrugId],'
                    SET @SQL = @SQL + ' [DrugName],'
                    SET @SQL = @SQL + ' [Unit],'
                    SET @SQL = @SQL + ' [UnitVN],'
                    SET @SQL = @SQL + ' [Remark],'
                    SET @SQL = @SQL + ' [Dosage],'
                    SET @SQL = @SQL + ' [Frequency],'
                    SET @SQL = @SQL + ' [VN_meaning],'
                    SET @SQL = @SQL + ' [Duration],'
                    SET @SQL = @SQL + ' [TotalUnit],'
                    SET @SQL = @SQL + ' [meaning],'
                    SET @SQL = @SQL + ' [abbre]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[VR_ePresDetail]'
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

	

-- Drop the dbo.VR_UnitTable_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.VR_UnitTable_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.VR_UnitTable_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets all records from the VR_UnitTable view
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.VR_UnitTable_Get_List

AS


                    
                    SELECT
                        [Unit],
                        [UnitVN],
                        [DosageUnit],
                        [DosageUnitVN]
                    FROM
                        [dbo].[VR_UnitTable]
                        
                    SELECT @@ROWCOUNT			
                

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.VR_UnitTable_Get procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.VR_UnitTable_Get') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.VR_UnitTable_Get
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: RafflesMedical ()
-- Purpose: Gets records from the VR_UnitTable view passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.VR_UnitTable_Get
(

	@WhereClause varchar (2000)  ,

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
    
                    IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
                    BEGIN
                        -- default order by to first column
                        SET @OrderBy = '[Unit]'
                    END
    
                    -- SQL Server 2005 Paging
                    DECLARE @SQL AS nvarchar(MAX)
                    SET @SQL = 'WITH PageIndex AS ('
                    SET @SQL = @SQL + ' SELECT'
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
                    SET @SQL = @SQL + ', [Unit]'
                    SET @SQL = @SQL + ', [UnitVN]'
                    SET @SQL = @SQL + ', [DosageUnit]'
                    SET @SQL = @SQL + ', [DosageUnitVN]'
                    SET @SQL = @SQL + ' FROM [dbo].[VR_UnitTable]'
                    IF LEN(@WhereClause) > 0
                    BEGIN
                        SET @SQL = @SQL + ' WHERE ' + @WhereClause
                    END
                    SET @SQL = @SQL + ' ) SELECT'
                    SET @SQL = @SQL + ' [Unit],'
                    SET @SQL = @SQL + ' [UnitVN],'
                    SET @SQL = @SQL + ' [DosageUnit],'
                    SET @SQL = @SQL + ' [DosageUnitVN]'
                    SET @SQL = @SQL + ' FROM PageIndex'
                    SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
                    IF @PageSize > 0
                    BEGIN
                        SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
                    END
                    IF LEN(@OrderBy) > 0
                    BEGIN
                        SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
                    END
                    EXEC sp_executesql @SQL
    
                    -- get row count
                    SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
                    SET @SQL = @SQL + ' FROM [dbo].[VR_UnitTable]'
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

