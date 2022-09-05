using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    [Serializable]
    public class FacBatchOrderEntity
    {
        /// <summary>
        ///Id
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        ///主工单号
        /// </summary>
        public Int64 FacOrderId { get; set; }

        /// <summary>
        ///分单数量
        /// </summary>
        public decimal Num { get; set; }

        /// <summary>
        ///计划出货时间
        /// </summary>
        public DateTime? POutTime { get; set; }

        /// <summary>
        ///计划上线时间
        /// </summary>
        public DateTime? POnlineTime { get; set; }

        /// <summary>
        ///计划入库时间
        /// </summary>
        public DateTime? PInTime { get; set; }

        /// <summary>
        ///上线数量
        /// </summary>
        public decimal OnlineNum { get; set; }

        /// <summary>
        ///入库数量
        /// </summary>
        public decimal InNum { get; set; }

        /// <summary>
        ///出货数量
        /// </summary>
        public decimal OutNum { get; set; }

        /// <summary>
        ///FacInfoId
        /// </summary>
        public Int64 FacInfoId { get; set; }

        /// <summary>
        ///料件编号
        /// </summary>
        public string Xmdd001 { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///工厂据点
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        ///Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// erp工单号
        /// </summary>
        public string ErpWorkCode { get; set; }

        public DateTime? CancelTime { get; set; }
        public DateTime? FinishTime { get; set; }
    }
}
