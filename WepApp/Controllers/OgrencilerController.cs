using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WepApp.Data;

namespace WepApp.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly OkulContext _context;

        public OgrencilerController(OkulContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var okulContext = _context.Ogrenciler.Include(o => o.Bolum);
            return View(await okulContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi", ogrenci.BolumId);
            return View(ogrenci);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi", ogrenci.BolumId);
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,BolumId,Id")] Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciExists(ogrenci.Id))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "Id", "Adi", ogrenci.BolumId);
            return View(ogrenci);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogrenciler == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogrenciler == null)
            {
                return Problem("Entity set 'OkulContext.Ogrenciler'  is null.");
            }
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciExists(int id)
        {
          return (_context.Ogrenciler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
