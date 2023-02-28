USE [kf_imow]
GO

/****** Object:  Table [dbo].[ecCreditLimit]    Script Date: 2023/2/16 8:49:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ecCreditLimit](
	[Id] [bigint] NOT NULL,
	[CreditQuota] [decimal](18, 2) NOT NULL,
	[CreditBalance] [decimal](18, 2) NOT NULL,
	[AllowableLimit] [decimal](18, 2) NOT NULL,
	[AllowableLiDate] [datetime] NULL,
	[ExcessRate] [decimal](18, 2) NOT NULL,
	[ExcessDate] [datetime] NULL,
	[UnwrittenLimit] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[ErpCode] [nvarchar](50) NOT NULL,
	[TotalLimit] [decimal](18, 2) NOT NULL,
	[AvailableLimit] [decimal](18, 2) NOT NULL,
	[OccupyLimit] [decimal](18, 2) NOT NULL,
	[UnoccupiedLimit] [decimal](18, 2) NOT NULL,
	[Earnest] [decimal](18, 2) NOT NULL,
	[SurplusEarnest] [decimal](18, 2) NOT NULL,
	[ReturnEarnest] [decimal](18, 2) NOT NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_CreditLimit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'CreditQuota'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ö�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'CreditBalance'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'AllowableLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����������Ч����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'AllowableLiDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'ExcessRate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������Ч��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'ExcessDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δ������ȱ��ֽ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'UnwrittenLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'Rate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'erp�ͻ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'ErpCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҵ��ܶ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'TotalLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'AvailableLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ռ�ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'OccupyLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δռ�ö��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'UnoccupiedLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'Earnest'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʣ�ౣ֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'SurplusEarnest'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ѷ�����֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'ReturnEarnest'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͬ��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecCreditLimit', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO


ALTER TABLE Orders ADD SurplusEarnest decimal(18, 2) NULL  ;
ALTER TABLE Orders ADD ReturnEarnest decimal(18, 2) NULL ; 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʣ�ౣ֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'SurplusEarnest'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ѷ�����֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'ReturnEarnest'
GO