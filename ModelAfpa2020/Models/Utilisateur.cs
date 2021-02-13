using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        public string Logging { get; set; }
        public string Courriel { get; set; }
        public string Passworld { get; set; }

    }
}
