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
    public class FirmaController : Controller
    {
        TourEntities db = new TourEntities(); 
        // GET: Firma
        public ActionResult Index()
        {
            var user = db.Users.Where(x => x.isDeleted == false).ToList();
            return View(user);
        }
        /* public JsonResult SaveData(User user)
         {
             db.Users.Add(user);
             user.isDeleted = false;
             user.userTipID = 2;
             user.active = true;
             db.SaveChanges();
             return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
         } 
         */
          public JsonResult SaveData(User user)
          {
              db.Users.Add(user);
              user.isDeleted = false;
              user.userTipID = 2;
              user.active = true;
              db.SaveChanges();
              return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
          } 

        public JsonResult DeleteFirmaRecord(int userID)
        {
            bool result = false;
            User usr = db.Users.SingleOrDefault(x => x.isDeleted == false && x.userID == userID);
            if (usr != null)
            {
                usr.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int userID)
        {
            var firmalar = db.Users.Where(m => m.userID == userID).SingleOrDefault();
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        [HttpPost]
        public ActionResult Edit(int userID, User x, HttpPostedFileBase userPhoto)
        {
            if (ModelState.IsValid)
            {
                var firmalar = db.Users.Where(m => m.userID == userID).SingleOrDefault();
                if (userPhoto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(x.userPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(firmalar.userPhoto));
                    }
                    WebImage img = new WebImage(userPhoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(userPhoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(300, 500);
                    img.Save("~/Uploads/UyeFoto/" + newfoto);
                    firmalar.userPhoto = "/Uploads/UyeFoto/" + newfoto;
                }
                firmalar.username = x.username;
                firmalar.active = x.active;
                firmalar.email = x.email;
                firmalar.isim = x.isim;
                firmalar.telefon = x.telefon;
                firmalar.adres = x.adres;
                db.SaveChanges();
                return RedirectToAction("Index", "Firma", new { userID = firmalar.userID });
            }
            return View();
        }
    }
}