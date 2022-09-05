using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndAction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ListInt = new List<int>() { 1,2,3,4,5};
            ArrayList k = new ArrayList();
            k.Capacity = ListInt.Count;

            k.Add(ListInt.First999(m=>m>3));
            k.Add(ListInt.First999(m => m > 3));

            for (int i=0;i<k.Count;i++)
            {
                Console.WriteLine(k[i]);
            }
            Console.ReadKey();
        }

        #region Func和Action内置委托
        public static void SayHello(string str)
        {
            Console.WriteLine();
        }
        public static string SayHello()
        {
            return "Hello";
        }
        public static string SayHello(string str1,string str2)
        {
            return str1+str2;
        }
        /// <summary>
        /// 有返回值    支持lambda调用
        /// </summary>
        public static void Func()
        {
            Console.WriteLine("Func内置委托");
            Func<string, string,string> say = SayHello;
            string str = say("abc","bca");
            Console.WriteLine(str);
        }
        /// <summary>
        /// 无返回值   支持lambda调用
        /// </summary>
        public static void Action()
        {
            Console.WriteLine("Action内置委托");
            Action<string> ac = SayHello;
        }
        #endregion

    }
    /// <summary>
    /// 常见的   func在方法的参数中
    /// </summary>
    static class Extend
    {
        public static TSource First999<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            //.Net本身的源代码好多异常情况处理，好多设计模式，我也不懂，只提取逻辑
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return (item);
                }
            }
            throw new Exception("不存在满足条件的第一个元素！");
        }
    }
}
