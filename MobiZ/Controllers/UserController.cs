using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Model;
using MobiZ.Helpers;
using HiHe.Models;
using MobiZ.Models;
//using Model.EF;

namespace MobiZ.Controllers
{
    public class UserController : Controller
    {
        MobiZContext db = new MobiZContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel user)
        {
            if(ModelState.IsValid)
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
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    count++;
                }
                if (count == 0)
                {
                    Entity.Username = user.Username;
                    Entity.Password = GetMd5.Generate(user.Password);
                    Entity.FullName = user.FullName;
                    Entity.Age = user.Age;
                    Entity.Address = user.Address;
                    Entity.Email = user.Email;
                    Entity.AccessDeTail = null;
                    Entity.PhoneNumber = user.PhoneNumber;
                    db.Users.Add(Entity);
                    db.SaveChanges();
                    return Redirect("/");
                }
            }
            return View(user);
        }
    }
}