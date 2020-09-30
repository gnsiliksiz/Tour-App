using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class AracController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Arac
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var araclar = db.Aracs.Where(x => x.userID == sess || x.userID == altfirmasess && x.isDeleted == false).ToList();
            return View(araclar);
        }
         public JsonResult SaveData(Arac arac)
         {
             int sess = Convert.ToInt32(Session["userID"]);
             db.Aracs.Add(arac);
             arac.isDeleted = false;
             arac.userID = sess;
             db.SaveChanges();
             return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
         }
        public ActionResult Edit(int aracID)
        {
            var araclar = db.Aracs.Where(m => m.aracID == aracID).SingleOrDefault();
            if (araclar == null)
            {
                return HttpNotFound();
            }
            return View(araclar);
        }

        [HttpPost]
        public ActionResult Edit(int aracID, Arac x)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            try
            {
                var araclar = db.Aracs.Where(m => m.aracID == aracID).SingleOrDefault();
                araclar.aracPlaka = x.aracPlaka;
                araclar.aracMarka = x.aracMarka;
                araclar.aracFiyat = x.aracFiyat;
                araclar.aracFiyatBirim = x.aracFiyatBirim;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(x);
            }
        }
        public JsonResult DeleteAracRecord(int aracID)
        {
            bool result = false;
            Arac arc = db.Aracs.SingleOrDefault(x => x.isDeleted == false && x.aracID == aracID);
            if (arc != null)
            {
                arc.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}