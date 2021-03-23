using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa2020.Models
{
    [Table("Reponse")]
    public class Reponse
    {
        #region Propriété
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="La réponse à la question doit être saisie.")]
        [StringLength(255,MinimumLength =15,ErrorMessage ="La réponse doit comporter 15 caractères minimun et 255 caractères maximun.")]
        public string Description { get; set; }
        [Required]
        public int QuestionId { get; set; }

        public int? ParagrapheId { get; set; }

        #endregion
    }
}
