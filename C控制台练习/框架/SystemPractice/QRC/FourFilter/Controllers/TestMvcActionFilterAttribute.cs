using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourFilter.Controllers
{
    public class TestMvcActionFilterAttribute:ActionFilterAttribute
    {
        /// <summary>
        /// 执行中
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnActionExecuting\t");
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 执行结束
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnActionExecuted\t");
            base.OnActionExecuted(filterContext);
        }
        /// <summary>
        /// 生成结果中
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting\t");
            base.OnResultExecuting(filterContext);
        }
        /// <summary>
        /// 生成结果结束
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting\t");
            base.OnResultExecuted(filterContext);
        }
    }
}