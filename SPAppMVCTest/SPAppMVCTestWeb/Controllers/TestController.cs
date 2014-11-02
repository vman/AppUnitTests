using SPAppMVCTestWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SPAppMVCTestWeb.Controllers
{
    public class TestController : Controller
    {
        List<QueryStringParamsModel> paramsList;

        [SharePointContextFilter]
        public ActionResult Index()
        {
            var spContext = HttpContext.Session["SPContext"] as SharePointAcsContext;

            ViewBag.ContextToken = spContext.ContextToken;

            ViewBag.ClientId = string.IsNullOrEmpty(WebConfigurationManager.AppSettings.Get("ClientId")) ? WebConfigurationManager.AppSettings.Get("HostedAppName") : WebConfigurationManager.AppSettings.Get("ClientId");

            ViewBag.ClientSecret = string.IsNullOrEmpty(WebConfigurationManager.AppSettings.Get("ClientSecret")) ? WebConfigurationManager.AppSettings.Get("HostedAppSigningKey") : WebConfigurationManager.AppSettings.Get("ClientSecret");

            paramsList = GetQueryStringParams();

            foreach (QueryStringParamsModel q in paramsList)
            {
                ViewBag.QSV = ViewBag.QSV + q.Key + " : " + q.Value;
            }
            
            return View();

        }

        private List<QueryStringParamsModel> GetQueryStringParams()
        {
            var paramList = new List<QueryStringParamsModel>();

            foreach (var key in HttpContext.Request.QueryString.AllKeys)
            {
                var qspm = new QueryStringParamsModel();
                qspm.Key = key;
                qspm.Value = HttpContext.Request.QueryString[key];
                paramList.Add(qspm);
            }

            return paramList;
        }
    }


}