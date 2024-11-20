using System;
using System.Collections.Generic;
using System.IO;
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

        ~UsersController()
        {
            Dispose();
        }

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
        public ActionResult Edit(UserInfo model, HttpPostedFileBase file)
        {
            var context = new AdSystemEntities();
            try
            {
                // TODO: Add update logic here
                var users = context.Users.Find(model.UserEmail);
                if (users == null)
                {
                    ModelState.AddModelError("", "尚未登入帳號");
                    context.Dispose();
                    return View("Index", model);
                }
                else
                {
                    users.UserName = model.UserName;
                    users.EnglishName = model.EnglishUserName;
                    users.Phone = model.UserPhone;
                    users.Sex = model.UserSex;
                    users.Address = model.UserAddress;
                    users.Birthday = model.UserBirthday;
                    users.UserImage = GetImageData(file) ?? model.UserImage;
                    context.SaveChanges();
                    context.Dispose();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                context.Dispose();
                return View();
            }
        }

        public ActionResult GetImage(string email)
        {
            var context = new AdSystemEntities();

            var user = context.Users.Find(email);
            if (user != null && user.UserImage != null)
            {
                return File(user.UserImage, "image/jpeg");
            }
            return HttpNotFound();
        }

        private byte[] GetImageData(HttpPostedFileBase file)
        {
            byte[] bytes = null;
            if (file != null && file.ContentLength > 0)
            {
                using (var reader = new BinaryReader(file.InputStream))
                {
                    bytes = reader.ReadBytes(file.ContentLength);
                }
            }
            return bytes;
        }
    }
}
