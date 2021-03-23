using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelAfpa
{
    [Table("Etablissement")]
    public partial class Etablissement
    {
        public Etablissement()
        {
            InverseIdEtablissementRattachementNavigation = new HashSet<Etablissement>();
            //OffreFormations = new HashSet<OffreFormation>();
        }
        [Key]
        [Required(AllowEmptyStrings =false,ErrorMessage ="La saisie du code établissement est obligatoire.")]
        [Display(Name ="Identifiant de l'établissement")]
        public string IdEtablissement { get; set; }

        [Display(Name ="Nom de l'établissement")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Le nom de l'établissement est obligatoire.")]
        [StringLength(255,ErrorMessage ="Le nom de l'établissement doit comporter 255 caractères maximun.")]
        public string DesignationEtablissement { get; set; }

        [Display(Name ="Complément d'information sur l'établissement")]
        [StringLength(255, ErrorMessage ="Ce champ doit doit comporter 255 caractères maximun.")]
        public string ComplementIdentificationEtablissement { get; set; }

        [Display(Name ="Adresse")]
        [StringLength(255, ErrorMessage = "Ce champ doit doit comporter 255 caractères maximun.")]
        public string NumeroNomVoieEtablissement { get; set; }

        [Display(Name ="Complément de l'adresse")]
        [StringLength(255, ErrorMessage = "Ce champ doit doit comporter 255 caractères maximun.")]
        public string ComplementAdresseEtablissement { get; set; }

        [Display(Name ="Code postal")]
        [Required(AllowEmptyStrings = true)]
        [StringLength(5,MinimumLength = 1,ErrorMessage ="Le code postal doit comporter 5 caractères.")]
        [RegularExpression(@"^[0-9]{5}",ErrorMessage ="Le code postal doit comporter 5 chiffres.")]
        public string CodePostalEtablissement { get; set; }

        [Display(Name ="Ville")]
        [StringLength(255, ErrorMessage = "Ce champ doit doit comporter 255 caractères maximun.")]
        public string VilleEtablissement { get; set; }
        public string IdEtablissementRattachement { get; set; }

        public virtual Etablissement IdEtablissementRattachementNavigation { get; set; }
        public virtual ICollection<Etablissement> InverseIdEtablissementRattachementNavigation { get; set; }
        public virtual ICollection<OffreFormation> OffreFormations { get; set; }
    }
}
