using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Kuahread();
            Console.ReadKey();
        }
        #region 跨线程访问
        public static void Kuahread()
        {
            Thread thread = new Thread(new ThreadStart(Test));
            thread.IsBackground = true;
            thread.Start();
        }
        public static void Test()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i.ToString());
            }
        }
        #endregion

        #region 线程同步--lock
        public static void ThreadTong()
        {
            BookShop book = new BookShop();
            Thread t1 = new Thread(new ThreadStart(book.Sale));
            Thread t2 = new Thread(new ThreadStart(book.Sale));
            t1.Start();
            t2.Start();
        }
        #endregion

        #region 前后台线程
        public static void BegoreBack()
        {
            BackGroundTest background = new BackGroundTest(10);
            Thread fThread = new Thread(new ThreadStart(background.RunLoop));
            fThread.Name = "前台线程";

            BackGroundTest background1 = new BackGroundTest(20);
            Thread bThread = new Thread(new ThreadStart(background1.RunLoop));
            bThread.Name = "后台线程";
            bThread.IsBackground = true;

            fThread.Start();
            bThread.Start();
        }
        #endregion

        #region 通过ParaMeterizedThreadStart创建线程
        public static void ParaMeter()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Thread1));
            thread.Start("这是一个有参数的委托");
        }
        public static void Thread1(object obj)
        {
            Console.WriteLine(obj);
        }
        #endregion

        #region 匿名委托创建
        public static void NiDelegate()
        {
            Thread thread1 = new Thread(delegate() { Console.WriteLine("我是通过匿名委托创建的线程"); });
            thread1.Start();
            Thread thread2 = new Thread(() => Console.WriteLine("我是通过Lambda表达式创建的委托"));
            thread2.Start();

        }
        #endregion

        #region 实例方法
        public static void MyThreadDiao()
        {
            MyThread m = new MyThread("这是实例方法的参数1","这是实例方法的参数2");
            Thread thread = new Thread(new ThreadStart(m.Test));
            thread.Start();
        }
        #endregion

        #region 后台和前台线程
        public static void ThreadMain()
        {
            Console.WriteLine("Thread+"+Thread.CurrentThread.Name+"started");
            Thread.Sleep(3000);
            Console.WriteLine("Thread+"+Thread.CurrentThread.Name+"started");
        }
        public static void ThreadMainDiao()
        {
            Thread t1 = new Thread(ThreadMain);
            t1.IsBackground = false;
            t1.Start();
            Console.WriteLine("Main thread ending now.");
        }
        #endregion

        #region 定义一个委托   异步调用
        public static void TestDiao()
        {
            //通过委托，开启一个线程
            Func<int, string, int> a = Test;
            //开启一个新的线程去执行 a 所引用的方法
            IAsyncResult ar = a.BeginInvoke(100, "LST", null, null);
        }
        //一般我们会为比较耗时的操作  开启单独的线程去执行
        public static int Test(int i, string str)
        {
            Console.WriteLine("test" + i + str);
            Thread.Sleep(100);
            return 100;
        }
        #endregion

        #region 通过Thread类
        public static void ThreadTestDiao()
        {
            Thread t = new Thread(ThreadTest);
            t.Start("这是方法的参数");
        }
        public static void ThreadTest(object name)
        {
            Console.WriteLine("参数："+name);
            Console.WriteLine("Test");
            Thread.Sleep(2000);
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(id+"线程结束");
        }
        #endregion

        #region 构造函数 传参
        public static void Diao()
        {
            MyThread my = new MyThread("参数1","参数2");
            Thread t = new Thread(my.Test);
            t.Start();
        }
        #endregion

        #region 通过线程池创建线程
        public static void Test1(object state)
        {
            Console.WriteLine("线程开始："+Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束");
        }
        public static void MainTest()
        {
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
            ThreadPool.QueueUserWorkItem(Test1);
        }
        #endregion

    }
    class BookShop
    {
        public int num = 1;
        public void Sale()
        {
            lock(this)
            {
                int tmp = num;
                if (tmp > 0)
                {
                    Thread.Sleep(1000);
                    num -= 1;
                    Console.WriteLine("售出一本图书，还剩{0}本", num);
                }
                else
                {
                    Console.WriteLine("没有了");
                }
            }
            
        }
    }
    class BackGroundTest
    {
        private int Count;
        public BackGroundTest(int count)
        {
            this.Count = count;
        }
        public void RunLoop()
        {
            string threadName = Thread.CurrentThread.Name;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("{0}计数:{1}",threadName,i.ToString());
                Thread.Sleep(1000);
            }
            Console.WriteLine("{0}完成计数",threadName);
        }
    }
    class MyThread
    {
        private string name1;
        private string name2;
        public MyThread(string Name1, string Name2)
        {
            this.name1 = Name1;
            this.name2 = Name2;
        }
        public void Test()
        {
            Console.WriteLine("Test"+name1+name2);
            Thread.Sleep(2000);
            Console.WriteLine("线程结束");
        }
    }
}







