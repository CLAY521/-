using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions.Mapper;
using imow.Model.EntityModel.Shop;
using imow.Model.EntityModel.User;
using imow.Model.Enum;

namespace imow.Model.EntityModel.Order
{
    /// <summary>
    /// imow.Model.EntityModel：实体对象
    /// </summary>
    [Serializable]
    public class ActiveOrderV2Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 下单账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 活动ID
        /// </summary>
        public long PromotionId { get; set; }
        /// <summary>
        /// 应付 OrderAmount-优惠
        /// </summary>
        public decimal PayableAmount { get; set; }
        /// <summary>
        /// 订单总金额（成交总价+运费）
        /// </summary>
        public decimal OrderAmount { get; set; }
        /// <summary>
        /// 商品总金额
        /// </summary>
        public decimal ProductAmount { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal ShipAmount { get; set; }
        /// <summary>
        /// 发票ID
        /// </summary>
        public long InvoiceId { get; set; }
        /// <summary>
        /// 商品备注ID
        /// </summary>
        public long OrderShipId { get; set; }
        /// <summary>
        /// 发票备注ID
        /// </summary>
        public long ReceiptShipId { get; set; }
        /// <summary>
        /// 买家备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 后台备注
        /// </summary>
        public string AdminRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public int CreateDate { get; set; }
        /// <summary>
        /// 交易成功时间
        /// </summary>
        public DateTime SuccessTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 协商运费
        /// </summary>
        public bool ConsultShipFree { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public long ShopId { get; set; }
    }




    /// <summary>
    /// Order：实体对象映射关系
    /// </summary>
    [Serializable]
    public class ActiveOrderV2EntityOrmMapper : ClassMapper<ActiveOrderV2Entity>
    {
        public ActiveOrderV2EntityOrmMapper()
        {
            base.Table("ecActiveOrderV2");
            //Map(f => f.StatusStr).Ignore();//设置忽略

            //Map(f => f.Id).Key(KeyType.Assigned);//设置主键  (如果主键名称不包含字母“ID”，请设置)      
            //Map(f => f.InvoiceId).ForignKey<UserInvoiceEntity>(f => f.Id);
            //
            AutoMap();
        }
    }
}

