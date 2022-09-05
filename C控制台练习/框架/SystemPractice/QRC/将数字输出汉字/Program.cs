using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 将数字输出汉字
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserState user = UserState.Normal;
            //Console.WriteLine(user.GetRemark());
            //user = UserState.Forzen;
            //Console.WriteLine(user.GetRemark());
            //user = UserState.Deleted;
            //Console.WriteLine(user.GetRemark());

            Int32 i = 1;
            Console.WriteLine(i.Get());
            string a =null;
            Console.WriteLine(a.Get());
            Console.ReadKey();
        }

        public enum UserState
        {
            [Remark("正常")]
            Normal=0,//正常
            [Remark("冻结")]
            Forzen =1,//冻结
            [Remark("删除")]
            Deleted =2//删除
        }
    }
    public static class IntExtension
    {
        public static string Get(this Int32 value)
        {
            return "调用到了get方法";
        }
    }
    public static class StringExtension
    {
        public static string Get(this string value)
        {
            return "调用到了String的扩展方法";
        }
    }
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        public static string GetRemark(this Enum value)
        {
            //获取类型
            Type type = value.GetType();
            //获取字段
            FieldInfo field = type.GetField(value.ToString());
            //判断字段上是否有这个特性
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return value.ToString();
            }
        }
    }
    /// <summary>
    /// 定义特性
    /// </summary>
    public class RemarkAttribute : Attribute
    {
        private string _Remark = null;
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
        public string GetRemark()
        {
            return _Remark;
        }
    }
}
