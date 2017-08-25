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
    public class SaleController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Sale/
        public ActionResult Index()
        {
            return View(db.Sale.ToList());
        }

        // GET: /Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", sale);
        }

        // GET: /Sale/Create
        public ActionResult Create()
        {
            var sale = new Sale();
            return PartialView("Create", sale);
        }

        // POST: /Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sale.Add(sale);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", sale);
        }

        // GET: /Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", sale);
        }

        // POST: /Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", sale);
        }

        // GET: /Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", sale);
        }

        // POST: /Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sale.Find(id);
            db.Sale.Remove(sale);
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
