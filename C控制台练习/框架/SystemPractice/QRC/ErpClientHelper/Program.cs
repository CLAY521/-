using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpClientHelper
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //public static ApiJsonResp<T> Get<T>(string url) where T : class
        //{
        //    //url拼接
        //    url = GetConfig().ErpUrl + "/" + url;
        //    string log = "[中台API]请求url:" + url;
        //    //记录日志
        //    LogHelper.ThirdLog(log);
        //    //请求接口   接收响应  获取数据
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "GET";
        //    request.ContentType = "application/json;charset=UTF-8";
        //    string responseBody = string.Empty;
        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    {
        //        using (Stream stream = response.GetResponseStream())
        //        {
        //            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //            {
        //                responseBody = reader.ReadToEnd();
        //            }
        //        }
        //    }
        //    log = "[中台API]返回结果:" + responseBody;
        //    //记录日志
        //    LogHelper.ThirdLog(log);

        //    var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        //    //反序列化成list
        //    var result = JsonConvert.DeserializeObject<ApiJsonResp<T>>(responseBody, jsonSetting);
        //    if (!result.Success)
        //    {
        //        throw new ServiceException("[中台API]接口返回失败:" + result.Message);
        //    }
        //    return result;
        //}
    }
    public sealed class ApiJsonResp<T>
    {
        public T Data { get; set;}
        public string Message { get; set; }
        public int Status { get; set; }
        public bool Success => Status == 0;
    }
}
