using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula29.Models;

namespace Aula29.Controllers
{
    public class AtoresController : Controller
    {
        private readonly CatalogoContext _context;

        public AtoresController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: Atores
        public async Task<IActionResult> Index()
        {
              return _context.Atores != null ? 
                          View(await _context.Atores.ToListAsync()) :
                          Problem("Entity set 'CatalogoContext.Atores'  is null.");
        }

        // GET: Atores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores
                .FirstOrDefaultAsync(m => m.id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // GET: Atores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sobrenome")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ator);
        }

        // GET: Atores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores.FindAsync(id);
            if (ator == null)
            {
                return NotFound();
            }
            return View(ator);
        }

        // POST: Atores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome")] Ator ator)
        {
            if (id != ator.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtorExists(ator.id))
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
            return View(ator);
        }

        // GET: Atores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores
                .FirstOrDefaultAsync(m => m.id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // POST: Atores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atores == null)
            {
                return Problem("Entity set 'CatalogoContext.Atores'  is null.");
            }
            var ator = await _context.Atores.FindAsync(id);
            if (ator != null)
            {
                _context.Atores.Remove(ator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtorExists(int id)
        {
          return (_context.Atores?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
