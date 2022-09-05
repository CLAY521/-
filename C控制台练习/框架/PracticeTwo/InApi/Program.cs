using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "get";
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
                Console.WriteLine(responseBody);



            Console.ReadKey();
        }
    }
}
