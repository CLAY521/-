using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._3使用SemaphoreSlim类
{
     class Program
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);//该类限制了同时访问同一个资源的线程数量

        /// <summary>
        /// 在餐厅吃饭
        /// </summary>
        /// <param name="seconds"></param>
        static void EatIniningRoom(int seconds)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}等待座位...");
            semaphoreSlim.Wait();
            Console.WriteLine($"{Thread.CurrentThread.Name}坐下来开始吃饭");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{Thread.CurrentThread.Name}吃完了！");
            semaphoreSlim.Release();
        }
        static void Main(string[] args)
        {
            //SemaphoreSlim:信号量
            //假设餐厅只有10个位置，但有15位顾客要吃饭，所以有5位顾客需要等待
            for (int i = 0; i < 15; i++)
            {
                Thread t = new Thread(()=>
                {
                    EatIniningRoom(5);
                });
                t.Name = $"t{i}";
                t.Start();
            }
            Console.ReadKey();
        }
    }
}
