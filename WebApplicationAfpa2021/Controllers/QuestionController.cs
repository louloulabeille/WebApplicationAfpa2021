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
    public class QuestionController : ControllerBase
    {
        public QuestionController ( DefaultContext context )
            :base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.ParagrapheList = _context.Paragraphes.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add( Question question )
        {
            if ( question == null )
            {
                return NotFound();
            }
            if ( ModelState.IsValid )
            {
                try
                {
                    _context.Add(question);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute("Debut-Aventure");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToRoute("Debut-Aventure");
                }
            }
            ViewBag.ParagrapheList = _context.Paragraphes.ToList();
            return View(question);
        }
    }
}
