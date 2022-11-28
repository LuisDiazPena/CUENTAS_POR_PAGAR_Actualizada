using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CUENTAS_POR_PAGAR.Data;
using CUENTAS_POR_PAGAR.Models;

namespace CUENTAS_POR_PAGAR.Controllers
{
    public class NOTACREDITOesController : Controller
    {
        private readonly CUENTAS_POR_PAGARContext _context;

        public NOTACREDITOesController(CUENTAS_POR_PAGARContext context)
        {
            _context = context;
        }

        // GET: NOTACREDITOes
        public async Task<IActionResult> Index()
        {
            return View(await _context.NOTACREDITO.ToListAsync());
        }

        // GET: NOTACREDITOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nOTACREDITO = await _context.NOTACREDITO
                .FirstOrDefaultAsync(m => m.NOTACREDITOID == id);
            if (nOTACREDITO == null)
            {
                return NotFound();
            }

            return View(nOTACREDITO);
        }

        // GET: NOTACREDITOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NOTACREDITOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NOTACREDITOID,CODPROVEEDOR,CANTIDAD,DESCRIPCION")] NOTACREDITO nOTACREDITO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nOTACREDITO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nOTACREDITO);
        }

        // GET: NOTACREDITOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nOTACREDITO = await _context.NOTACREDITO.FindAsync(id);
            if (nOTACREDITO == null)
            {
                return NotFound();
            }
            return View(nOTACREDITO);
        }

        // POST: NOTACREDITOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NOTACREDITOID,CODPROVEEDOR,CANTIDAD,DESCRIPCION")] NOTACREDITO nOTACREDITO)
        {
            if (id != nOTACREDITO.NOTACREDITOID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nOTACREDITO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NOTACREDITOExists(nOTACREDITO.NOTACREDITOID))
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
            return View(nOTACREDITO);
        }

        // GET: NOTACREDITOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nOTACREDITO = await _context.NOTACREDITO
                .FirstOrDefaultAsync(m => m.NOTACREDITOID == id);
            if (nOTACREDITO == null)
            {
                return NotFound();
            }

            return View(nOTACREDITO);
        }

        // POST: NOTACREDITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nOTACREDITO = await _context.NOTACREDITO.FindAsync(id);
            _context.NOTACREDITO.Remove(nOTACREDITO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NOTACREDITOExists(int id)
        {
            return _context.NOTACREDITO.Any(e => e.NOTACREDITOID == id);
        }
    }
}
