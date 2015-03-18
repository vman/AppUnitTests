using Microsoft.SharePoint.Client;
using SPRepository.MVCWeb.Interfaces;
using SPRepository.MVCWeb.Repositories;
using SPRepository.MVCWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPRepository.MVCWeb.Controllers
{
    public class HomeController : Controller
    {
         

        [SharePointContextFilter]
        public ActionResult Index()
        {

            var repository = new SharePointRepository(HttpContext);

            var userService = new UserService(repository);
              
            ViewBag.UserName = userService.GetCurrentUserTitle();

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
    }
}
