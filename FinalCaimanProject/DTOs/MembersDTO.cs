using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class MembersDTO
    {
        public int MemberId { get; set; }

        public string MemberName { get; set; }
        public string MemberPnom { get; set; }

        public string MemberImageName { get; set; }
        public int MemberNote { get; set; }

        public int ProjetMoney { get; set; }
        public int SpecialiteId { get; set; }
    }
}