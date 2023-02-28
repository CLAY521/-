USE [kf_imow]
GO

/****** Object:  Table [dbo].[ecAuction]    Script Date: 2023/2/1 16:46:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ecAuction](
	[Id] [bigint] NOT NULL,
	[UserId] [bigint] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CurrentPrice] [decimal](18, 2) NOT NULL,
	[Range] [int] NOT NULL,
	[VNumber] [int] NULL,
	[Position] [nvarchar](30) NOT NULL,
	[ExtendTime] [int] NOT NULL,
	[ExtendTimes] [datetime] NULL,
	[Img] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[IsDel] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ecAuction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id（拍卖成功的用户）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'UserId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拍卖名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'StartTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'EndTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拍卖产品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Product'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'起拍价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Price'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'CurrentPrice'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加价幅度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Range'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'VNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Position'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'竞拍延期时长（固定多少秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'ExtendTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'具体延期时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'ExtendTimes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拍卖图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Img'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（0：禁用  1：启用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除（0：未删除  1：已删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'IsDel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecAuction', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO


