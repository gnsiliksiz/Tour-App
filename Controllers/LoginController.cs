using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class LoginController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: Login
        public ActionResult FirmaLogin()
        {
            return View();
        }
        public ActionResult AltFirmaLogin()
        {
            return View();
        }
        public JsonResult CheckUser(User model)
        {
            string result = "Fail";
            var DataItem = db.Users.Where(x => x.email == model.email && x.password == model.password).SingleOrDefault();
            if (DataItem != null)
            {
                Session["userID"] = DataItem.userID;
                Session["username"] = DataItem.email.ToString();
                Session["userTipID"] = DataItem.userTipID;
                Session["userPhoto"] = DataItem.userPhoto.ToString();
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckAltFirma(AltFirma model)
        {
            string result = "Fail";
            var DataItem = db.AltFirmas.Where(x => x.altFirmaEmail == model.altFirmaEmail && x.altFirmaSifre == model.altFirmaSifre).SingleOrDefault();
            if (DataItem != null)
            {
                Session["altFirmaID"] = DataItem.altFirmaID;
                Session["username"] = DataItem.altFirmaEmail.ToString();
                Session["firmasi"] = DataItem.userID.ToString();
                Session["anaFirmaAdi"] = DataItem.User.username.ToString();
                Session["anaFirmaEmail"] = DataItem.User.email.ToString();
                Session["anaFirmaTelefon"] = DataItem.User.telefon.ToString();
                Session["anaFirmaAdres"] = DataItem.User.adres.ToString();
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FirmaGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirmaGiris(User user)
        {
            var login = db.Users.Where(x => x.email == user.email).SingleOrDefault();
            if (login.email == user.email && login.password == user.password)
            {
                Session["userID"] = login.userID.ToString();
                Session["username"] = login.username.ToString();
                Session["userTipID"] = login.userTipID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AltFirmaGiris()
        {
            return View();
        }
        public ActionResult AltFirmaGiris(AltFirma altfirma)
        {
            var login = db.AltFirmas.Where(x => x.altFirmaEmail == altfirma.altFirmaEmail).SingleOrDefault();
            if (login.altFirmaEmail == altfirma.altFirmaEmail && login.altFirmaSifre == altfirma.altFirmaSifre)
            {
                Session["userID"] = login.userID.ToString();
                Session["username"] = login.altFirmaEmail.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        //public JsonResult CheckSubUser(AltFirma model)
        //{
        //    string result = "Fail";
        //    var DataItem = db.AltFirmas.Where(x => x.altFirmaEmail == model.altFirmaEmail && x.altFirmaSifre == model.altFirmaSifre).SingleOrDefault();
        //    if (DataItem != null)
        //    {
        //        Session["userID"] = DataItem.User.userID;
        //        Session["username"] = DataItem.altFirmaEmail.ToString();
        //        result = "Success";
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("../Login/FirmaLogin");
        }
    }
}