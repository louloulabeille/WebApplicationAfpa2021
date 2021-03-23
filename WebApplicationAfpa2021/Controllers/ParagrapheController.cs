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
    public class ParagrapheController : ControllerBase
    {
        public ParagrapheController(DefaultContext context)
            :base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paragraphes.ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Paragraphes.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Titre,Description")] Paragraphe paragraphe)
        {
            if (id != paragraphe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paragraphe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(paragraphe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paragraphe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelAfpa2020.Models.Paragraphe paragrahe)
        {
            if ( paragrahe==null )
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(paragrahe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(paragrahe);
        }

        private bool QuestionExists(int id)
        {
            return _context.Paragraphes.Any(e => e.Id == id);
        }
    }
}
