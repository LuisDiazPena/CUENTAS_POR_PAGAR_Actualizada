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
    public class CHEQUESController : Controller
    {
        private readonly CUENTAS_POR_PAGARContext _context;

        public CHEQUESController(CUENTAS_POR_PAGARContext context)
        {
            _context = context;
        }

        // GET: CHEQUES
        public async Task<IActionResult> Index()
        {
            return View(await _context.CHEQUES.ToListAsync());
        }

        // GET: CHEQUES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHEQUES = await _context.CHEQUES
                .FirstOrDefaultAsync(m => m.CHEQUESID == id);
            if (cHEQUES == null)
            {
                return NotFound();
            }

            return View(cHEQUES);
        }

        // GET: CHEQUES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CHEQUES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CHEQUESID,CODFACTURA,VALORCHEQUE,FECHACHEQUE,BANCO")] CHEQUES cHEQUES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cHEQUES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cHEQUES);
        }

        // GET: CHEQUES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHEQUES = await _context.CHEQUES.FindAsync(id);
            if (cHEQUES == null)
            {
                return NotFound();
            }
            return View(cHEQUES);
        }

        // POST: CHEQUES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CHEQUESID,CODFACTURA,VALORCHEQUE,FECHACHEQUE,BANCO")] CHEQUES cHEQUES)
        {
            if (id != cHEQUES.CHEQUESID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cHEQUES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CHEQUESExists(cHEQUES.CHEQUESID))
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
            return View(cHEQUES);
        }

        // GET: CHEQUES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHEQUES = await _context.CHEQUES
                .FirstOrDefaultAsync(m => m.CHEQUESID == id);
            if (cHEQUES == null)
            {
                return NotFound();
            }

            return View(cHEQUES);
        }

        // POST: CHEQUES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cHEQUES = await _context.CHEQUES.FindAsync(id);
            _context.CHEQUES.Remove(cHEQUES);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CHEQUESExists(int id)
        {
            return _context.CHEQUES.Any(e => e.CHEQUESID == id);
        }
    }
}
