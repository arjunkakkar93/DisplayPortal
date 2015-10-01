using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View();
            return File(Server.MapPath("/Views/Home/") + "Index1.html", "text/html"); 
        }

        // GET: Home
        public ActionResult Google()
        {
            //return View();
            return File(Server.MapPath("/Views/Home/") + "Index2.html", "text/html");
        }


    }
}