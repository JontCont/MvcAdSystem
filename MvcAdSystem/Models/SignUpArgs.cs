using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdSystem.Models
{
    public class SignUpArgs
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}