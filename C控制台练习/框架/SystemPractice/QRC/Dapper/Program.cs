using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Dapper
{
    class Program
    {
        public static string connection = "server=.;database=ERP;uid=sa;pwd=123456;";
        static void Main(string[] args)
        {
            Slects();
            Console.ReadKey();
        }
        public static void Slects()
        {
            string sql = "select * from Student a left join Grade b on a.ClassId = b.Id";
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                var StuList = conn.Query<Student, Grade, Student>(
                    sql,
                    (stu, gra) =>
                    {
                        stu.GradeEntity = gra;
                        return stu;
                    },
                    splitOn: "ClassId")
                    .Distinct()
                    .ToList();
                List<Student> result = StuList.Where(a=>a.IsDel==false).ToList();

            }
        }
    }
}
