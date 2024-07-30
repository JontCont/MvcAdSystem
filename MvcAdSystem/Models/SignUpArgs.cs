using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class SignUpArgs
    {
        [Required(ErrorMessage = "請輸入Email")]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "請輸入姓名")]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "請輸入手機")]
        [RegularExpression(@"^09\d{2}-?\d{3}-?\d{3}$", ErrorMessage = "手機格式錯誤")]
        [StringLength(10, ErrorMessage = "手機號碼長度錯誤", MinimumLength = 10)]
        [Display(Name = "手機")]
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(20, ErrorMessage = "密碼長度錯誤", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Required(ErrorMessage = "請輸入確認密碼")]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不一致")]
        [StringLength(20, ErrorMessage = "確認密碼長度錯誤", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        public string ConfirmPassword { get; set; }
    }
}