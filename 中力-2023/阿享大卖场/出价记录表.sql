USE [kf_imow]
GO

/****** Object:  Table [dbo].[ecAuctionRecord]    Script Date: 2023/2/1 16:46:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ecAuctionRecord](
	[Id] [bigint] NOT NULL,
	[AuctionId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserCompany] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BNumber] [int] NOT NULL,
	[CreateTime] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ecAuctionRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拍卖id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'AuctionId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'UserId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'UserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'UserCompany'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拍卖出价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'Price'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出价次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'BNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuctionRecord', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO


