using MvcAdSystem.Dtos;
using MvcAdSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdSystem.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(SignUpArgs model)
        {
            if (ModelState.IsValid)
            {
                var context = new AdSystemEntities();
                var isEmailExist = context.Users.Any(x => x.Email == model.UserEmail);
                if (isEmailExist)
                {
                    //error 
                    ModelState.AddModelError("UserEmail", "此Email已經註冊過了");
                    return View("Index",model);
                }

                // 保存User資料至資料庫的邏輯
                Dtos.User user = new User { 
                    UserName = model.UserName,
                    Email = model.UserEmail,
                    Phone = model.UserPhone,
                    Password = model.Password
                };
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                context.Dispose();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", model);
        }
    }
}