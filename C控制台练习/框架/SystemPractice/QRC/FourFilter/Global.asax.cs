using Autofac;
using Autofac.Integration.Mvc;
using FourFilter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FourFilter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //路径
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //注册过滤器
            GlobalFilters.Filters.Add(new TestHandleErrorAttribute());
            GlobalFilters.Filters.Add(new TestMvcActionFilterAttribute());
            GlobalFilters.Filters.Add(new TestMvcAuthorizeAttribute());



            var builder = new ContainerBuilder();
            //通过程序集注册所有控制器和属性注入
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //单个控制器注入
            builder.RegisterType<Service>().As<IService>();

            #region 集体自动注入（未完成）

            #region 集体自动注入
            //var baseType = typeof(IDependency);
            //var assbembly = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //builder.RegisterAssemblyTypes(assbembly.ToArray())
            //    .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();
            #endregion

            #region 集体自动注入2
            // ContainerBuilder builder = new ContainerBuilder();
            // Assembly assembly = Assembly.Load("FourFilter.Controllers");   //实现类所在的程序集名称
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();  //常用
            //builder.RegisterAssemblyTypes(assembly).Where(t=>t.Name.StartsWith("S")).AsImplementedInterfaces();  //带筛选
            //builder.RegisterAssemblyTypes(assembly).Except<School>().AsImplementedInterfaces();  //带筛选
            //IContainer container = builder.Build();

            //单实现类的用法
            //IStudent student = container.Resolve<IStudent>();
            //student.Add("1001", "Hello");

            //多实现类的用法
            //IEnumerable<IService> animals = container.Resolve<IEnumerable<IService>>();
            //foreach (var item in animals)
            //{
            //item.Sleep();
            //}
            #endregion

            #endregion

            //将依赖性分解器设置为AutoFac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}
