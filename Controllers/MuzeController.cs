using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TourApp.Models;

namespace TourApp.Controllers
{
    public class MuzeController : Controller
    {
        // GET: Muze
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var muzeler = db.Muzes.Where(x => x.userID == sess || x.userID == altfirmasess && x.isDeleted == false).ToList();
            return View(muzeler);
        }
        public ActionResult MuzeInfo(int muzeID)
        {
            List<Muze> muzeInfo = db.Muzes.Where(x => x.muzeID == muzeID).ToList();
            return View(muzeInfo);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Muze muze, HttpPostedFileBase muzeFoto)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                if (muzeFoto != null)
                {
                    WebImage img = new WebImage(muzeFoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(muzeFoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/MuzePhoto/" + newfoto);
                    muze.muzeFoto = "/Uploads/MuzePhoto/" + newfoto;
                    muze.isDeleted = false;
                    muze.userID = sess;
                    db.Muzes.Add(muze);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Muze");
                }
                else
                {
                    muze.isDeleted = false;
                    muze.userID = sess;
                    db.Muzes.Add(muze);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Muze");
                }
            }
            return View(muze);
        }

        public JsonResult SaveData(Muze muze)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            db.Muzes.Add(muze);
            muze.userID = sess;
            muze.isDeleted = false;
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult MuzeEdit(int? muzeID)
        {
            var muzeler = db.Muzes.Where(m => m.muzeID == muzeID).SingleOrDefault();
            if (muzeler == null)
            {
                return HttpNotFound();
            }
            return View(muzeler);
        }
        [HttpPost]
        public ActionResult MuzeEdit(int? muzeID, Muze x, HttpPostedFileBase muzeFoto)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                var muzeler = db.Muzes.Where(m => m.muzeID == muzeID).SingleOrDefault();
                if (muzeFoto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(x.muzeFoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(muzeler.muzeFoto));
                    }
                    WebImage img = new WebImage(muzeFoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(muzeFoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/MuzePhoto/" + newfoto);
                    muzeler.muzeFoto = "/Uploads/MuzePhoto/" + newfoto;
                }
                muzeler.muzeAd = x.muzeAd;
                muzeler.muzeIl = x.muzeIl;
                muzeler.muzeIlce = x.muzeIlce;
                muzeler.muzeAdres = x.muzeAdres;
                muzeler.muzeGirisFiyat = x.muzeGirisFiyat;
                muzeler.muzeFiyatBirim = x.muzeFiyatBirim;
                muzeler.userID = sess;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult DeleteMuzeRecord(int muzeID)
        {
            bool result = false;
            Muze mz = db.Muzes.SingleOrDefault(x => x.muzeID == muzeID);
            if (mz != null)
            {
                mz.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void ExportToExcel()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            //List<Muze> muzeList = db.Muzes.Select(x => new Muze
            //{
            //    muzeID = x.muzeID,
            //    muzeAd = x.muzeAd,
            //    muzeIlce = x.muzeIlce,
            //    muzeIl = x.muzeIl,
            //    muzeGirisFiyat = x.muzeGirisFiyat,
            //    muzeFoto = x.muzeFoto,
            //}).ToList();
            var muzeList = db.Muzes.Where(x=>x.userID == sess).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Rapor";
            ws.Cells["B1"].Value = "Anlaşmalı Müzeler";

            ws.Cells["A2"].Value = "Tarih";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "muzeID";
            ws.Cells["B6"].Value = "muzeAd";
            ws.Cells["C6"].Value = "muzeIl";
            ws.Cells["D6"].Value = "muzeIlce";
            ws.Cells["E6"].Value = "muzeGirisFiyat";

            int rowStart = 7;
            foreach (var item in muzeList)
            {
                if (item.muzeGirisFiyat < 50)
                {
                    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                }

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.muzeID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.muzeAd;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.muzeIl;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.muzeIlce;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.muzeGirisFiyat;
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