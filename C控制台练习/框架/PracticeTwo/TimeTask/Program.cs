using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var time = DateTime.Now.ToString();
                Console.WriteLine(time);
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
