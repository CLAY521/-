using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourFilter.Controllers
{
    public interface IBaseService:IDependency
    {
        /// <summary>
        /// 插入错误日志数据
        /// </summary>
        /// <returns></returns>
        int AddErriLog();
        /// <summary>
        /// 插入登录日志
        /// </summary>
        /// <returns></returns>
        int AddLoginLog();
    }
}