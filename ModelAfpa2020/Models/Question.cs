using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa2020.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public int ParagrapheId { get; set; }

        public ICollection<Reponse> MesPeponses { get; set; }
    }
}
