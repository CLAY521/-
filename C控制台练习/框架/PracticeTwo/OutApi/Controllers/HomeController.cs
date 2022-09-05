using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OutApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        ///  工厂排单系统接单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //      [Route("factory/orders"), SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResultModel<List<OrderErpListModel>>))]
        //      [HttpGet]
        //      public IHttpActionResult GetSaleOrderList([FromUri]FactoryOrderSearchModel model)
        //      {
        //          var data = _service.GetErpList(model);
        //          return ResultOk(data);
        //      }
    }
}