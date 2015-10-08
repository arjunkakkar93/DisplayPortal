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
        public ActionResult FirstSlide()
        {
            //return View();
            return File(Server.MapPath("/Views/Home/") + "FirstSlide.html", "text/html"); 
        }

        // GET: Home
        public ActionResult SecondSlide()
        {
            //return View();
            return File(Server.MapPath("/Views/Home/") + "SecondSlide.html", "text/html");
        }


    }
}