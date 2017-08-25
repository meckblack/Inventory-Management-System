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
    public class ProductController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Product/
        [Route("Product/Index/{CategoryId}")]
        public ActionResult Index(int CategoryId)
        {
            var x = db.Category.Find(CategoryId);
            Session["categoryname"] = x.CategoryName;
            Session["categoryId"] = x.CategoryId;

            var product = db.Product.Where(p => p.CategoryId == CategoryId).ToList();
            return View(product);
        }

        // GET: /Product/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            var product = new Product();
            return PartialView("Create", product);
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductQuantity,ProductDescription,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                var p = new Product
                {
                    CategoryId = Convert.ToInt32(Session["categoryId"]),
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductQuantity = product.ProductQuantity
                };
                db.Product.Add(p);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", product.CategoryId);
            return PartialView("Edit", product);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductQuantity,ProductDescription,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", product.CategoryId);
            return PartialView("Edit", product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
