using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class HomeController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            DateTime suan = DateTime.Now;
            int sess = Convert.ToInt32(Session["userID"]);
            var tur = db.Turs.Where(x => x.userID == sess).OrderByDescending(x => x.turBaslangic).ToList();
            ViewBag.Rehbers = db.Rehbers.Where(x=>x.userID == sess && x.isDeleted == false && x.rehberRating >=4.0 ).ToList();
            ViewBag.ErtelenenTurlar = db.Turs.Where(x => x.userID == sess && x.ertelenmis == true).Count();
            ViewBag.GelecekTurlar = db.Turs.Where(x => x.userID == sess && suan < x.turBaslangic).Count();
            ViewBag.BitmisTurlar = db.Turs.Where(x => x.userID == sess && suan > x.turBitis).Count();
            ViewBag.FirmaSayisi = db.AltFirmas.Where(x => x.userID == sess).Count();
            ViewBag.KafileSayisi = db.Kafiles.Where(x => x.Tur.userID == sess).Count();
            ViewBag.KotasyonSayisi = db.Kotasyons.Where(x => x.AltFirma.userID == sess && x.onaylanmis == true).Count();
            return View(tur);
        }
        public ActionResult AltFirmaIndex()
        {
            int sess = Convert.ToInt32(Session["altFirmaID"]);
            var kotasyon = db.Kotasyons.Where(x=>x.altFirmaID == sess).ToList();
            ViewBag.totalOtel = db.OtelKots.Sum(x => x.otelToplamFiyat);
            return View(kotasyon);
        }
        //USER İÇİN
        public ActionResult Teklifler()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var teklifler = db.Kotasyons.Where(x => x.AltFirma.userID == sess).ToList();
            return View(teklifler);
        }
        //USER İÇİN
        public ActionResult TeklifDetay(int? kotasyonID)
        {
            int sess = Convert.ToInt32(Session["altFirmaID"]);
            Kotasyon kotasyon = db.Kotasyons.Find(kotasyonID);
            if (kotasyon == null)
            {
                return HttpNotFound();
            }
            return View(kotasyon);
        }
        [HttpPost]
        public ActionResult TeklifOnayla(List<Kotasyon> model)
        {
                foreach (var item in model)
                {
                    var kotasyonDurum = db.Kotasyons.FirstOrDefault(q => q.kotasyonID == item.kotasyonID);

                    if (kotasyonDurum != null)
                    {
                    if(kotasyonDurum.onaylanmis == false)
                    {
                        kotasyonDurum.onaylanmis = true;
                    }
                    else
                    {
                        kotasyonDurum.onaylanmis = false;
                    }
                        
                        db.SaveChanges();
                    }
                }
            return RedirectToAction("Index","Home");
        }
        //ALT FIRMA ICIN
        public ActionResult KotasyonDetay(int? kotasyonID)
        {
            int sess = Convert.ToInt32(Session["altFirmaID"]);
            string sess2 = Session["anaFirmaAdi"].ToString();
            string sess3 = Session["anaFirmaEmail"].ToString();
            string sess4 = Session["anaFirmaTelefon"].ToString();
            string sess5 = Session["anaFirmaAdres"].ToString();
            ViewBag.AnaFirma = sess2;
            ViewBag.AnaFirmaEmail = sess3;
            ViewBag.AnaFirmaTelefon = sess4;
            ViewBag.AnaFirmaAdres = sess5;
            Kotasyon kotasyon = db.Kotasyons.Find(kotasyonID);
            if(kotasyon == null) 
            {
                return HttpNotFound();
            }
            return View(kotasyon);
        }
    }
}