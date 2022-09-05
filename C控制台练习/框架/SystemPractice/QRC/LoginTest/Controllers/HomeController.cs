
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var a = redis.Program.GetStringRedis("EPFAC:UserModule:333966554896962");
            return View();
        }

        #region 登录

        public ActionResult Login(string name,string pwd)
        {
            #region 演习1
            ////设置session
            //Session["UserName"] = "张三";
            ////获取session
            //string str = Session["UserName"].ToString();
            ////清除session
            //Session["UserName"] = null;
            //Session.Remove("UserName");
            ////清除全部Session
            //Session.Abandon();
            //Session.RemoveAll();

            //bool pass = true;
            //if (name == "admin" && pwd == "123456")
            //{
            //    AddTicket();  //添加票据
            //    //添加日志
            //    BuildAccess("登录成功");
            //    return Content("登录成功");
            //}
            //else
            //{
            //    BuildAccess("账号或密码输入错误");
            //    return Content("账号或密码输入错误");
            //}
            #endregion

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                throw new Exception("账号或密码不能为空");
            }
            if (name != "zhangsan" || pwd != "123456")
            {
                throw new Exception("账号或密码错误");
            }
            //把当前用户的信息存在redis中
            //把当前用户的信息加密写入cookie中
            AddTicket(name);
            //记录日志
            BuildAccess($"{name}登陆成功,{DateTime.Now}");
            return RedirectToAction("About", "Home");
            
        }

        #endregion

        #region 日志
        public void BuildAccess(string result)
        {
            LogHelper.InfoLog(result, null, Log4NetLevel.Info);
        }
        #endregion

        #region 演习1
        //public ActionResult Find()
        //{

        ////获取cookie
        //HttpCookie cookie = Request.Cookies["Login:admin"];
        //string values = cookie.Value;
        //var result = redis.Program.GetStringRedis("Login:admin");
        //var encryTicket = FormsAuthentication.Decrypt(values);  //解密
        //if (result != null)
        //{
        //    if (values == result)
        //    {
        //        return Content($"用户是{encryTicket.Name},\n并且将老的redis和cookie的过期时间  重新设置，因为用户有了新的操作");
        //    }
        //    else
        //    {
        //        return Content("没有登录或已在其他地方登录");
        //    }
        //}
        //else
        //{
        //    return Content("");
        //}

        //}
        #endregion

        #region  主页
        public ActionResult About()
        {
            if (Session["AdminKey"] ==null|| Session["ModuleKey"]==null)
            {
                ViewBag.msg = "还没有登录";
                return View();
            }
            string key = Session["AdminKey"].ToString();
            Admin admin = (Admin)Session["ModuleKey"];
            if (Request.Cookies[key] == null || redis.Program.GetStringRedis(key) == null)
            {
                ViewBag.msg = "还没有登录";
                return View();
            }
            HttpCookie cookie = Request.Cookies[key];
            string values = cookie.Value;
            var result = redis.Program.GetStringRedis(key);
            if (result == values)
            {
                var encryTicket = FormsAuthentication.Decrypt(values);  //解密
                ViewBag.msg = $"欢迎您，用户{encryTicket.Name}!";
                return View();
            }
            else
            {
                ViewBag.msg = "还没有登录";
                return View();
            }
        }
        #endregion

        #region 退出
        public ActionResult Exit()
        {
            //清除session
            Session.RemoveAll();
            //清除cookie
            HttpCookie cookie = new HttpCookie("Login:zhangsan");
            cookie.Expires = DateTime.Now.AddDays(-1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            //删除票据
            //FormsAuthentication.SignOut();
            //清除redis的module和admin信息
            redis.Program.DeleteStringRedis("Login:zhangsan,Login:Modules");
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Ticket   Cookie  Session
        public void AddTicket(string name)
        {
            var ticket = new FormsAuthenticationTicket(
                2,
                name,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                $"Login:{name}"
                );
            var encryTicket = FormsAuthentication.Encrypt(ticket);//加密票据
            var cookie = new HttpCookie(ticket.UserData);
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddHours(1);
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Value = encryTicket;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            Response.Cookies.Add(cookie);//添加cookie
            //添加session
            Session["AdminKey"] = ticket.UserData;
            

            //添加缓存
            redis.Program.StringRedis(ticket.UserData,encryTicket);
            Admin admin = new Admin
            {
                Ids = 123465,
                Names = "zhangsan",
                Pwds = "123456"
            };
            Session["ModuleKey"] = admin;
            string adminInfo = JsonConvert.SerializeObject(admin);
            
            redis.Program.StringRedis("Login:Modules",adminInfo);
        }
        #endregion

    }
}