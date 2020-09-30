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
    public class RehberController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Rehber
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var rehber = db.Rehbers.Where(x => x.userID == sess || x.userID == altfirmasess && x.isDeleted == false).ToList();
            return View(rehber);
        }
        public ActionResult RehberInfo(int id)
        {
            List<Rehber> rehberInfo = db.Rehbers.Where(x => x.rehberID == id).ToList();
            return View(rehberInfo);
        }
        public ActionResult Create()
        {
            ViewBag.Diller = new MultiSelectList(db.Dils, "dilID", "dilAd");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rehber rehber, HttpPostedFileBase rehberPhoto, string diller)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                if (rehberPhoto != null && !string.IsNullOrEmpty(diller))
                {
                    WebImage img = new WebImage(rehberPhoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(rehberPhoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/RehberPhoto/" + newfoto);
                    rehber.rehberPhoto = "/Uploads/RehberPhoto/" + newfoto;

                    string[] dilDizi = diller.Split(',');
                    foreach (var i in dilDizi)
                    {
                        var yeniDil = new Dil { dilAd = i };
                        db.Dils.Add(yeniDil);
                        rehber.Dils.Add(yeniDil);
                    }

                    rehber.isDeleted = false;
                    rehber.userID = sess;
                    db.Rehbers.Add(rehber);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Rehber");
                }
                else
                {
                    ModelState.AddModelError("Fotoğraf", "Fotoğraf Seçiniz");
                }
            }
            return View(rehber);
        }

        public JsonResult DeleteRehberRecord(int? rehberID)
        {
            bool result = false;
            Rehber rhb = db.Rehbers.SingleOrDefault(x => x.rehberID == rehberID);
            if (rhb != null)
            {
                rhb.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int rehberID)
        {
            var rehberler = db.Rehbers.Where(m => m.rehberID == rehberID).SingleOrDefault();
            if (rehberler == null)
            {
                return HttpNotFound();
            }
            return View(rehberler);
        }

        [HttpPost]
        public ActionResult Edit(int rehberID, Rehber x, HttpPostedFileBase rehberPhoto)
        {
            if (ModelState.IsValid)
            {
                var rehberler = db.Rehbers.Where(m => m.rehberID == rehberID).SingleOrDefault();
                if (rehberPhoto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(x.rehberPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(rehberler.rehberPhoto));
                    }
                    WebImage img = new WebImage(rehberPhoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(rehberPhoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/RehberPhoto/" + newfoto);
                    rehberler.rehberPhoto = "/Uploads/RehberPhoto/" + newfoto;
                }
                rehberler.rehberUsername = x.rehberUsername;
                rehberler.rehberPassword = x.rehberPassword;
                rehberler.rehberEmail = x.rehberEmail;
                rehberler.rehberAd = x.rehberAd;
                rehberler.rehberTelefon = x.rehberTelefon;
                rehberler.rehberAdres = x.rehberAdres;
                rehberler.rehberCinsiyet = x.rehberCinsiyet;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}