using DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ModelAfpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAfpa2020.Layer
{
    public class EtablissementLayer 
    {
        private readonly DefaultContext _context = null;

        public EtablissementLayer(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Méthode qui retourne les enregistrements de la table Etablissement
        /// </summary>
        /// <param name="nb">Nombre d'enregistrement retourné, null tous</param>
        /// <returns></returns>
        public IEnumerable<Etablissement> EtablissementToList(int? nb)
        { 
            return nb == null?_context.etablissements.ToList():_context.etablissements.Take((int)nb);
        }

        public async Task<int> EtablissementAddProcedureAsync( Etablissement etablissement)
        {
            DatabaseFacade facade = new DatabaseFacade(_context);
            await facade.BeginTransactionAsync();
            try
            {
                int nbRow = await _context.Database.ExecuteSqlInterpolatedAsync($"exec dbo.EtablissementInsertCommand {etablissement.IdEtablissement},{etablissement.DesignationEtablissement},{etablissement.ComplementIdentificationEtablissement},{etablissement.NumeroNomVoieEtablissement},{etablissement.ComplementAdresseEtablissement},{etablissement.CodePostalEtablissement},{etablissement.VilleEtablissement},{etablissement.IdEtablissementRattachement}");
                await facade.CommitTransactionAsync();
                return nbRow;
            }
            catch(Exception)
            {
                await facade.RollbackTransactionAsync();
                return 0;
            }
        }

        public int EtablissementAddProcedure(Etablissement etablissement)
        {
            DatabaseFacade facade = new DatabaseFacade(_context);
            facade.BeginTransaction();
            try
            {
                int nbRow = _context.Database.ExecuteSqlInterpolated($"exec dbo.EtablissementInsertCommand {etablissement.IdEtablissement},{etablissement.DesignationEtablissement},{etablissement.ComplementIdentificationEtablissement},{etablissement.NumeroNomVoieEtablissement},{etablissement.ComplementAdresseEtablissement},{etablissement.CodePostalEtablissement},{etablissement.VilleEtablissement},{etablissement.IdEtablissementRattachement}");
                facade.CommitTransactionAsync();
                return nbRow;
            }
            catch (Exception)
            {
                facade.RollbackTransaction();
                return 0;
            }
        }

        public async Task<int> EtablissementUpdateProcedureAsync(Etablissement etablissement)
        {
            DatabaseFacade facade = new DatabaseFacade(_context);
            await facade.BeginTransactionAsync();
            try
            {
                int nbRow = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.EtablissementUpdateCommand {etablissement.IdEtablissement},{etablissement.DesignationEtablissement},{etablissement.ComplementIdentificationEtablissement},{etablissement.NumeroNomVoieEtablissement},{etablissement.ComplementAdresseEtablissement},{etablissement.CodePostalEtablissement},{etablissement.VilleEtablissement},{etablissement.IdEtablissementRattachement},{etablissement.IdEtablissement}");
                await facade.CommitTransactionAsync();
                return nbRow;
            }
            catch(Exception)
            {
                await facade.RollbackTransactionAsync();
                return 0;
            }
        }

        public int EtablissementUpdateProcedure(Etablissement etablissement)
        {
            DatabaseFacade facade = new DatabaseFacade(_context);
            facade.BeginTransaction();
            try
            {
                int nbRow = _context.Database.ExecuteSqlInterpolated($"EXEC dbo.EtablissementUpdateCommand {etablissement.IdEtablissement},{etablissement.DesignationEtablissement},{etablissement.ComplementIdentificationEtablissement},{etablissement.NumeroNomVoieEtablissement},{etablissement.ComplementAdresseEtablissement},{etablissement.CodePostalEtablissement},{etablissement.VilleEtablissement},{etablissement.IdEtablissementRattachement},{etablissement.IdEtablissement}");
                facade.CommitTransaction();
                return nbRow;
            }
            catch (Exception)
            {
                facade.RollbackTransaction();
                return 0;
            }
        }

        public Etablissement EtablissementFind(string id)
        {
            return _context.etablissements.Find(id);
        }

        public void EtablissementAdd(Etablissement etablissement)
        {
            _context.Add(etablissement);
            _context.SaveChanges();
        }


        public void EtablissementUpdate (Etablissement etablissement)
        {
            _context.Update(etablissement);
            _context.SaveChanges();
        }

        public async void EtablissementAddAsync(Etablissement etablissement)
        {
            _context.Add(etablissement);
            await _context.SaveChangesAsync();
        }

        public async void EtablissementUpdateAsync(Etablissement etablissement)
        {
            _context.Update(etablissement);
            await _context.SaveChangesAsync();
        }
    }
}
