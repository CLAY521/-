using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//是一个轻量级的依赖注入的框架
namespace AutoFacPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ReturnList();
            Console.ReadKey();
        }

        #region 依赖注入（.Net中的依赖关系注入是框架的内置部分，与配置、日志记录和选项模式一样。）
        //public static void
        #endregion

        #region AutoFacTwo

        #region 组件
        //Start   Basic  Run
        public static void Start()
        {
            ContainerBuilder builder = new ContainerBuilder();//实例化容器类
            #region 组件的创建有4种方式
            //1.类型创建RegisterType
            builder.RegisterType<AutoFacManager>();           //将此类放进容器中
            builder.RegisterType<Worker>().As<IPerson>();     //将此类型放进容器中(对应关系)
            //2.实例创建
            builder.RegisterInstance<AutoFacManager>(new AutoFacManager(new Worker()));
            //3.Lambda表达式创建
            builder.Register(a => new AutoFacManager(a.Resolve<IPerson>()));
            builder.RegisterType<Worker>().As<IPerson>();
            //4.程序集创建
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());   //在当前运行的程序集中找
            builder.RegisterType<Worker>().As<IPerson>();
            #endregion


            using (IContainer container = builder.Build())    //将之前里面有东西的容器创建
            {
                AutoFacManager manager = container.Resolve<AutoFacManager>();//取出第一个放进去的实例
                manager.Say();                                               //执行此实例的方法
            }
        }
        //泛型注册
        public static void ReturnList()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>)).InstancePerLifetimeScope();
            using (IContainer container = builder.Build())
            {
                IList<string> ListString = container.Resolve<IList<string>>();
            }
        }
        //默认的注册
        public static void Default()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<AutoFacManager>();
            builder.RegisterType<Worker>().As<IPerson>();
            builder.RegisterType<Student>().As<IPerson>().PreserveExistingDefaults();//指定Student为默认值
            using (IContainer container = builder.Build())
            {
                AutoFacManager manager = container.Resolve<AutoFacManager>();
                manager.Say();
            }
        }
        #endregion

        #region 服务
        //1.类型
        public static void Types()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Worker>().As<IPerson>();
        }
        //2.名字
        //3.键
        #endregion

        #region 等等等等
        //1.自动装配
        //选择构造函数
        //额外的构造函数参数
        //自动装配
        //2.程序集扫描
        //扫描
        //选择类型
        //指定服务
        //3.事件
        //激活事件
        //4.属性注入
        //5.方法注入
        //1.使用Activator
        //2.Activating Handler
        //6.Resolve的参数
        //传递参数给Resolve
        //可用的参数类型
        //从表达式中使用参数
        //7.元数据
        //在注册的时候添加元数据
        //使用元数据
        //8.循环依赖
        //构造函数/属性依赖
        //9.泛型
        //10.适配器和装饰器
        //适配器
        //装饰器
        //11.实例生命周期
        //Per Dependency
        //Single Instance
        //Per Lifetime Scope
        //上下文
        #endregion

        #region 基本配置的使用
        //1.通过配置的方式使用Autofac
        //<configuration>
        //<conifigSections>
        //<section name="autofac" type="Autofac.Configuration.SectionHandler,Autofac.Configuration"/>
        //</configSections>
        //<autofac defaultAssembly="ConsoleApplication3">
        //<components>
        //<component type="ConsoleApplication3.Worker,ConsoleApplication3" service="ConsoleApplication3.IPerson"/>
        //</Components>
        //</autofac>
        //</configuration>
        //2.通过RegisterModule方式使用配置文件中的信息
        //ContainerBuilder = builder = new ContainerBuilder();
        //builder.RegisterType<AutoFacManager>();
        //builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
        //using(IContainer container = builder.Build())
        //{
        //  AutoFacManager manager = container.Resolve<AutoFacManager>();
        //  manager.Say();
        //}
        //3.通过Register的方式
        //builder.RegisterModule(new ConfigurationSettingsReader("autofac"))
        //builder.Register(c=>new AutoFacManager(c.Resolve<IPerson>()));
        #endregion

        #endregion

        #region AutoFacOne
        public static void One()
        {
            //// 创建容器
            //var builder = new ContainerBuilder();
            ////注册对象
            ////builder.RegisterType<Service>().As<IService>().UsingConstructor(typeof(int), typeof(int));
            //// builder.RegisterType<ServiceTwo>();
            //builder.RegisterType<Service>().As<IService>();
            ////builder.RegisterType<ServiceTwo>().As<IService>().PreserveExistingDefaults();   //不被覆盖
            //builder.RegisterType<ServiceTwo>().OnActivating(e =>
            //{
            //    e.Instance.SetName();
            //});
            //var Container = builder.Build();

            ////使用方法一
            //using (var ioc = Container.BeginLifetimeScope())
            //{
            //    //var service = ioc.Resolve<IService>(new NamedParameter("A", 666), new NamedParameter("B", 888));
            //    var service = ioc.Resolve<ServiceTwo>();
            //    //var serviceList = ioc.Resolve<IEnumerable<IService>>();
            //    //foreach (var item in serviceList)
            //    //{
            //    //    item.ConsoleWord();
            //    //}
            //    service.ConsoleName();
            //}
        }
        #endregion
    }

    #region 依赖注入（.Net中的依赖关系注入是框架的内置部分，与配置、日志记录和选项模式一样。）
    public static class MessageWriter
    {
        public static void Write(string message)
        {
            Console.WriteLine("MessageWriter.Write(Message:\"{ message} \")");
        }
    }
    #endregion

    #region AutoFacTwo
    public interface IPerson
    {
        void Say();
    }

    public class Worker : IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public void Say()
        {
            Console.WriteLine("我是一个工人");
        }
    }

    public class Student : IPerson
    {
        public void Say()
        {
            Console.WriteLine("我是一个学生");
        }
    }

    public class AutoFacManager
    {
        IPerson person;
        public AutoFacManager(IPerson MyPerson)
        {
            person = MyPerson;
        }
        public void Say()
        {
            person.Say();
        }
    }
    #endregion

    #region AutoFacOne
    //public interface IService
    //{
    //    void ConsoleWord();
    //}
    //public class Service : IService
    //{
    //    public Service()
    //    {
    //        Console.WriteLine("我是默认的构造函数");
    //    }
    //    public Service(ServiceTwo two)
    //    {
    //        Console.WriteLine("我是serviceTwo的一个参数构造");
    //    }
    //    public Service(int A)
    //    {
    //        Console.WriteLine("我是service的一个参数构造");
    //    }
    //    public Service(int A, int B)
    //    {
    //        Console.WriteLine($"我是service的两个参数构造{A}和{B}");
    //    }
    //    public void ConsoleWord()
    //    {
    //        Console.WriteLine("我是service打印的Hello word");
    //    }
    //}
    //public class ServiceTwo : IService
    //{
    //    public string name { get; set; }
    //    public void ConsoleName()
    //    {
    //        Console.WriteLine($"我是name属性：{name}");
    //    }
    //    public void SetName()
    //    {
    //        name = "李四";
    //    }
    //    public void ConsoleWord()
    //    {
    //        Console.WriteLine("我是serviceTwo打印的Hello word");
    //    }
    //}
    #endregion
}
