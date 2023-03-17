select a.GroupId from oemUser c join oemUserAssociated a on c.Id = a.UserId join oemUserGroup b on a.GroupId = b.Id where a.UserId = '550506911461446'



select a.Id as GroupId,c.* from oemUserGroup a inner join oemUserAssociated b on a.Id = b.GroupId inner join oemUser c on b.UserId = c.Id where a.id in(550506911461446)



select top 10 * from
	(select ROW_NUMBER() over(order by Xmgeuc003 asc) as rownumber,* from [dbo].[oemSummaryReport] where Xmgeuc002 in

		(select c.ERPCode from oemUserGroup a inner join oemUserAssociated b on a.Id = b.GroupId inner join oemUser c on b.UserId = c.Id 

		where a.id in( select a.Id from oemUserGroup a join oemUser b on a.UserId = b.Id where b.Id = '1' ) or c.Id = '1' group by c.ERPCode)

	and Xmgeuc004 = 'cPN' and Xmgeuc011 = 'vPN') as a
where rownumber > 0 --(page-1) * size                     --groupId \ erpCode  ¿É±ä


select top 10 * from 
	(
		select ROW_NUMBER() over(order by Xmgeuc003 asc) as rownumber,* from [dbo].[oemSummaryReport] 
			where Xmgeuc002 in
				(
					select c.ERPCode from oemUserGroup a inner join oemUserAssociated b on a.Id = b.GroupId inner join oemUser c on b.UserId = c.Id 
					where 1 = 1 And a.id in
						(
							select a.Id from oemUserGroup a join oemUser b on a.UserId = b.Id where b.Id = 1 
						) or c.Id = 1 group by c.ERPCode
				)
	) as a where rownumber > 0 