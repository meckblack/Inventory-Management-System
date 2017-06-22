﻿using System;
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
    public class CategoryController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /Category/
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CategoryNameParm = String .IsNullOrEmpty(sortOrder) ? "CategoryName_desc": "";
            var category = from c in db.Category
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                category = category.Where(c => c.CategoryName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch(sortOrder)
            {
                case "CategoryName_desc":
                    category = category.OrderByDescending(c => c.CategoryName);
                    break;
                default:
                    category = category.OrderBy(c => c.CategoryName);
                    break;
            }
            return View(category.ToList());
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            var category = new Category();
            return PartialView("", category);
        }

        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", category);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", category);
        }

        // POST: /Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", category);
        }

        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", category);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
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
