using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginTest.Controllers
{
    public class Admin
    {
        public Admin()
        {
            Id = 123465;
            Name = "zhangsan";
            Pwd = "123456";
        }
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Pwd { get; set; }
        public int Ids { get; set; }
        public string Names { get; set; }
        public string Pwds { get; set; }
        //public string Salt { get; set; }
        //public string SaltPwd { get; set; }
    }
}