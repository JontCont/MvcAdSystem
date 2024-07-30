using MvcAdSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class UserInfo
    {
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Display(Name = "英文名字")]
        public string EnglishUserName { get; set; }
        [Display(Name = "手機")]
        public string UserPhone { get; set; }
        [Display(Name = "性別")]
        public int UserSex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "生日")]
        public DateTime? UserBirthday { get; set; }
        [Display(Name = "地址")]
        public string UserAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "加入會員時間")]
        public DateTime? UserAddDataTime { get; set; }

        //image
        [Display(Name ="大頭貼")]
        public string UserImage { get; set; }
    }
}