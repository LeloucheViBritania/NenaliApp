using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCaimanProject.VM
{
    public class SpecialitieVM
    {
        [Required]
        [StringLength(30, ErrorMessage ="Le nom est trop long")]
        [Display(Name ="Nom")]
        public string SpecialiteName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Donnez une brief description")]
        [Display(Name = "Description")]
        public string SpecialiteInfo { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="Le nom est trop long")]
        /*[RegularExpression(@"^([a-z])$", ErrorMessage ="Le nom de la couleur ne peut pas contenir de chiffre")]*/
        [Display(Name = "Couleur 'en Anglais svp' ")]
        public string SpecialiteColor { get; set; }

        [Required(ErrorMessage = "Selectionnez un fichier image svp !")]
        [Display(Name ="Image")]
        /*[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Extension non pris en charge")]*/
        public string ImageSpecialité { get; set; }

        public string Url_Image { get; set; }

    }
}