using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._5使用ManualResetEventSlim类
{
    internal class Program
    {
        //主要功能   控制锁的打开和关闭    打开之后才能执行wait后面的语句    关闭之后不能执行wait后面的语句
        static ManualResetEventSlim _event = new ManualResetEventSlim(false);
        static void Main(string[] args)
        {
            var t1 = new Thread(() => { ThroughGated(5); });
            var t2 = new Thread(() => { ThroughGated(6); });
            var t3 = new Thread(() => { ThroughGated(12); });
            t1.Name = "t1";
            t2.Name = "t2";
            t3.Name = "t3";
            t1.Start();
            t2.Start();
            t3.Start();


            Console.WriteLine("主线程暂停6秒");
            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("主线程打开传送门...");
            _event.Set();

            Console.WriteLine("主线程暂停2秒");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("主线程关闭传送门...");
            _event.Reset();

            Console.WriteLine("主线程暂停10秒");
            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("主线程第二次打开传送门...");
            _event.Set();

            Console.WriteLine("主线程暂停2秒");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("主线程第二次关闭传送门...");
            _event.Reset();

            Console.ReadKey();
        }
        static void ThroughGated(int seconds)
        {
            Console.WriteLine($"线程{Thread.CurrentThread.Name}进入" +
                $"传送门之前先暂停{seconds}秒");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"线程{Thread.CurrentThread.Name}暂停" +
                $"完毕,等待传送门的开启。");
            _event.Wait();
            Console.WriteLine($"线程{Thread.CurrentThread.Name}进入" +
                $"传送门！");
        }
    }
}
