﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourApp.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}