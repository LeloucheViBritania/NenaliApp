using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.Models
{
    public class Competence
    {
        [Key]
        public int CompetenceId { get; set; }
        public string CompetenceName { get; set; }
        //recuperation d'une personne qui a une competence
        public virtual Member Member { get; set; }

    }
}