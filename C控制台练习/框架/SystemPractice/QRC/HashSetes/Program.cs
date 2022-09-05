using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetes
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSets();
            Console.ReadKey();
        }
        /// <summary>
        /// HsahSet主要是用来作集合运算的   交集  并集  差集
        /// </summary>
        public static void HashSets()
        {
            HashSet<string> hs1 = new HashSet<string>();
            hs1.Add("你"); hs1.Add("好"); hs1.Add("吗");
            HashSet<string> hs2 = new HashSet<string>();
            hs2.Add("你"); hs2.Add("好");
            HashSet<string> hs3 = new HashSet<string>();
            hs3.Add("爱你"); hs3.Add("好");

            //确定还是hs2是否是hs1的真子集
            bool b = hs2.IsProperSubsetOf(hs1);
            string result = b == true ? "是真子集" : "不是真子集";
            Console.WriteLine(result);
            //返回并集
            IEnumerable<string> list = hs1.Union(hs3);
            IEnumerable<string> list1 = hs1.Intersect(hs3);
            foreach (string str in list1)
            {
                Console.WriteLine(str);     //输出 你 好 吗 爱你
            }

        }
    }
}
