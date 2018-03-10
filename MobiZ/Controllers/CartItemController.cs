using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Models;
using System.Web.Script.Serialization;
namespace MobiZ.Controllers
{
    public class CartItemController : Controller
    {
        private const string cartSession = "cartSession";
        MobiZContext db = new MobiZContext();
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[cartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem!=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[cartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[cartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[cartSession] = sessionCart;
            return Json(new
            {
                status = true
            });

        }
        public JsonResult DeleteAll()
        {
            Session[cartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long ProductId,int quantity)
        {

            var product = db.Products.Find(ProductId);
            var cart = Session[cartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == ProductId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == ProductId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[cartSession] = list;
            }
            else
            {

                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[cartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string ShipName,string ShipMobile,string ShipMail)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipName = ShipName;
            order.ShipMail = ShipMail;
            order.ShipMobile = ShipMobile;
            db.Orders.Add(order);
            db.SaveChanges();
            var cart = (List<CartItem>)Session[cartSession];
            foreach(var item in cart)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductId = item.Product.ID;
                orderDetail.OrderId = order.ID;
                orderDetail.Price = item.Product.Price;
                orderDetail.Quantity = item.Quantity;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            return Redirect("/mua-hang-thanh-cong");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}