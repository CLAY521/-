using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _4._2从任务中获取结果
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //主线程中运行
            TaskMethod("Main task");

            Task<int> t1 = CreateTask("task1");
            t1.Start();
            //主线程会等待
            Console.WriteLine($"task1返回值:{t1.Result}");

            Task<int> t2 = CreateTask("task2");
            //主线程中运行
            t2.RunSynchronously();
            Console.WriteLine($"task2 返回值：{ t2.Result}");

            Task<int> t3 = CreateTask("t3");
            t3.Start();
            while (!t3.IsCompleted)
            {
                Console.WriteLine($"task3任务状态:{t3.Status}");
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            Console.WriteLine($"task3任务状态:{t3.Status}");
            Console.WriteLine($"task3 返回值：{t3.Result}");


            Console.ReadKey();
        }

        static Task<int> CreateTask(string taskName)
        {
            return new Task<int>(()=>TaskMethod(taskName));
        }
        static int TaskMethod(string taskName)
        {
            Console.WriteLine($"任务{taskName}正在运行，"+
                $"线程ID：{Thread.CurrentThread.ManagedThreadId}"+
                $"，是否为线程池中的线程:{Thread.CurrentThread.IsThreadPoolThread}"
                );
            return 36;
        }
    }
}
