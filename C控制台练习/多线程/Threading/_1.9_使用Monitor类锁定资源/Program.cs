using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threading;
using System.Threading;
using System.Reflection.Emit;

namespace _1._9_使用Monitor类锁定资源
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YaoGuai yaoGuai = new YaoGuai(1000);
            Player p1 = new Player("孙悟空",300);
            Player p2 = new Player("猪八戒",200);


            Thread t1 = new Thread(() => { p1.Attack(yaoGuai); });    //出现已经是0   还在打妖怪的情况
                                                                      //那是因为在妖怪的血还不是0的时候   两个线程就都已经进入了循环里面
            Thread t2 = new Thread(() => { p2.Attack(yaoGuai); });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("===================================");

            YaoGuai yaoGuai2 = new YaoGuai(1000);
            PlayerWithMonitor p3 = new PlayerWithMonitor("孙悟空", 300);        //同一时刻只能有一个线程进入
            PlayerWithMonitor p4 = new PlayerWithMonitor("猪八戒", 180);


            Thread t3 = new Thread(() => { p3.Attack(yaoGuai2); });
            Thread t4 = new Thread(() => { p4.Attack(yaoGuai2); });
            t3.Start();
            t4.Start();
            t3.Join();
            t4.Join();



            Console.WriteLine("===================================");

            YaoGuai yaoGuai3 = new YaoGuai(1000);
            Lock p5 = new Lock("孙悟空", 300);        //同一时刻只能有一个线程进入
            Lock p6 = new Lock("猪八戒", 180);


            Thread t5 = new Thread(() => { p5.Attack(yaoGuai3); });
            Thread t6 = new Thread(() => { p6.Attack(yaoGuai3); });
            t5.Start();
            t6.Start();
            t5.Join();
            t6.Join();


            Console.ReadKey();
        }
    }
}
