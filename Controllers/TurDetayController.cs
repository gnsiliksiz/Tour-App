using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class TurDetayController : Controller
    {
        TourEntities db = new TourEntities();
        // GET: TurDetay
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            ViewBag.turList = new SelectList(db.Turs.Where(x => x.userID == sess), "turID", "turAd");
            return View();
        }

    }
}