using FinalCaimanProject.DTOs;
using FinalCaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class ProfilMVM
    {
        public ProfilMemberDTO ProfilMemberDTO { get; set; }

        public List<Specialite> Specialites { get; set; }
        public List<Transport> Transports { get; set; }
    }
}