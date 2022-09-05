using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpRequestAndHttpResponse
{
    class Program
    {
        /// <summary>
        /// HttpRequest服务端   HttpWebRequest客户端
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GetWWW();
            Console.ReadKey();
        }
        /// <summary>
        /// 发送http请求   接收响应
        /// </summary>
        public static void GetWWW()
        {
            //创建一个httpwebrequest请求实例
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:58895/BatchOrder/Edit?Id='475537568770517'");

            //发送请求
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //获取响应，得到数据流
            Stream responseStream = response.GetResponseStream();
            //把数据流绑定在streamreader上
            StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
            //通过streamReader的readtoend方法，把整个http响应作为一个字符串取回
            string html = streamReader.ReadToEnd();
            //然后打印在控制台上
            Console.WriteLine(html);
            //释放资源，不然一旦出错，就会卡很长时间。
            response.Close();
            responseStream.Close();
            streamReader.Close();
        }
        /// <summary>
        /// 获取cookie
        /// </summary>
        public static void CookieExample(string[] args)
        {
            //if (args == null || args.Length != 1)
            //{
            //    Console.WriteLine("Specify the URL to receive the request.");
            //    Environment.Exit(1);
            //}
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:59003/Home/Index");
            request.CookieContainer = new CookieContainer();
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie cook in response.Cookies)
                {
                    Console.WriteLine("Cookie:");
                    Console.WriteLine($"{cook.Name} = {cook.Value}");
                    Console.WriteLine($"Domain: {cook.Domain}");
                    Console.WriteLine($"Path: {cook.Path}");
                    Console.WriteLine($"Port: {cook.Port}");
                    Console.WriteLine($"Secure: {cook.Secure}");

                    Console.WriteLine($"When issued: {cook.TimeStamp}");
                    Console.WriteLine($"Expires: {cook.Expires} (expired? {cook.Expired})");
                    Console.WriteLine($"Don't save: {cook.Discard}");
                    Console.WriteLine($"Comment: {cook.Comment}");
                    Console.WriteLine($"Uri for comments: {cook.CommentUri}");
                    Console.WriteLine($"Version: RFC {(cook.Version == 1 ? 2109 : 2965)}");

                    // Show the string representation of the cookie.
                    Console.WriteLine($"String: {cook}");
                }
            }
        }
        /// <summary>
        /// HttpClient 发送http请求  接收响应
        /// </summary>
        public static async Task HttpClientClass()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:59003/Home/Index");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }

    }
}
