using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._4使用AutoResetEvent类
{
    class Sample1
    {
        //false  false:无信号，子线程的WaitOne方法不会被自动调用
        //true   true: 有信号，子线程的WaitOne方法会被自动调用
        //只有一个线程可以看到信号的改变
        static AutoResetEvent resetEvent = new AutoResetEvent(false);
        static int number = -1;


        public static void Start()
        {
            Thread t = new Thread(ReadThreadProc);
            t.Name = "Read";
            t.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Write线程写入数字:{i}");
                number = i;
                //发信号,通知正在等待的读线程写入操作完成
                resetEvent.Set();
                //暂停1毫秒，给读线程时间读取数字
                Thread.Sleep(1);
            }
        }

        static void ReadThreadProc()
        {
            while (true)
            {
                //读线程等待线程写入数字
                resetEvent.WaitOne();
                Console.WriteLine($"{Thread.CurrentThread.Name}线程读取到数字：{number}");
            }
        }
    }
}
