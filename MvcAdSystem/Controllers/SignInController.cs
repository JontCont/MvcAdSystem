using MvcAdSystem.Dtos;
using MvcAdSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcAdSystem.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserPost(UserSignInArgs model)
        {
            if (ModelState.IsValid)
            {
                var context = new AdSystemEntities();
                var users = context.Users.AsNoTracking().SingleOrDefault(x => x.Email == model.UserEmail);
                if (users == null)
                {
                    ModelState.AddModelError("UserEmail", "此Email尚未註冊過");
                    return View("Index", model);
                }

                if (users.Password != model.Password)
                {
                    ModelState.AddModelError("Password", "此 Email 或 密碼輸入錯誤");
                    return View("Index", model);
                }

                DateTime currentDateTime = DateTime.Now;
                var authTicket = new FormsAuthenticationTicket(   // 登入成功，取得門票 (票證)。請自行填寫以下資訊。
                    version: 1,   //版本號（Ver.）
                    name: users.Email, // ***自行放入資料（如：使用者帳號、真實名稱）
                    issueDate: currentDateTime,  // 登入成功後，核發此票證的本機日期和時間（資料格式 DateTime）
                    expiration: currentDateTime.AddHours(3),  //  "一天"內都有效（票證到期的本機日期和時間。）
                    isPersistent: model.RememberMe,  // 記住我？ true or false（畫面上通常會用 CheckBox表示）
                    userData: JsonConvert.SerializeObject(new Dictionary<string, object>() {
                        { "UserName" , users.UserName },
                        { "Email" , users.Email },
                        { "Phone" , users.Phone },
                        { "Roles" , new string[] { "User" }}
                    }),
                    cookiePath: FormsAuthentication.FormsCookiePath
                    );

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
                {
                    HttpOnly = true
                };

                if (authTicket.IsPersistent)
                {
                    authCookie.Expires = authTicket.Expiration;
                }
                Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }
            return View("Index", model);
        }
    }
}