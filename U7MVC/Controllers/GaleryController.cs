using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U7MVC.Controllers
{
    public class GaleryController : Controller
    {
        RabbitClubEntitiesConnection db = new RabbitClubEntitiesConnection();

        // GET: Galery
        public ActionResult Index()
        {
            var photos = db.Photos;
            ViewBag.Photos = photos;
            return View();
        }
        public ActionResult AddPhoto()
        {
            var photos = db.Photos;
            ViewBag.Photos = photos;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPhoto(Photos n)
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
                n.CreatedDate = DateTime.Now;
                db.Photos.Add(n);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception E)
            {
                var a = E.Message;
                return View();
            }
        }

        public ActionResult DeletePhoto(Int32 id)
        {
            try
            {
                var n = db.Photos.Where(a => a.Id == id).First();
                db.Photos.Remove(n);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception E)
            {
                var a = E.Message;
                return View();
            }
        }
    }
}