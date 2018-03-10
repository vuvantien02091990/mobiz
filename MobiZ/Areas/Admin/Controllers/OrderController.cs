using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Areas.Admin.Models;
using PagedList;
namespace MobiZ.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        MobiZContext db = new MobiZContext();
        // GET: Admin/Order
        public ActionResult Index(int? page,string searchString)
        {
            var orders = from od in db.OrderDetails
                         join o in db.Orders on od.OrderId equals o.ID
                         join p in db.Products on od.ProductId equals p.ID
                         select new OrderView
                         {
                             OrderId = od.OrderId,
                             ProductName = p.Name,
                             ShipName = o.ShipName,
                             ShipAddress = o.ShipAddress,
                             ShipMail = o.ShipMail,
                             ShipMobile = o.ShipMobile,
                             Price = od.Price,
                             Quantity= od.Quantity

                         };
            if (searchString != null)
            {
                page = 1;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o=>o.ProductName.Contains(searchString) || o.ShipName.Contains(searchString));
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(orders.OrderBy(x=>x.ShipName).ToPagedList(pageNumber,pageSize));
        }
    }
}