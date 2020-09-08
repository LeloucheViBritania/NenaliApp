using FinalCaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class ProDetailVm
    {
        public IEnumerable<Member> Members { get; set; }
        public ProjetDetailDTO projetDetailDTO { get; set; }
    }
}