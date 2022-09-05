using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsExceedTime(12, "2022-08-16 23:59:59")?"超出了":"没有超出");


            Console.ReadKey();
        }
        //当前时间是否超出指定时间（的指定小时数）
        public static bool IsExceedTime(int hours, string endTime)
        {
            if (endTime == null) return false;
            if (hours <= 0) return false;

            DateTime time = DateTime.Parse("1970-01-01");
            if (DateTime.TryParse(endTime, out time))
            {
                DateTime now = DateTime.Now;
                double difference = (now - time).TotalHours;
                if (difference > hours) return true;
            }
            return false;
        }
    }
}
