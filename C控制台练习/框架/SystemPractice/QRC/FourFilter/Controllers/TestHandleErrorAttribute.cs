using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourFilter.Controllers
{
    public class TestHandleErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //异常的具体信息
            var exceptionType = filterContext.Exception.InnerException.GetType().FullName;
            var exceptionMessage = filterContext.Exception.InnerException.Message;
            var exceptionMethod = filterContext.Exception.InnerException.TargetSite;
            var exceptionStackTrace = filterContext.Exception.StackTrace;

            //写入日志文件
            filterContext.ExceptionHandled = true;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //返回统一的错误信息
                var result = new Grade();
                filterContext.HttpContext.Response.ContentType = "application/json";
                filterContext.HttpContext.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                filterContext.HttpContext.Response.End();
            }
            else
            {
                //返回同意的错误页面
                filterContext.HttpContext.Response.Redirect("/Home/Error");
                base.OnException(filterContext);
                filterContext.HttpContext.Response.End();
            }
        }
    }
}