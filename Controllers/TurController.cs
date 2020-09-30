using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class TurController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Tur
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            return View();            
        }
        public JsonResult GetTur()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var turs = db.Turs.Select(x => new
            {
                turID = x.turID,
                turAd = x.turAd,
                turKod = x.turKod,
                turAciklama = x.turAciklama,
                turBaslangic = x.turBaslangic,
                turKisiSayisi = x.turKisiSayisi,
                turGunSayisi = x.turGunSayisi,
                turBitis = x.turBitis,
                turRenk = x.turRenk,                
                isFullDay = x.isFullDay,
                rehberID = x.rehberID,
                rehberAd = x.Rehber.rehberAd,
                userID = x.userID
               
            }).Where(x => x.userID == sess).ToList();
            return new JsonResult { Data = turs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };            
        }
        public ActionResult CreateTur()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            ViewBag.RehberList = new SelectList(db.Rehbers.Where(x => x.userID == sess), "rehberID", "rehberAd");
            ViewBag.OtelList = new SelectList(db.Otels.Where(x => x.userID == sess), "otelID", "otelAd");
            ViewBag.RestorantList = new SelectList(db.Restorants.Where(x => x.userID == sess), "restorantID", "restorantAd");
            ViewBag.MuzeList = new SelectList(db.Muzes.Where(x => x.userID == sess), "muzeID", "muzeAd");
            ViewBag.EkstraList = new SelectList(db.Ekstras.Where(x => x.userID == sess), "ekstraID", "ekstraAd");
            ViewBag.AracList = new SelectList(db.Aracs.Where(x => x.userID == sess), "aracID", "aracMarka");
            return View();
        }
        public ActionResult SaveOrder(string turKod, int rehberID, string turAd, string turAciklama, int turKisiSayisi, DateTime turBaslangic, DateTime turBitis, string turRenk, TurOtel[] turOtel, TurMuze[] turMuze, TurRestorant[] turRestorant, TurEkstra[] turEkstra, TurArac[] turArac)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            string result = "Ekleme işlemi Başarısız";
            if (turKod != null && turAd != null && turAciklama != null && turBaslangic != null && turKisiSayisi != 0 &&  turBitis != null && turRenk != null && turOtel != null && turMuze != null && turRestorant != null && turEkstra != null && turArac !=null && rehberID !=null)
            {
                Tur model = new Tur();
                model.turKod = turKod;
                model.turAd = turAd;
                model.turAciklama = turAciklama;
                model.turBaslangic = turBaslangic;
                model.turKisiSayisi = turKisiSayisi;
                model.turBitis = turBitis;
                model.turRenk = turRenk;
                model.isFullDay = true;
                model.ertelenmis = false;
                model.userID = sess;
                model.rehberID = rehberID;
                db.Turs.Add(model);
                
                foreach(var item in turOtel)
                {
                    TurOtel O = new TurOtel();
                    O.turOtelTarih = item.turOtelTarih;
                    O.singleKisi = item.singleKisi;
                    O.doubleKisi = item.doubleKisi;
                    O.familyKisi = item.familyKisi;
                    O.kingSuitKisi = item.kingSuitKisi;
                    O.otelToplamFiyat = item.otelToplamFiyat;
                    O.otelID = item.otelID;
                    O.turID = model.turID;
                    db.TurOtels.Add(O);
                }

                foreach (var item in turMuze)
                {
                    TurMuze M = new TurMuze();
                    M.turMuzeTarih = item.turMuzeTarih;
                    M.turMuzeToplamFiyat = item.turMuzeToplamFiyat;
                    M.muzeID = item.muzeID;
                    M.turID = model.turID;
                    db.TurMuzes.Add(M);
                }

                foreach (var item in turRestorant)
                {
                    TurRestorant R = new TurRestorant();
                    R.turRestorantTarih = item.turRestorantTarih;
                    R.turRestorantToplamFiyat = item.turRestorantToplamFiyat;
                    R.restorantID = item.restorantID;
                    R.turID = model.turID;
                    db.TurRestorants.Add(R);
                }

                foreach (var item in turEkstra)
                {
                    TurEkstra E = new TurEkstra();
                    E.turEkstraTarih = item.turEkstraTarih;
                    E.turEkstraToplamFiyat = item.turEkstraToplamFiyat;
                    E.ekstraID = item.ekstraID;
                    E.turID = model.turID;
                    db.TurEkstras.Add(E);
                }

                foreach (var item in turArac)
                {
                    TurArac A = new TurArac();
                    A.turAracToplamFiyat = item.turAracToplamFiyat;
                    A.aracID = item.aracID;
                    A.turID = model.turID;
                    db.TurAracs.Add(A);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteEvent(int turID)
        {
            var status = false;            
                var v = db.Turs.Where(a => a.turID == turID).FirstOrDefault();
                if (v != null)
                {
                    db.Turs.Remove(v);
                    db.SaveChanges();
                    status = true;
                }            
            return new JsonResult { Data = new { status = status } };
        }
        [HttpGet]
        public JsonResult GetOtel(int? otelID)
        {
            var oteller = db.Otels.Select(x => new
            {
                otelID = x.otelID,
                otelSingleRoomFiyat = x.otelSingleRoomFiyat,
                otelDoubleRoomFiyat = x.otelDoubleRoomFiyat,
                otelKingSuitFiyat = x.otelKingSuitFiyat,
                otelFamilyRoomFiyat = x.otelFamilyRoomFiyat,
                userID = x.userID
            }).Where(x=>x.otelID == otelID).ToList();
            return new JsonResult { Data = oteller, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public JsonResult GetMuze(int? muzeID)
        {
            var muzeler = db.Muzes.Select(x => new
            {
                muzeID = x.muzeID,
                muzeGirisFiyat = x.muzeGirisFiyat,
                muzeFiyatBirim = x.muzeFiyatBirim,
                userID = x.userID
            }).Where(x => x.muzeID == muzeID).ToList();
            return new JsonResult { Data = muzeler, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public JsonResult GetRestorant(int? restorantID)
        {
            var restorantlar = db.Restorants.Select(x => new
            {
                restorantID = x.restorantID,
                restorantOrtalamFiyat = x.restorantOrtalamFiyat,
                muzeFiyatBirim = x.restorantFiyatBirimi,
                userID = x.userID
            }).Where(x => x.restorantID == restorantID).ToList();
            return new JsonResult { Data = restorantlar, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public JsonResult GetEkstra(int? ekstraID)
        {
            var ekstralar = db.Ekstras.Select(x => new
            {
                ekstraID = x.ekstraID,
                ekstraFiyat = x.ekstraFiyat,
                ekstraFiyatBirimi = x.ekstraFiyatBirimi,
                userID = x.userID
            }).Where(x => x.ekstraID == ekstraID).ToList();
            return new JsonResult { Data = ekstralar, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public JsonResult GetArac(int? aracID)
        {
            var araclar = db.Aracs.Select(x => new
            {
                aracID = x.aracID,
                aracPlaka = x.aracPlaka,
                aracFiyat = x.aracFiyat,
                aracFiyatBirim = x.aracFiyatBirim,
                userID = x.userID
            }).Where(x => x.aracID == aracID).ToList();
            return new JsonResult { Data = araclar, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}