using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequest
{
    class Program
    {
        //模拟表单提交
        static void Main(string[] args)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            CookieContainer cc = new CookieContainer();
            request = (HttpWebRequest)WebRequest.Create("http://localhost:3041/Home/Index1");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";

            string requestForm = "userName=16933721&userPassword=123456";
            byte[] postdatebyte = Encoding.UTF8.GetBytes(requestForm);
            request.ContentLength = postdatebyte.Length;
            request.AllowAutoRedirect = false;
            request.CookieContainer = cc;
            request.KeepAlive = true;

            Stream stream;
            stream = request.GetRequestStream();
            stream.Write(postdatebyte,0,postdatebyte.Length);
            stream.Close();

            response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine();

            Stream stream1 = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream1);
            Console.WriteLine(sr.ReadToEnd());

            Console.ReadKey();
        }
    }
}
