using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class UserSignInArgs
    {
        [Display(Name = "帳號(Email)")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string UserEmail { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我")]
        public bool RememberMe { get; set; } = false;
    }
}