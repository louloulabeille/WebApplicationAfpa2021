using DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelAfpa2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationAfpa2021.Controllers
{
    [Authorize]
    public class ReponseController : ControllerBase
    {
        public ReponseController( DefaultContext context )
            :base(context)
        {

        }

        public IActionResult Index()
        {
            var query = _context.Reponses.ToList();
            if ( query.Count()==0 )
            {
                return RedirectToAction(nameof(Create));
            }
            return View(query);
        }

        public IActionResult Create()
        {
            ListeQuestion();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reponse reponse)
        {
            if ( reponse == null )
            {
                return NotFound();
            } 
            if ( ModelState.IsValid )
            {
                try
                {
                    _context.Add(reponse);
                    await _context.SaveChangesAsync();
                    RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));

                }
            }
            ListeQuestion();
            return View(reponse);
        }

        private void ListeQuestion()
        {
            this.ViewBag.questionList = _context.Questions.ToList();
        }
    }
}
