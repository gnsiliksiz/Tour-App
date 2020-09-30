using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourApp.Controllers
{
    public class HataController : Controller
    {
        // GET: Hata
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InsufficientPrivileges()
        {
            return View();
        }
        public ActionResult Page404()
        {
            return View();
        }
    }
}