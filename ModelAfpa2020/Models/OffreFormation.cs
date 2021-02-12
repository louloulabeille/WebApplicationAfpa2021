using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ModelAfpa
{
    [Table("OffreFormation")]
    public partial class OffreFormation
    {
        public OffreFormation()
        {
            //StagiaireOffreFormations = new HashSet<StagiaireOffreFormation>();
        }

        public int IdOffreFormation { get; set; }
        public string IdEtablissement { get; set; }
        public DateTime DateDebutOffreFormation { get; set; }
        public DateTime DateFinOffreFormation { get; set; }
        public int? IdPersonne { get; set; }
        public string IdProduitFormation { get; set; }

        public virtual Etablissement IdEtablissementNavigation { get; set; }
        //public virtual CollaborateurAfpa IdPersonneNavigation { get; set; }
        //public virtual ProduitDeFormation IdProduitFormationNavigation { get; set; }
        //public virtual ICollection<StagiaireOffreFormation> StagiaireOffreFormations { get; set; }

        public override string ToString()
        {
            return string.Format("date de début: "+this.DateDebutOffreFormation)+string.Format("date de fin: "+this.DateFinOffreFormation);
        }
    }
}
