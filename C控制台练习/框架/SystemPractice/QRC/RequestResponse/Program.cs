using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetData<List<ErpOrderModel>>();
            ImportData(result);
            Console.ReadKey();
        }
        /// <summary>
        /// 反序列化   将json转换成对象或者集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ApiJsonResp<T> GetData<T>()
        {
            string url = "https://xcx.imovv.com/factory/orders?xmda008=&salesman=&depart=&docno=&start=2022/06/28&end=2022/07/28";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "application/json;charset=UTF-8";
            string responseBody = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };//忽略的字段
            var result = JsonConvert.DeserializeObject<ApiJsonResp<T>>(responseBody);
            return result;
        }
        /// <summary>
        /// 序列化   将对象或集合转换成json
        /// </summary>
        /// <param name="list"></param>
        public static void ImportData(dynamic list)
        {
            JsonSerializerSettings camelCase = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };   //设置时间转换后的时间格式
            var result = JsonConvert.SerializeObject(list,camelCase);
        }
    }
}