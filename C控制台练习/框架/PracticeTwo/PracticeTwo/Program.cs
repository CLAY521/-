using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebRequests
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    #region 模拟登录
    public class LoginTest
    {

    }
    public class HTMLHelper
    {

    }
    public class HttpHeader
    {
        public string contentType { get; set; }
        public string accept { get; set; }
        public string userAgent { get; set; }
        public string method { get; set; }
        public int maxTry { get; set; }
    }
    #endregion

    #region 模拟表单提交
    public class FormSubmit
    {
        public static void Submit()
        {
            //请求对象
            HttpWebRequest request = null;
            //响应类
            HttpWebResponse response = null;
            //为System.net的集合提供容器。cookieCollection对象
            CookieContainer cc = new CookieContainer();
            //创建请求实例
            request = (HttpWebRequest)WebRequest.Create("http://localhost:3041/Home/Index1");
            //请求方式
            request.Method = "POST";
            //文本类型
            request.ContentType = "application/x-www-form-urlencoded";
            //获取或设置用户代理HTTP表头的值
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
            //参数
            string requestForm = "userName=16933721&userPassword=123456";
            //将参数转化为字节  
            byte[] postdatebyte = Encoding.UTF8.GetBytes(requestForm);
            //将参数入职给请求的实例
            request.ContentLength = postdatebyte.Length;
            //获取或设置一个值，该值只是请求是否应遵循重定向响应。
            request.AllowAutoRedirect = false;
            //获取或设置与请求关联的Cookie
            request.CookieContainer = cc;
            //获取或设置一个值，该值指示是否与internet资源建立持久链接
            request.KeepAlive = true;
            //声明流
            Stream stream;
            //调用方法创建流
            stream = request.GetRequestStream();
            //在流中写入参数
            stream.Write(postdatebyte, 0, postdatebyte.Length);
            //关闭--释放
            stream.Close();
            //获取响应
            response = (HttpWebResponse)request.GetResponse();
            //一行一行输出
            Console.WriteLine();
            //返回响应的流
            Stream stream1 = response.GetResponseStream();
            //读取返回的流
            StreamReader sr = new StreamReader(stream1);
            //输出
            Console.WriteLine(sr.ReadToEnd());


            //暂停   按任意键继续程序运行
            Console.ReadKey();
        }
    }
    #endregion

    #region 模拟上传
    public class Online
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");
    }
    #endregion
}
