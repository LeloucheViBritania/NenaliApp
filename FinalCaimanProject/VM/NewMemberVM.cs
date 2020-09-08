using FinalCaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCaimanProject.VM
{
    public class NewMemberVM
    {
        public int MemberId { get; set; }

        public int MemberMissionActive { get; set; }
        public int SpecialiteId { get; set; }
        public string MemberName { get; set; }
        public string MemberImageName { get; set; }
        public string MemberPnom { get; set; }
        public int MemberNote { get; set; }
        public bool IsChecked { get; set; }
 
    }
}