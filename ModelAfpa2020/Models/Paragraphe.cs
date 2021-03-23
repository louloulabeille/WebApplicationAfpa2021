using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa2020.Models
{
    [Table("Paragraphe")]
    public class Paragraphe
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Le numéro du paragraphe est obligatoire.")]
        [Range(1,1000,ErrorMessage ="Le numéro est compris en 1 et 1000")]
        public int Numero { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Le titre doit être saisie.")]
        public string Titre { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="La description doit être saisie.")]
        public string Description { get; set; }

        public Question MaQuestion { get; set; }

        public Reponse MaReponse { get; set; }

    }
}
