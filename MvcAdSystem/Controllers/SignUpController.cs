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
                // 保存User資料至資料庫的邏輯
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}