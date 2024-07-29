using MvcAdSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class UserInfo
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string EnglishUserName { get; set; }
        public string UserPhone { get; set; }
        public UserSex userSex { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserAddress { get; set; }
        public DateTime UserAddDataTime { get; set; }

        //image
        public string UserImage { get; set; }
    }
}