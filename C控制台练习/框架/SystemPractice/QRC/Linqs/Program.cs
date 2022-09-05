using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linqs
{
    #region 对集合操作的相关实体
    //class Student
    //{
    //    public string First { get; set; }
    //    public string Last { get; set; }
    //    public int ID { get; set; }
    //    public string Street { get; set; }
    //    public string City { get; set; }
    //    public List<int> Scores;
    //}

    //class Teacher
    //{
    //    public string First { get; set; }
    //    public string Last { get; set; }
    //    public int ID { get; set; }
    //    public string City { get; set; }
    //}

    //class Market
    //{
    //    public string Name { get; set; }
    //    public string[] Items { get; set; }
    //}
    //class Bouquet
    //{
    //    public List<string> Flowers { get; set; }
    //}
    //class Product
    //{
    //    public string Name { get; set; }
    //    public int CategoryId { get; set; }
    //}

    //class Category
    //{
    //    public int Id { get; set; }
    //    public string CategoryName { get; set; }
    //}
    #endregion

    #region 协变与逆变
    public class Base
    {
        public static void PrintBase(IEnumerable<Base> bases)
        {
            foreach (Base b in bases)
            {
                Console.WriteLine(b);
            }
        }
    }
    #endregion

    class Program:Base
    {
        static void Main(string[] args)
        {
            #region linq对集合的操作
            //    List<Student> students = new List<Student>()
            //    {
            //        new Student { First="Svetlana",
            //        Last="Omelchenko",
            //        ID=111,
            //        Street="123 Main Street",
            //        City="Seattle",
            //        Scores= new List<int> { 97, 92, 81, 60 } },
            //    new Student { First="Claire",
            //        Last="O’Donnell",
            //        ID=112,
            //        Street="124 Main Street",
            //        City="Redmond",
            //        Scores= new List<int> { 75, 84, 91, 39 } },
            //    new Student { First="Sven",
            //        Last="Mortensen",
            //        ID=113,
            //        Street="125 Main Street",
            //        City="Lake City",
            //        Scores= new List<int> { 88, 94, 65, 91 } },
            //    };
            //    List<Teacher> teachers = new List<Teacher>()
            //    {
            //    new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
            //    new Teacher { First="Alex", Last="Robinson", ID=956, City="Redmond" },
            //    new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
            //    };
            //    //var result = (from s in students where s.City == "Seattle" select s.Last).Concat
            //    //(from t in teachers where t.City == "Seattle" select t.Last);
            //    //foreach (var item in result)
            //    //{
            //    //    Console.WriteLine(string.Join(",",item));
            //    //}
            //    //To XML
            //    var studentsToXML = new XElement("Root",
            //        from student in students
            //        let scores = string.Join(",", student.Scores)
            //        select new XElement("Student",
            //                new XElement("First", student.First),
            //                new XElement("Lase", student.Last),
            //                new XElement("Scores", scores)
            //            )
            //        );
            //    Console.WriteLine(studentsToXML);

            //    double[] radii = { 1, 2, 3 };
            //    //IEnumerable<string> output = radii.Select(a => $"{a * a * Math.PI}");
            //    //foreach (string s in output)
            //    //{
            //    //    Console.WriteLine(s);
            //    //}
            //    //不转换数据源的查询
            //    List<string> names = new List<string> { "John", "Rick", "Maggie", "Mary" };
            //    IEnumerable<string> nameQuery = from name in names where name[0] == 'M' select name;
            //    //IEnumerable<string> nameQuery = from name in names where name.StartsWith("M") select name;
            //    foreach (string str in nameQuery)
            //    {
            //        Console.WriteLine(str);
            //    }
            //    //转换数据源的查询
            //    IEnumerable<string> t = from tea in teachers where tea.City == "Redmond" select tea.First;
            //    foreach (var item in t)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    var studentQuery5 = from student in students
            //                        let totalScore = student.Scores[0] + student.Scores[1] +
            //                        student.Scores[2] + student.Scores[3]
            //                        where totalScore / 4 < student.Scores[0]
            //                        select student.Last + "  And  " + student.First;
            //    foreach (string s in studentQuery5)
            //    {
            //        Console.WriteLine(s);
            //    }

            //    string[] planets1 = { "Mercury", "Venus", "Earth", "123", "fds", "Jupiter" };
            //    string[] planets2 = { "Mercury", "Earth", "Mars", "Jupiter" };
            //    IEnumerable<string> query = from plant in planets1.Except(planets2) select plant;//差集（属于第一个集合，不属于第二个集合）
            //    foreach (var item in query)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    IEnumerable<string> query1 = from p in planets1.Intersect(planets2) select p;//交集
            //    foreach (var item in query1)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    IEnumerable<string> query3 = from p in planets1.Union(planets2) select p;//并集
            //    foreach (var item in query3)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    object[] a = { "123", 1122, 3.123 };
            //    var list = a.OfType<string>().Count();
            //    Console.WriteLine($"类型为string的数据有{list}个");

            //    List<Market> markets = new List<Market>
            //    {
            //        new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            //        new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            //        new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
            //    };
            //    IEnumerable<string> name9 = from m in markets where m.Items.All(item => item.Length == 5) select m.Name;
            //    Console.WriteLine(name9);

            //    //投影运算
            //    List<string> words = new List<string>() { "an", "apple", "a", "day" };
            //    var query8 = from word in words select word.Substring(0, 1);
            //    foreach (string s in query8)
            //        Console.WriteLine(s);
            //    List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };
            //    var q1 = from s in phrases
            //             from word in s.Split(' ')
            //             select word;
            //    foreach (string s in q1)
            //        Console.WriteLine(s);
            //    //zip
            //    // An int array with 7 elements.
            //    IEnumerable<int> numbers = new[]
            //    {
            //        1, 2, 3, 4, 5, 6, 7
            //    };
            //    // A char array with 6 elements.
            //    IEnumerable<char> letters = new[]
            //    {
            //        'A', 'B', 'C', 'D', 'E', 'F'
            //    };
            //    List<Bouquet> bouquets = new List<Bouquet>()
            //    {
            //    new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
            //    new Bouquet { Flowers = new List<string> { "tulip", "rose", "orchid" }},
            //    new Bouquet { Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
            //    new Bouquet { Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            //    };
            //    //子数据   List<string>   返回多个
            //    IEnumerable<List<string>> q2 = bouquets.Select(bq => bq.Flowers);
            //    //原子数据   所有的字符串  放在一个集合中，返回
            //    IEnumerable<string> q3 = bouquets.SelectMany(bq => bq.Flowers);
            //    foreach (var q22 in q2)
            //        Console.WriteLine("q2:" + q22);
            //    foreach (var q33 in q3)
            //        Console.WriteLine("q3:" + q33);


            //    //int chunkNumber = 1;
            //    //foreach (int[] chunk in Enumerable.Range(0, 8).Chunk(3))
            //    //{
            //    //    Console.WriteLine($"Chunk {chunkNumber++}:");
            //    //    foreach (int item in chunk)
            //    //    {
            //    //        Console.WriteLine($"    {item}");
            //    //    }

            //    //    Console.WriteLine();
            //    //}

            //    //跳过
            //    int[] grades = { 59, 82, 70, 56, 92, 98, 85 };
            //    IEnumerable<int> lowerGrades = grades.OrderByDescending(g => g).Skip(3);
            //    foreach (var item in lowerGrades)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    int[] amounts = { 5000, 2500, 9000, 8000, 6500, 4000, 1500, 5500 };
            //    //当前值的长度大于当前值*1000
            //    IEnumerable<int> q6 = amounts.SkipWhile((amount, index) => amount > index * 1000);
            //    foreach (var item in q6)
            //        Console.WriteLine(item);
            //    //获取序列中指定位置之前的元素
            //    int[] grade1 = { 59, 82, 70, 56, 92, 98, 85 };
            //    IEnumerable<int> topThreeGrades = grade1.OrderByDescending(grade => grade).Take(3);
            //    string[] fruits = { "apple", "passionfruit", "banana", "mango",
            //              "orange", "blueberry", "grape", "strawberry" };
            //    //值的长度大于索引
            //    IEnumerable<string> q66 = fruits.TakeWhile((fruit, index) => fruits.Length >= index);
            //    //连接查询   Join
            //    List<Product> products = new List<Product>
            //    {
            //        new Product { Name = "Cola", CategoryId = 0 },
            //        new Product { Name = "Tea", CategoryId = 0 },
            //        new Product { Name = "Apple", CategoryId = 1 },
            //        new Product { Name = "Kiwi", CategoryId = 1 },
            //        new Product { Name = "Carrot", CategoryId = 2 },
            //    };

            //    List<Category> categories = new List<Category>
            //    {
            //        new Category { Id = 0, CategoryName = "Beverage" },
            //        new Category { Id = 1, CategoryName = "Fruit" },
            //        new Category { Id = 2, CategoryName = "Vegetable" }
            //    };
            //    //Join
            //    var qq = from product in products
            //             join cate in categories on product.CategoryId equals cate.Id
            //             select new { product.Name, cate.CategoryName };
            //    //生成序列
            //    IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x);
            //    foreach (var item in squares)
            //        Console.WriteLine(item);
            //    //生成重复值的集合
            //    IEnumerable<string> strings = Enumerable.Repeat(" I Like You", 2);
            //    foreach (string str in strings)
            //        Console.WriteLine(str);
            //    //相等运算
            //    List<int> list1 = new List<int>() { 1, 2, 3 };
            //    List<int> list2 = new List<int>() { 1, 2, 3 };
            //    bool equal = list1.SequenceEqual(list2);
            //    Console.WriteLine(equal ? "相等" : "不相等");
            //    //元素运算
            //    string[] fruit6 = { "1","2"};
            //    //Console.WriteLine(fruit6.SingleOrDefault());

            //    //转换数据类型
            //    //https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/linq/converting-data-types
            //    ArrayList array = new ArrayList();
            //    array.Add("mango");
            //    array.Add("apple");
            //    array.Add("lemon");
            //    IEnumerable<string> qw = array.Cast<string>().OrderBy(arr => arr).Select(arr => arr);
            //    foreach (var item in qw)
            //        Console.WriteLine(item);
            //    //int[] score = { 97,92,81,60};
            //    //int[] Country = { 97, 92, 81, 60 };
            //    //IEnumerable<int> scoreQuery = from s in score where s > 80 select s;
            //    //foreach (var item in scoreQuery)
            //    //{
            //    //    Console.WriteLine(item);
            //    //}
            //    //
            //    //var r1 = from s in score where s == 97 select s;
            //    //var r2 = from s in score orderby s ascending select s;
            //    //var r3 = from s in score group s by s;
            //    //var r4 = from s in score join c in Country on s equals c select new {97,98 };
            #endregion

            #region linq对字符串的操作
            //查询某个单词在字符串中出现了多少次
            string text = @"Historically, the world of data and the world of objects" +
          @" have not been well integrated. Programmers work in C# or Visual Basic" +
          @" and also in SQL or XQuery. On the one side are concepts such as classes," +
          @" objects, fields, inheritance, and .NET APIs. On the other side" +
          @" are tables, columns, rows, nodes, and separate languages for dealing with" +
          @" them. Data types often require translation between the two worlds; there are" +
          @" different standard functions. Because the object world has no notion of query, a" +
          @" query can only be represented as a string without compile-time type checking or" +
          @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
          @" objects in memory is often tedious and error-prone.";
            string searchTerm = "data";
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',','-'}, StringSplitOptions.RemoveEmptyEntries);   //这句话一共有多少个单词
            var matchQuery = (from word in source
                             where word.Equals(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                             select word).Count();
            Console.WriteLine($"有{matchQuery}个：{searchTerm}单词");


            //查询包含一组指定词语的句子
            string[] sentences = text.Split(new char[] { '.', '?', '!' });
            string[] wordsToMatch = { "Historically", "data", "integrated" };
            //条件查询思想
            //      首先将文本拆分成句子--sentences，然后再将句子拆分成单次组 --sentence，对于每个数组，先去重，然后再对字符数组和要查找的单词数组执行Intersect（交集）操作，如果相交并且与要查找的字符数组的数量相同（数量相同--全部相交），将在单词中找到所有单词并返回原始句子--select sentence                   
            var sentenceQuery = from sentence in sentences
                                let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                StringSplitOptions.RemoveEmptyEntries)
                                where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()
                                select sentence;
            foreach (string str in sentenceQuery)
                Console.WriteLine(str);

            //查询字符串中的字符
            string aString = "ABCDE99F-J74-12-89A";
            //IsDigit   指定的字符是否分类为十进制数字
            IEnumerable<char> stringQuery = from ch in aString where Char.IsDigit(ch) select ch;
            foreach (var item in stringQuery)
                Console.Write("\t"+item);
            Console.WriteLine();

            //将Linq查询和正则表达式结合在一起

            //根据需要修改此路径，以便它访问您的Visual Studio版本
            string startFolder = @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\";
            //拍摄文件系统的快照
            IEnumerable<System.IO.FileInfo> fileList = GetFiles(startFolder);
            //创建正则表达式以查找所有可视内容
            System.Text.RegularExpressions.Regex searchTerms = new System.Text.RegularExpressions.Regex(@"Visual(Basic|C#|C\+\+|Studio)");
            //搜索每个.htm后缀文件的内容
            //删除where子句以查找更多匹配的值
            //此查询生成匹配的文件列表
            //以及该文件中匹配值的列表
            //注意：在select子句中显示键入“Match”
            var queryMatchingFiles = from file in fileList
                                     where file.Extension == ".htm"
                                     let fileText = System.IO.File.ReadAllText(file.FullName)
                                     let matches = searchTerms.Matches(fileText)
                                     where matches.Count > 0
                                     select new
                                     {
                                         name = file.FullName,
                                         matchedValues = from System.Text.RegularExpressions.Match match in matches
                                                         select match.Value
                                     };
            //执行查询
            Console.WriteLine("The term \"{0}\" was found in:",searchTerms.ToString());


            foreach (var v in queryMatchingFiles)
            {
                //修改路径  然后写入
                //找到匹配项的文件名
                string s = v.name.Substring(startFolder.Length-1);
                Console.WriteLine(s);
                //对于该文件   写出所有匹配的字符串
                foreach (var v2 in v.matchedValues)
                {
                    Console.WriteLine(" "+v2);
                }
            }
            //在调试模式下   保持控制台窗口打开
            Console.WriteLine("Press any key to exit");
            #endregion

            Console.ReadKey();
        }

        #region 将Linq和正则表达式结合在一起
        //此方法假设应用程序具有发现功能
        //指定路径下所有文件夹的权限
        public static IEnumerable<System.IO.FileInfo> GetFiles(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new System.IO.DirectoryNotFoundException();
            }
            string[] fileNames = null;
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();
            fileNames = System.IO.Directory.GetFiles(path,"*.*",System.IO.SearchOption.AllDirectories);
            foreach (string name in fileNames)
            {
                files.Add(new System.IO.FileInfo(name));
            }
            return files;
        }
        #endregion

        #region Linq中的oftype
        public static void LinqOfType()
        {
            List<int> list = new List<int>();
            list.Add(1); list.Add(2); list.Add(3);
            var a = list.OfType<int>();

            Console.WriteLine(a);
        }
        #endregion

        #region 通过反射获取属性   用Linq排序
        public static void PageSortListDiao()
        {
            List<Person> listP = new List<Person>();
            listP.Add(new Person(1, "刘备", 40));
            listP.Add(new Person(2, "张飞", 25));
            listP.Add(new Person(3, "关羽", 21));

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SortName", "Id");
            dic.Add("SortOrder", "ASC");
            Hashtable ht = new Hashtable();
            ht.Add("Age", "30");

            List<Person> ListT = PageSortList(listP, ht);
            foreach (Person p in ListT)
            {
                Console.WriteLine(p.Id);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Age);
            }
        }
        public static List<T> PageSortList<T>(List<T> ListT, Dictionary<string, string> dic)
        {
            string SortName = dic["SortName"];
            string SortOrder = dic["SortOrder"];
            if (!string.IsNullOrEmpty(SortName))
            {
                if (SortOrder.ToLower() == "desc")
                {
                    ListT = ListT.OrderByDescending(m => m.GetType().GetProperty(SortName).GetValue(m, null)).ToList();
                }
                else
                {
                    ListT = ListT.OrderBy(m => m.GetType().GetProperty(SortName).GetValue(m, null)).ToList();
                }
            }
            return ListT;
        }
        #endregion

        #region 分页排序(条件)
        public static List<T> PageSortList<T>(List<T> ListT, Hashtable ht)
        {
            string Key = ht.Cast<DictionaryEntry>().FirstOrDefault().Key.ToString();
            string Value = ht.Cast<DictionaryEntry>().FirstOrDefault().Value.ToString();
            int a = 0;
            bool v = int.TryParse(Value, out a);
            ListT = ListT.Where(m => (int)m.GetType().GetProperty(Key).GetValue(m, null) < a).ToList();
            return ListT;
        }
        #endregion

        #region Linq To Xml
        public static void LinqToXml()
        {
            XElement xml = new XElement(
                "Persons", new XElement("Person",
                new XElement("Name", "刘备"),
                new XElement("Age", "28")
                ),
                new XElement("Person",
                new XElement("Name", "关羽"),
                new XElement("Age", "27")
                )
                );
            xml.Save(@"E:\Xml\XmlToLinq.txt");
        }
        #endregion

        #region Linq转化Object
        public static void LinqToObject()
        {
            string str = "你在他乡还好吗？";
            string[] WordList = new string[] { "他乡", "家庭", "还好", "怎么" };
            int count = WordList.Where(m => m.Contains(m)).Count();
            Console.WriteLine(count);
        }
        #endregion

        #region Linq比较   IEqualityComparer<T>接口
        public static void EqualityComparerDiao()
        {
            People p1 = new People(1, "刘备", 23);
            People p2 = new People(1, "关羽", 22);
            People p3 = new People(1, "张飞", 21);
            List<People> listP1 = new List<People>();
            listP1.Add(p1);
            listP1.Add(p2);
            listP1.Add(p3);

            People p4 = new People(2, "赵云", 23);
            People p5 = new People(2, "黄忠", 22);
            People p6 = new People(2, "马超", 21);
            List<People> listP2 = new List<People>();
            listP2.Add(p4);
            listP2.Add(p5);
            listP2.Add(p6);

            Comparers c = new Comparers();
            bool b = listP1.SequenceEqual(listP2, c);
            Console.WriteLine(b);
        }
        #endregion

        #region Linq比较  IComparer<T> 接口
        public static void ComparerIDiao()
        {
            People p1 = new People(1, "刘备", 23);
            People p2 = new People(1, "关羽", 22);
            People p3 = new People(1, "张飞", 21);
            List<People> listP = new List<People>();
            listP.Add(p1);
            listP.Add(p2);
            listP.Add(p3);

            Comparers c = new Comparers();
            IEnumerable<People> items = listP.OrderBy(m => m, c);
            foreach (People p in items)
            {
                Console.WriteLine(p.Name);  //输出张飞关羽刘备
            }
        }
        #endregion

        #region 
        public class Comparers : IEqualityComparer<People>, IComparer<People>
        {
            public bool Equals(People p1, People p2)
            {
                if (p1.Age == p2.Age)
                {
                    return true;
                }
                return false;
            }
            public int GetHashCode(People obj)
            {
                throw new NotImplementedException();
            }
            public int Compare(People p1, People p2)
            {
                if (p1.Age > p2.Age)
                {
                    return 1;
                }
                else if (p1.Age == p2.Age)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
        public class People
        {
            public People(int id, string name, int age)
            {
                this.Id = id;
                this.Name = name;
                this.Age = age;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Person
        {
            public Person(int id, string name, int age)
            {
                Id = id;
                Name = name;
                Age = age;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        #endregion

    }
}
