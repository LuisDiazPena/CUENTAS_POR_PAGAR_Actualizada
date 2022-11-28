using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CUENTAS_POR_PAGAR.Data;
using CUENTAS_POR_PAGAR.Models;
using System.Text;
using System.Security.Cryptography;

namespace CUENTAS_POR_PAGAR.Controllers
{
    public class USUARIOSController : Controller
    {
        private readonly CUENTAS_POR_PAGARContext _context;

        public USUARIOSController(CUENTAS_POR_PAGARContext context)
        {
            _context = context;
        }

        // GET: USUARIOS
        public async Task<IActionResult> Index()
        {
            return View(await _context.USUARIOS.ToListAsync());
        }

        // GET: USUARIOS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSUARIOS = await _context.USUARIOS
                .FirstOrDefaultAsync(m => m.USUARIOSID == id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            return View(uSUARIOS);
        }

        // GET: USUARIOS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: USUARIOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("USUARIOSID,USUARIO,CLAVE")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                var clave = uSUARIOS.CLAVE;

            static string ComputeMd5Hash(string clave)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] input = Encoding.ASCII.GetBytes(clave);
                    byte[] hash = md5.ComputeHash(input);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
                // Console.WriteLine(ComputeMd5Hash(message));
                uSUARIOS.CLAVE = ComputeMd5Hash(clave);

                _context.Add(uSUARIOS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSUARIOS = await _context.USUARIOS.FindAsync(id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("USUARIOSID,USUARIO,CLAVE")] USUARIOS uSUARIOS)
        {
            if (id != uSUARIOS.USUARIOSID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uSUARIOS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USUARIOSExists(uSUARIOS.USUARIOSID))
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
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uSUARIOS = await _context.USUARIOS
                .FirstOrDefaultAsync(m => m.USUARIOSID == id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            return View(uSUARIOS);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uSUARIOS = await _context.USUARIOS.FindAsync(id);
            _context.USUARIOS.Remove(uSUARIOS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool USUARIOSExists(int id)
        {
            return _context.USUARIOS.Any(e => e.USUARIOSID == id);
        }
    }
}
