using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string tblName = string.Format("dbo.{0}", (typeof(PersonEntity).Name).Replace("Entity",""));
            Console.WriteLine(tblName);
            Console.ReadKey();
        }
    }
    public class MyList<T>where T:class
    {
        List<T> list = new List<T>();
        public T this[int i]
        {
            get { return list[i]; }
            set { this.list[i] = value; }
        }
    }
    [Serializable]
    public class PersonEntity
    {
        MyList<PersonEntity> list = new MyList<PersonEntity>();
        public string Name { get; set; }
    }
}
