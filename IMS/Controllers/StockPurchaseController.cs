using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMS.Models;
using IMS.DAL;

namespace IMS.Controllers
{
    public class StockPurchaseController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /StockPurchase/
        public ActionResult Index()
        {
            return View(db.StockPurchase.ToList());
        }

        // GET: /StockPurchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPurchase stockpurchase = db.StockPurchase.Find(id);
            if (stockpurchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", stockpurchase);
        }

        // GET: /StockPurchase/Create
        public ActionResult Create()
        {
            var stockpurchase = new StockPurchase();
            return PartialView("Create", stockpurchase);
        }

        // POST: /StockPurchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockPurchase stockpurchase)
        {
            if (ModelState.IsValid)
            {
                db.StockPurchase.Add(stockpurchase);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", stockpurchase);
        }

        // GET: /StockPurchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPurchase stockpurchase = db.StockPurchase.Find(id);
            if (stockpurchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", stockpurchase);
        }

        // POST: /StockPurchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockPurchase stockpurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockpurchase).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", stockpurchase);
        }

        // GET: /StockPurchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPurchase stockpurchase = db.StockPurchase.Find(id);
            if (stockpurchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", stockpurchase);
        }

        // POST: /StockPurchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockPurchase stockpurchase = db.StockPurchase.Find(id);
            db.StockPurchase.Remove(stockpurchase);
            db.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
