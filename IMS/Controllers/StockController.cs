using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMS.Data.Objects.Entities;
using IMS.Data.DbConnections.DAL;

namespace IMS.Controllers
{
    public class StockController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Stock/
        public ActionResult Index()
        {
            var stock = db.Stock.Include(s => s.StockCategory).Include(s => s.StockSupplier);
            return View(stock.ToList());
        }

        // GET: /Stock/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Stock stock = db.Stock.Find(id);
        //    if (stock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stock);
        //}

        // GET: /Stock/Create
        public ActionResult Create()
        {
            var stock = new Stock();
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return PartialView("Create", stock);
        }

        // POST: /Stock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StockId,StockName,StockBuyingPrice,StockSellingPrice,CategoryId,SupplierId")] Stock stock)
        {  
            if (ModelState.IsValid)
            {
                db.Stock.Add(stock);
                db.SaveChanges();
                return Json(new { success = true } );
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", stock.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", stock.SupplierId);
            return PartialView("Create", stock);
        }

        // GET: /Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", stock.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", stock.SupplierId);
            return PartialView("Edit", stock);
        }

        // POST: /Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StockId,StockName,StockBuyingPrice,StockSellingPrice,CategoryId,SupplierId")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true } );
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", stock.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", stock.SupplierId);
            return PartialView("Edit", stock);
        }

        // GET: /Stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", stock);
        }

        // POST: /Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stock.Find(id);
            db.Stock.Remove(stock);
            db.SaveChanges();
            return Json(new { success = true } );
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
