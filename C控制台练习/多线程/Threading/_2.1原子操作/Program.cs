using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CounterNoInterlocked counterNoInterlocked = new CounterNoInterlocked();   //互锁

            Thread t1 = new Thread(() => { TestCounter(counterNoInterlocked); });
            Thread t2 = new Thread(() => { TestCounter(counterNoInterlocked); });
            Thread t3 = new Thread(() => { TestCounter(counterNoInterlocked); });
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine($"没有原子操作的结果:{counterNoInterlocked.Count}");

            CounterWithInterlocked counterWithInterlocked = new CounterWithInterlocked();

            Thread tt1 = new Thread(() => { TestCounter(counterWithInterlocked); });
            Thread tt2 = new Thread(() => { TestCounter(counterWithInterlocked); });
            Thread tt3 = new Thread(() => { TestCounter(counterWithInterlocked); });
            tt1.Start();
            tt2.Start();
            tt3.Start();
            tt1.Join();
            tt2.Join();
            tt3.Join();
            Console.WriteLine($"有原子操作的结果:{counterWithInterlocked.Count}");

            Console.ReadKey();
        }
        static void TestCounter(CounterBase counter)
        {
            for (int i = 0; i < 100000; i++)
            {
                counter.Increment();
                counter.Decrement();
            }
        }
    }
}
