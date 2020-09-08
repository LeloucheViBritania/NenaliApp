using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage ="Le champ Nom est requis")]
        [Display(Name = "Nom")]
        public string UserName { get; set; }

        [Required]
        [StringLength(90, ErrorMessage = "Le champ Prénoms est requis")]
        [Display(Name = "Prénoms")]
        public string UserPnom { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Le champ Sexe est requis", MinimumLength = 3)]
        [Display(Name = "Sexe")]
        public string UserSexe { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adresse Mail")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage ="Adresse Mail Invalide")]
        public string UserMail { get; set; }


        [Required]
        [Phone]
        [Display(Name = "Téléphone")]
        [RegularExpression(@"((\+)?[ ]?(225))?[ ]?[02456789]{1}[\d]{1}([ _.-]?[\d]{2}){3}", ErrorMessage ="Ce champ requiert un numéro ivoirien")]
        public string UserPhone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}