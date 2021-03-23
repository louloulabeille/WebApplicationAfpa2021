using DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelAfpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using ModelAfpa2020.Layer;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationAfpa2021.Controllers
{
    //[Authorize]
    public class EtablissementController : ControllerBase
    {
        private EtablissementLayer _etablissementLayer = null;

        public EtablissementController(DefaultContext context)
            :base(context)
        {
            _etablissementLayer = new EtablissementLayer(context);
        }

        public IActionResult Index()
        {
            //this.ViewBag.Toto = this.HttpContext.Session.GetString("Toto");
            //ICollection<Etablissement> query = _context.etablissements
            //            .FromSqlRaw("select top(2) * from Etablissement order by idEtablissement desc").ToList();
            var query = _etablissementLayer.EtablissementToList(null);
            return View(query);
        }

        public IActionResult Edit(string id)
        {
            //this.HttpContext.Session.SetString("Toto", "Toto");
            var query = _etablissementLayer.EtablissementFind(id);
            ListeEtablissement();
            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string IdEtablissement,Etablissement etablissement )
        {
            if ( IdEtablissement != etablissement.IdEtablissement  )
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _etablissementLayer.EtablissementUpdateProcedureAsync(etablissement);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ListeEtablissement();
            return View(etablissement);
        }

        public IActionResult Create()
        {
            ListeEtablissement();
            return View();
        }
        
        //[HttpPost]
        //public async Task<IActionResult> Create(Etablissement etablissement)
        //{
        //    if ( etablissement == null )
        //    {
        //        return NotFound();
        //    } 

        //    if ( ModelState.IsValid )
        //    {
        //        try
        //        {
        //            await _etablissementLayer.EtablissementAddProcedureAsync(etablissement);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbException)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    ListeEtablissement();
        //    return View(etablissement);
        //}

        [HttpPost]
        public IActionResult Create(Etablissement etablissement)
        {
            if (etablissement == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _etablissementLayer.EtablissementAddProcedure(etablissement);
                    //return View(etablissement); pour les tests
                    return RedirectToAction(nameof(Index));
                }
                catch (DbException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ListeEtablissement();
            return View(etablissement);
        }

        protected void ListeEtablissement() 
        {
            this.ViewBag.IdEtablissementRattachement = _etablissementLayer.EtablissementToList(null);
        }
    }
}
