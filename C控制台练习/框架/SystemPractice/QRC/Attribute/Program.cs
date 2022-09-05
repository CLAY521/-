//#define TRACE_ON
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public class Trace
    {
        [Conditional("TRACE_ON")]
        public static void Msg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    /// <summary>
    /// 特性：用于在运行时传递程序中各种元素的行为信息的声明性标签
    ///       预定义特性和自定义特性
    ///       特性就是一个类，直接或间接继承Attribute
    /// 语法：特性的名称和值都是放在方括号内的，放置在它所应用的元素之前。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            Manager.Show(stu);
            //Trace.Msg("Now in main");
            //Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }

    #region 预定义特性
    //Obsolete标记   第一个参数为提示信息   第二个参数为true是错误  为false是警告
    [Obsolete("请不要使用该类了，已经过时了，请使用什么代替",false)]
    [Custom("这是Custom自定义特性")]
    public class Student
    {
        public int Id { get; set; }
        [Custom("这是Name属性")]
        [Custom("这是Name的第二个属性")]
        public string Name { get; set; }
        public string Tel { get; set; }
        public bool Sex { get; set; }
        public int ClassId { get; set; }
        public bool IsDel { get; set; }
        public string Photo { get; set; }
        [Custom("这是Answer方法")]
        [return:Custom("返回string类型")]
        public string Answer([Custom("这是Answer方法参数:NAME")]string name)
        {

            return $"This is {name}";
        }
    }
    #endregion

    #region 自定义特性
    /// <summary>
    /// 1.声明自定义特性
    /// 2.构建自定义特性
    /// 3.在目标程序元素上应用自定义特性
    /// 4.通过反射访问特性
    /// 
    /// Attribute  
    /// 1.AttributeTargets的枚举值表示Custom特性可以应用在哪些目标上面。例如：AttributeTargets的枚举值是Class，则表示      CustomAttribute只能应用在类上面。这里枚举值是All，表示可以在任何类型上面使用该特性。默认情况下枚举值是All。
    /// 2.这里AllowMultiple的值为true，表示可以在类型上面多次使用该特性。如果为false，则表示只能使用一次。默认情况下是     false。
    /// 3.Inherited表示该特性是否可以由子类继承：默认为true
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class CustomAttribute : Attribute
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public CustomAttribute()
        {

        }
        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="description"></param>
        public CustomAttribute(string description)
        {
            this.Description = description;
        }
        /// <summary>
        /// 属性
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        public string Remark = null;
        public void Show()
        {
            Console.WriteLine(Description);
        }
    }

    #region 通过反射访问特性
    public class Manager
    {
        public static void Show(Student stu)
        {
            //获取类型
            //Type type = typeof(Student);
            Type type = stu.GetType();

            //获取类型上面的特性   type.IsDefined表示找特性
            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                //获取CustomAttribute特性的对象--type.GetCustomAttribute(typeof(CustomAttribute), true)
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }

            //获取属性上面定义的特性
            PropertyInfo property = type.GetProperties()[1];
            if (property.IsDefined(typeof(CustomAttribute), true))
            {
                //获取CustomAttribute特性的对象--type.GetCustomAttribute(typeof(CustomAttribute), true)
                CustomAttribute attribute = (CustomAttribute)property.GetCustomAttributes(typeof(CustomAttribute), true)[1];
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }
            //获取方法上面定义的特性
            MethodInfo method = type.GetMethod("Answer");
            if (method.IsDefined(typeof(CustomAttribute), true))
            {
                //获取CustomAttribute特性的对象--type.GetCustomAttribute(typeof(CustomAttribute), true)
                CustomAttribute attribute = (CustomAttribute)method.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }
            //获取参数定义的特性
            ParameterInfo para = method.GetParameters()[0];
            if (para.IsDefined(typeof(CustomAttribute), true))
            {
                //获取CustomAttribute特性的对象--type.GetCustomAttribute(typeof(CustomAttribute), true)
                CustomAttribute attribute = (CustomAttribute)para.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }
            //获取返回值定义的特性
            ParameterInfo returnValue = method.ReturnParameter;
            if (returnValue.IsDefined(typeof(CustomAttribute), true))
            {
                //获取CustomAttribute特性的对象--type.GetCustomAttribute(typeof(CustomAttribute), true)
                CustomAttribute attribute = (CustomAttribute)returnValue.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();
            }
            string result = stu.Answer("Tom");
            Console.WriteLine(result);
        }
    }
    #endregion

    #endregion
}
