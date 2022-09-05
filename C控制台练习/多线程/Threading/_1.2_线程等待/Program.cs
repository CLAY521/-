using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threading;

namespace _1._2_线程等待
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Common.PringNumbersWithDelay);
            thread.Start();
            //等待线程（当前线程完成之后在执行下面的语句）
            thread.Join();

            Console.WriteLine("打印完成");
            Console.ReadKey();
        }
    }
}
