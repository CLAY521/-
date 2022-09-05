using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digui
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Thirty(4);
            Console.WriteLine(a);
            Console.ReadKey();
        }
        public static int Thirty(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Thirty(n - 1) + Thirty(n - 2);//4:     (3:1+1)+(2:1+0)
                
            }
            
        }
    }
}
