/*** ��������鱨�� ***/
select
a.OrderCode as '�������',
case a.Status when '-10' then '��ȡ��' when '10' then '�����' when '20' then '�������' when '30' then '������' end as '����״̬',
case a.SpecialEnd when '0' then 'û�н᰸' when '1' then '�ѽ᰸' end as '�᰸״̬',
case a.OrderType when '1' then '����' when '2' then  '���' when '3' then '��ĸ����' end as '��������',
h.RegisterProvince as 'ʡ��',b.UserName as '��Ա��',c.Company as '��˾����',
case d.ShipType when '1' then '����' when '2' then '����' end as '��������',
d.UserName as '�ռ���',d.UserMobile as '�ռ��˵绰',d.UserFullAddr as '���͵�ַ',
a.OrderAmount as '�����ܽ��',a.ShipAmount as '�˷ѽ��',a.CreateTime as '����ʱ��',
f.ProductName '��Ʒ����',e.Title as '�����',f.SkuCode as 'SKU��',f.SkuName as '���',f.SalePrice as '���۵���',f.Num as '����',f.SendNum as '�������',f.TradingPrice as '��Ʒ�ܽ��',
g.Name as '��������',
a.SuccessTime as 'ȷ��ʱ��',a.AdminRemark as '���ұ�ע'from 
ecActiveOrderV2 a inner join ecUser b on a.UserId = b.Id inner join ecUserFK j on a.UserId = j.UserId inner join ecUserInfo c on j.InfoId = c.ID
inner join ecPromotion e on a.PromotionId = e.Id inner join ecOrderDetailV2 f on a.Id = f.OrderId left join ecOrderShip d on a.OrderShipId = d.Id
left join ecShop g on a.ShopId = g.ID left join ecUserInvoice h on h.UserID = b.Pid where a.Status  = '10'