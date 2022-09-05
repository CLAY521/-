using GizmoSDK.Coordinate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPToAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = DateTime.Now.AddYears(-100).ToString();
            Console.WriteLine(date);
            Console.ReadKey();
        }

    }
    public class BaiDuMap
    {
     /// 
        /// 依据IP获取定位信息的URL模板。
        /// 参数1:百度地图API的KEY。
        /// 参数2:IP。   
        public const string IP_LOCATION_URL_TEMPLATE = "http://api.map.baidu.com/location/ip?ak={0}&ip={1}&coor=bd09ll";
 
   /// 
        /// 依据IP获取定位信息
        /// 
        ///坐标
        /// 
        //public static IpLocationResult FetchLocation(String ip)
        //{
        //    if (String.IsNullOrWhiteSpace(ip))
        //    {
        //        return null;
        //    }
        //    String ipLocationUrl = String.Format(IP_LOCATION_URL_TEMPLATE,
        //                                         MAP_KEY_BAI_DU,
        //                                         ip);
        //    String responseText = RequestHelper.RequestUrl(ipLocationUrl, null);
        //    if (String.IsNullOrWhiteSpace(responseText))
        //    {
        //        return null;
        //    }
        //    IpLocationResult locationResult = null;
        //    try
        //    {
        //        locationResult = Newtonsoft.Json.JsonConvert.DeserializeObject(responseText);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    return locationResult;
        //}
        [Serializable]
        public class IpLocationResult
        {
            /// 
            /// 状态
            /// 
            public String status { get; set; }

            /// 
            /// 地址
            /// 
            public String address { get; set; }

            /// 
            /// 内容
            /// 
            public IpLocationResult_Content content { get; set; }
        }

        #region IpLocationResult_Content
        /// 
        /// 定位结果文本
        /// 
        [Serializable]
        public class IpLocationResult_Content
        {
            /// 
            /// 地址
            /// 
            public String address { get; set; }

            /// 
            /// 地址明细
            /// 
            public IpLocationResult_Content_AddressDetail address_detail { get; set; }

            /// 
            /// 经纬度
            /// 
            public Coordinate point { get; set; }
        }

        /// 
        /// 定位结果文本之地址明细
        /// 
        [Serializable]
        public class IpLocationResult_Content_AddressDetail
        {
            /// 
            /// 城市
            /// 
            public String city { get; set; }

            /// 
            /// 城市代码
            /// 
            public String city_code { get; set; }

            /// 
            /// 地区
            /// 
            public String district { get; set; }

            /// 
            /// 省份
            /// 
            public String province { get; set; }

            /// 
            /// 街道
            /// 
            public String street { get; set; }

            /// 
            /// 门牌号
            /// 
            public String street_number { get; set; }
        }
        #endregion

    }
}
