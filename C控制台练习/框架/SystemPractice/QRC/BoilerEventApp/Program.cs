using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerEventApp
{
    /// <summary>
    /// 发布订阅   可以用多播委托实现  也可以用事件实现
    /// 事件是对委托的封装   
    /// 当委托为private的时候，外部调用不到。当为public的时候，外部就可以随便改变它
    /// 这个时候，就需要通过事件，去调用委托
    /// 事件通过+=和-=    要比委托安全
    /// </summary>
    class Program
    {
        static void Logger(string info)
        {
            Console.WriteLine(info);
        }
        static void Main(string[] args)
        {
            //日志的地址
            BoilerInfoLogger filelog = new BoilerInfoLogger("E:\\boiler.txt");
            //声明发布器
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            //发布器中加上打印的方法
            DelegateBoilerEvent.BoilerLogHandler r = new DelegateBoilerEvent.BoilerLogHandler(Logger);
            r += filelog.Logger;
            //boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(Logger);//控制台的打印方法
            //boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);//txt的打印
            //执行调用
            boilerEvent.LogProcess(r);
            //标准输入流中读取下一行字符
            Console.ReadLine();
            //释放资源  释放流
            filelog.Close();
        }
    }
}
