using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2使用Mutex类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //应用场景：Winform应用程序只能启动一个         (互斥)
            string mutexName = "互斥量";
            using (var mutex = new Mutex(false, mutexName))
            {
                if (mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Console.WriteLine("运行中...");
                    Console.ReadLine();
                    mutex.ReleaseMutex();
                }
                else
                {
                    Console.WriteLine("第二个程序运行啦。。。。");
                }
            }
            Console.WriteLine("Hello world!");



            Console.ReadKey();
        }
    }
}
