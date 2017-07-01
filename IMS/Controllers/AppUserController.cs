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
    public class AppUserController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: /AppUser/
        public ActionResult Index()
        {
            var appuser = db.AppUser.Include(a => a.Role);
            return View(appuser.ToList());
        }

        // GET: /AppUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appuser = db.AppUser.Find(id);
            if (appuser == null)
            {
                return HttpNotFound();
            }
            return View(appuser);
        }

        // GET: /AppUser/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName");
            return View();
        }

        // POST: /AppUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AppUserId,AppUserName,AppUserEmail,AppUserPassword,AppUserComfirmPassword,RoleId")] AppUser appuser)
        {
            if (ModelState.IsValid)
            {
                db.AppUser.Add(appuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName", appuser.RoleId);
            return View(appuser);
        }

        // GET: /AppUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appuser = db.AppUser.Find(id);
            if (appuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName", appuser.RoleId);
            return View(appuser);
        }

        // POST: /AppUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AppUserId,AppUserName,AppUserEmail,AppUserPassword,AppUserComfirmPassword,RoleId")] AppUser appuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName", appuser.RoleId);
            return View(appuser);
        }

        // GET: /AppUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appuser = db.AppUser.Find(id);
            if (appuser == null)
            {
                return HttpNotFound();
            }
            return View(appuser);
        }

        // POST: /AppUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUser appuser = db.AppUser.Find(id);
            db.AppUser.Remove(appuser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
