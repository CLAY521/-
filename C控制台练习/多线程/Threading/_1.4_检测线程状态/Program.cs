using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threading;
using System.Threading;

namespace _1._4_检测线程状态
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Common.PringNumbersWithStatus);
            t1.Name = "t1";
            Thread t2 = new Thread(DoNothing);
            t2.Name = "t2";
            Console.WriteLine($"线程{t1.Name}的状态是:{t1.ThreadState}");
            Console.WriteLine($"线程{t2.Name}的状态是：{t2.ThreadState}");

            t1.Start();
            t2.Start();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"线程{t1.Name}的状态是:{t1.ThreadState}");
            }

            Thread.Sleep(TimeSpan.FromSeconds(4));

            t1.Abort();
            Console.WriteLine($"线程{t1.Name}的状态是:{t1.ThreadState}");
            Console.WriteLine($"线程{t2.Name}的状态是：{t2.ThreadState}");


            Console.ReadKey();
        }
        static void DoNothing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
