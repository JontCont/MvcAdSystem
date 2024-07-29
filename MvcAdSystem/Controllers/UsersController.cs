using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdSystem.Dtos;
using MvcAdSystem.Models;
namespace MvcAdSystem.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(string email)
        {

            var context = new AdSystemEntities();
            var user = context.Users.Where(x => x.Email == email)
                .Select(x=>new UserInfo {
                    UserEmail = x.Email,
                    UserName = x.UserName,
                    EnglishUserName = x.EnglishName,
                    //UserPhone = x.Phone,
                    UserAddDataTime = x.CreateDateTime,
                    UserAddress = x.Address,
                    UserBirthday = x.Birthday,
                    UserSex = x.Sex
                });

            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //var context = new AdSystemEntities();
                //context.SaveChanges();
                //context.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
