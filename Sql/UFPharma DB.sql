USE [UFPharma]
GO
/****** Object:  Table [dbo].[UnitTable]    Script Date: 05/30/2017 10:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitTable](
	[Unit] [nvarchar](50) NOT NULL,
	[UnitVN] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnitTable] PRIMARY KEY CLUSTERED 
(
	[Unit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugDispo]    Script Date: 05/30/2017 10:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugDispo](
	[DrugId] [nvarchar](20) NOT NULL,
	[DrugName] [nvarchar](250) NOT NULL,
	[GenericName] [nvarchar](250) NULL,
	[Specification] [nvarchar](250) NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[MarkUpType] [int] NULL,
	[CostPrice] [decimal](12, 0) NOT NULL,
	[SellPrice] [decimal](12, 0) NOT NULL,
	[ValidPeriod] [datetime] NULL,
	[MinStock] [int] NULL,
	[MaxStock] [int] NULL,
	[Shelf] [nvarchar](50) NULL,
	[GroupId] [int] NULL,
	[ClassificationId] [int] NULL,
	[UseGuide] [nvarchar](500) NULL,
	[Precaution] [nvarchar](500) NULL,
	[Package] [nvarchar](50) NULL,
	[Remark] [nvarchar](250) NULL,
	[IsControlDrug] [bit] NOT NULL,
 CONSTRAINT [PK_DrugDispo] PRIMARY KEY CLUSTERED 
(
	[DrugId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Vr_DrugForPrescription]    Script Date: 05/30/2017 10:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vr_DrugForPrescription]
AS
WITH data AS (SELECT     SUM(Quantity) AS quantity, DrugId
                                FROM         dbo.Stock
                                GROUP BY DrugId)
    SELECT     dbo.DrugDispo.DrugId, dbo.DrugDispo.DrugName, dbo.DrugDispo.GenericName, dbo.DrugDispo.Unit, dbo.DrugDispo.IsControlDrug, data_1.quantity
     FROM         dbo.DrugDispo INNER JOIN
                            data AS data_1 ON dbo.DrugDispo.DrugId = data_1.DrugId
     WHERE     (dbo.DrugDispo.DrugId NOT LIKE '@%') AND (dbo.DrugDispo.IsControlDrug = 0)
     GROUP BY dbo.DrugDispo.DrugId, dbo.DrugDispo.DrugName, dbo.DrugDispo.GenericName, dbo.DrugDispo.Unit, dbo.DrugDispo.IsControlDrug, data_1.quantity
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
         Begin Table = "DrugDispo"
            Begin Extent = 
               Top = 36
               Left = 60
               Bottom = 155
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 15
         End
         Begin Table = "data_1"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 95
               Right = 435
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
      Begin ColumnWidths = 12
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vr_DrugForPrescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vr_DrugForPrescription'
GO
/****** Object:  Default [DF_DrugDispo_MinStock]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo] ADD  CONSTRAINT [DF_DrugDispo_MinStock]  DEFAULT ((0)) FOR [MinStock]
GO
/****** Object:  Default [DF_DrugDispo_MaxStock]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo] ADD  CONSTRAINT [DF_DrugDispo_MaxStock]  DEFAULT ((0)) FOR [MaxStock]
GO
/****** Object:  Default [DF_DrugDispo_IsControlDrug]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo] ADD  CONSTRAINT [DF_DrugDispo_IsControlDrug]  DEFAULT ((0)) FOR [IsControlDrug]
GO
/****** Object:  ForeignKey [FK_DrugDispo_Classification]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo]  WITH CHECK ADD  CONSTRAINT [FK_DrugDispo_Classification] FOREIGN KEY([ClassificationId])
REFERENCES [dbo].[Classification] ([ClassificationId])
GO
ALTER TABLE [dbo].[DrugDispo] CHECK CONSTRAINT [FK_DrugDispo_Classification]
GO
/****** Object:  ForeignKey [FK_DrugDispo_Group]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo]  WITH CHECK ADD  CONSTRAINT [FK_DrugDispo_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[DrugDispo] CHECK CONSTRAINT [FK_DrugDispo_Group]
GO
/****** Object:  ForeignKey [FK_DrugDispo_MarkUpType]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo]  WITH CHECK ADD  CONSTRAINT [FK_DrugDispo_MarkUpType] FOREIGN KEY([MarkUpType])
REFERENCES [dbo].[MarkUpType] ([MarkUpType])
GO
ALTER TABLE [dbo].[DrugDispo] CHECK CONSTRAINT [FK_DrugDispo_MarkUpType]
GO
/****** Object:  ForeignKey [FK_DrugDispo_Shelf]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo]  WITH CHECK ADD  CONSTRAINT [FK_DrugDispo_Shelf] FOREIGN KEY([Shelf])
REFERENCES [dbo].[Shelf] ([Shelf])
GO
ALTER TABLE [dbo].[DrugDispo] CHECK CONSTRAINT [FK_DrugDispo_Shelf]
GO
/****** Object:  ForeignKey [FK_DrugDispo_UnitTable]    Script Date: 05/30/2017 10:39:01 ******/
ALTER TABLE [dbo].[DrugDispo]  WITH CHECK ADD  CONSTRAINT [FK_DrugDispo_UnitTable] FOREIGN KEY([Unit])
REFERENCES [dbo].[UnitTable] ([Unit])
GO
ALTER TABLE [dbo].[DrugDispo] CHECK CONSTRAINT [FK_DrugDispo_UnitTable]
GO
