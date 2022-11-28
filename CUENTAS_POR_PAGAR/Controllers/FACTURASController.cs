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
    public class FACTURASController : Controller
    {
        private readonly CUENTAS_POR_PAGARContext _context;

        public FACTURASController(CUENTAS_POR_PAGARContext context)
        {
            _context = context;
        }

        // GET: FACTURAS
        public async Task<IActionResult> Index()
        {
            return View(await _context.FACTURAS.ToListAsync());
        }

        // GET: FACTURAS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fACTURAS = await _context.FACTURAS
                .FirstOrDefaultAsync(m => m.FACTURASID == id);
            if (fACTURAS == null)
            {
                return NotFound();
            }

            return View(fACTURAS);
        }

        // GET: FACTURAS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FACTURAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FACTURASID,CODPROVEDORES,FORMADEPAGO,FECHA,FECHAVENCIMIENTO,DEBITO,CREDITO,RAZONSOCIAL,ESTADO")] FACTURAS fACTURAS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fACTURAS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fACTURAS);
        }

        // GET: FACTURAS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fACTURAS = await _context.FACTURAS.FindAsync(id);
            if (fACTURAS == null)
            {
                return NotFound();
            }
            return View(fACTURAS);
        }

        // POST: FACTURAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FACTURASID,CODPROVEDORES,FORMADEPAGO,FECHA,FECHAVENCIMIENTO,DEBITO,CREDITO,RAZONSOCIAL,ESTADO")] FACTURAS fACTURAS)
        {
            if (id != fACTURAS.FACTURASID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fACTURAS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FACTURASExists(fACTURAS.FACTURASID))
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
            return View(fACTURAS);
        }

        // GET: FACTURAS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fACTURAS = await _context.FACTURAS
                .FirstOrDefaultAsync(m => m.FACTURASID == id);
            if (fACTURAS == null)
            {
                return NotFound();
            }

            return View(fACTURAS);
        }

        // POST: FACTURAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fACTURAS = await _context.FACTURAS.FindAsync(id);
            _context.FACTURAS.Remove(fACTURAS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FACTURASExists(int id)
        {
            return _context.FACTURAS.Any(e => e.FACTURASID == id);
        }
    }
}
