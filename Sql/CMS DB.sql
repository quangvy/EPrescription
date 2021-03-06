USE [CMS]
GO
/****** Object:  Table [dbo].[PatientActivation]    Script Date: 05/30/2017 10:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientActivation](
	[TransactionId] [nvarchar](15) NOT NULL,
	[PatientCode] [nvarchar](11) NULL,
	[LastName] [nvarchar](30) NULL,
	[FirstName] [nvarchar](30) NULL,
	[DateOfBirth] [datetime] NULL,
	[Phone] [nvarchar](20) NULL,
	[Sex] [char](1) NULL,
	[MemberType] [nvarchar](50) NULL,
	[MembershipSOSNumber] [nvarchar](25) NULL,
	[MembershipSOSExpDate] [datetime] NULL,
	[InsuranceCardNumber] [nvarchar](25) NULL,
	[InsuranceCardExpDate] [datetime] NULL,
	[CompanyCode] [nchar](9) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Nationality] [nvarchar](50) NULL,
	[ApptRemark] [nvarchar](250) NULL,
	[ApptStatus] [nvarchar](500) NULL,
	[ApptNote] [nvarchar](50) NULL,
	[Remark] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NULL,
	[IsComplete] [bit] NOT NULL,
	[CreateUser] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[MiddleName] [nvarchar](30) NULL,
	[Address] [nvarchar](250) NULL,
	[TaxCode] [nvarchar](20) NULL,
 CONSTRAINT [PK_PatientActivation] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DIAG_LIST]    Script Date: 05/30/2017 10:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIAG_LIST](
	[CATEGORY] [nvarchar](8) NOT NULL,
	[DIAG_CODE] [nvarchar](15) NOT NULL,
	[DIAG_NAME] [nvarchar](500) NOT NULL,
	[IsDisabled] [bit] NOT NULL,
 CONSTRAINT [PK_DIAG_LIST] PRIMARY KEY CLUSTERED 
(
	[DIAG_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VR_PatActivation]    Script Date: 05/30/2017 10:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VR_PatActivation]
AS
SELECT     TransactionId, PatientCode, LastName, FirstName, DateOfBirth, Sex, CASE WHEN (FLOOR((CAST(CONVERT(VARCHAR(8), GETDATE(), 112) AS INT) 
                      - CAST(CONVERT(VARCHAR(8), DateOfBirth, 112) AS INT)) / 10000)) > 6 THEN CONVERT(NVARCHAR(15), (FLOOR((CAST(CONVERT(VARCHAR(8), GETDATE(), 112) AS INT) 
                      - CAST(CONVERT(VARCHAR(8), DateOfBirth, 112) AS INT)) / 10000))) + ' Years old' WHEN (FLOOR((CAST(CONVERT(VARCHAR(8), GETDATE(), 112) AS INT) 
                      - CAST(CONVERT(VARCHAR(8), DateOfBirth, 112) AS INT)) / 10000)) BETWEEN 1 AND 6 THEN CONVERT(NVARCHAR(20), CAST((DATEDIFF(m, DateOfBirth, GETDATE()) 
                      / 12) AS VARCHAR)) + ' Years:' + CONVERT(NVARCHAR(10), CAST((DATEDIFF(m, DateOfBirth, GETDATE()) % 12) AS VARCHAR)) 
                      + ' Months' ELSE CONVERT(NVARCHAR(20), CAST((DATEDIFF(m, DateOfBirth, GETDATE()) % 12) AS VARCHAR)) + ' Months:' + CAST((DATEDIFF(m, DateOfBirth, 
                      GETDATE()) % 31) AS varchar) + ' Days' END AS Age, Address,MemberType,CreateDate
FROM         dbo.PatientActivation
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PatientActivation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 22
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VR_PatActivation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VR_PatActivation'
GO
/****** Object:  Default [DF_DIAG_LIST_IsDisabled]    Script Date: 05/30/2017 10:36:38 ******/
ALTER TABLE [dbo].[DIAG_LIST] ADD  CONSTRAINT [DF_DIAG_LIST_IsDisabled]  DEFAULT ((0)) FOR [IsDisabled]
GO
/****** Object:  Default [DF_PatientActivation_IsComplete]    Script Date: 05/30/2017 10:36:38 ******/
ALTER TABLE [dbo].[PatientActivation] ADD  CONSTRAINT [DF_PatientActivation_IsComplete]  DEFAULT ((0)) FOR [IsComplete]
GO
/****** Object:  Default [DF_PatientActivation_CreateDate]    Script Date: 05/30/2017 10:36:38 ******/
ALTER TABLE [dbo].[PatientActivation] ADD  CONSTRAINT [DF_PatientActivation_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
