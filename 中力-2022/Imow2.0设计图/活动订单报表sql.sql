/*** 活动订单详情报表 ***/
select
a.OrderCode as '订单编号',
case a.Status when '-10' then '已取消' when '10' then '待提货' when '20' then '部分提货' when '30' then '提货完成' end as '订单状态',
case a.SpecialEnd when '0' then '没有结案' when '1' then '已结案' end as '结案状态',
case a.OrderType when '1' then '整机' when '2' then  '配件' when '3' then '阿母好物' end as '订单类型',
h.RegisterProvince as '省份',b.UserName as '会员名',c.Company as '公司名称',
case d.ShipType when '1' then '自提' when '2' then '配送' end as '配送类型',
d.UserName as '收件人',d.UserMobile as '收件人电话',d.UserFullAddr as '配送地址',
a.OrderAmount as '订单总金额',a.ShipAmount as '运费金额',a.CreateTime as '创建时间',
f.ProductName '商品名称',e.Title as '活动标题',f.SkuCode as 'SKU号',f.SkuName as '规格',f.SalePrice as '销售单价',f.Num as '数量',f.SendNum as '提货数量',f.TradingPrice as '商品总金额',
g.Name as '店铺名称',
a.SuccessTime as '确认时间',a.AdminRemark as '卖家备注'from 
ecActiveOrderV2 a inner join ecUser b on a.UserId = b.Id inner join ecUserFK j on a.UserId = j.UserId inner join ecUserInfo c on j.InfoId = c.ID
inner join ecPromotion e on a.PromotionId = e.Id inner join ecOrderDetailV2 f on a.Id = f.OrderId left join ecOrderShip d on a.OrderShipId = d.Id
left join ecShop g on a.ShopId = g.ID left join ecUserInvoice h on h.UserID = b.Pid where a.Status  = '10'