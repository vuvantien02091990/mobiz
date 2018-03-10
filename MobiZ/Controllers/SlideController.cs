using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;

namespace MobiZ.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        private MobiZContext db = new MobiZContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slide()
        {
            var slide = db.Slides.Where(x => x.Status == true).ToList();
            var slideSP = db.Products.Where(x=>x.CategoryID==1 || x.CategoryID == 2).Take(4).ToList();
            ViewBag.slide = slide;
            return PartialView(slideSP);
        }
    }
}