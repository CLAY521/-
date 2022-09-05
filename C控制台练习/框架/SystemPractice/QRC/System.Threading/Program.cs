using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System.Threading
{
    class Program
    {
        delegate string MyDelegate(string name,int age);
        static void Main(string[] args)
        {
            DuoGetTitleCall();
            Console.ReadKey();
        }

        #region 线程优先级
        public static void ThreadProority()
        {
            //新建3个线程并设定各自的优先级
            Thread t1 = new Thread(Run);
            t1.Priority = ThreadPriority.Lowest;
            Thread t2 = new Thread(Run);
            t2.Priority = ThreadPriority.BelowNormal;
            Thread t3 = new Thread(Run);
            t3.Priority = ThreadPriority.Normal;
            Thread t4 = new Thread(Run);
            t4.Priority = ThreadPriority.AboveNormal;
            Thread t5 = new Thread(Run);
            t5.Priority = ThreadPriority.Highest;
            //由低到高优先级的顺序一次调用
            t5.Start();
            t4.Start();
            t3.Start();
            t2.Start();
            t1.Start();
        }
        public static void Run()
        {
            Console.WriteLine("我的优先级是："+Thread.CurrentThread.Priority);
        }
        #endregion

        #region 线程Thread常用属性
        public static void AttributeDiao()
        {
            Thread t1 = new Thread(AttributeRun);
            t1.Priority = ThreadPriority.Normal;
            t1.Start();
        }
        public static void AttributeRun()
        {
            Thread t1 = Thread.CurrentThread;   //静态属性，获取当前执行这行代码的线程
            Console.WriteLine("我的优先级是：" + t1.Priority);
            Console.WriteLine("我是否还在执行：" + t1.IsAlive);
            Console.WriteLine("是否是后台线程：" + t1.IsBackground);
            Console.WriteLine("是否是线程池线程：" + t1.IsThreadPoolThread);
            Console.WriteLine("线程唯一标识符：" + t1.ManagedThreadId);
            Console.WriteLine("我的名称是：" + t1.Name);
            Console.WriteLine("我的状态是：" + t1.ThreadState);
        }
        #endregion

        #region 前后台线程
        public static void FontBeHind()
        {
            Thread t1 = new Thread(BeHindRun);
            t1.IsBackground = true;   //设置为后台线程
            t1.Start();
            Console.WriteLine("不等你咯，后台线程");
        }
        public static void BeHindRun()
        {
            Thread.Sleep(2000);
            Console.WriteLine("后台线程正在执行");
        }
        #endregion

        #region 串行执行
        public static void SerialCall()
        {
            Thread t1 = new Thread(SerialRun);
            t1.Name = "t1";
            t1.Start();
            //串行执行
            t1.Join();    //等待t1执行结束之后，主线程再执行
            Console.WriteLine("主线程执行这了么？");

        }
        public static void SerialRun()
        {
            Console.WriteLine("线程" + Thread.CurrentThread.Name + "开始执行!");
            Thread.Sleep(5000);
            Console.WriteLine("线程" + Thread.CurrentThread.Name + "执行完毕!");
        }
        #endregion

        #region Interrupt与Abort   用来强制终止线程
        public static void AbortInterCall()
        {
            Thread t1 = new Thread(AbortInterRun);
            t1.Start();
            //当interrupt时，线程已进入for循环，中断第一次之后，第二次循环无法再停止
            t1.Interrupt();
            t1.Join();
            Console.WriteLine("============================================================");
            Thread t2 = new Thread(AbortInterRun);
            t2.Start();
            //停止1秒的目的是为了让线程t2开始，否则t2都没开始就直接终止了
            Thread.Sleep(500);
            //直接终止线程，线程被终止，自然无法输出什么
            t2.Abort();
        }
        public static void AbortInterRun()
        {
            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    //连续睡眠5次
                    Thread.Sleep(500);
                    Console.WriteLine("第" + i + "次Sleep!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("第" + i + "次Sleep被中断!" + "   " + e.Message);
                }
            }
        }
        #endregion

        #region ThreadStart委托
        public static void SusResCall()
        {
            Console.WriteLine("主线程Id是：" + Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(new ThreadStart(SusResRun));  //ThreadStart所生成并不受线程池管理。
            thread.Start();
            Console.WriteLine("正在做某事......");
            Console.WriteLine("主线程工作完成!");
        }
        public static void SusResRun()
        {
            string message = string.Format("异步线程Id是:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(message);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine("异步线程当前循环执行到" + i);
            }
        }
        #endregion

        #region ParameterizedThreadStart委托   带参数的方法
        public static void ParameterCall()
        {
            //整数作为参数
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(ParameterRun));
                t.Start(i);
            }
            Console.WriteLine("主线程执行完毕");
            //自定义类型作为参数
            Person p1 = new Person("关羽",22);
            Thread t1 = new Thread(new ParameterizedThreadStart(ParameterRunP));
            t1.Start(p1);
        }
        public static void ParameterRun(object i)
        {
            Thread.Sleep(50);
            Console.WriteLine("线程传进来的参数是："+i.ToString());
        }
        public static void ParameterRunP(object o)
        {
            Thread.Sleep(50);
            Person p = o as Person;
            Console.WriteLine(p.Name+p.Age);
        }
        #endregion

        #region TimerCallback委托    定时--调用
        public static void TimerCall()
        {
            System.Threading.Timer clock = new System.Threading.Timer(ShowTime,null,0,1000);
            Console.WriteLine("主线程执行完毕！！！--前台线程");
        }
        public static void ShowTime(object userData)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
        #endregion

        #region ThreadPool线程池

        #region ThreadPool常用方法
        /// <summary>
        /// GetAvailableThreads	剩余空闲线程数
        /// GetMaxThreads	最多可用线程数，所有大于此数目的请求将保持排队状态，直到线程池线程变为可用
        /// GetMinThreads	检索线程池在新请求预测中维护的空闲线程数。
        /// QueueUserWorkItem	启动线程池里得一个线程(队列的方式，如线程池暂时没空闲线程，则进入队列排队)
        /// SetMaxThreads	设置线程池中的最大线程数
        /// SetMinThreads	设置线程池最少需要保留的线程数
        /// </summary>
        public static void ThreadPoolCall()
        {
            int i = 0;
            int j = 0;
            //前面是辅助(也就是所谓的工作者)线程，后面是I/O线程
            ThreadPool.GetMaxThreads(out i, out j);
            Console.WriteLine(i.ToString() + "   " + j.ToString()); //默认都是1000

            //获取空闲线程，由于现在没有使用异步线程，所以为空
            ThreadPool.GetAvailableThreads(out i, out j);
            Console.WriteLine(i.ToString() + "   " + j.ToString()); //默认都是1000
        }
        #endregion

        #region 工作者线程
        #region QueueUserWorkItem启动工作者线程
        public static void QueueCall()
        {
            Person p = new Person("刘备", 21);
            //工作者线程最大数目，IO线程的最大数目
            ThreadPool.SetMaxThreads(1000, 1000);
            //启动工作者线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(QueueRunWorkerParameter), p);
            ThreadPool.QueueUserWorkItem(new WaitCallback(QueueRunWorker));
        }
        public static void QueueRunWorker(object state)
        {
            Console.WriteLine("RunWorkerThread开始工作");
            Console.WriteLine("工作者线程启动成功!");
        }
        public static void QueueRunWorkerParameter(object obj)
        {
            Thread.Sleep(200);
            Console.WriteLine("线程池线程开始!");
            Person p = obj as Person;
            Console.WriteLine(p.Name);
        }
        #endregion

        #region BeginInvoke EndInvoke委托异步调用线程

        #region IAsyncResult轮询
        public static void BeginEndCall()
        {
            //建立委托
            MyDelegate myDelegate = new MyDelegate(BeginEndGetString);
            //异步调用委托，除最后两个参数外，前面的参数都可以传进去
            IAsyncResult result = myDelegate.BeginInvoke("刘备", 22, null, null);　　//IAsynResult还能轮询判断，功能不弱

            Console.WriteLine("主线程继续工作!");

            //调用EndInvoke(IAsyncResult)获取运行结果，一旦调用了EndInvoke，即使结果还没来得及返回，主线程也阻塞等待了
            //注意获取返回值的方式
            string data = myDelegate.EndInvoke(result);
            Console.WriteLine(data);

            Console.ReadKey();
        }
        public static string BeginEndGetString(string name, int age)
        {
            Console.WriteLine("我是不是线程池线程" + Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }
        #endregion

        #region IAsyncResult轮询   优化版
        /// <summary>
        /// IAsyncResult轮询   属性
        /// object AsyncState {get;} 　　　　　 //获取用户定义的对象，它限定或包含关于异步操作的信息。
        /// WailHandle AsyncWaitHandle { get; }  //获取用于等待异步操作完成的 WaitHandle。
        /// bool CompletedSynchronously { get; } //获取异步操作是否同步完成的指示。
        /// bool IsCompleted { get; } 　　　　　　 //获取异步操作是否已完成的指示。
        /// </summary>
        public static void ResultCall()
        {
            MyDelegate mydelegate = new MyDelegate(ResultGetString);
            IAsyncResult result = mydelegate.BeginInvoke("刘备", 22, null, null);
            Console.WriteLine("主线程继续工作");
            while (!result.IsCompleted)
            {
                Thread.Sleep(500);
                Console.WriteLine("异步线程还没完成，主线程干其他事");
            }
            string data = mydelegate.EndInvoke(result);
            Console.WriteLine(data);
        }
        public static string ResultGetString(string name, int age)
        {
            Thread.Sleep(2000);
            return string.Format("我是{0},今年{1}岁", name, age);
        }
        #endregion

        #region IAsyncResult  回调函数--第三个参数
        public static void ResultHuiCall()
        {
            //建立委托
            MyDelegate mydelegate = new MyDelegate(ResultHuiGetString);
            //倒数第二个参数   委托中绑定了完成后的回调方法
            IAsyncResult result1 = mydelegate.BeginInvoke("刘备", 23, new AsyncCallback(Completed), null);
            //主线程可以继续工作而不需要等待
            Console.WriteLine("我是主线程，我干我的活，不再理你");
            Thread.Sleep(5000);

        }
        public static string ResultHuiGetString(string name, int age)
        {
            Thread.CurrentThread.Name = "异步线程";
            //注意  如果不设置为前台线程   则主线程完成后就直接卸载程序了
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }
        public static void Completed(IAsyncResult result)
        {
            //获取委托对象，调用EndInvoke方法获取运行结果
            AsyncResult _result = (AsyncResult)result;
            MyDelegate myDelegate = (MyDelegate)_result.AsyncDelegate;
            //获得参数
            string data = myDelegate.EndInvoke(_result);
            Console.WriteLine(data);
            //异步线程执行完毕
            Console.WriteLine("异步线程完成咯！");
            Console.WriteLine("回调函数也是由" + Thread.CurrentThread.Name + "调用的！");
        }
        #endregion

        #region IAsyncResult  回调函数--第四个参数
        public static void FourCall()
        {
            Person p = new Person("关羽", 26);
            //建立委托
            MyDelegate mydelegate = new MyDelegate(FourGetString);
            //最后一个参数的作用，原来是用来传参的
            IAsyncResult result1 = mydelegate.BeginInvoke("刘备", 23, new AsyncCallback(CompletedFour), p);
            //主线程可以继续工作而不需要等待
            Console.WriteLine("我是主线程，我干我的活，不再理你！");
            Console.ReadKey();
        }
        public static string FourGetString(string name, int age)
        {
            Thread.CurrentThread.Name = "异步线程";
            //注意，如果不设置为前台线程，则主线程完成后就直接卸载程序了
            Thread.CurrentThread.IsBackground = false;
            Thread.Sleep(2000);
            return string.Format("我是{0}，今年{1}岁!", name, age);
        }
        public static void CompletedFour(IAsyncResult result)
        {
            //获取委托对象，调用EndInvoke方法获取运行结果
            AsyncResult _result = (AsyncResult)result;
            MyDelegate myDelegaate = (MyDelegate)_result.AsyncDelegate;
            //获得参数
            string data = myDelegaate.EndInvoke(_result);
            Console.WriteLine(data);

            Person p = result.AsyncState as Person;

            Console.WriteLine($"传过来的参数是{p.Name}----{p.Age}");
            //异步线程执行完毕
            Console.WriteLine("异步线程完成咯！");
            Console.WriteLine("回调函数也是由" + Thread.CurrentThread.Name + "调用的！");
        }
        #endregion

        #endregion
        #endregion

        #region IO线程

        #region 异步写入
        public static void IOCall()
        {
            int a, b;
            ThreadPool.GetMaxThreads(out a, out b);
            Console.WriteLine("原有辅助线程数" + a + "   " + "原有I/O线程数" + b);

            //文件名  文件创建方式   文件权限  文件进程共享  缓冲区大小为1024   是否启动异步IO线程为true
            FileStream stream = new FileStream(@"D:\123.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true);
            //这里要注意，如果写入的字符串很小，则.net会使用辅助线程写，因为这样比较快
            byte[] bytes = Encoding.UTF8.GetBytes("你在杭州还好吗？");
            //异步写入开始，倒数第二个参数指定回调函数，最后一个参数将自身传到回调函数里，用于结束异步线程
            stream.BeginWrite(bytes, 0, (int)bytes.Length, new AsyncCallback(IOCallback), stream);

            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("现有辅助线程数" + a + "   " + "现有有I/O线程数" + b);

            Console.WriteLine("主线程继续干其他活!");
        }
        public static void IOCallback(IAsyncResult result)
        {
            //显示线程池现状
            Thread.Sleep(2000);
            //通过result.AsyncState再强制转换为FileStream就能够获取FileStream对象，用于结束异步写入
            FileStream stream = (FileStream)result.AsyncState;
            stream.EndWrite(result);
            stream.Flush();
            stream.Close();
        }
        #endregion

        #region 异步读取
        public static void CompletedCall()
        {
            int a, b;
            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("原有辅助线程:" + a + "原有I/O线程:" + b);

            byte[] byteData = new byte[1024];
            FileStream stream = new FileStream(@"D:\123.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite,1024,true);
            //把filestream对象，byte【】对象，长度等有关数据绑定到filedate对象中，以附带属性方式送到回调函数
            Hashtable ht = new Hashtable();
            ht.Add("Length",(int)stream.Length);
            ht.Add("Stream",stream);
            ht.Add("ByteData",byteData);
            //启动异步读取，倒数第二个参数是指定回调函数，倒数第一个参数是传入回调函数中的参数
            stream.BeginRead(byteData,0,(int)ht["Length"],new AsyncCallback(CompletedRead),ht);

            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("现有辅助线程:" + a + "现有I/O线程:" + b);
        }
        //实际参数就是回调函数
        public static void CompletedRead(IAsyncResult result)
        {
            Thread.Sleep(2000);
            //参数result实际上就是Hashtable对象，以filestream.endread完成异步读取
            Hashtable ht = (Hashtable)result.AsyncState;
            FileStream stream = (FileStream)ht["Stream"];
            int length = stream.EndRead(result);
            stream.Close();
            string str = Encoding.UTF8.GetString(ht["ByteData"] as byte[]);
            Console.WriteLine(str);
            stream.Close();
        }
        #endregion

        #region 异步WebRequest
        public static void WebRequestCall()
        {
            int a, b;
            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("原有辅助线程:" + a + "原有I/O线程:" + b);

            //使用WebRequest.Create方法建立HttpWebRequest对象
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
            webRequest.Method = "Post";
            //对写入数据的RequestStream对象进行异步请求
            IAsyncResult result = webRequest.BeginGetResponse(new AsyncCallback(EndGetResponse),webRequest);

            Thread.Sleep(1000);
            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("现有辅助线程:" + a + "现有I/O线程:" + b);

            Console.WriteLine("主线程继续干其他事!");
        }
        public static void EndGetResponse(IAsyncResult result)
        {
            Thread.Sleep(2000);
            //结束异步请求，获取结果
            HttpWebRequest webRequest = (HttpWebRequest)result.AsyncState;
            WebResponse webResponse = webRequest.EndGetResponse(result);

            Stream stream = webResponse.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string html = sr.ReadToEnd();
            Console.WriteLine(html.Substring(0,50));
        }
        #endregion

        #region 异步SqlCommand
        public static void NoSameCall()
        {
            int a, b;
            ThreadPool.GetMaxThreads(out a, out b);
            Console.WriteLine("原有辅助线程数" + a + "   " + "原有I/O线程数" + b);

            string str = "server=.;database=ERP;uid=sa;pwd=123456;";
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into Grade values ('1802','2','18021802',0)";
            conn.Open();
            cmd.BeginExecuteNonQuery(new AsyncCallback(EndCallBackNoSame), cmd);

            Thread.Sleep(1000);
            ThreadPool.GetAvailableThreads(out a, out b);
            Console.WriteLine("现有辅助线程数" + a + "   " + "现有I/O线程数" + b);

            Console.WriteLine("主线程继续执行!");

            Console.ReadKey();
        }
        public static void EndCallBackNoSame(IAsyncResult result)
        {
            Thread.Sleep(2000);
            SqlCommand cmd = result.AsyncState as SqlCommand;//获得异步传入的参数
            Console.WriteLine("成功执行命令："+cmd.CommandText);
            Console.WriteLine($"本次执行影响行数：{cmd.EndExecuteNonQuery(result)}");
            cmd.Connection.Close();
        }
        #endregion

        #endregion


        #endregion

        #region 锁机制和原子操作    线程同步  ???

        #region 原子操作同步原理
        public static Int32 count;//计数值，用于线程同步（注意原子性，所以本例中使用int23）
        public static Int32 value;//实际运算值，用于显示计算结果
        public static void YuanCall()
        {
            //读线程
            Thread t2 = new Thread(new ThreadStart(Read));
            t2.Start();
            //写线程
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(20);
                Thread thread = new Thread(new ThreadStart(Write));
                thread.Start();
            }
        }
        /// <summary>
        /// 实际运算写操作
        /// </summary>
        private static void Write()
        {
            Int32 temp = 0;
            for (int i = 0; i < 10; i++)
            {
                temp += 1;
            }
            //真正写入
            value += temp;
            Thread.VolatileWrite(ref count,1);
        }
        /// <summary>
        /// 死循环监控读信息
        /// </summary>
        private static void Read()
        {
            while (true)
            {
                if (Thread.VolatileRead(ref count) > 0)
                {
                    Console.WriteLine("累计计数:{1}",Thread.CurrentThread.ManagedThreadId,value);
                    count = 0;
                }
            }
        }
        #endregion

        #endregion









        #region 例子  ???

        #region 单线程执行十亿次添加操作
        public static void DanGetTitleCall()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DanGetTitle();
            sw.Stop();
            Console.WriteLine("增加十亿次执行完成，用时:" + sw.ElapsedMilliseconds + "毫秒");
        }
        public static void DanGetTitle()
        {
            long i = 0;
            for (long j = 1; j <= 1000000000; j++)
            {
                i += j;
            }
            Console.WriteLine(i);
        }
        #endregion

        #region 多线程执行十亿次添加操作
        public static volatile int k = 1;
        public static void DuoGetTitleCall()
        {
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ThreadPool.QueueUserWorkItem(DuoGetTitle);
            Console.WriteLine("增加十亿次执行完成，用时:" + sw.ElapsedMilliseconds + "毫秒");
        }
        public static void DuoGetTitle(object o)
        {
            long i = 0;
            for (long j = 1; j <= 1000000000; j++)
            {
                i += j;
            }
            Console.WriteLine(i);
        }
        #endregion

        #endregion

    }
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
