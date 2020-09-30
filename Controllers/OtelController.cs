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
    public class OtelController : Controller
    {
        TourEntities db = new TourEntities();
        public ActionResult Index()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            int altfirmasess = Convert.ToInt32(Session["firmasi"]);
            var oteller = db.Otels.Where(x => x.userID == sess || x.userID == altfirmasess && x.isDeleted == false).ToList();            
            return View(oteller);
        }

        public ActionResult OtelInfo(int otelID)
        {
            List<Otel> otelInfo = db.Otels.Where(x => x.otelID == otelID).ToList();
            return View(otelInfo);
        }
        [HttpGet]
         public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Otel otel, HttpPostedFileBase otelResim)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                if(otelResim != null)
                {
                    WebImage img = new WebImage(otelResim.InputStream);
                    FileInfo fotoinfo = new FileInfo(otelResim.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/OtelPhoto/" + newfoto);
                    otel.otelResim = "/Uploads/OtelPhoto/" + newfoto;
                    otel.userID = sess;
                    otel.isDeleted = false;
                    db.Otels.Add(otel);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Otel");
                }
                else
                {
                    otel.userID = sess;
                    otel.isDeleted = false;
                    db.Otels.Add(otel);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Otel");
                }

            }
            return View(otel);
        }


        [HttpGet]
        public ActionResult OtelEdit(int? otelID)
        {
            var oteller = db.Otels.Where(m => m.otelID == otelID).SingleOrDefault();
            if (oteller == null)
            {
                return HttpNotFound();
            }
            return View(oteller);
        }
        [HttpPost]
        public ActionResult OtelEdit(int? otelID, Otel x, HttpPostedFileBase otelResim)
        {
            int sess = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                var oteller = db.Otels.Where(m => m.otelID == otelID).SingleOrDefault();
                if (otelResim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(x.otelResim)))
                    {
                        System.IO.File.Delete(Server.MapPath(oteller.otelResim));
                    }
                    WebImage img = new WebImage(otelResim.InputStream);
                    FileInfo fotoinfo = new FileInfo(otelResim.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/OtelPhoto/" + newfoto);
                    oteller.otelResim = "/Uploads/OtelPhoto/" + newfoto;
                }
                oteller.otelAd = x.otelAd;
                oteller.otelTip = x.otelTip;
                oteller.otelTelefon = x.otelTelefon;
                oteller.otelAdres = x.otelAdres;
                oteller.otelGecelikFiyat = x.otelGecelikFiyat;
                oteller.otelFiyatBirimi = x.otelFiyatBirimi;
                oteller.otelSingleRoomFiyat = x.otelSingleRoomFiyat;
                oteller.otelDoubleRoomFiyat = x.otelDoubleRoomFiyat;
                oteller.otelKingSuitFiyat = x.otelKingSuitFiyat;
                oteller.otelFamilyRoomFiyat = x.otelFamilyRoomFiyat;
                oteller.otelLat = x.otelLat;
                oteller.otelLong = x.otelLong;
                oteller.otelIl = x.otelIl;
                oteller.otelIlce = x.otelIlce;
                oteller.userID = sess;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult DeleteOtelRecord(int otelID)
        {
            bool result = false;
            Otel otl = db.Otels.SingleOrDefault(x => x.otelID == otelID);
            if (otl != null)
            {
                otl.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void ExportToExcel()
        {
            int sess = Convert.ToInt32(Session["userID"]);
            var otelList = db.Otels.Where(x => x.userID == sess).OrderByDescending(x=>x.otelIl).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Rapor";
            ws.Cells["B1"].Value = "Anlaşmalı Oteller";

            ws.Cells["A2"].Value = "Tarih";
            ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "otelID";
            ws.Cells["B6"].Value = "Ad";
            ws.Cells["C6"].Value = "Tip";
            ws.Cells["D6"].Value = "Telefon";
            ws.Cells["E6"].Value = "İl";
            ws.Cells["F6"].Value = "İlçe";
            ws.Cells["G6"].Value = "Tek Kişilik";
            ws.Cells["H6"].Value = "Çift Kişilik";
            ws.Cells["I6"].Value = "King Suit";
            ws.Cells["J6"].Value = "Family Suit";
            int rowStart = 7;
            foreach (var item in otelList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.otelID;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.otelAd;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.otelTip;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.otelTelefon;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.otelIl;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.otelIlce;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.otelSingleRoomFiyat + item.otelFiyatBirimi;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.otelDoubleRoomFiyat + item.otelFiyatBirimi;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.otelKingSuitFiyat + item.otelFiyatBirimi;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.otelFamilyRoomFiyat + item.otelFiyatBirimi;
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