#define PI
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QRC
{
    class Program
    {
        delegate int NumberChanger(int n);
        static int num = 10;
        private static readonly object Form_Lock = new object();//锁对象的标准写法
        static void Main(string[] args)
        {
            CunQian();
            Console.ReadKey();
        }

        #region 协变和逆变
        public static void ConvertType()
        {
            
            //只有泛型接口和泛型委托参数支持协变和逆变

            //协变（如果某个返回的类型可以由其派生类替换，那么这个类型就是支持协变的）
            IEnumerable<object> list = new List<string>();//本质上是子类到父类的转换，所以是类型安全的，本质上就是里氏替换原则

            //逆变（如果某个返回的类型可以由其基类替换，那么这个类型就是支持逆变的）
            Action<string> action = new Action<object>((o) => { });
            action("");//看似object转换成string，但实际上，使用action委托传入参数的时候，传入的是一个string类型的参数，然后将string转换成了object，本质上还是派生类到基类的转换，所以是类型安全的。

            //为什么协变和逆变是针对泛型接口或泛型委托参数的？而不能针对泛型类？
            //因为涉及到类型转换，必须考虑类型安全的问题。由于前者本质上就是派生类向基类的转换，遵循里氏替换原则，所以是安全的。而泛型类中是允许定义字段的，字段之间转换就有可能存在类型不安全的情况，但接口和委托都是定义方法的，所以类型安全是必然的。

            
        }
        #endregion

        #region 显示类型转换（强制）和隐式类型转换（子类到父类,精度小的到精度大的）
        public static void ConvertTypeTwo()
        {
            //显示类型转换
            double number = 123456.789;
            int i = (int)number;
        }
        #endregion
        public static void CunQian()
        {
            int a = 0;
            for (var i = 1; i <= 365; i++)
            {
                a = a + i;
            }
            Console.WriteLine(a);
            int b = 0;
            for (var i = 1; i <= 52; i++)
            {
                b = b + i;
            }
            Console.WriteLine(b.ToString()+"0");
        }
        public static void GetSort()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("server=.;database=Test;uid=sa;pwd=123456;"))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    string sql = "select d.学号,sname 姓名,d.成绩,d.排名,d.是否并列 from student inner join (select 学号, 成绩, 排名,case 数量 when '1' then '' else '并列' end 是否并列 from(select b.学号, b.成绩, a.排名, a.数量 from(select count(1) 数量, 排名 from view_ranks group by 排名) as a inner join view_ranks as b on a.排名 = b.排名) c) as d on Student.SId = d.学号 order by 排名 asc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dt);
                        Console.WriteLine("学号" +"\t"+ "姓名" +"\t"+ "成绩" + "\t"+"排名"+"\t" + "是否并列");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Console.Write(dt.Rows[i]["学号"] + "\t");
                            Console.Write(dt.Rows[i]["姓名"] + "\t");
                            Console.Write(dt.Rows[i]["成绩"] + "\t");
                            Console.Write(dt.Rows[i]["排名"] + "\t");
                            Console.WriteLine(dt.Rows[i]["是否并列"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        #region 特性
        //视频学习
        #endregion

        #region 反射
        //视频学习
        #endregion

        #region 多线程

        #region 当前线程
        public static void Current()
        {
            Thread th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine();
        }
        #endregion

        #region 创建线程
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
        }
        public static void StartThread()
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
        }
        #endregion

        #region 管理线程
        public static void CallToChild()
        {
            Console.WriteLine("Child thread starts");
            //线程暂停5000毫秒
            int sleepfor = 5000;
            Console.WriteLine("child thread paused for {0} seconds",sleepfor/1000);
            Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread resumes");
        }
        public static void ChildMain()
        {
            ThreadStart childref = new ThreadStart(CallToChild);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.ReadKey();
        }
        #endregion

        #region 销毁线程
        public static void CallToChildThreada()
        {
            try
            {

                Console.WriteLine("Child thread starts");
                // 计数到 10
                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }
                Console.WriteLine("Child Thread Completed");

            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }

        }
        static void Mainthread()
        {
            ThreadStart childref = new ThreadStart(CallToChildThreada);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            // 停止主线程一段时间
            Thread.Sleep(2000);
            // 现在中止子线程
            Console.WriteLine("In Main: Aborting the Child thread");
            childThread.Abort();
            Console.ReadKey();
        }
        #endregion

        #endregion

        #region 集合

        #region ArrayList(动态数组--自动调整大小)
        public static void ArrayListWrite()
        {
            ArrayList al = new ArrayList();
            Console.WriteLine("Adding some numbers");
            al.Add(45); al.Add(12); al.Add(11); al.Add(22);
            al.Add(78); al.Add(96); al.Add(66); al.Add(33);
            Console.WriteLine("Capacity:{0}", al.Capacity);
            Console.WriteLine("Count:{0}", al.Count);
            Console.WriteLine("Content:");
            foreach (int i in al)
            {
                Console.Write(i.ToString() + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Sorted Content asc");
            al.Sort();
            foreach (int i in al)
            {
                Console.Write(i.ToString() + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Sorted Content desc");
            al.Reverse();
            for (int i = 0; i < al.Count; i++)
            {
                Console.Write(al[i].ToString() + "\t");
            }
            Console.WriteLine();
        }
        #endregion

        #region Hashtable(哈希表--键值对)
        public static void HashTableWrite()
        {
            Hashtable ht = new Hashtable();
            ht.Add("001", "张三"); ht.Add("002", "李四");
            ht.Add("003", "王五"); ht.Add("004", "赵六");
            if (ht.ContainsValue("张三"))
            {
                Console.WriteLine("Is already!!!");
            }
            //获取键的集合
            ICollection key = ht.Keys;
            foreach (string k in key)
            {
                Console.WriteLine(k.ToString() + ":" + ht[k].ToString());
            }
        }
        #endregion

        #region SortedList(排序列表--哈希表和动态数组的组合  键、索引)
        public static void SortedList()
        {
            SortedList sl = new SortedList();
            sl[0] = "123"; sl[1] = "456";
            for (int i = 0; i < sl.Count; i++)
            {
                Console.WriteLine(sl[i].ToString());
            }
            sl.Add("001", "Zara Ali");
            sl.Add("002", "Abida Rehman");
            sl.Add("003", "Joe Holzner");
            sl.Add("004", "Mausam Benazir Nur");
            sl.Add("005", "M. Amlan");
            sl.Add("006", "M. Arif");
            sl.Add("007", "Ritesh Saikia");

            if (sl.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add("008", "Nuha Ali");
            }

            // 获取键的集合
            ICollection key = sl.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }

        }
        #endregion

        #region Stack(堆栈--先进后出的对象集合)
        public static void StackWrite()
        {
            Stack st = new Stack();
            st.Push('1'); st.Push('2');
            st.Push('3'); st.Push('4');
            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            st.Push('V');
            st.Push('H');
            Console.WriteLine("The next poppable value in stack: {0}",
            st.Peek());
            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Removing values ");
            st.Pop();
            st.Pop();
            st.Pop();

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Array a = st.ToArray();
            Console.WriteLine("\nArray item: ");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Queue(队列--先进先出的对象集合)
        public static void QueueWite()
        {
            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
        }
        #endregion

        #region BitArry(点阵列--1和0表示的二进制数组)
        public static void BitArryWrite()
        {
            // 创建两个大小为 8 的点阵列
            BitArray ba1 = new BitArray(8);
            BitArray ba2 = new BitArray(8);
            byte[] a = { 60 };
            byte[] b = { 13 };

            // 把值 60 和 13 存储到点阵列中
            ba1 = new BitArray(a);
            ba2 = new BitArray(b);

            // ba1 的内容
            Console.WriteLine("Bit array ba1: 60");
            for (int i = 0; i < ba1.Count; i++)
            {
                Console.Write("{0,-6} ", ba1[i]);
            }
            Console.WriteLine();

            // ba2 的内容
            Console.WriteLine("Bit array ba2: 13");
            for (int i = 0; i < ba2.Count; i++)
            {
                Console.Write("{0, -6} ", ba2[i]);
            }
            Console.WriteLine();


            BitArray ba3 = new BitArray(8);
            ba3 = ba1.And(ba2);

            // ba3 的内容
            Console.WriteLine("Bit array ba3 after AND operation: 12");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();

            ba3 = ba1.Or(ba2);
            // ba3 的内容
            Console.WriteLine("Bit array ba3 after OR operation: 61");
            for (int i = 0; i < ba3.Count; i++)
            {
                Console.Write("{0, -6} ", ba3[i]);
            }
            Console.WriteLine();
        }
        #endregion
        #endregion

        #region 委托（delegate）

        #region 多播委托调用
        public static void Diao()
        {
            NumberChanger nc = new NumberChanger(AddNum) + new NumberChanger(MultNum);
            //调用多播
            nc(5);
            Console.WriteLine("Value of Num:{0}", getNum());
        }
        #endregion
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }
        #endregion

        #region 预处理器
        public static void Yu()
        {
#if (PI)
            Console.WriteLine("true");
#else
                Console.WriteLine("false");
#endif
        }
        #endregion

        #region 枚举
        enum Day { Sun, Mon, Tue, Web, Thu, Fri, Sat };
        public static void Enums()
        {
            int a = (int)(Day.Sun);
            Console.WriteLine(a);
        }
        #endregion

        #region 多线程 和锁

        #region 线程异常
        public static void TaskException()
        {
            try
            {
                // 定义一个Task类型的List集合
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 30; i++)
                {
                    string str = $"main_{i}";
                    // 开启线程，并把线程添加到集合中
                    taskList.Add(Task.Run(() =>
                    {
                        Console.WriteLine($"{str} 开始了");
                        if (str.Equals("main_5"))
                        {
                            throw new Exception("main_5 发生了异常");
                        }
                        else if (str.Equals("main_11"))
                        {
                            throw new Exception("main_11 发生了异常");
                        }
                        else if (str.Equals("main_18"))
                        {
                            throw new Exception("main_18 发生了异常");
                        }
                        Console.WriteLine($"{str} 结束了");
                    }));
                }

                // 等待所有线程都执行完
                Task.WaitAll(taskList.ToArray());
            }
            catch (AggregateException are)
            {
                foreach (var exception in are.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        #endregion

        #region 线程取消
        public static void TaskCancle()
        {
            try
            {
                //实例化对象
                CancellationTokenSource cts = new CancellationTokenSource();
                //创建task类型的集合
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 20; i++)
                {
                    string str = $"main_{i}";
                    taskList.Add(
                    // 开启线程
                    Task.Run(() =>
                    {
                        try
                        {
                            Console.WriteLine($"{str} 开始了");
                            // 暂停
                            Thread.Sleep(new Random().Next(50, 100) * 10);
                            if (str.Equals("main_5"))
                            {
                                throw new Exception("main_5 发生了异常");
                            }
                            else if (str.Equals("main_11"))
                            {
                                throw new Exception("main_11 发生了异常");
                            }
                            if (cts.IsCancellationRequested == false)
                            {
                                Console.WriteLine($"{str} 结束了");
                            }
                            else
                            {
                                Console.WriteLine($"{str} 线程取消");
                            }

                        }
                        catch (Exception ex)
                        {
                            // 发生了异常，将IsCancellationRequested的值设置为true
                            cts.Cancel();
                        }
                    }, cts.Token));
                }
                //等待所有线程执行完
                Task.WaitAll(taskList.ToArray());
            }
            catch (AggregateException are)
            {
                foreach (var exception in are.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        #endregion

        #region 临时变量
        public static void Temps()
        {
            for (int i = 0; i < 20; i++)
            {
                //定义一个新的变量
                int k = i;
                // 开启线程
                Task.Run(() =>
                {
                    Task.Run(() => Console.WriteLine($"this is {i}_{k}  ThreadId: {Thread.CurrentThread.ManagedThreadId.ToString("00")}"));
                    //Task.Run(() => Console.WriteLine($"this is {i}  ThreadId: {Thread.CurrentThread.ManagedThreadId.ToString("00")}"));
                });
            }
        }
        #endregion

        #region 线程安全
        public static void Threads()
        {
            int snum = 0;
            int anum = 0;
            //创建task类型的集合
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 10000; i++)
            {
                snum++;
            }
            Console.WriteLine(snum);
            for (int j = 0; j < 1500000; j++)
            {
                taskList.Add(Task.Run(() =>
                {
                    
                    lock (Form_Lock)
                    {
                        anum++;
                    }
                }));

            }
            //等待所有线程结束运行
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine(anum);

        }
        #endregion

        #endregion

        #region string.Intern  Lock
        public static void InternCompare(ref string a)
        {
            //string s1 = "Mytest";
            //string s2 = new StringBuilder().Append("My").Append("Test").ToString();
            //string s3 = string.Intern(s2);
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine(s3);
            //Console.WriteLine(s2==s1);
            //Console.WriteLine(s3==s1);

            //string a = new string(new char[] { 'a', 'b', 'c' });
            //object o = String.Copy(a);
            //Console.WriteLine(object.ReferenceEquals(o, a));
            //string result = String.IsInterned(o.ToString());
            //Console.WriteLine(String.Intern(o.ToString()));
            //Console.WriteLine(object.ReferenceEquals(o, String.Intern(a)));
            lock (Form_Lock)
            {
                var b = string.Intern(a);
                Console.WriteLine(b);
            }
        }
        #endregion
    }
    #region 不安全代码(允许在函数中使用指针变量)

    #region 指针变量（另一个变量的地址）
    public class UnsafeVoid
    {
        //static unsafe void Main(string[] args)
        //{
        //    int a = 20;
        //    int* p = &a;
        //    Console.WriteLine("Data is: {0} ", a);
        //    Console.WriteLine("Address is: {0}", (int)p);
        //    Console.ReadKey();
        //}
    }
    #endregion

    #region 使用指针检索数据值
    public class GetUnsafeVoid
    {
        //public static void Main()
        //{
        //    unsafe
        //    {
        //        int a = 20;
        //        int* p = &a;
        //        Console.WriteLine("Data is:{0}",a);
        //        Console.WriteLine("Data is:{0}",p->ToString());
        //        Console.WriteLine("Address is:{0}",(int)p);
        //    }
        //    Console.ReadKey();
        //}
    }
    #endregion

    #region 传递指针作为方法的参数
    public class VoidParams
    {
        public unsafe void swap(int* p, int* q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }
        //public unsafe static void Main()
        //{
        //    VoidParams p = new VoidParams();
        //    int var1 = 10;
        //    int var2 = 20;
        //    int* x = &var1;
        //    int* y = &var2;

        //    Console.WriteLine("Before Swap: var1:{0}, var2: {1}", var1, var2);
        //    p.swap(x, y);

        //    Console.WriteLine("After Swap: var1:{0}, var2: {1}", var1, var2);
        //    Console.ReadKey();
        //}
    }
    #endregion

    #region 使用指针访问数组元素
    public class GetArray
    {
        //public unsafe static void Main()
        //{
        //    int[] list = { 10, 100, 200 };
        //    fixed (int *ptr = list)
        //    //显示指针中数组的地址
        //    for (int i = 0; i < 3; i++)
        //    {
        //        //Console.WriteLine("ptr:{0}", (int)ptr);
        //        //Console.WriteLine("ptr+i:{0}", (int)(ptr+ i));
        //        //Console.WriteLine("*(ptr):{0}", *(ptr));
        //        //Console.WriteLine("*(ptr+i):{0}", *(ptr+i));
        //        Console.WriteLine("Address of list[{0}]={1}", i, (int)(ptr + i));
        //        Console.WriteLine("Value of list[{0}]={1}", i, *(ptr + i));
        //    }
        //    Console.ReadKey();
        //}
    }
    #endregion

    #region 编译不安全代码
       //    为了编译不安全代码，您必须切换到命令行编译器指定 /unsafe 命令行。
       
       //例如，为了编译包含不安全代码的名为 prog1.cs 的程序，需在命令行中输入命令：
       
       //csc /unsafe prog1.cs
       //如果您使用的是 Visual Studio IDE，那么您需要在项目属性中启用不安全代码。
       
       //步骤如下：
       
       //通过双击资源管理器（Solution Explorer）中的属性（properties）节点，打开项目属性（project properties）。
       //点击 Build 标签页。
       //选择选项"Allow unsafe code"。
    #endregion

    #endregion

    #region 匿名方法
    delegate void NumberChanger(int n);
    public class TestDelegate
    {
        static int num = 10;
        public static void AddNum(int p)
        {
            num += p;
            Console.WriteLine("Named Method: {0}", num);
        }

        public static void MultNum(int q)
        {
            num *= q;
            Console.WriteLine("Named Method: {0}", num);
        }
        //static void Main(string[] args)
        //{
        //    //使用匿名方法来创建委托的实例
        //    NumberChanger nc = delegate (int x)
        //    {
        //        Console.WriteLine("Anonymous Method: {0}", x);
        //    };
        //    // 使用匿名方法调用委托
        //    nc(10);

        //    // 使用命名方法实例化委托
        //    nc = new NumberChanger(AddNum);

        //    // 使用命名方法调用委托
        //    nc(5);

        //    // 使用另一个命名方法实例化委托
        //    nc = new NumberChanger(MultNum);

        //    // 使用命名方法调用委托
        //    nc(2);
        //    Console.ReadKey();
        //}
    }
    #endregion

    #region 泛型

    //public class MyGenericArray<T>
    //{
    //    private T[] array;
    //    public MyGenericArray(int size)
    //    {
    //        array = new T[size + 1];
    //    }
    //    public T getItem(int index)
    //    {
    //        return array[index];
    //    }
    //    public void setItem(int index, T value)
    //    {
    //        array[index] = value;
    //    }
    //}
    //public class Tester
    //{
    //    static void Main(string[] args)
    //    {
    //        //声明一个整形数组
    //        MyGenericArray<int> intArray = new MyGenericArray<int>(5);
    //        //设置值
    //        for (int c = 0; c < 6; c++)
    //        {
    //            intArray.setItem(c,c*5);
    //        }
    //        //获取值
    //        for (int c = 0; c < 5; c++)
    //        {
    //            Console.WriteLine(intArray.getItem(c) + " ");
    //        }
    //        Console.WriteLine();
    //        //声明一个字符数组
    //        MyGenericArray<char> chararray = new MyGenericArray<char>(5);
    //        //设置值
    //        for (int c = 0; c < 6; c++)
    //        {
    //            chararray.setItem(c,(char)(c+97));
    //        }
    //        //获取值
    //        for (int c = 0; c < 5; c++)
    //        {
    //            Console.WriteLine(chararray.getItem(c)+" ");
    //        }
    //        Console.WriteLine();
    //        Console.ReadKey();
    //    }
    //}

    #region 泛型（Generic）方法
    //public class ListVoid
    //{
    //    //交换值
    //    static void Swap<T>(ref T lhs, ref T rhs)
    //    {
    //        T temp;
    //        temp = lhs;
    //        lhs = rhs;
    //        rhs = temp;
    //    }
    //    static void Main(string[] args)
    //    {
    //        int a, b;
    //        char c, d;
    //        a = 10;b = 20;
    //        c = 'I';d = 'V';
    //        //在交换之前显示值
    //        // 在交换之前显示值
    //        Console.WriteLine("Int values before calling swap:");
    //        Console.WriteLine("a = {0}, b = {1}", a, b);
    //        Console.WriteLine("Char values before calling swap:");
    //        Console.WriteLine("c = {0}, d = {1}", c, d);
    //        //调用Swap
    //        Swap<int>(ref a, ref b);
    //        Swap<char>(ref c, ref d);
    //        // 在交换之后显示值
    //        Console.WriteLine("Int values after calling swap:");
    //        Console.WriteLine("a = {0}, b = {1}", a, b);
    //        Console.WriteLine("Char values after calling swap:");
    //        Console.WriteLine("c = {0}, d = {1}", c, d);
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region 泛型委托
    //delegate T NumberChanger<T>(T n);
    //public class TestDelegate
    //{
    //    static int num = 10;
    //    public static int AddNum(int p)
    //    {
    //        num += p;
    //        return num;
    //    }
    //    public static int MultNum(int q)
    //    {
    //        num *= q;
    //        return num;
    //    }
    //    public static int getNum()
    //    {
    //        return num;
    //    }
    //    static void Main(string[] args)
    //    {
    //        NumberChanger<int> nc1 = new NumberChanger<int>(AddNum);
    //        NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);
    //        // 使用委托对象调用方法
    //        nc1(25);
    //        Console.WriteLine("Value of Num: {0}", getNum());
    //        nc2(5);
    //        Console.WriteLine("Value of Num: {0}", getNum());
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #endregion

    #region 索引器
    public class IndexedNames
    {
        private string[] namelist = new string[size];
        public static int size = 10;
        public IndexedNames()
        {
            for (int i = 0; i < size; i++)
            {
                namelist[i] = "N. A.";
            }
        }
        public string this[int index]
        {
            get
            {
                string tmp;
                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "超出索引范围";
                }
                return tmp;
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (namelist[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return index;
            }

        }
        public static void Diao()
        {
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "qara";
            names[2] = "Zwara";
            names[3] = "Zarera";
            names[4] = "Zarta";
            names[5] = "Zarwa";
            names[6] = "Zarfa";
            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }

    #endregion

    #region 多态

    #region 重写(抽象类、虚方法、接口)
    public interface Test
    {
         void Te();
    }
    public interface Test1: Test
    {
        void Te1();
    }
    //抽象类
    public abstract class Shape: Test1
    {
        public abstract void area();
        public void Te()
        {
            
        }
        public void Te1()
        {

        }
    }
    public abstract class Shapes: Shape
    {
        public abstract void areas();
    }
    //派生类
    public class Rectangle : Shape
    {
        private int length = 10;
        private int width = 10;
        public override void area()
        {
            Console.WriteLine("面积为：{0}", width * length);
        }
    }
    #endregion

    #region 运算符重载
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public double GetVolume()
        {
            return length * width * height;
        }
        public void setlength(double len)
        {
            length = len;
        }
        public void setwidth(double bre)
        {
            width = bre;
        }

        public void setHeight(double hei)
        {
            height = hei;
        }
        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.length = b.length + c.length;
            box.width = b.width + c.width;
            box.height = b.height + c.height;
            return box;
        }
        public static void Diao()
        {
            Box Box1 = new Box();         // 声明 Box1，类型为 Box
            Box Box2 = new Box();         // 声明 Box2，类型为 Box
            Box Box3 = new Box();         // 声明 Box3，类型为 Box
            double volume = 0.0;          // 体积

            // Box1 详述
            Box1.setlength(6.0);
            Box1.setwidth(7.0);
            Box1.setHeight(5.0);

            // Box2 详述
            Box2.setlength(12.0);
            Box2.setwidth(13.0);
            Box2.setHeight(10.0);

            // Box1 的体积
            volume = Box1.GetVolume();
            Console.WriteLine("Box1 的体积： {0}", volume);

            // Box2 的体积
            volume = Box2.GetVolume();
            Console.WriteLine("Box2 的体积： {0}", volume);

            // 把两个对象相加
            Box3 = Box1 + Box2;

            // Box3 的体积
            volume = Box3.GetVolume();
            Console.WriteLine("Box3 的体积： {0}", volume);
        }
    }
    #endregion

    #region 函数重载(参数个数、类型的不同)
    public class TestData
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    #endregion

    #endregion

    #region 事件

    #region 发布器类
    public class EventTest
    {
        private int value;
        //声明委托
        public delegate void NumManIpulationHandler();
        //声明委托类型的事件
        public event NumManIpulationHandler ChangNum;
        protected virtual void OnNumChanged()
        {
            if (ChangNum != null)
            {
                //事件触发
                ChangNum();
            }
            else
            {
                //事件未触发
                Console.WriteLine("event not fire");
                Console.ReadKey();
            }
        }
        public EventTest()
        {
            int n = 5;
            SetValue(n);

        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
    #endregion

    #region 订阅器类
    public class SubScribEvent
    {
        public static void printf()
        {
            Console.WriteLine("event fire");
            Console.ReadKey();
        }
        //触发
        public static void Diao()
        {
            EventTest e = new EventTest();//实例化对象，第一次没有触发事件
            e.ChangNum += new EventTest.NumManIpulationHandler(printf);//注册事件（把委托类型的方法放进事件中）
            e.SetValue(7);
            e.SetValue(11);
        }
    }
    #endregion

    #region 热水锅炉系统故障排除应用程序
    //锅炉类
    public class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }
        public int GetTemp()
        {
            return temp;
        }
        public int GetPressure()
        {
            return pressure;
        }
    }
    //事件发布器
    public class DelegateBoilerEvent
    {
        public delegate void BoilerLogHandler(string status);
        //基于上面的委托定义事件
        public event BoilerLogHandler BoilerEventLog;
        public void LogProcess()
        {
            string remark = "O.K";
            Boiler b = new Boiler(160, 11);
            int t = b.GetTemp();
            int p = b.GetPressure();
            if (t > 150 || t < 80 || p < 12 || p > 15)
            {
                remark = "Need Maintenance";
            }
            OnBoilerEventLog("-----------------------------------");
            OnBoilerEventLog("\nDateTime: " + DateTime.Now);
            OnBoilerEventLog("\nLogging Info:\n");
            OnBoilerEventLog("Temparature " + t + "\nPressure: " + p);
            OnBoilerEventLog("\nMessage: " + remark);
            OnBoilerEventLog("\n-----------------------------------\n");

        }
        protected void OnBoilerEventLog(string message)
        {
            if (BoilerEventLog != null)
            {
                BoilerEventLog(message);
            }
        }
    }
    //该类保留写入日志文件的条款
    public class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;
        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }
        public void Logger(string info)
        {
            sw.Write(info);
        }
        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
    //事件订阅器
    public class RecordBoilerInfo
    {
        public static void Logger(string info)
        {
            Console.WriteLine(info);
        }
        public static void Diao()
        {
            BoilerInfoLogger filelog = new BoilerInfoLogger("e:\\boiler.txt");
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(Logger);
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
            boilerEvent.LogProcess();
            filelog.Close();
        }
    }
    #endregion

    #endregion
}
