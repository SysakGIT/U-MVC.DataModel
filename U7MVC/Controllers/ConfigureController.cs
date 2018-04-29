using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using U7MVC.Models;

namespace U7MVC.Controllers
{
    public class ConfigureController : Controller
    {
        //RabbitContext db = new RabbitContext();

        RabbitClubEntitiesConnection db = new RabbitClubEntitiesConnection();
        // GET: Configure
        [HttpGet]
        public ActionResult AddMembers()
        {
            var member = db.v_Members;
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

            var reg = db.Region;
            ViewBag.Reg = reg.ToList();

            var distr = db.RegionsDistrincts.Where(r =>r.RegionId == 1);
            ViewBag.District = distr.ToList();

            int disrtId = distr.FirstOrDefault().DistrictId;

            var lstCity = db.RegionsDistrinctsCities.Where(x => x.DistrictId == 1
                && x.RegionId == disrtId);
            ViewBag.lstCity = lstCity.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult GetDistrictList(string regionID)
        {
            List<RegionsDistrincts> lstdistrict = new List<RegionsDistrincts>();
            int regioniD = Convert.ToInt32(regionID);
            lstdistrict = db.RegionsDistrincts.Where(x => x.RegionId == regioniD).ToList<RegionsDistrincts>();
           
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstdistrict);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCityList(string regionID, string districtID)
        {
            List<RegionsDistrinctsCities> lstcity = new List<RegionsDistrinctsCities>();
            int regioniD = Convert.ToInt32(regionID);
            int districtiD = Convert.ToInt32(districtID);
            lstcity = db.RegionsDistrinctsCities.Where(x => x.DistrictId == districtiD 
                && x.RegionId == regioniD)
                    .ToList<RegionsDistrinctsCities>();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstcity);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddMembers(Members memb)
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

        // GET: Configure
        [HttpGet]
        public ActionResult AddBreeds()
        {
            var breed = db.RabbitBreed;
            ViewBag.Breed = breed;

            var color = db.RabbitColor;// Breeds.Where(r => r.RabbitBreedId == 1);
            ViewBag.Color = color;

            var breedId = breed.FirstOrDefault().ID;
            var breedColorList = db.v_RabbitBreedColorList.Where(rcl => rcl.BreedId == breedId);
            ViewBag.BreedColorList = breedColorList;
            return View();

        }
        public ActionResult AddNewBreed()
        {
            var breed = db.RabbitBreed;
            ViewBag.Breed = breed;

            var color = db.RabbitColor;
            ViewBag.Color = color;
            return View();

        }

        [HttpPost]
        public ActionResult AddBreeds(RabbitBreed breed)
        {
            try
            {
                db.RabbitBreed.Add(breed);

                db.SaveChanges();
                //return "dmads,ma.";

                return RedirectToAction("AddBreeds");
            }
            catch
            {
                return View();
                //return "dmads,ma.";
            }
        }

        public ActionResult AddNewColor()
        {
            var color = db.RabbitColor;
            ViewBag.Color = color;
            return View();
        }

        [HttpPost]
        public ActionResult AddColors(RabbitColor color)
        {
            try
            {
                db.RabbitColor.Add(color);

                db.SaveChanges();

                return RedirectToAction("AddBreeds");
            }
            catch
            {
                return View();
            }
        }
        
        
        public ActionResult AddNewBreedColor(List<CheckBoxListItem> breedColor)
        {
            try
            {
                foreach( var l in  breedColor)
                {
                    db.UpdateRabbitColorrelation(l.ParentID, l.ID, l.IsChecked);
                }
                var a = breedColor;
                return RedirectToAction("AddBreeds");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddRelateBreedAndColor(int Id)
        {
            var breedName = db.RabbitBreed.Where(b => b.ID == Id).Select( a=> a.BreedName).Single() ;
            List<CheckBoxListItem> colorList = new List<CheckBoxListItem>();
            var breedColorList = db.v_RabbitBreedColorList.Where(rcl => rcl.BreedId == Id)
                    .Select(l => new { ColorId = l.ColorId, ColorName = l.ColorName, IsSelected = l.IsSelected});
            foreach (var a in breedColorList)
            {
                colorList.Add( new CheckBoxListItem { ParentID = Id, ID = a.ColorId, Display = a.ColorName
                        , IsChecked = Convert.ToBoolean(a.IsSelected)});

            }
            
            //ViewBag.BreedColorList = breedColorList;
            //ViewBag.ColorList = colorList;
            ViewBag.BredName = breedName;
            return View(colorList);

        }

    }
}
