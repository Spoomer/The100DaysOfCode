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
    public class DaysOfCodeController : Controller
    {
        private readonly DayOfCodeContext _context;
        private readonly IConfiguration _config;

        public DaysOfCodeController(DayOfCodeContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: DaysOfCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.DayOfCode.ToListAsync());
        }

        // GET: DaysOfCode/Day/5
        public async Task<IActionResult> Day(int? id)
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

        // GET: DaysOfCode/CreateDay
        public IActionResult CreateDay()
        {
            return View();
        }

        // POST: DaysOfCode/CreateDay
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDay([Bind("Id,Title,Date")] DayOfCode dayOfCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayOfCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dayOfCode);
        }

        // GET: DaysOfCode/EditDay/5
        public async Task<IActionResult> EditDay(int? id)
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

        // POST: DaysOfCode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDay(int id, [Bind("Id,Title,Date")] DayOfCode dayOfCode)
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

        // GET: DayOfCode/DeleteDay/5
        public async Task<IActionResult> DeleteDay(int? id)
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

        // POST: DaysOfCode/DeleteDay/5
        [HttpPost, ActionName("DeleteDay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dayOfCode = await _context.DayOfCode.FindAsync(id);
            _context.DayOfCode.Remove(dayOfCode);
            await _context.SaveChangesAsync();
            var daysOfCode = await _context.DayOfCode.ToArrayAsync();
            if (daysOfCode.Length == 0)
            {
                await ResetId();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DayOfCodeExists(int id)
        {
            return _context.DayOfCode.Any(e => e.Id == id);
        }

        private async Task ResetId()
        {
            if (_config.GetValue<string>(AppSettings.DatabaseKey) == AppSettings.DatabaseValueSQLite)
            {
                await _context.Database.ExecuteSqlRawAsync("delete from DayOfCode;");
                await _context.Database.ExecuteSqlRawAsync("delete from sqlite_sequence where name='DayOfCode';");
            }
            else if (_config.GetValue<string>(AppSettings.DatabaseKey) == AppSettings.DatabaseValueMssql)
            {
                await _context.Database.ExecuteSqlRawAsync("delete from DayOfCode;");
                await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('DayOfCode', RESEED, 0)");
            }
            _context.SaveChanges();
        }
    }
}
