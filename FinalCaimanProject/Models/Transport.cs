using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class Transport
    {
        [Key]
        public int TransportId { get; set; }

        public string TranportName { get; set; }

         //recupere la liste des membre qui ont le meme type de transport
        public virtual ICollection<Member> Members { get; set; }
    }
}