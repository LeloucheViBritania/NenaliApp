using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class ProjetMember
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ProjetId { get; set; }
        public Projet Projet{ get; set; }
       
    }
}