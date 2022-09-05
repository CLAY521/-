using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }
        /// <summary>
        /// 所谓的位运算，通常是指将数值型的值从十进制转换成二进制后的运算，由于是对二进制数进行运算，所以使用位运算符对操作数进行运算的速度稍快。
        /// </summary>
        public static void Bits()
        {
            string str = "leetcode";
            int mark = 0;
            int moveStep = 0;
            foreach (char c in str)
            {
                moveStep = (short)c - (short)'a';
                if ((mark & (1 << moveStep)) != 0)
                {
                    Console.WriteLine("false");
                }
                mark |= 1 << moveStep;
            }
            Console.WriteLine("true");
        }

        /// <summary>
        /// 按位求补运算符或称为按位取反运算符，符号位~
        /// 左移运算符，符号为<<
        /// 右移运算符，符号为>>
        /// 按位与运算符，符号为&
        /// 按位或运算符，符号为|
        /// 按位异或运算符,符号为^
        /// </summary>
        public static void Test()
        {
            Console.WriteLine("~按位求补运算符或称为按位取反运算符");
            int num1 = 14;
            int num2 = -15;
            Console.WriteLine("二进制："+ Convert.ToString(num1,2));
            Console.WriteLine(~num1);
            Console.WriteLine("二进制：" + Convert.ToString(~num1, 2));
            Console.WriteLine();
            Console.WriteLine("二进制："+ Convert.ToString(num2, 2));
            Console.WriteLine(~num2);
            Console.WriteLine("二进制：" + Convert.ToString(~num2, 2));

            Console.WriteLine("<<  >>移位运算符");
            Console.WriteLine(14<<1);
            Console.WriteLine(14>>1);

            Console.WriteLine("按位与、或、异运算符");
            Console.WriteLine(13&14);
            Console.WriteLine(13|14);
            Console.WriteLine(13^14);


        }
    }
}
