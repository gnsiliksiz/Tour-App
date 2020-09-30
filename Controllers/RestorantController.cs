using OfficeOpenXml;
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
    public class RestorantController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var restorantlar = db.Restorants.Where(x => x.userID == sess || x.userID == altfirmasess && x.isDeleted == false).ToList();
            return View(restorantlar);
        }
        public ActionResult RestorantInfo(int restorantID)
        {
            List<Restorant> restorantInfo = db.Restorants.Where(x => x.restorantID == restorantID).ToList();
            return View(restorantInfo);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Restorant restorant, HttpPostedFileBase restorantFoto)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                if (restorantFoto != null)
                {
                    WebImage img = new WebImage(restorantFoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(restorantFoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/RestorantPhoto/" + newfoto);
                    restorant.restorantFoto = "/Uploads/RestorantPhoto/" + newfoto;
                    restorant.userID = sess;
                    restorant.isDeleted = false;
                    db.Restorants.Add(restorant);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Restorant");

                }
                else
                {
                    restorant.userID = sess;
                    restorant.isDeleted = false;
                    db.Restorants.Add(restorant);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Restorant");
                }
                
            }
            return View(restorant);
        }
        [HttpGet]
        public ActionResult RestorantEdit(int? restorantID)
        {
            var restorant = db.Restorants.Where(m => m.restorantID == restorantID).SingleOrDefault();
            if (restorant == null)
            {
                return HttpNotFound();
            }
            return View(restorant);
        }
        [HttpPost]
        public ActionResult RestorantEdit(int? restorantID, Restorant x)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            try
            {
                var restorantlar = db.Restorants.Where(m => m.restorantID == restorantID).SingleOrDefault();
                restorantlar.restorantAd = x.restorantAd;
                restorantlar.restorantIl = x.restorantIl;
                restorantlar.restorantIlce = x.restorantIlce;
                restorantlar.restorantAdres = x.restorantAdres;
                restorantlar.restorantTelefon = x.restorantTelefon;
                restorantlar.restorantKahvaltiFiyat = x.restorantKahvaltiFiyat;
                restorantlar.restorantAksamFiyat = x.restorantAksamFiyat;
                restorantlar.restorantOglenFiyat = x.restorantOglenFiyat;
                restorantlar.restorantFiyatBirimi = x.restorantFiyatBirimi;
                restorantlar.userID = sess;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(x);
            }
        }
        public JsonResult DeleteRestorantRecord(int restorantID)
        {
            bool result = false;
            Restorant res = db.Restorants.SingleOrDefault(x => x.restorantID == restorantID);
            if (res != null)
            {
                res.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void ExportToExcel()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var restorantListt = db.Restorants.Where(x => x.userID == sess).OrderByDescending(x => x.restorantIl).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Rapor";
            ws.Cells["B1"].Value = "Anlaşmalı Restorantlar";

            ws.Cells["A2"].Value = "Tarih";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "restorantID";
            ws.Cells["B6"].Value = "Ad";
            ws.Cells["C6"].Value = "Telefon";
            ws.Cells["D6"].Value = "Ortalama Fiyat";
            ws.Cells["E6"].Value = "restorantAdres";
            ws.Cells["F6"].Value = "restorantIl";
            ws.Cells["G6"].Value = "restorantIlce";
            int rowStart = 7;
            foreach (var item in restorantListt)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.restorantID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.restorantAd;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.restorantTelefon;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.restorantOrtalamFiyat + item.restorantFiyatBirimi;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.restorantAdres;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.restorantIl;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.restorantIlce;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}