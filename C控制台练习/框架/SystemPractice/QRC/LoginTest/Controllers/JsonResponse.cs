using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTest.Controllers
{
    public class JsonResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public JsonResponse()
        {
            this.Message = string.Empty;
            this.Success = false;
        }
        public JsonResult ToJsonResult()
        {
            return new JsonResult { Data=this};
        }
    }
}