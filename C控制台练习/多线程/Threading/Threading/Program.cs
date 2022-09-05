using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Common.PringNumbersWithDelay);
            thread.Start();
            Common.PringNumbers();

            Console.ReadKey();
        }
    }
}
