using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class ProjetsDTO
    {
        public int ProjetId { get; set; }

        public string ProjetName { get; set; }

        public bool IsArchieved { get; set; }

        public DateTime ProjetDateDebut { get; set; }
        public DateTime ProjetDateFin { get; set; }
        public string ProjetDescription { get; set; }
        public string ProjetObservationFinal { get; set; }
        public int ProjetProgressBar { get; set; }
        public int ProjetMoney { get; set; }
        public IList<MembersDTO> MembersDTOs { get; set; }
    }
}