using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobiZ.Areas.Admin.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}