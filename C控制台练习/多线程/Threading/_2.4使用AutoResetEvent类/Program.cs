using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4使用AutoResetEvent类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //先写入   后读取    让线程等待写入成功后在读取
            Sample1.Start();
            Console.WriteLine("=========================");
            Sample2.Start();

            Console.ReadKey();
        }
    }
}
