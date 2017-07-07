using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using IMS.DAL;
using IMS.Models;
using System;

namespace IMS.Controllers
{
    public class AppUserController : Controller
    {
        private IMS_DB db = new IMS_DB();

        // GET: AppUser
        public ActionResult Index()
        {
            var appUser = db.AppUser.Include(a => a.Role);
            return View(db.AppUser.ToList());
        }
        

        // GET: AppUser/Register
        public ActionResult Register()
        {
            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName");
            return View();
        }

        // POST: AppUser/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "AppUserId,AppUserName,AppUserEmail,AppUserPassword,AppUserComfirmPassword,RoleId")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.AppUser.Add(appUser);
                appUser.RoleId = Convert.ToInt32(Session["role"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Role, "RoleId", "RoleName", appUser.RoleId);
            return View(appUser);
        }

        // GET: AppUser/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: AppUser/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AppUser appUser)
        {
            var user = db.AppUser.Where(ap => ap.AppUserName == appUser.AppUserName && ap.AppUserPassword == appUser.AppUserPassword).SingleOrDefault();
            if (user != null)
            {
                Session["AppUserId"] = user.AppUserId.ToString();
                Session["AppUsername"] = user.AppUserName.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Password doesnt match the Username");
            }
            
            return View();
        }

        //Logged In
        public ActionResult Dashboard()
        {
            if (Session["AppUserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
            
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
