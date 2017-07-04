using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["AdminId"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login");
            }

        }
	}
}