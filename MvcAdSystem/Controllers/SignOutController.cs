using MvcAdSystem.Dtos;
using MvcAdSystem.Models;
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
    public class SignOutController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "SignIn");
        }
    }
}