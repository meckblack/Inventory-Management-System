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
    public class PurchaseController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Purchase/
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.PurchaseProductNameParm = String.IsNullOrEmpty(sortOrder) ? "PurchaseProductName_desc" : "";
            ViewBag.PurchaseSupplierParm = sortOrder == "PurchaseSupplier" ? "PurchaseSupplier_desc" : "PurchaseSupplier";
            ViewBag.PurchaseDateParm = sortOrder == "PurchaseDate" ? "PurchaseDate_desc" : "PurchaseDate";
            ViewBag.PurcahseBalance = sortOrder == "PurcahseBalance" ? "PurcahseBalance_desc" : "PurcahseBalance";
            ViewBag.PurcahseBillNoParm = sortOrder == "PurcahseBillNo" ? "PurcahseBillNo_desc" : "PurcahseBillNo";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var purchase = from p in db.Purchase
                           select p;

            if(!String.IsNullOrEmpty(searchString))
            {
                purchase = purchase.Where(p => p.PurchaseBillNo.ToUpper().Contains(searchString.ToUpper()) ||
                                               p.PurchaseSupplier.ToUpper().Contains(searchString.ToUpper()) || p.PurchaseProductName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "PurchaseProductName_desc":
                    purchase = purchase.OrderByDescending(p => p.PurchaseProductName);
                    break;
                case "PurchaseSupplier":
                    purchase = purchase.OrderBy(p => p.PurchaseSupplier);
                    break;
                case "PurchaseSupplier_desc":
                    purchase = purchase.OrderByDescending(p => p.PurchaseSupplier);
                    break;
                case "PurchaseDate":
                    purchase = purchase.OrderBy(p => p.PurchaseDate);
                    break;
                case "PurchaseDate_desc":
                    purchase = purchase.OrderByDescending(p => p.PurchaseDate);
                    break;
                case "PurcahseBalance":
                    purchase = purchase.OrderBy(p => p.PurcahseBalance);
                    break;
                case "PurcahseBalance_desc":
                    purchase = purchase.OrderByDescending(p => p.PurcahseBalance);
                    break;
                case "PurcahseBillNo":
                    purchase = purchase.OrderBy(p => p.PurchaseBillNo);
                    break;
                case "PurcahseBillNo_desc":
                    purchase = purchase.OrderByDescending(p => p.PurchaseBillNo);
                    break;
                default:
                    purchase = purchase.OrderBy(p => p.PurchaseProductName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(purchase.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Purchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", purchase);
        }

        // GET: /Purchase/Create
        public ActionResult Create()
        {
            var purchase = new Purchase();
            return PartialView("Create", purchase);
        }

        // POST: /Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchase.Add(purchase);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", purchase);
        }

        // GET: /Purchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", purchase);
        }

        // POST: /Purchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", purchase);
        }

        // GET: /Purchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", purchase);
        }

        // POST: /Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            db.Purchase.Remove(purchase);
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
