using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexHelper
{
    class Program
    {
        private static string mobilePattern = "^1[3|4|5|7|8]\\d{9}$";
        private static string emailPattern = "^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$";
        static void Main(string[] args)
        {
            Console.WriteLine("请依次输入手机号  数字   邮箱");

            bool result = IsMobile(Console.ReadLine());
            Console.WriteLine(result?"您输入的是手机号":"您输入的 不 是手机号");

            bool result1 = IsNum(Console.ReadLine());
            Console.WriteLine(result1 ? "您输入的是数字" : "您输入的 不 是数字");

            bool result2 = IsEmail(Console.ReadLine());
            Console.WriteLine(result2 ? "您输入的是邮箱" : "您输入的 不 是邮箱");


            Console.ReadKey();
        }
        public static bool IsEmail(string email)
        {
            return IsMatch(email,emailPattern);
        }
        public static bool IsNum(string value)
        {
            return IsMatch(value,"^\\d$");
        }
        public static bool IsMobile(string mobile)
        {
            return IsMatch(mobile,mobilePattern);
        }
        public static bool IsMatch(string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(input,pattern,options);
        }
    }
}
