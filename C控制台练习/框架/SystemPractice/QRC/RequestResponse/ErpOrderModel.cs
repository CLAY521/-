using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ErpOrderModel
    {
        /// <summary>
        /// 订单单号
        /// </summary>
        [JsonProperty("col1")]
        public string Xmdadocno { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        [JsonProperty("col2")]
        public DateTime Xmdadocdt { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        [JsonProperty("col5")]
        public string Xmda002 { get; set; }

        /// <summary>
        /// 业务员全名
        /// </summary>
        [JsonProperty("col6")]
        public string Ooag011 { get; set; }

        /// <summary>
        /// 业务部门
        /// </summary>
        [JsonProperty("col7")]
        public string Xmda003 { get; set; }

        /// <summary>
        /// 业务部门说明
        /// </summary>
        [JsonProperty("col8")]
        public string Ooefl003 { get; set; }


        /// <summary>
        /// 客户编号
        /// </summary>
        [JsonProperty("col12")]
        public string Xmda004 { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [JsonProperty("col13")]
        public string Xmda004_desc { get; set; }

        /// <summary>
        /// 来源单号
        /// </summary>
        [JsonProperty("col14")]
        public string Xmda008 { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [JsonProperty("col19")]
        public DateTime Xmdacnfdt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("col23")]
        public string Xmda071 { get; set; }

    }
}
