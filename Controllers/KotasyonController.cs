using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class KotasyonController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult CreateKotasyon()
        {
            int sess2 = Convert.ToInt32(Session["firmasi"]);
            ViewBag.OtelList = new SelectList(db.Otels.Where(x => x.userID == sess2), "otelID", "otelAd");
            ViewBag.RestorantList = new SelectList(db.Restorants.Where(x => x.userID == sess2), "restorantID", "restorantAd");
            ViewBag.MuzeList = new SelectList(db.Muzes.Where(x => x.userID == sess2), "muzeID", "muzeAd");
            ViewBag.EkstraList = new SelectList(db.Ekstras.Where(x => x.userID == sess2), "ekstraID", "ekstraAd");
            ViewBag.AracList = new SelectList(db.Aracs.Where(x => x.userID == sess2), "aracID", "aracMarka");
            return View();
        }

        [HttpGet]
        public ActionResult GetOtel(int? otelID)
        {
            var oteller = db.Otels.Where(x => x.otelID == otelID).ToList();
            ViewBag.OtelDetayları = oteller;
           // ViewData["Oteller"] = oteller;
            return PartialView(oteller);
        }
        public ActionResult SaveOrder(string ad, int gunSayisi, DateTime bas, DateTime bit, string ulke, string sehir, int sayi, OtelKot[] otelAdim, MuzeKot[] muzeAdim, ResKot[] resAdim, EkstraKot[] ekstraAdim, AracKot[] aracAdim)
        {
            int sess = Convert.ToInt32(Session["altFirmaID"]);
            int sess2 = Convert.ToInt32(Session["firmasi"]);
            string result = "Error! Order Is Not Complete!";
            float sayac = 0;
            if (ad != null && bas != null && bit !=null && ulke !=null && sehir != null && otelAdim != null && muzeAdim != null && resAdim != null && ekstraAdim !=null && aracAdim !=null)
            {
                //var cutomerId = Guid.NewGuid();
                Kotasyon model = new Kotasyon();
                model.kotasyonAd = ad;
                model.kotasyonBas = bas;
                model.kotasyonBit = bit;
                model.kotasyonGelenUlke = ulke;
                model.kotasyonGelenSehir = sehir;
                model.kotasyonGunSayisi = gunSayisi;
                model.kotasyonKisiSayisi = sayi;
                model.onaylanmis = false;
                model.altFirmaID = sess;
                db.Kotasyons.Add(model);
                foreach (var item in otelAdim)
                {
                    OtelKot O = new OtelKot();
                    O.otelkotTarih = item.otelkotTarih;
                    O.singleKisi = item.singleKisi;
                    O.doubleKisi = item.doubleKisi;
                    O.familyKisi = item.familyKisi;
                    O.kingSuitKisi = item.kingSuitKisi;
                    O.otelToplamFiyat = item.otelToplamFiyat;
                    O.otelID = item.otelID;
                    O.kotasyonID = model.kotasyonID;
                    db.OtelKots.Add(O);
                }
                
                foreach(var item in muzeAdim)
                {
                    MuzeKot M = new MuzeKot();
                    M.muzeTarih = item.muzeTarih;
                    M.muzeToplamFiyat = item.muzeToplamFiyat;
                    M.muzeID = item.muzeID;
                    M.kotasyonID = model.kotasyonID;
                    db.MuzeKots.Add(M);
                }

                foreach (var item in resAdim)
                {
                    ResKot R= new ResKot();
                    R.reskotTarih = item.reskotTarih;
                    R.resToplamFiyat = item.resToplamFiyat;
                    R.restorantID = item.restorantID;
                    R.kotasyonID = model.kotasyonID;
                    db.ResKots.Add(R);
                }

                foreach (var item in ekstraAdim)
                {
                    EkstraKot E = new EkstraKot();
                    E.ekstraTarih = item.ekstraTarih;
                    E.ekstraToplamFiyat = item.ekstraToplamFiyat;
                    E.ekstraID = item.ekstraID;
                    E.kotasyonID = model.kotasyonID;
                    db.EkstraKots.Add(E);
                }

                foreach (var item in aracAdim)
                {
                    AracKot A = new AracKot();
                    A.aracToplamFiyat = item.aracToplamFiyat;
                    A.aracID = item.aracID;
                    A.kotasyonID = model.kotasyonID;
                    db.AracKots.Add(A);
                }

                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteKotasyonRecord(int kotasyonID)
        {
            bool result = false;
            Kotasyon kt = db.Kotasyons.SingleOrDefault(x => x.kotasyonID == kotasyonID);
            if (kt != null)
            {
                db.Kotasyons.Remove(kt);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}