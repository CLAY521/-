using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4._3组合任务
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTask = new Task<int>(()=>TestMethod("task1",3));
            var secondTask = new Task<int>(()=>TestMethod("task2",2));

            firstTask.ContinueWith(t => {
                Console.WriteLine($"task1 任务返回结果是{t.Result}," +
                    $"线程id： {Thread.CurrentThread.ManagedThreadId}" +
                    $"，是否为线程池中的线程：{Thread.CurrentThread.IsThreadPoolThread}");
            },TaskContinuationOptions.OnlyOnRanToCompletion);//firstTask的延续任务（第二个参数的意思是：在前面任务完成的情况下才执行延续任务。没完成的情况下，不执行此延续任务）

            firstTask.Start();
            secondTask.Start();

            Thread.Sleep(TimeSpan.FromSeconds(4));
            Console.WriteLine("暂停4秒结束");

            Task continuation = secondTask.ContinueWith(
                t => {
                    // secondTask任务的后续操作
                    Console.WriteLine($"task2 任务返回结果是{t.Result}，" +
                        $"线程id： {Thread.CurrentThread.ManagedThreadId}" +
                        $"，是否为线程池中的线程：{Thread.CurrentThread.IsThreadPoolThread}");
                },TaskContinuationOptions.OnlyOnRanToCompletion|TaskContinuationOptions.ExecuteSynchronously);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine();


            var thirdTask = new Task<int>(() => {
                //父子线程，只有所有子任务结束工作，父任务才会完成
                var innerTask = Task.Factory.StartNew(()=>TestMethod("task4",5),TaskCreationOptions.AttachedToParent);
                //也可以在子任务上运行后续操作，后续操作也会影响到父任务
                innerTask.ContinueWith(t=>TestMethod("task5",3),TaskContinuationOptions.AttachedToParent);
                return TestMethod("task3", 2);
            });
            thirdTask.Start();

            while (!thirdTask.IsCompleted)
            {
                Console.WriteLine($"任务3的状态:{thirdTask.Status}");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine($"任务3的状态:{thirdTask.Status}");


            Console.ReadKey();
        }
        static int TestMethod(string taskName, int seconds)
        {
            Console.WriteLine($"任务 {taskName} 正在运行，" +
                $"线程id： {Thread.CurrentThread.ManagedThreadId}" +
                $"，是否为线程池中的线程：{Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            return 36 * seconds;
        }
    }
}
