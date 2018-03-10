using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobiZ
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new string[] { "MobiZ.Controllers" }
           );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "CartItem", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new string[] { "MobiZ.Controllers" }
           );
            routes.MapRoute(
             name: "Payment",
             url: "thanh-toan",
             defaults: new { controller = "CartItem", action = "Payment", id = UrlParameter.Optional },
             namespaces: new string[] { "MobiZ.Controllers" }
         );
            routes.MapRoute(
             name: "Cart",
             url: "gio-hang",
             defaults: new { controller = "CartItem", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "MobiZ.Controllers" }
         );
            routes.MapRoute(
             name: "Success",
             url: "mua-hang-thanh-cong",
             defaults: new { controller = "CartItem", action = "Success", id = UrlParameter.Optional },
             namespaces: new string[] { "MobiZ.Controllers" }
         );
            routes.MapRoute(
              name: "Product Category",
              url: "sanpham/{metatitle}-{CategoryId}",
              defaults: new { controller = "Product", action = "GetListProductCategory", id = UrlParameter.Optional },
              namespaces: new string[] { "MobiZ.Controllers" }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "MobiZ.Controllers" }
            );
        }
    }
}
