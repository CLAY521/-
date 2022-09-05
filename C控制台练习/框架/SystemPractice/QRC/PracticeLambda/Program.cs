using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lambda表达式
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            //表达式树类型
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);

            int[] numbers = { 2,3,4,5,6};
            var squareNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(",",squareNumbers));

            Action<string> greet = name =>
            {
                string greeting = $"Hellow   {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");


            //元组类型
            //Func < (int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            //var numbers = (2, 3, 4);
            //var doubledNumbers = doubleThem(numbers);
            //Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}");

            Func<int, bool> equalsFive = x => x == 5;
            Func<bool, string> returnString = x => x == true ? "等于5" : "不等于5";
            string resultString = returnString(equalsFive(6));
            Console.WriteLine(resultString);

            int[] number = { 5,4,3,2,1,9,8,7,6,5};
            int oddNumbers = number.Count(n=>n%2==1);
            Console.WriteLine($"There are {oddNumbers} odd numbers in {string.Join(",", number)}");


            var firstNumbers = number.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(",",firstNumbers));

            var numberSets = new List<int[]>
            {
                new[] { 1,2,3,4,5},
                new[] { 0,0,0},  //不大于0
                new[] { 9,8},    //不大于3
                new[] { 1,0,1,0,1,0,1,0}
            };
            var setsWithManyPositives = from s in numberSets where s.Count(n => n > 0) > 3 select s;
            foreach (var s in setsWithManyPositives)
            {
                Console.WriteLine(string.Join(",",s));
            }

            ////表达式的自然类型
            //var parse = (string s) => int.Parse(s);
            //object parse = (string s) => int.Parse(s);
            //Delegate parse = (string s) => int.Parse(s);

            //var choose = (bool b) => b ? 1 : "two";

            //属性
            //Func<string,int> parse = [Example(1)] (s)=>int.Parse(s);

            Console.ReadKey();
        }


    }
}
