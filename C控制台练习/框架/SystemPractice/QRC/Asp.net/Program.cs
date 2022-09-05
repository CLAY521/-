using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;

namespace Asp.net
{
    #region 常用类库之.net中的字符串

    #region 字符串的特性
    //1.不可变性
    //   由于字符串是不可变的的，每次修改字符串，都是创建了一个单独字符串副本（拷贝了一个字符串副本）。之所以发生改变只是因为指向了一块新的地址。

    //2.字符串池（只针对字符串常量）
    //  当一个程序中有多个相同的字符串常量时，多个变量指向的是内存中同一块字符串！这个特性叫字符串池。之所以字符串，不会造成程序混乱，是因为字符串的不可变性。
    #endregion

    #region string的成员方法和属性
    //    1.Contains(String str)  判断字符串中是否包含，指定字符串。

    //    用法

    //      string str = "helloworld";

    //    str.Contains("hello");   //true 

    //2.StartsWith(String str)

    //          判断字符串对象是否以，指定字符串开头。

    //3.EndWith(String str)

    //         判断字符串对象是否以，指定字符串结尾。

    //4.Length 属性

    //         获取字符串的长度

    //5.IndexOf(String str)

    //         获取指定字符/字符串.....在对象字符串中第一次出现的位置。

    //6.LastIndexOf(String str)

    //         获取指定字符/字符串....在对象字符串中最后一次 出现的位置。

    //7.SubString(int start)

    //   SubString(int strat, int length)   从指定位置，截取字符串。

    //8.ToLower()

    //        将串转换成小写，返回一个新的全小写的字符串。

    //9.ToUpper()

    //       将串转换成大写，返回一个新的全大写的字符串。

    //10. Replace(string oldStr, string newStr)

    //        用新的字符串，替换对象字符串中老的字符串部分。

    //11.Trim()   去掉对象字符串两端的空格

    //        TrimStart() 去掉对象字符串 开头的空格

    //        TrimEnd()  去掉对象字符串 结尾的空格

    //        PS：如果想去掉其他的开头结尾的其他字符其他的字符，可以采用Trim()的其他重载。

    //12.Split()     把对象字符串，按照指定字符分割成一个字符串数组！

    //     Split()    的重载同样很多，

    //     例如 Split(new char[]{'|'}, StringSplitOption.RemoveEmptyEntries)// 删除空数据
    #endregion

    #region string的静态方法
    //    1.IsNullOrEmpty(string)

    //       //string.IsNullOrEmpty(str1) 判断某字符串是否为null，或者为空字符串。

    //2.Equals(string, string, StringComparison.OrdianlIgnore)
    //        忽略大小写比较两个字符串是否相同。
    //3.Join(string, string[])
    //        把一个数组按照指定字符串，拼接成一个字符串。
    //public class a
    //{
    //    public static void Main()
    //    {
    //        string[] aa = { "1234ab456", "123", "789" };
    //        Console.WriteLine(string.Join("\t", aa));
    //        Console.ReadKey();
    //    }

    //}
    #endregion
    #endregion

    #region ref（传入参数之前对其进行初始化） out（在方法中对其进行初始化）
    public class RefOut
    {
        public static void Main()
        {
            int number = 50;
            //out
            Console.WriteLine("out调用方法前 number 值：" + number);
            RefFunction(out number);
            Console.WriteLine("out调用方法后 number 值：" + number);
            int number1 = 50;
            //ref
            Console.WriteLine("ref调用方法前 number 值：" + number1);
            RefFunctionref(ref number1);
            Console.WriteLine("ref调用方法后 number 值：" + number1);
            Console.ReadKey();
        }
        /// <summary>
        /// ref
        /// </summary>
        /// <param name="num"></param>
        static void RefFunctionref(ref int num)
        {
            num = num / 2;
        }
        /// <summary>
        /// out
        /// </summary>
        /// <param name="num"></param>
        static void RefFunction(out int num)
        {
            num = 50;
            num = num / 2;
        }
    }
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion
}
