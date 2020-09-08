using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPnom { get; set; }
        public string UserSexe { get; set; }
        public string UserMail { get; set; }
        public string UserPhone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}