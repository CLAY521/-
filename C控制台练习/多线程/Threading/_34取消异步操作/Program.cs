using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _34取消异步操作
{
    internal class Program
    {
        //Task没有方法支持在外部取消task   只能通过一个公共变量存放线程的取消状态，在线程内部通过变量判断线程是否被取消
        //当CancellationToken时取消状态，Task内部未启动的任务不会启动新线程。
        static void Main(string[] args)
        {
            using (var cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    AsyncOperation1(token);
                });
                Thread.Sleep(TimeSpan.FromSeconds(2));
                cts.Cancel();
            }

            using (var cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    AsyncOperation2(token);
                });
                Thread.Sleep(TimeSpan.FromSeconds(2));
                cts.Cancel();
            }

            using (var cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    AsyncOperation3(token);
                });
                Thread.Sleep(TimeSpan.FromSeconds(2));
                cts.Cancel();
            }

            Console.ReadKey();
        }
        static void AsyncOperation1(CancellationToken token)
        {
            Console.WriteLine("启动第一个异步操作");
            for (int i = 0; i < 5; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("第一个异步操作被取消啦~~~");
                    return;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine("第一个异步操作完成");
        }
        static void AsyncOperation2(CancellationToken token)
        {
            try
            {
                Console.WriteLine("启动第二个异步操作");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                Console.WriteLine("第二个异步操作完成");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"第二个异步操作被取消,异常消息:{ex.Message}");
            }
        }
        static void AsyncOperation3(CancellationToken token)
        {
            bool cancellationFlag = false;
            //注册回调函数，当操作被取消时，线程池将调用该回调函数
            token.Register(() => cancellationFlag = true);
            Console.WriteLine("启动第三个异步操作");
            for (int i = 0; i < 5; i++)
            {
                if (cancellationFlag)
                {
                    Console.WriteLine("第三个异步操作被取消啦~~~");
                    return;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine("第三个异步操作完成");
        }
    }
}
