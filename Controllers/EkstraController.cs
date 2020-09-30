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
    public class EkstraController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var esktralar = db.Ekstras.Where(x=>x.userID == sess || x.userID == altfirmasess).ToList();
            return View(esktralar);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ekstra eks, HttpPostedFileBase ekstraFoto)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                if (ekstraFoto != null)
                {
                    WebImage img = new WebImage(ekstraFoto.InputStream);
                    FileInfo fotoinfo = new FileInfo(ekstraFoto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/EkstraPhoto/" + newfoto);
                    eks.ekstraFoto = "/Uploads/EkstraPhoto/" + newfoto;
                    db.Ekstras.Add(eks);
                    eks.userID = sess;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Ekstra");
                }
                else
                {
                    db.Ekstras.Add(eks);
                    eks.userID = sess;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Ekstra");
                }
            }
            return View(eks);
        }

        public JsonResult DeleteEkstraRecord(int ekstraID)
        {
            bool result = false;
            Ekstra eks = db.Ekstras.SingleOrDefault(x=>x.ekstraID == ekstraID);
            if (eks != null)
            {
                db.Ekstras.Remove(eks);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EkstraEdit(int ekstraID)
        {
            var ekstralar = db.Ekstras.Where(m => m.ekstraID == ekstraID).SingleOrDefault();
            if (ekstralar == null)
            {
                return HttpNotFound();
            }
            return View(ekstralar);
        }

        [HttpPost]
        public ActionResult EkstraEdit(int ekstraID, Ekstra x)
        {
            if (ModelState.IsValid)
            {
                var ekstralar = db.Ekstras.Where(m => m.ekstraID == ekstraID).SingleOrDefault();
                ekstralar.ekstraAd = x.ekstraAd;
                ekstralar.ekstraFiyat = x.ekstraFiyat;
                ekstralar.ekstraIl = x.ekstraIl;
                ekstralar.ekstraIlce = x.ekstraIlce;
                ekstralar.ekstraTelefon = x.ekstraTelefon;
                ekstralar.ekstraAdres = x.ekstraAdres;
                db.SaveChanges();
                return RedirectToAction("Index", "Ekstra", new { ekstraID = ekstralar.ekstraID });
            }
            return View();
        }

        public void ExportToExcel()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var ekstraList = db.Ekstras.Where(x => x.userID == sess).OrderByDescending(x => x.ekstraIl).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Rapor";
            ws.Cells["B1"].Value = "Anlaşmalı Etkinlikler";

            ws.Cells["A2"].Value = "Tarih";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "ID";
            ws.Cells["B6"].Value = "Ad";
            ws.Cells["C6"].Value = "Fiyat";
            ws.Cells["D6"].Value = "İl";
            ws.Cells["E6"].Value = "İlçe";
            ws.Cells["F6"].Value = "Adres";
            ws.Cells["G6"].Value = "Telefon";
            int rowStart = 7;
            foreach (var item in ekstraList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.ekstraID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.ekstraAd;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.ekstraFiyat + item.ekstraFiyatBirimi;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.ekstraIl;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.ekstraIlce;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.ekstraAdres;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.ekstraTelefon;
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