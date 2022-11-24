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
    public class OrderDetailV2Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// SkuID
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        /// SkuCode
        /// </summary>
        public string SkuCode { get; set; }
        /// <summary>
        /// SkuName
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 成交总价
        /// </summary>
        public decimal TradingPrice { get; set; }
        /// <summary>
        /// 提货数量
        /// </summary>
        public int SendNum { get; set; }
        /// <summary>
        /// 阿母积分优惠
        /// </summary>
        public decimal ImbAmount { get; set; }
        /// <summary>
        /// 优惠券优惠
        /// </summary>
        public decimal CouponAmount { get; set; }
        /// <summary>
        /// 系统优惠
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// 阿母积分比例
        /// </summary>
        public decimal ImbRate { get; set; }
        /// <summary>
        /// 替换产品配置id
        /// </summary>
        public long ChangeId { get; set; }
        /// <summary>
        /// true/false=旧/新产品
        /// </summary>
        public bool IsDel { get; set; }
        /// <summary>
        /// 对应旧的明细id
        /// </summary>
        public long OldDetailId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 父级分配的优惠（阿姆币）
        /// </summary>
        public decimal PImbAmount { get; set; }
        /// <summary>
        /// 父级分配的优惠（优惠券）
        /// </summary>
        public decimal PCouponAmount { get; set; }
        /// <summary>
        /// 父级分配的优惠（优惠）
        /// </summary>
        public decimal PDiscountAmount { get; set; }
        /// <summary>
        /// 父级对应的明细
        /// </summary>
        public long PDetailId { get; set; }
        /// <summary>
        /// 父级对应的活动订单
        /// </summary>
        public long POrderId { get; set; }
        /// <summary>
        /// 购买单价
        /// </summary>
        public decimal BuyPriceUnit { get; set; }
        /// <summary>
        /// 预计交期
        /// </summary>
        public DateTime? Expire { get; set; }
    }




    /// <summary>
    /// Order：实体对象映射关系
    /// </summary>
    [Serializable]
    public class OrderDetailV2EntityOrmMapper : ClassMapper<OrderDetailV2Entity>
    {
        public OrderDetailV2EntityOrmMapper()
        {
            base.Table("ecOrderDetailV2");
            //Map(f => f.StatusStr).Ignore();//设置忽略

            //Map(f => f.Id).Key(KeyType.Assigned);//设置主键  (如果主键名称不包含字母“ID”，请设置)      
            //Map(f => f.InvoiceId).ForignKey<UserInvoiceEntity>(f => f.Id);
            //
            AutoMap();
        }
    }
}

