using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.DTOs
{
    public class ProjetDirectiveDTO
    {
        public int ProjetId { get; set; }

        public string ProjetName { get; set; }
        public string ProjetCahierCharge { get; set; }

        public string ProjetDescription { get; set; }
    }
}