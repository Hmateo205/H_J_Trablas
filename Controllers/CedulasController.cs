using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using H_J_Trablas.Data;
using H_J_Trablas.Models;

namespace H_J_Trablas.Controllers
{
    public class CedulasController : Controller
    {
        private readonly H_J_TrablasContext _context;

        public CedulasController(H_J_TrablasContext context)
        {
            _context = context;
        }

        // GET: Cedulas
        public async Task<IActionResult> Index()
        {
              return _context.Cedulas != null ? 
                          View(await _context.Cedulas.ToListAsync()) :
                          Problem("Entity set 'H_J_TrablasContext.Cedulas'  is null.");
        }

        // GET: Cedulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cedulas == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cedulas == null)
            {
                return NotFound();
            }

            return View(cedulas);
        }

        // GET: Cedulas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cedulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Casado,Estado")] Cedulas cedulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cedulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cedulas);
        }

        // GET: Cedulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cedulas == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas.FindAsync(id);
            if (cedulas == null)
            {
                return NotFound();
            }
            return View(cedulas);
        }

        // POST: Cedulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Casado,Estado")] Cedulas cedulas)
        {
            if (id != cedulas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cedulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CedulasExists(cedulas.Id))
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
            return View(cedulas);
        }

        // GET: Cedulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cedulas == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cedulas == null)
            {
                return NotFound();
            }

            return View(cedulas);
        }

        // POST: Cedulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cedulas == null)
            {
                return Problem("Entity set 'H_J_TrablasContext.Cedulas'  is null.");
            }
            var cedulas = await _context.Cedulas.FindAsync(id);
            if (cedulas != null)
            {
                _context.Cedulas.Remove(cedulas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CedulasExists(int id)
        {
          return (_context.Cedulas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
