using System.Web.Mvc;

namespace MobiZ.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Admin_User",
               "Admin/nguoi-dung",
               new { controller = "Users", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "MobiZ.Areas.Admin.Controllers" }
           );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces : new string[] { "MobiZ.Areas.Admin.Controllers" }
            );
        }
    }
}