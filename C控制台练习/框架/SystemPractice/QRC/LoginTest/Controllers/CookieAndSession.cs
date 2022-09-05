using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginTest.Controllers
{
    public class CookieAndSession
    {

        #region Cookie
        private readonly HttpContextBase _httpContextBase;
        public CookieAndSession(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }
        //获取cookie
        public HttpCookie Get()
        {
            return _httpContextBase.Request.Cookies[""];
        }
        //查找cookie是否存在
        public bool Exists()
        {
            var cookie = Get();
            return cookie != null && !string.IsNullOrEmpty(cookie.Value);
        }
        //移除cookie
        public void Remove()
        {
            var cookie = Get();
            if (cookie != null)
            {
                cookie.Values.Clear();
                cookie.Expires = DateTime.Now.AddYears(-100);
                _httpContextBase.Response.Cookies.Add(cookie);
                _httpContextBase.Request.Cookies.Add(cookie);
            }
        }
        //设置cookie
        public void SetCookie(string value)
        {
            var cookie = new HttpCookie("");
            cookie.Value = value;
            Remove();
            _httpContextBase.Response.Cookies.Add(cookie);
            _httpContextBase.Request.Cookies.Add(cookie);
        }
        public void SetCookie(bool httpOnly, string path, string value, bool secure, string domain)
        {
            var cookie = new HttpCookie("");
            //获取或设置一个值，该值指定客户端脚本是否可以访问cookie
            cookie.HttpOnly = httpOnly;
            //获取或设置要与当前cookie一起传输的虚拟路径。
            cookie.Path = path;
            //cookie的值
            cookie.Value = value;
            //获取或设置与cookie关联的域。
            cookie.Domain = domain;
            //获取或设置一个值，该值指示是否使用安全套接字层（SSL）——即仅通过HTTPS传输cookie
            cookie.Secure = secure;
            Remove();
            _httpContextBase.Response.Cookies.Add(cookie);
            _httpContextBase.Request.Cookies.Add(cookie);
        }
        public void SetCookie(string value, DateTime expires)
        {
            var cookie = new HttpCookie("");
            cookie.Value = value;
            //过期时间
            cookie.Expires = expires;
            Remove();
            _httpContextBase.Response.Cookies.Add(cookie);
            _httpContextBase.Request.Cookies.Add(cookie);
        }
        #endregion

        #region Session
        public void Session()
        {
            //详情请见HomeController中的LoginAction
        }
        #endregion

    }
}