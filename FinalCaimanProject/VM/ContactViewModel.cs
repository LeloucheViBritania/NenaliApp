using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Le champ Nom est requis")]
        [Display(Name = "Nom")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(90, ErrorMessage = "Le champ Prénom est requis")]
        [Display(Name = "Prénoms")]
        public string ContactPname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adresse Mail")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Adresse Mail Invalide")]
        public string ContactEmail { get; set; }



        [Required]
        [Display(Name ="Téléphone")]
        [RegularExpression(@"((\+)?[ ]?(225))?[ ]?[02456789]{1}[\d]{1}([ _.-]?[\d]{2}){3}", ErrorMessage = "Ce champ requiert un numéro ivoirien")]
        public int ContactNumber { get; set; }


        
        [Display(Name = "Site Web")]
        public string ContactSite { get; set; }

        [Display(Name = "Fonction")]
        public string ContactFonction { get; set; }
    }
}