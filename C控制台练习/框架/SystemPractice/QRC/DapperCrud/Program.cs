using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Timers;
using System.Diagnostics;

namespace DapperCrud
{
    class Program
    {
        public static string connection = "server=.;database=ERP;uid=sa;pwd=123456;";
        
        static void Main(string[] args)
        {
            Slects();
            Console.ReadKey();
        }
        /// <summary>
        /// 查询多映射（一对一）  缓存未开启
        /// </summary>
        public static List<Student> Slects()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
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
                    splitOn: "Id", buffered: true)
                    .Distinct()
                    .ToList();
                List<Student> result = StuList.Where(a => a.IsDel == false).ToList();
                time.Stop();
                Console.WriteLine("buffered->true:{0}", time.Elapsed.TotalMilliseconds);
                return result;
            }
        }
        /// <summary>
        /// 查询多映射（一对一） 缓存开启
        /// </summary>
        public static List<Student> SlectSame()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
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
                    splitOn: "Id", buffered: false)
                    .Distinct()
                    .ToList();
                List<Student> result = StuList.Where(a => a.IsDel == false).ToList();
                time.Stop();
                Console.WriteLine("buffered->false:{0}", time.Elapsed.TotalMilliseconds);
                return result;
            }
        }
        //同时执行多条查询语句  同步   存储过程（commandType: CommandType.StoredProcedure）->在sql和参数后面
        public static void QueryMultiples()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            string sql = "select * from Student;select * from Grade";
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                using (var multi = conn.QueryMultiple(sql))
                {
                    var stu = multi.Read<Student>().ToList();
                    var grade = multi.Read<Grade>().ToList();
                    if (stu != null)
                    {
                        time.Stop();
                        Console.WriteLine("同步:{0}", time.Elapsed.TotalMilliseconds);
                    }
                }  
            }
            
        }
        //同时执行多条查询语句   异步（Result）   事务transaction
        public static void QueryMultiplesAsync()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            string sql = "select * from Student;select * from Grade";
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (var multi = conn.QueryMultipleAsync(sql, transaction: transaction).Result)
                        {
                            var stu = multi.Read<Student>().ToList();
                            var grade = multi.Read<Grade>().ToList();
                            if (stu != null)
                            {
                                time.Stop();
                                Console.WriteLine("异步:{0}", time.Elapsed.TotalMilliseconds);
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    
                }
                    
            }
            
        }


    }
}
