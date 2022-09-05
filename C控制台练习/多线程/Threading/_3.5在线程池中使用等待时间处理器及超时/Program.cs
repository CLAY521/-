using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3._5在线程池中使用等待时间处理器及超时
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunOperation(TimeSpan.FromSeconds(5));
            RunOperation(TimeSpan.FromSeconds(7));
            Console.ReadKey();
        }
        static void RunOperation(TimeSpan workerOperationTs)
        {
            using (var evt = new ManualResetEvent(false))
            using (var cts = new CancellationTokenSource())
            {
                Console.WriteLine("注册操作超时的方法...");
                var worker = ThreadPool.RegisterWaitForSingleObject(evt,
                    (state, isTimeout) => WorkerOperationWait(cts, isTimeout),//超时后，被调用的函数
                    null,
                    workerOperationTs   //超时值
                    , true);
                Console.WriteLine("开始长时间操作...");
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    WorkerOperation(cts.Token, evt);
                });

                Thread.Sleep(workerOperationTs.Add(TimeSpan.FromSeconds(2)));
                worker.Unregister(evt);
            }
        }
        static void WorkerOperation(CancellationToken token, ManualResetEvent evt)
        {
            for (int i = 0; i < 6; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("异步操作被取消");
                    return;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            evt.Set();
        }
        static void WorkerOperationWait(CancellationTokenSource cts, bool isTimeout)
        {
            if (isTimeout)
            {
                cts.Cancel();
                Console.WriteLine("异步操作超时并被取消了");
            }
            else
            {
                Console.WriteLine("异步操作完成");
            }
        }
    }
}
