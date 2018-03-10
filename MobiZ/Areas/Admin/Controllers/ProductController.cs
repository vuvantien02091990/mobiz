using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Areas.Admin.Controllers;
using MobiZ.Areas.Admin.Models;
using PagedList;
namespace MobiZ.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private MobiZContext db = new MobiZContext();
        // GET: Product
        public ActionResult Index(int? page ,string searchString)
        {

            var products = from p in db.Products
                           join c in db.ProductCategories on p.CategoryID equals c.ID
                           join d in db.Manufacturers on p.ManufacturerID equals d.ID
                           select new ProductView
                           {
                               ID = p.ID,
                               Name = p.Name,
                               Img = p.Image,
                               Price = p.Price,
                               CategoryName = c.Name,
                               ManuName = d.Name
                                        };
            if (searchString!= null)
            {
                page = 1;
            }
            if(!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
           
           // ViewBag.CatName = result;
            return View(products.OrderBy(p=>p.Name).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetListCategory();
            SetManufacturer();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product();
                var session = (UserLoginModel)Session["userSession"];
                entity.Name = product.Name;
                entity.MetaTitle = product.MetaTitle;
                entity.Code = product.Code;
                entity.Decriptions = product.Decriptions;
                entity.MetaKeywords = product.MetaKeywords;
                entity.Image = product.Image;
                entity.Price = product.Price;
                entity.CategoryID = product.CategoryID;
                entity.ManufacturerID = product.ManufacturerID;
                entity.CreateDate = DateTime.Now;
                entity.Status = true;
                entity.Detail = product.Detail;
                entity.CreateBy = session.Name;
                db.Products.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // SetListCategory();
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(long?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            SetListCategory(product.CategoryID);
            SetManufacturer(product.ManufacturerID);
            return View(product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Products.Find(product.ID);
                var session = (UserLoginModel)Session["userSession"];
                entity.Name = product.Name;
                entity.MetaTitle = product.MetaTitle;
                entity.Code = product.Code;
                entity.Decriptions = product.Decriptions;
                entity.MetaKeywords = product.MetaKeywords;
                entity.Image = product.Image;
                entity.Price = product.Price;
                entity.CategoryID = product.CategoryID;
                entity.CreateBy = entity.CreateBy;
                entity.CreateDate = entity.CreateDate;
                entity.ManufacturerID = product.ManufacturerID;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = true;
                entity.Detail = product.Detail;
                entity.ModifiedBy = session.Name;
              //  db.Products.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             SetListCategory(product.CategoryID);
            SetManufacturer(product.ManufacturerID);
            return View(product);
        }
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void SetListCategory(long? Selected = null)
        {
            var listCategory = db.ProductCategories.Where(x => x.ParentID == null).ToList();
            ViewBag.CategoryId = new SelectList(listCategory, "ID", "Name", Selected);
        }
        public void SetManufacturer(long? Selected = null)
        {
            var listManufacturer = db.Manufacturers.ToList();
            ViewBag.ManufacturerID = new SelectList(listManufacturer,"ID","Name",Selected);
        }
        [HttpGet]
        public ActionResult Load()
        {
            var listProduct = db.Products.ToList();
            return Json(new {
                data = listProduct,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}