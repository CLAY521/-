using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {

            LinqCompare();
            Console.ReadKey();
        }
        /// <summary>
        /// 使用linq得方法进行排序功能的实现
        /// </summary>
        public static void LinqCompare()
        {
            var stus = new List<Student>();
            stus.Add(new Student() { Name = "zhangsan", EnglishGrades = 80.5, MathGrades = 90 });
            stus.Add(new Student() { Name = "lisi", EnglishGrades = 74, MathGrades = 91 });
            stus.Add(new Student() { Name = "wangwu", EnglishGrades = 94, MathGrades = 85.5 });
            stus.Add(new Student() { Name = "zhaoliu", EnglishGrades = 88.5, MathGrades = 86 });
            var orderByStus = from a in stus orderby a.EnglishGrades select a;
            foreach (var stu in orderByStus)
            {
                Console.WriteLine($"Name:{stu.Name},\tEnglish:{stu.EnglishGrades},\tMath:{stu.MathGrades}");
            }
            Console.WriteLine();
            orderByStus = from s in stus orderby s.MathGrades select s;
            foreach (var stu in orderByStus)
            {
                Console.WriteLine($"Name:{stu.Name},\tEnglish:{stu.EnglishGrades},\tMath:{stu.MathGrades}");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 使用接口中的方法比较实现排序功能
        /// </summary>
        public static void Comparable()
        {
            var stus = new List<Student>();
            stus.Add(new Student() { Name="zhangsan",EnglishGrades=80.5,MathGrades=90});
            stus.Add(new Student() { Name="lisi",EnglishGrades=74,MathGrades=91});
            stus.Add(new Student() { Name="wangwu",EnglishGrades=94,MathGrades=85.5});
            stus.Add(new Student() { Name="zhaoliu",EnglishGrades=88.5,MathGrades=86});
            stus.Sort();
            Console.WriteLine("使用默认比较器排序");
            foreach (var stu in stus)
            {
                Console.WriteLine($"Name:{stu.Name},\tEnglish:{stu.EnglishGrades},\tMath:{stu.MathGrades}");
            }
            stus.Sort(new MathComparer());
            Console.WriteLine("使用自定义比较器排序");
            foreach (var stu in stus)
            {
                Console.WriteLine($"Name:{stu.Name},\tEnglish:{stu.EnglishGrades},\tMath:{stu.MathGrades}");
            }
            Console.ReadLine();
        }
    }
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double EnglishGrades { get; set; }
        public double MathGrades { get; set; }
        public int CompareTo(Student stu)
        {
            if (EnglishGrades > stu.EnglishGrades)
            {
                return 1;
            }
            else if (EnglishGrades == stu.EnglishGrades)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class MathComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.MathGrades.CompareTo(y.MathGrades);
        }
    }
}
