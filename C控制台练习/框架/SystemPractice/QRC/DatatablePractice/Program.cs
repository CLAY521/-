using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatatablePractice
{
    class Program
    {
        public delegate int Trancformer(int x);
        static void Main(string[] args)
        {
            ////委托中有两个参数一样  返回值一样的方法   在调用的时候，优先调用后添加的方法（先进后出，一个口儿）
            //Trancformer t = null;
            //t += Square;
            //t += Cube;
            //var i = t(3);
            //Console.WriteLine(i);
            //t -= Cube;
            //var j = t(3);
            //Console.WriteLine(j);

            //int num = 5;
            ///*  Func和Action委托的唯一区别在于Func要有返回值， Action没有返回值 */
            //FirstCalcSquare calFirst = Square;//delegate
            //Console.WriteLine("The square of {0} is {1}.", num, calFirst(num));

            //Func<int, int> funcTest = Program.Square;//Func
            //Console.WriteLine("The square of {0} is {1}.", num, funcTest(num));

            //SecondCalcSquare calSecond = GetSquere;
            //calSecond(num);//delegate

            //Action<int> actionTest = Program.GetSquere;
            //actionTest(num);//Action

            //object[] data = { "one",2,3,"four","five",6};
            //var query = data.OfType<string>();   //OfType根据类型筛选
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            List<Student> list = new List<Student>();
            for (int i = 0; i < 20; i++)
            {
                Student s = new Student();
                s.Age = i + 20;
                s.Name = i.ToString() + "张";
                
                list.Add(s);
            }
            //var result = list.Where(t => t.Age >= 29);
            //var result = from s in list where s.Age >= 35 select s;

            ///var result = list.GroupBy(t=>t.Name);
            //var result = from s in list group s by s.Name;

            //var result = list.Where(a => a.Name.StartsWith("2"));
            //var result = from s in list where s.Name.StartsWith("2") select s;

            //var result = list.OrderByDescending(a=>a.Age);
            //var result = from s in list orderby s.Age descending select s;

            //var result = list.OrderBy(a => a.Age).ThenBy(a=>a.Name);
            //var result = list.OrderByDescending(a => a.Age).ThenBy(a=>a.Name);
            //var result = from s in list orderby s.Age, s.Name select s;


            //Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.ReadKey(); 
        }
        //private delegate int FirstCalcSquare(int input);
        //private static int Square(int input)
        //{
        //    return input * input;
        //}

        //private delegate void SecondCalcSquare(int input);
        //private static void GetSquere(int input)
        //{
        //    Console.WriteLine("The square of {0} is {1}.", input, input * input);
        //}
        //public static int Square(int x)
        //{
        //    var result = x * x;
        //    return result;
        //}
        //public static int Cube(int x)
        //{
        //    var result = x;
        //    return result;
        //} 
        public void CreateDatatable()
        {
            //创建表
            DataTable dt = new DataTable("表名");

            DataSet ds = new DataSet();
            DataTable dt1 = ds.Tables.Add("Customers");

            DataSet ds1 = new DataSet();
            DataTable dt2 = new DataTable("表名1");
            ds1.Tables.Add(dt2);
            //添加列
            dt.Columns.Add("Id",typeof(Int32));
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
