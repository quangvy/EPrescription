USE [EPrescription]
GO
/****** Object:  Table [dbo].[ePrescription]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ePrescription](
	[PrescriptionID] [nvarchar](20) NOT NULL,
	[TransactionID] [nvarchar](15) NULL,
	[PatientCode] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Address] [nvarchar](150) NULL,
	[DateOfBirth] [datetime] NULL,
	[Age] [nvarchar](20) NULL,
	[Weight] [nvarchar](20) NULL,
	[Diagnosis] [nvarchar](500) NULL,
	[PrescribingDoctor] [nvarchar](100) NULL,
	[Sex] [nvarchar](10) NULL,
	[Remark] [nvarchar](250) NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK_ePrescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[UserRole] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Signature] [varbinary](max) NULL,
	[Location] [nvarchar](10) NULL,
	[IsDisabled] [bit] NOT NULL,
	[Avatar] [varbinary](max) NULL,
	[MobilePhone] [nvarchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pres_Abbre]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pres_Abbre](
	[abbre] [nvarchar](50) NULL,
	[meaning] [nvarchar](250) NULL,
	[VN_meaning] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoritMaster]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoritMaster](
	[ID] [int] NOT NULL,
	[DiceaseName] [nvarchar](50) NOT NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Diagnosis] [nvarchar](500) NULL,
	[IsPrivate] [bit] NULL,
 CONSTRAINT [PK_FavoritMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoritDetail]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoritDetail](
	[ID] [int] NOT NULL,
	[DrugID] [nvarchar](20) NULL,
	[DrugName] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ePrescriptionDetail]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ePrescriptionDetail](
	[PrescriptionDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[PrescriptionID] [nvarchar](20) NOT NULL,
	[Sq] [int] NOT NULL,
	[DrugId] [nvarchar](20) NULL,
	[DrugName] [nvarchar](250) NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Remark] [nvarchar](250) NULL,
	[Dosage] [nvarchar](20) NULL,
	[Frequency] [nvarchar](150) NULL,
	[Duration] [nvarchar](50) NULL,
	[TotalUnit] [nvarchar](50) NULL,
 CONSTRAINT [PK_ePrescriptionDetail] PRIMARY KEY CLUSTERED 
(
	[PrescriptionDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VR_ePresDetail]    Script Date: 05/30/2017 10:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VR_ePresDetail]
AS
SELECT     A.PrescriptionDetailId, A.PrescriptionID, A.Sq, A.DrugId, A.DrugName, A.Unit, B.UnitVN, A.Remark, A.Dosage, A.Frequency, C.VN_meaning, A.Duration, A.TotalUnit
FROM         dbo.ePrescriptionDetail AS A LEFT OUTER JOIN
                      UFPharma.dbo.UnitTable AS B ON A.Unit = B.Unit LEFT OUTER JOIN
                      dbo.Pres_Abbre AS C ON A.Frequency = C.abbre + ' - ' + C.meaning
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
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 167
               Left = 331
               Bottom = 256
               Right = 491
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 456
               Bottom = 110
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 0
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VR_ePresDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VR_ePresDetail'
GO
/****** Object:  Default [DF_ePrescription_CreateDate]    Script Date: 05/30/2017 10:40:08 ******/
ALTER TABLE [dbo].[ePrescription] ADD  CONSTRAINT [DF_ePrescription_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Users_IsDisabled]    Script Date: 05/30/2017 10:40:08 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDisabled]  DEFAULT ((0)) FOR [IsDisabled]
GO
/****** Object:  ForeignKey [FK_ePrescriptionDetail_ePrescription]    Script Date: 05/30/2017 10:40:08 ******/
ALTER TABLE [dbo].[ePrescriptionDetail]  WITH CHECK ADD  CONSTRAINT [FK_ePrescriptionDetail_ePrescription] FOREIGN KEY([PrescriptionID])
REFERENCES [dbo].[ePrescription] ([PrescriptionID])
GO
ALTER TABLE [dbo].[ePrescriptionDetail] CHECK CONSTRAINT [FK_ePrescriptionDetail_ePrescription]
GO
/****** Object:  ForeignKey [FK_FavoritDetail_ID]    Script Date: 05/30/2017 10:40:08 ******/
ALTER TABLE [dbo].[FavoritDetail]  WITH CHECK ADD  CONSTRAINT [FK_FavoritDetail_ID] FOREIGN KEY([ID])
REFERENCES [dbo].[FavoritMaster] ([ID])
GO
ALTER TABLE [dbo].[FavoritDetail] CHECK CONSTRAINT [FK_FavoritDetail_ID]
GO
