using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactPname { get; set; }
 
        public string ContactEmail { get; set; }

        public int ContactNumber { get; set; }
        public string ContactSite { get; set; }
        public string ContactFonction { get; set; }
    }
}