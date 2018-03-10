using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Models;
using Model.Dao;

namespace MobiZ.Controllers
{
    public class HomeController : Controller
    {
        private MobiZContext db = new MobiZContext();
        public ActionResult Index(string sortOrder)
        {
            var productDao = new ProductDao();
            var listCategory = db.ProductCategories.Where(x => x.ParentID == null).ToList();
            var slide = db.Slides.Where(x => x.Status == true).ToList();
         //   ViewBag.CurentSort = sortOrder;
            var listNewProduct = productDao.ListNewProduct(12);
            var listFeatureProduct = productDao.ListFeatureProduct(12);
            ViewBag.NewProducts = listNewProduct;
            ViewBag.FeatureProducts = listFeatureProduct;
            ViewBag.Slides = slide;

            return View();
        }
        public ActionResult mainMenu()
        {
            var menu = db.ProductCategories.ToList();
            return PartialView(menu);
        }
        public ActionResult HeaderCart()
        {
            var cart = Session[Helpers.Constants.cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

    }
}