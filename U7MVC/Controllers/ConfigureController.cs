using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U7MVC.Models;

namespace U7MVC.Controllers
{
    public class ConfigureController : Controller
    {
        RabbitContext db = new RabbitContext();

        // GET: Configure
        [HttpGet]
        public ActionResult AddMembers()
        {
            var member = db.Members;
            ViewBag.Members = member;
            return View();
        }
        public ActionResult AddRabits()
        {
            return View();
        }

        public ActionResult AddmemberForm()
        {
            var member = db.Members;
            ViewBag.Members = member;
            var reg = db.RegionList;
            ViewBag.Reg = reg;

            /*var distr = db.DistrictList;
            ViewBag.Distric = distr;*/
            return View();
        }

        [HttpPost]
        public ActionResult AddMembers(Member memb)
        {
            try
            {
                db.Members.Add(memb);
                db.SaveChanges();
                //return "dmads,ma.";

                return RedirectToAction("AddMembers");
            }
            catch
            {
                return View();
                //return "dmads,ma.";
            }
        }
        public ActionResult LeftMenuAdmin()
        {
            return View();
        }

        // GET: Configure
        public ActionResult Index()
        {
            return View();
        }

        // GET: Configure/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Configure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configure/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Configure/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Configure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Configure/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Configure/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
