using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpResponse
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.baidu.com");//创建一个请求实例
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.CharacterSet);
            Console.WriteLine(response.ContentEncoding);
            Console.WriteLine(response.ContentLength);
            Console.WriteLine(response.ContentType);

            CookieCollection cc = response.Cookies;
            Console.WriteLine(cc.Count);

            WebHeaderCollection whc = response.Headers;
            Console.WriteLine(whc.Count);
            foreach (string h in whc.AllKeys)
            {
                Console.WriteLine(h.ToString()+""+whc[h].ToString());
            }

            Console.WriteLine(response.IsFromCache);    //输出 false 该值指示响应是否从缓存获取的 
            Console.WriteLine(response.IsMutuallyAuthenticated); //输出 false 客户端和服务器端都已通过身份认证
            Console.WriteLine(response.LastModified);   //输出 2013-04-06 21:03:06 最后一次修改响应的时间和日期
            Console.WriteLine(response.Method);     //输出 Get 返回响应的方法
            Console.WriteLine(response.ProtocolVersion);    //输出 1.1 响应的HTTP协议的版本
            Console.WriteLine(response.ResponseUri);    //输出 http://www.baidu.com 响应请求的Interner资源的URI
            Console.WriteLine(response.Server); //输出 BWS/1.0 发送响应的服务器的名称
            Console.WriteLine(response.StatusCode);     //输出 OK 获取响应的状态，这个不是状态码，而是状态描述，为什么不是200呢，奇怪啊，测试了好几个网站都是OK，而不是200
            Console.WriteLine(response.StatusDescription);      //输出 OK 这个是状态描述，

            Console.ReadKey();
        }
        public static void Methods()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.GetResponseHeader("Content-Type"));
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string html = sr.ReadToEnd();
            Console.WriteLine(html);

            Console.ReadKey();
        }
    }
}
