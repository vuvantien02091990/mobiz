using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;

namespace MobiZ.Controllers
{
    public class ProductController : Controller
    {
        private MobiZContext db = new MobiZContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Categories()
        {
            var categories = db.ProductCategories.ToList();
            return PartialView(categories);
        }
        //public List<Product> ListNewProduct(int top)
        //{
        //    return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        //}
        //public List<Product> ListFeatureProduct(int top)
        //{
        //    return db.Products.Where(x=>x.TopHot != null).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        //}
        public ActionResult ProductCategory(long Id)
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            var details = db.Products.Find(id);
            return View(details);
        }
        public ActionResult GetListProductCategory(long CategoryId,string currentFilter)
        {
            ViewBag.CurrentFilter = currentFilter;
            var catId = db.ProductCategories.Find(CategoryId);
            var list = db.Products.Where(x => x.CategoryID == CategoryId).ToList();
            long IphoneId = getManuId("Iphone");
            long SamSungID = getManuId("Samsung");
            long OppoId = getManuId("oppo");
            var listIphone = list.Where(x => x.ManufacturerID == IphoneId).Take(4).ToList();
            var listSamsung = list.Where(x => x.ManufacturerID == SamSungID).Take(4).ToList();
            var listOppo = list.Where(x => x.ManufacturerID == OppoId).Take(4).ToList();
            //ViewBag.CurrentFilter
            ViewBag.Category = catId;
          //  ViewBag.Iphone = listIphone;
          //  ViewBag.Samsung = listSamsung;
           // ViewBag.Oppo = listOppo;
            switch(currentFilter)
            {
                case "Iphone":
                    list = listIphone;
                    break;
                case "Oppo":
                    list = listOppo;
                    break;
                case "Samsung":
                    list = listSamsung;
                    break;
                default:
                    break;

            }
            return View(list);
        }
        public long getManuId(string manuName)
        {
            return db.Manufacturers.FirstOrDefault(x => x.Name.Contains(manuName)).ID;
        }
    }
}