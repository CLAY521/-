using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpContexts
{
    class Program
    {
        static void Main(string[] args)
        {
            Configurations();
            Console.ReadKey();
        }
        //HttpContext   http上下文：关于http请求中的一些信息   生命周期（从服务器接收http请求开始到反应发送回客户端结束）
        //HttpRuntime   在.net处理请求中  负责的是创建httpcontext对象  以及  调用httpapplicationfactory 创建httpapplication
        //HttpServerUtility  是一个工具类  为了在后台 处理请求 方便获取到一些常用的类型   很多常用的东西都封装在这里   比如url和html的编码解码
        //httpresponse类  服务器接收到浏览器的请求后，处理  返回结果  常用的一个类

        //httprequest  读取客户端发送的http值  比如  表单（form、url、cookie、请求头）
        #region httprequest的属性
        //、Params，Item与QueryString、Forms的区别Get请求用QueryString;Post请求用Forms;Parms与Item可以不区分Get请求还是Post请求；Params与Item两个属性唯一不同的是：Item是依次访问这4个集合，找到就返回结果，而Params是在访问时，先将4个集合的数据合并到一个新集合(集合不存在时创建)， 然后再查找指定的结果。
        #endregion

        //会话状态session  

        //Appsettings
        public static void Configurations()
        {
            string Appsettings = ConfigurationManager.AppSettings["DB"];
            string connection = ConfigurationManager.ConnectionStrings["conn"].ToString();
            Console.WriteLine(Appsettings);
            Console.WriteLine(connection);

            IDictionary dic = (IDictionary)ConfigurationManager.GetSection("Person");
            foreach (string key in dic.Keys)
            {
                Console.WriteLine(key + ":" + dic[key]);
            }
        }
    }
}
