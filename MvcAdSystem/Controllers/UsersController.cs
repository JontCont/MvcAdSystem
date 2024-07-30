using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MvcAdSystem.Dtos;
using MvcAdSystem.Models;
namespace MvcAdSystem.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var context = new AdSystemEntities();


            if (User.Identity.IsAuthenticated)
            {
                string email = User.Identity.Name;
                var user = context.Users.Where(x => x.Email == email)
                    .Select(x => new UserInfo
                    {
                        UserEmail = x.Email,
                        UserName = x.UserName,
                        EnglishUserName = x.EnglishName,
                        UserPhone = x.Phone,
                        UserAddDataTime = x.CreateDateTime,
                        UserAddress = x.Address,
                        UserBirthday = x.Birthday,
                        UserSex = x.Sex
                    }).SingleOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError("", "登入帳號異常，請重新登入");
                }
                return View(user);

            }
            ModelState.AddModelError("", "尚未登入此系統");
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
