select * from ecOrderExpress where OrderCode = 'ZJ1690010146P'

select * from ecOrderV2 where OrderCode in ('ZJ1690010146P-002','ZJ1690010146P-001')


select * from ecAdminModule where Name = 'V2����ģ��'

select * from ecAdminModule where Name = '����ģ��'



ALTER TABLE [dbo].[ecOrderExpress] ADD SendType nvarchar(50) NULL ;
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʽ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ecOrderExpress', @level2type=N'COLUMN',@level2name=N'SendType'
GO


select * from ecOrderExpress where BatchNo = 'IM1684999214'

select Status from ecOrderV2 where OrderCode = 'IM1684999214'

select top 10 * from ecOrderLog order by CreateTime desc 