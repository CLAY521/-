using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threading;

namespace _1._3_终止线程
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始...");
            //创建一个子线程并启动
            Thread t = new Thread(Common.PringNumbersWithDelay);
            t.Start();

            //主线程暂停6秒
            Thread.Sleep(6000);

            //终止线程t
            t.Abort();
            Console.WriteLine("子线程终止了...");

            Thread t1 = new Thread(Common.PringNumbers);
            t1.Start();
            Common.PringNumbers();

            Console.ReadKey();
        }
    }
}
