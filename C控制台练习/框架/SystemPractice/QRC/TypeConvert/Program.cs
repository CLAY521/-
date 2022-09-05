using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.ReadKey();
        }
        /// <summary>
        /// Parse   如果转换失败，则报错
        /// TryParse如果转换失败，则返回一个false   并且将返回值设置为0    效率高（因为前者   在报异常的时候  对性能造成损耗）
        /// </summary>
        public static void Test()
        {
            double result;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    result = double.Parse("abc");
                }
                catch
                {
                    result = 0;
                }
            }
            sw.Stop();
            Console.WriteLine($"Parse Success,{sw.ElapsedTicks} ticks");

            var sa = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                if (double.TryParse("abc", out result) == false)
                {
                    result = 0;
                }
            }
            sa.Stop();
            Console.WriteLine($"TryParse Success,{sa.ElapsedTicks}ticks");
        }
    }
}
