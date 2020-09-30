using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class AltFirmaController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var altfirma = db.AltFirmas.Where(x => x.userID == sess && x.isDeleted == false).ToList();
            return View(altfirma);
        }
        public JsonResult SaveData(AltFirma frm)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            db.AltFirmas.Add(frm);
            frm.userID = sess;
            frm.isDeleted = false;
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AltFirmaEdit(int? altFirmaID)
        {
            var firma = db.AltFirmas.Where(m => m.altFirmaID == altFirmaID).SingleOrDefault();
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }
        [HttpPost]
        public ActionResult AltFirmaEdit(int? altFirmaID, AltFirma x)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            try
            {
                var firmalar = db.AltFirmas.Where(m => m.altFirmaID == altFirmaID).SingleOrDefault();
                firmalar.altFirmaAd = x.altFirmaAd;
                firmalar.altFirmaEmail = x.altFirmaEmail;
                firmalar.altFirmaAdres = x.altFirmaAdres;
                firmalar.altFirmaSifre = x.altFirmaSifre;
                firmalar.altFirmaTel = x.altFirmaTel;
                firmalar.userID = sess;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(x);
            }
        }
        public JsonResult DeleteAltFirmaRecord(int? altFirmaID)
        {
            bool result = false;
            AltFirma frm = db.AltFirmas.SingleOrDefault(x => x.altFirmaID == altFirmaID);
            if (frm != null)
            {
                frm.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}