using DataContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAfpa2021.Controllers
{
    public class EtablissementController : Controller
    {
        private readonly DefaultContext _context = null;

        public EtablissementController ( DefaultContext context )
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            this.ViewBag.id = id==null?0:id;
            var query = _context.etablissements.ToList();
            return View(query);
        }

        public IActionResult Edit(int? id)
        {
            return View();
        }
    }
}
