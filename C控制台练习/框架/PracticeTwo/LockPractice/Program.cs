using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockPractice
{
    class Program
    {
        public static Thread worker1;
        public static Thread worker2;
        public static Thread sleeper;
        public static Thread worker;
        private static readonly object Lock = new object();
        private static long max = 5;
        static long _count = 0;
        static void Main(string[] args)
        {
            //Console.WriteLine("Entering the void Main");
            //worker1 = new Thread(new ThreadStart(Counter));
            //worker2 = new Thread(new ThreadStart(Counter2));
            //worker1.Start();
            //worker2.Start();
            //Console.WriteLine("Exiting the void Main!");

            //Console.WriteLine("Entering the void Main");
            //sleeper = new Thread(new ThreadStart(SleepingThread));
            //worker = new Thread(new ThreadStart(AwakeThread));
            //sleeper.Start();
            //worker.Start();
            //Console.WriteLine("Exiting the void Main");

            //ParameterizedThreadStart parStart = new ParameterizedThreadStart(ThreadMethod);
            //Thread thread = new Thread(parStart);
            //object o = "Hello";
            //thread.Start(o);

            //TestLock();

            //Threads t = new Threads();
            //Threads.obj.i = 0;
            //
            //Thread th1 = new Thread(new ThreadStart(t.hhh));
            //th1.Name = "th1";
            //th1.Start();
            //
            //Thread th2 = new Thread(new ThreadStart(t.hhh));
            //th2.Name = "th2";
            //th2.Start();

            Console.ReadKey();
        }

        #region 加锁


        //public static void TestLock()
        //{
        //    Thread t1 = new Thread(new ThreadStart(() =>
        //    {
        //        for (int i = 0; i < max; i++)
        //        {
        //            lock (Lock)
        //            {
        //                _count++;
        //            }
        //        }
        //    }));
        //    t1.Start();
        //    for (int i = 0; i < max; i++)
        //    {
        //        lock (Lock)
        //        {
        //            _count++;
        //        }
        //    }
        //    t1.Join();
        //    Console.WriteLine("_count的结果是:{0}", _count);
        //}
        #endregion

        #region 优先级
        //Heighest 可以安排在具有任何其他优先级的线程之前
        //AboveNormal 可以安排在优先级为Highest的线程之后和优先级为Normal的线程之前
        //Normal 可以安排在AboveNormal之后和BelowNormal之前   默认线程的优先级为Normal
        //BelowNormal 可以安排在优先级为Normal之后和Lowest之前
        //Lowest 可以安排在具有任何其他优先级的线程之后

        //线程优先级越高，只是意味着优先级高的线程占有更多的CPU时间，并不意味着一定会先执行优先级高的线程。

        #endregion

        #region 传参
        public static void ThreadMethod(object obj)
        {
            Console.WriteLine("参数为:"+obj);
        }
        #endregion

        #region 多线程  中止睡眠或阻塞状态，让线程继续工作（Interrupt）
        public static void SleepingThread()
        {
            for (int i = 1; i < 50; i++)
            {
                Console.WriteLine(i+"");
                if (i == 10 || i == 20 || i == 30)
                {
                    Console.WriteLine("Going to sleep as :"+i);
                    try
                    {
                        Thread.Sleep(20);
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        public static void AwakeThread()//唤醒
        {
            for (int i = 51; i < 100; i++)
            {
                Console.WriteLine(i+"");
                if (sleeper.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine("Interrupting the sleeping thread");
                    sleeper.Interrupt();
                }
            }
        }
        #endregion

        #region 多线程   休眠（sleep）
        public static void Counter()
        {
            Console.WriteLine("Entering Counter");
            for (int i = 1; i < 50; i++)
            {
                Console.WriteLine(i + "");
                if (i == 10)
                {
                    Console.WriteLine("work1线程要休眠1000毫秒");
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("Exiting Counter");
        }
        public static void Counter2()
        {
            Console.WriteLine("Entering Counter");
            for (int i = 51; i < 100; i++)
            {
                Console.WriteLine(i + "");
                if (i == 70)
                {
                    Console.WriteLine("work2线程要休眠5000毫秒");
                    Thread.Sleep(5000);
                }
            }
            Console.WriteLine("Exiting Counter");
        }
        #endregion

    }

    #region 加锁
    public class Threads
    {
        public static sss obj = new sss();
        public void hhh()
        {
            lock(obj)
            {
                for (int i = 0; i < 10; i++)
                {
                    //Thread.Sleep(500);
                    obj.i++;
                    Console.WriteLine("当前线程名:" + Thread.CurrentThread.Name + ",obj.i=" + obj.i);
                }
            }
        }
    }
    public class sss
    {
        public int i;
    }
    #endregion

}
