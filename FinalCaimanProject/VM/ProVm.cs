using FinalCaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCaimanProject.VM
{
    public class ProVm
    {
        public string ProjetName { get; set; }
        public DateTime ProjetDateDebut { get; set; }
        public string ProjetDescription { get; set; }
        public string ProjetCahierCharge { get; set; }
       

        public ICollection<NewMemberVM> Members { get; set; }
        public ICollection<Specialite> Specialites { get; set; }
        public ICollection<Member> memerBySpe { get; set; }
    }
}