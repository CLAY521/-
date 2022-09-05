using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._4使用AutoResetEvent类
{
    class Sample2
    {
        public static void Start()
        {
            RemoteRequest request = new RemoteRequest();
            new Thread(request.RequestInterfaceA).Start();
            new Thread(request.RequestInterfaceB).Start();

            AutoResetEvent.WaitAll(request.resetEvents.ToArray());

            request.RequestInterface();
        }
    }
    class RemoteRequest
    {
        public IList<AutoResetEvent> resetEvents;
        public RemoteRequest()
        {
            resetEvents = new List<AutoResetEvent>();
            resetEvents.Add(new AutoResetEvent(false));
            resetEvents.Add(new AutoResetEvent(false));
        }

        public void RequestInterfaceA()
        {
            Console.WriteLine("异步调用远程接口A获取用户数据...");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            resetEvents[0].Set();
            Console.WriteLine("接口A数据获取完成！");
        }

        public void RequestInterfaceB()
        {
            Console.WriteLine("异步调用远程接口B获取订单数据...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            resetEvents[1].Set();
            Console.WriteLine("接口B数据获取完成！");
        }
        public void RequestInterface()
        {
            Console.WriteLine("接口A和接口B的数据获取完成，开始处理C接口数据...");
        }
    }
}
