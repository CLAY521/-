using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflexReplaceSwitch();
            Console.ReadKey();
        }

        #region 单例模式
        public static void LanDiao()
        {
            SingLeton s1 = SingLeton.GetInstance();
            SingLeton s2 = SingLeton.GetInstance();           //调用静态方法获得实例
            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例");      //输出   两个对象是相同的实例
            }
        }
        public static void EDiao()
        {
            SingLeton2 s1 = SingLeton2.GetInstance();
            SingLeton2 s2 = SingLeton2.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例");
            }
        }
        #endregion

        #region 简单工厂模式
        public static void SimpleDiao()
        {
            DataBase db = SimpleFactory.GetInstance("Oracle");
            Console.WriteLine(db.SelectTopOne());

            DataBase db2 = SimpleFactory.GetInstance("SqlServer");
            Console.WriteLine(db2.SelectTopOne());
        }
        #endregion

        #region 方法工厂模式  
        public static void MethodFactoryDiao()
        {
            IFactory factory = new SqlServerFactory();     //依赖于具体的工厂类，但不依赖于具体的实现
            DataBase2 db = factory.GetDataBase();
            Console.WriteLine(db.SelectTopOne2());
        }
        #endregion

        #region 抽象工厂模式

        #region 抽象工厂形式的调用
        //public static void Abstracts()
        //{
        //    IFactory1 factory = new SqlServerFactory1();

        //    IUser iu = factory.CreateUser();
        //    iu.Insert(new User());
        //    iu.GetUser(1);

        //    IDepartment id = factory.CreateDepartment();
        //    id.Insert(new Department());
        //    id.GetDeptment(1);





        //    IFactory1 factory1 = new AccessFactory1();

        //    IUser iu1 = factory1.CreateUser();
        //    iu1.Insert(new User());
        //    iu1.GetUser(1);

        //    IDepartment id1 = factory1.CreateDepartment();
        //    id1.Insert(new Department());
        //    id1.GetDeptment(1);

        //}
        #endregion

        #region 简单工厂形式的调用
        //public static void Simple()
        //{
        //    IUser iu = DataSwitch.CreateUser();//获取数据库user访问类的对象，更改数据库就要改DataSwitch里面的设置
        //    iu.Insert(new User());
        //    iu.GetUser(1);

        //    IDepartment id = DataSwitch.CreateDepartment();//获得数据库Department访问类的对象，这里没有依赖SqlServerFactory或AccessFactory了（把工厂的具体实现   换成了DataSwitch）
        //    id.Insert(new Department());
        //    id.GetDeptment(1);
        //}
        #endregion

        #region 简单工厂形式之上   用反射替换掉Switch结构
        public static void ReflexReplaceSwitch()
        {
            IUser iu = DataSwitch.CreateUser();
            iu.Insert(new User());
            iu.GetUser(1);

            IDepartment id = DataSwitch.CreateDepartment();
            id.Insert(new Department());
            id.GetDeptment(1);


        }
        #endregion

        #endregion


    }

    #region 单例模式   保证一个类只有一个实例
    public class SingLeton2
    {
        /// <summary>
        /// 饿汉模式(先实例化好，直接调用)
        /// </summary>
        private static readonly SingLeton2 instance = new SingLeton2();
        private SingLeton2()
        {

        }
        public static SingLeton2 GetInstance()
        {
            return instance;
        }
    }
    /// <summary>
    /// 懒汉模式（被引用的时候实例化）
    /// </summary>
    public class SingLeton
    {
        private static SingLeton instance;
        private SingLeton()     //将构造方法设为private   防止外界利用new创建实例
        {

        }
        public static SingLeton GetInstance()// 此方法用于获得本类实例的唯一全局访问点
        {
            if (instance == null)             //若实例不存在则new一个新的实例，否则返回已有实例
            {
                instance = new SingLeton();
            }
            return instance;
        }
    }

    #endregion

    #region 简单工厂模式   根据传入不同的参数   创建不同的对象
    //简单工厂类     
    public class SimpleFactory
    {
        public static DataBase GetInstance(string type)
        {
            DataBase db = null;
            switch (type)
            {
                default:
                case "SqlServer":
                    db = new SqlServer();
                    break;
                case "Oracle":
                    db = new Oracle();
                    break;
            }
            return db;
        }
    }
    //基类
    public class DataBase
    {
        public virtual string SelectTopOne()
        {
            return "查询前1条";
        }
    }
    //实现类1
    public class SqlServer : DataBase
    {
        public override string SelectTopOne()
        {
            return "SqlServer的查询语句";
        }
    }
    //实现类2
    public class Oracle : DataBase
    {
        public override string SelectTopOne()
        {
            return "Oracle的查询语句";
        }
    }
    #endregion

    #region 方法工厂模式  依赖于具体的工厂类，但不依赖于具体的实现
    //数据库类
    public class DataBase2
    {
        public virtual string SelectTopOne2()
        {
            return "查询第一条数据";
        }
    }
    //SqlServer类
    public class SqlServer2 : DataBase2
    {
        public override string SelectTopOne2()
        {
            return "SqlServer";
        }
    }
    //Oracle类
    public class Oracle2 : DataBase2
    {
        public override string SelectTopOne2()
        {
            return "Oracle";
        }
    }
    //总结来说，下面的1个接口两个类实现的就是简单工厂中的switch功能
    //数据库工厂
    interface IFactory
    {
        DataBase2 GetDataBase();
    }
    //SqlServer工厂
    public class SqlServerFactory : IFactory
    {
        public DataBase2 GetDataBase() { return new SqlServer2(); }
    }
    //Oracle工厂
    public class OracleFactory : IFactory
    {
        public DataBase2 GetDataBase() { return new Oracle2(); }
    }
    #endregion

    #region 抽象工厂模式
    public class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    public class Department
    {
        private int _id;
        private string _deptName;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }
    }
    //IUser接口，用于客户端访问，接触与具体数据库访问的耦合
    public interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }
    public class SqlServerUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("Sql Server添加用户");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("Sql Server返填用户");
            return null;
        }
    }
    public class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("Access添加用户");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("Access返填用户");
            return null;
        }
    }
    public interface IDepartment
    {
        void Insert(Department dept);
        Department GetDeptment(int id);
    }
    public class SqlServerDepartment : IDepartment
    {
        public void Insert(Department dept)
        {
            Console.WriteLine("SqlServer添加部门");
        }
        public Department GetDeptment(int id)
        {
            Console.WriteLine("SqlServer返填部门");
            return null;
        }
        
    }
    public class AccessDepartment : IDepartment
    {
        public void Insert(Department dept)
        {
            Console.WriteLine("Access添加部门");
        }
        public Department GetDeptment(int id)
        {
            Console.WriteLine("Access返填部门");
            return null;
        }
    }

    #region 方法工厂形式的具体工厂实现 ---抽象工厂
    //interface IFactory1
    //{
    //    IUser CreateUser();
    //    IDepartment CreateDepartment();
    //}
    ////SQLServer实例化工厂，负责实例化SqlserverUser和SqlserverDepartment
    //class SqlServerFactory1 : IFactory1
    //{
    //    public IUser CreateUser()
    //    {
    //        return new SqlServerUser();
    //    }

    //    public IDepartment CreateDepartment()
    //    {
    //        return new SqlServerDepartment();
    //    }
    //}
    ////Access实例化工厂，负责实例化AccessUser和AccessDepartment
    //class AccessFactory1 : IFactory1
    //{
    //    public IUser CreateUser()
    //    {
    //        return new AccessUser();
    //    }

    //    public IDepartment CreateDepartment()
    //    {
    //        return new AccessDepartment();
    //    }
    //}
    #endregion

    #region 简单工厂形式的具体工厂实现 ---抽象工厂
    //public class DataSwitch
    //{
    //    private static readonly string db = "SqlServer";   //实现就设置好的数据库
    //    //private static readonly string db = "Access";    //也就是说，更改数据库改的就是这里了
    //    public static IUser CreateUser()
    //    {
    //        IUser result = null;
    //        switch (db)
    //        {
    //            case "SqlServer":
    //                result = new SqlServerUser();
    //                break;
    //            case "Access":
    //                result = new AccessUser();
    //                break;
    //        }
    //        return result;
    //    }
    //    public static IDepartment CreateDepartment()
    //    {
    //        IDepartment result = null;
    //        switch (db)
    //        {
    //            case "SqlServer":
    //                result = new SqlServerDepartment();
    //                break;
    //            case "Access":
    //                result = new AccessDepartment();
    //                break;
    //        }
    //        return result;
    //    }
    //}
    #endregion

    #region 简单工厂形式之上   用反射替换掉Switch结构  ---抽象工厂
    public class DataSwitch
    {
        private static readonly string AssemblyName = "DesignMode";                   //程序集的名字
        private static readonly string db = ConfigurationManager.AppSettings["DB"];   //数据库连接字符串

        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";                   //类的命名空间（所在位置）
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);   //反射创建这个实例
        }

        public static IDepartment CreateDepartment()
        {
            string className = AssemblyName + "." + db + "Department";                   //类的命名空间（所在位置）
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);   //反射创建这个实例
        }
    }
    #endregion

    #endregion

}
