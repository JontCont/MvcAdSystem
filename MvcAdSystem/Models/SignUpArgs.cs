using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class SignUpArgs
    {
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Display(Name = "手機")]
        public string UserPhone { get; set; }
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Display(Name = "確認密碼")]
        public string ConfirmPassword { get; set; }
    }
}