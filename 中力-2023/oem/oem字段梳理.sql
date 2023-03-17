CREATE TABLE [dbo].[ecSummaryReport](    -- ����״̬��ѯ���ܣ��ͻ���ѯ��վ��
	[Id] [bigint] NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[VenderPN] [nvarchar](30) not null,
	[ClientPN] [nvarchar](30) not null,
	[OpenPO] [int] not null,
	[MonthlyUsage] [int] not null,
	[ToDoor] [nvarchar](30) not null,
	[Inman] [nvarchar](30) not null,
	[Water] [int] not null,
	[China] [nvarchar](30) not null,
	[GroupId] [bigint] not null,
	[UserId] [bigint] not null,
	[CreateTime] [datetime] not NULL)

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ʒ�ͺ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'VenderPN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'ClientPN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ܲ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'OpenPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÿ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'MonthlyUsage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��;���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'Water'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ͻ�id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecDetailReport', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

create table [dbo].[ecPaid](
	[Id] [bigint] not null,
	[ContractNo] [nvarchar](30) not null,
	[PartNo] [nvarchar](30) not null,
	[ContractNum] [int] not null,
	[PaidNum] [int] not null,
	[UnPaidNum] [int] not null,
	[InNum] [int] not null,
	[DeliveryDate] [datetime] not null,
	[ActualDeliveryDate] [datetime] not null,
	[TimeDifference] [int] not null,
	[FactoryName] [nvarchar](30) not null,
	[FactoryCode] [nvarchar](30) not null,
	[TestNum] [int] not null,
	[CreateTime] [datetime] not null)

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͬ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'ContractNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'PartNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͬ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'ContractNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'δ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'UnPaidNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ѽ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'PaidNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'InNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'DeliveryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʵ�ʽ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'ActualDeliveryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʱ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'TimeDifference'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ȫ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'FactoryName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'FactoryCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'TestNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaid', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO


create table [dbo].[ecPaidDetail](
	[Id] [bigint] not null,
	[PaidId] [bigint] not null,
	[HappenDate] [datetime] not null,
	[QualifiedNum] [int] not null,
	[UnQualifiedNum] [int] not null,
	[UnQualifiedRemark] [nvarchar](500),
	[CreateTime] [datetime] not null)

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'PaidId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'HappenDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϸ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'QualifiedNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ϸ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'UnQualifiedNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ϸ�ԭ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'UnQualifiedNumRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecPaidDetail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
