using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = EnumHelper<Sex>.GetText(0);
            Console.WriteLine(text);

            Sex Value = EnumHelper<Sex>.GetEnum(EnumHelper<Sex>.GetText(0));
            Console.WriteLine(Value);
            Console.ReadKey();
        }
    }
    public class EnumHelper<T> where T : struct
    {
        /// <summary>
        /// 将枚举转换为字符串
        /// </summary>
        /// <param name="enumInstance"></param>
        /// <returns></returns>
        public static string GetText(T enumInstance)
        {
            Type t = typeof(T);
            FieldInfo[] fieldInfoList = t.GetFields();

            var query = from q in fieldInfoList
                        where q.GetCustomAttributes(typeof(DescriptionAttribute), false).Length > 0
                        && string.Equals(q.Name, enumInstance.ToString(), StringComparison.CurrentCultureIgnoreCase)
                        select ((DescriptionAttribute)q.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
            if (query != null && query.Count() > 0)
            {
                return query.First<string>();
            }
            return null;
        }
        /// <summary>
        /// 将字符串转换为枚举
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static T GetEnum(string Value)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                Type t = typeof(T);
                FieldInfo field = t.GetField(Value);
            }
            T e = default(T);
            System.Enum.TryParse<T>(Value,out e);
            return e;
        }
    }
    public enum Sex
    {
        [Description("男")]
        Man=0,
        [Description("女")]
        Woman =1,
        [Description("不男不女")]
        Not =2
    }
}
