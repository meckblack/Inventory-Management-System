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
using PagedList;

namespace IMS.Controllers
{
    public class StockController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Stock/

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.StockNameParm = String.IsNullOrEmpty(sortOrder) ? "StockName_desc" : "";
            ViewBag.StockCategoryParm = sortOrder == "StockCategory" ? "StockCategory_desc" : "StockCategory";
            ViewBag.StockSupplierParm = sortOrder == "StockSupplier" ? "StockSupplier_desc" : "StockSupplier";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var stock = from s in db.Stock
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stock = stock.Where(s => s.StockName.ToUpper().Contains(searchString.ToUpper()) || s.StockCategory.ToUpper().Contains(searchString.ToUpper()) ||
                                         s.StockSupplier.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "StockName_desc":
                    stock = stock.OrderByDescending(s => s.StockName);
                    break;
                case "StockCategory":
                    stock = stock.OrderBy(s => s.StockCategory);
                    break;
                case "StockCategory_desc":
                    stock = stock.OrderByDescending(s => s.StockCategory);
                    break;
                case "StockSupplier":
                    stock = stock.OrderBy(s => s.StockSupplier);
                    break;
                case "StockSupplier_desc":
                    stock = stock.OrderByDescending(s => s.StockSupplier);
                    break;
                default:
                    stock = stock.OrderBy(s => s.StockName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(stock.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Stock/Details/5
        public ActionResult Details(int? id)
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
            return PartialView("Details", stock);
        }

        // GET: /Stock/Create
        public ActionResult Create()
        {
            var stock = new Stock();
            return PartialView("Create", stock);
        }

        // POST: /Stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StockId,StockName,StockCategory,StockBuyingPrice,StockSellingPrice,StockSupplier")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stock.Add(stock);
                db.SaveChanges();
                return Json(new { success = true });
            }

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
            return PartialView("Edit", stock);
        }

        // POST: /Stock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StockId,StockName,StockCategory,StockBuyingPrice,StockSellingPrice,StockSupplier")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
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
