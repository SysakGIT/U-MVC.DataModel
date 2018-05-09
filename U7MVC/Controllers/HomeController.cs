using System;
using System.IO;
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
            var news = db.News;
            ViewBag.News = news;
            return View();
        }
        public ActionResult AddNews()
        {
            var news = db.News;
            ViewBag.News = news;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewsSave(  News n)
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                Stream fileStream = Request.Files[file].InputStream;
                byte[] fileData = new byte[hpf.ContentLength];
                fileStream.Read(fileData, 0, hpf.ContentLength);
                n.Image = fileData;
            }
                try
            {
                db.News.Add(n);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception E)
            {
                var a = E.Message;
                return View();
            }
        }
        //[HttpPost]
        public ActionResult DeleteNews(Int32 id)
        {
            try
            {
                var n = db.News.Where(a => a.Id == id).First();
                db.News.Remove(n);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception E)
            {
                var a = E.Message;
                return View();
            }
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