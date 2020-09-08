using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class SocialNetwork
    {
        [Key]
        public int SocialNetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NetworkLink { get; set; }
        public virtual Member Member { get; set; }
    }
}