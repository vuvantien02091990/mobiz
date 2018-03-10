using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MobiZ.Areas.Admin.Models;

namespace MobiZ.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLoginModel)Session["userSession"];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login", Area = "Admin" }));

            }
            base.OnActionExecuted(filterContext);
        }
    }
}