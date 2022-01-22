#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The100DaysOfCode.MVC.Models;

namespace The100DaysOfCode.MVC.Controllers
{
    public class DayOfCodeController : Controller
    {
        private readonly DayOfCodeContext _context;

        public DayOfCodeController(DayOfCodeContext context)
        {
            _context = context;
        }

        // GET: DayOfCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.DayOfCode.ToListAsync());
        }

        // GET: DayOfCode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfCode = await _context.DayOfCode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayOfCode == null)
            {
                return NotFound();
            }

            return View(dayOfCode);
        }

        // GET: DayOfCode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DayOfCode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date")] DayOfCode dayOfCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayOfCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dayOfCode);
        }

        // GET: DayOfCode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfCode = await _context.DayOfCode.FindAsync(id);
            if (dayOfCode == null)
            {
                return NotFound();
            }
            return View(dayOfCode);
        }

        // POST: DayOfCode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date")] DayOfCode dayOfCode)
        {
            if (id != dayOfCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayOfCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayOfCodeExists(dayOfCode.Id))
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
            return View(dayOfCode);
        }

        // GET: DayOfCode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfCode = await _context.DayOfCode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayOfCode == null)
            {
                return NotFound();
            }

            return View(dayOfCode);
        }

        // POST: DayOfCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dayOfCode = await _context.DayOfCode.FindAsync(id);
            _context.DayOfCode.Remove(dayOfCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayOfCodeExists(int id)
        {
            return _context.DayOfCode.Any(e => e.Id == id);
        }
    }
}
