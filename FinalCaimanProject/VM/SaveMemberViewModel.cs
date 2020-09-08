using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FinalCaimanProject.Models;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class SaveMemberViewModel
    {
       public Member Member { get; set; }
        public IList<Specialite> Specialites { get; set; }
        public IList<Transport> Transports { get; set; }

    }
}