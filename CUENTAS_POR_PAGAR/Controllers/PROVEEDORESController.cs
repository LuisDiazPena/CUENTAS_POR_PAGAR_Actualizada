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
    public class PROVEEDORESController : Controller
    {
        private readonly CUENTAS_POR_PAGARContext _context;

        public PROVEEDORESController(CUENTAS_POR_PAGARContext context)
        {
            _context = context;
        }

        // GET: PROVEEDORES
        public async Task<IActionResult> Index()
        {
            return View(await _context.PROVEEDORES.ToListAsync());
        }

        // GET: PROVEEDORES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROVEEDORES = await _context.PROVEEDORES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pROVEEDORES == null)
            {
                return NotFound();
            }

            return View(pROVEEDORES);
        }

        // GET: PROVEEDORES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PROVEEDORES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NOMBRES,APELLIDOS,DIRECCION,CIUDAD,TELEFONO")] PROVEEDORES pROVEEDORES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pROVEEDORES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pROVEEDORES);
        }

        // GET: PROVEEDORES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROVEEDORES = await _context.PROVEEDORES.FindAsync(id);
            if (pROVEEDORES == null)
            {
                return NotFound();
            }
            return View(pROVEEDORES);
        }

        // POST: PROVEEDORES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NOMBRES,APELLIDOS,DIRECCION,CIUDAD,TELEFONO")] PROVEEDORES pROVEEDORES)
        {
            if (id != pROVEEDORES.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pROVEEDORES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PROVEEDORESExists(pROVEEDORES.ID))
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
            return View(pROVEEDORES);
        }

        // GET: PROVEEDORES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pROVEEDORES = await _context.PROVEEDORES
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pROVEEDORES == null)
            {
                return NotFound();
            }

            return View(pROVEEDORES);
        }

        // POST: PROVEEDORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pROVEEDORES = await _context.PROVEEDORES.FindAsync(id);
            _context.PROVEEDORES.Remove(pROVEEDORES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Get ESTADO DE CUENTA FROM PROVEEDORES
        public async Task<IActionResult> EstadoDeCuentas(int id)
        {
            var estado = _context.ESTADODECUENTAS.FromSqlInterpolated($"EXEC SP_ESTADODECUENTAS");

            return View(estado);
        }

        private bool PROVEEDORESExists(int id)
        {
            return _context.PROVEEDORES.Any(e => e.ID == id);
        }
    }
}
