using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using U7MVC.Models;

namespace U7MVC.Controllers
{
    public class HomeController : Controller
    {
        //RabbitContext db = new RabbitContext();
        RabbitClubEntitiesConnection db = new RabbitClubEntitiesConnection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Member()
        {
            var member = db.v_Members;
            ViewBag.Members = member;

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