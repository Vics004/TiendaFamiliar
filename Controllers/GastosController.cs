using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaFamiliarMVC.Models;

namespace TiendaFamiliarMVC.Controllers
{
    [Authorize]
    public class GastosController : Controller
    {
        private readonly TiendaFamiliarContext _context;

        public GastosController(TiendaFamiliarContext context)
        {
            _context = context;
        }

        // GET: Gastos
        public async Task<IActionResult> Index()
        {
            return View(await _context.gastos.ToListAsync());
        }

        // GET: Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.gastos
                .FirstOrDefaultAsync(m => m.id == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fecha,categoria,monto")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gastos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.gastos.FindAsync(id);
            if (gastos == null)
            {
                return NotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fecha,categoria,monto")] Gastos gastos)
        {
            if (id != gastos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gastos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GastosExists(gastos.id))
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
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.gastos
                .FirstOrDefaultAsync(m => m.id == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gastos = await _context.gastos.FindAsync(id);
            if (gastos != null)
            {
                _context.gastos.Remove(gastos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GastosExists(int id)
        {
            return _context.gastos.Any(e => e.id == id);
        }
    }
}
