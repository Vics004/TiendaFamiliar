using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaFamiliarMVC.Models;

namespace TiendaFamiliarMVC.Controllers
{
    public class GananciasController : Controller
    {
        private readonly TiendaFamiliarContext _context;

        public GananciasController(TiendaFamiliarContext context)
        {
            _context = context;
        }

        // GET: Ganancias
        public async Task<IActionResult> Index()
        {
            var ganancias = await _context.ganancias
                .OrderByDescending(v => v.fecha) // Ordena por fecha descendente (más recientes primero)
                .ToListAsync();

            return View(ganancias);
        }

        // GET: Ganancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganancias = await _context.ganancias
                .FirstOrDefaultAsync(m => m.id == id);
            if (ganancias == null)
            {
                return NotFound();
            }

            return View(ganancias);
        }

        // GET: Ganancias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ganancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fecha,total_ventas,total_gastos,ganancia")] Ganancias ganancias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ganancias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ganancias);
        }

        // GET: Ganancias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganancias = await _context.ganancias.FindAsync(id);
            if (ganancias == null)
            {
                return NotFound();
            }
            return View(ganancias);
        }

        // POST: Ganancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fecha,total_ventas,total_gastos,ganancia")] Ganancias ganancias)
        {
            if (id != ganancias.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ganancias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GananciasExists(ganancias.id))
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
            return View(ganancias);
        }

        // GET: Ganancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganancias = await _context.ganancias
                .FirstOrDefaultAsync(m => m.id == id);
            if (ganancias == null)
            {
                return NotFound();
            }

            return View(ganancias);
        }

        // POST: Ganancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ganancias = await _context.ganancias.FindAsync(id);
            if (ganancias != null)
            {
                _context.ganancias.Remove(ganancias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GananciasExists(int id)
        {
            return _context.ganancias.Any(e => e.id == id);
        }
    }
}
