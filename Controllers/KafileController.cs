using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class KafileController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Kafile
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var kafiles = db.Kafiles.Where(x => x.Tur.userID == sess || x.Tur.userID == altfirmasess).OrderByDescending(x=>x.Tur.turBaslangic).ToList();
            return View(kafiles);
        }
        public ActionResult KafileEdit(int? kafileID)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var kafileler = db.Kafiles.Where(m => m.kafileID == kafileID).SingleOrDefault();
            if (kafileler == null)
            {
                return RedirectToAction("Page404", "Hata");
            }           
            return View(kafileler);
        }
        [HttpPost]
        public ActionResult KafileEdit(int? kafileID, Kafile x)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                var kafileler = db.Kafiles.Where(m => m.kafileID == kafileID).SingleOrDefault();
                kafileler.kafileAd = x.kafileAd;
                kafileler.kafileKisiSayisi = x.kafileKisiSayisi;
                kafileler.kafileUlke = x.kafileUlke;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View();
        }
        public JsonResult DeleteKafileRecord(int? kafileID)
        {
            bool result = false;
            Kafile kfl = db.Kafiles.SingleOrDefault(x => x.kafileID == kafileID);
            if (kfl != null)
            {
                db.Kafiles.Remove(kfl);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}