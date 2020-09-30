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
    public class TuristController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Turist
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            ViewBag.KafileList = new SelectList(db.Kafiles.Where(x => x.Tur.userID == sess || x.Tur.userID == altfirmasess), "kafileID", "kafileAd");
            return View();
        }
        [HttpGet]
        public ActionResult GetTurists(int? kafileID)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var turistler = db.Turists.Where(x => x.kafileID == kafileID).ToList();
            ViewBag.Turistler = turistler;
            ViewData["Turistler"] = turistler;
            return PartialView(turistler);
        }
        public ActionResult CreateTurist()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            ViewBag.kafileID = new SelectList(db.Kafiles.Where(x => x.Tur.userID == sess), "kafileID", "kafileAd");
            ViewBag.turID = new SelectList(db.Turs.Where(x => x.userID == sess), "turID", "turAd");
            return View();
        }
        public ActionResult SaveOrder(string kafileAd, string kafileUlke, int kafileKisiSayisi, int turID, Turist[] turist)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            string result = "Ekleme işlemi Başarısız";
            if (ModelState.IsValid)
            {
                Kafile model = new Kafile();
                model.kafileAd = kafileAd;
                model.kafileKisiSayisi = kafileKisiSayisi;
                model.kafileUlke = kafileUlke;
                model.turID = turID;
                model.isDeleted = false;
                db.Kafiles.Add(model);
                foreach (var item in turist)
                {
                    Turist t = new Turist();
                    t.turistAd = item.turistAd;
                    t.turistTel = item.turistTel;
                    t.turistYas = item.turistYas;
                    t.turistCinsiyet = item.turistCinsiyet;
                    t.turistPasaportNo = item.turistPasaportNo;
                    t.turistTC = item.turistTC;
                    t.kafileID = model.kafileID;
                    db.Turists.Add(t);
                }
                db.SaveChanges();
                result = "Tebrikler Başarıyla Tamamlandı";

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TuristEdit(int? turistID)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var turistler = db.Turists.Where(m => m.turistID == turistID).SingleOrDefault();
            if (turistler == null)
            {
                return HttpNotFound();
            }
            ViewBag.kafileID = new SelectList(db.Kafiles.Where(x => x.Tur.userID == sess), "kafileID", "kafileAd", turistler.kafileID);
            return View(turistler);
        }
        [HttpPost]
        public ActionResult TuristEdit(int? turistID, Turist x, HttpPostedFileBase turistFoto)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                var turistler = db.Turists.Where(m => m.turistID == turistID).SingleOrDefault();
                if (turistFoto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(x.turistFoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(turistler.turistFoto));
                    }
                    WebImage img = new WebImage(turistFoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(turistFoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/TuristPhoto/" + newfoto);
                    turistler.turistFoto = "/Uploads/TuristPhoto/" + newfoto;
                    turistler.turistAd = x.turistAd;
                    turistler.turistTel = x.turistTel;
                    turistler.turistCinsiyet = x.turistCinsiyet;
                    turistler.turistTC = x.turistTC;
                    turistler.turistPasaportNo = x.turistPasaportNo;
                    turistler.turistYas = x.turistYas;
                    db.SaveChanges();
                }
                else
                {
                    turistler.turistAd = x.turistAd;
                    turistler.turistTel = x.turistTel;
                    turistler.turistCinsiyet = x.turistCinsiyet;
                    turistler.turistTC = x.turistTC;
                    turistler.turistPasaportNo = x.turistPasaportNo;
                    turistler.turistYas = x.turistYas;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.kafileID = new SelectList(db.Kafiles.Where(a => a.Tur.userID == sess), "kafileID", "kafileAd", x.kafileID);
            return View();
        }
        public JsonResult DeleteTuristRecord(int turistID)
        {
            bool result = false;
            Turist trs = db.Turists.SingleOrDefault(x => x.turistID == turistID);
            if (trs != null)
            {
                db.Turists.Remove(trs);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}