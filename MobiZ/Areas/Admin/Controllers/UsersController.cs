using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Areas.Admin.Controllers;
using MobiZ.Helpers;
using PagedList;

namespace MobiZ.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private MobiZContext db = new MobiZContext();

        // GET: Admin/Users
        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UsernameSort = String.IsNullOrEmpty(sortOrder) ? "username_desc" : "";
            ViewBag.NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            var users = from u in db.Users
                        select u;
            ViewBag.SearchString = searchString;
            if(searchString != null)
            {
                page = 1;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Username.Contains(searchString) || u.FullName.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "username_desc":
                    users = users.OrderByDescending(u => u.Username);
                    break;
                case "Name":
                    users = users.OrderBy(u => u.FullName);
                    break;
                case "name_desc":
                    users = users.OrderByDescending(u => u.FullName);
                    break;
                default:
                    users = users.OrderBy(u => u.Username);
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var Entity = new User();
                var checkUsername = db.Users.SingleOrDefault(x => x.Username == user.Username);
                var checkEmail = db.Users.SingleOrDefault(x => x.Email == user.Email);
                int count = 0;
                if (checkUsername != null)
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                    count++;
                }
                if(checkEmail != null)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    count++;
                }
                if(count == 0)
                {
                    Entity.Username = user.Username;
                    Entity.Password = GetMd5.Generate(user.Password);
                    Entity.FullName = user.FullName;
                    Entity.Age = user.Age;
                    Entity.Address = user.Address;
                    Entity.Avatar = user.Avatar;
                    Entity.Email = user.Email;
                    Entity.AccessDeTail = null;
                    db.Users.Add(Entity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Users.Find(user.Id);
                entity.FullName = user.FullName;
                entity.Age = user.Age;
                entity.Address = user.Address;
                entity.Avatar = user.Avatar;
                var checkMail = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if(checkMail != null)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    entity.Email = user.Email;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
