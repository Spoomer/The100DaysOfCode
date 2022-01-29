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
            return View(await _context.DaysOfCode.ToListAsync());
        }

        // GET: DaysOfCode/Day/5
        public async Task<IActionResult> Day(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfCode = await _context.DaysOfCode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayOfCode == null)
            {
                return NotFound();
            }
            await _context.Entry(dayOfCode).Collection(x => x.Goals).LoadAsync();
            await _context.Entry(dayOfCode).Collection(x => x.Notes).LoadAsync();
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

            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
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

            var dayOfCode = await _context.DaysOfCode
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
            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
            _context.DaysOfCode.Remove(dayOfCode);
            await _context.SaveChangesAsync();
            var daysOfCode = await _context.DaysOfCode.ToArrayAsync();
            if (daysOfCode.Length == 0)
            {
                await ResetId();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal(int id, string name)
        {
            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
            dayOfCode.Goals.Add(new Goal() { Name = name });
            _context.Update(dayOfCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new { id });
        }
        [HttpPost]
        public async Task<IActionResult> AddNote(int id, string text)
        {
            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
            dayOfCode.Notes.Add(new Note() { Text = text });
            _context.Update(dayOfCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new { id });
        }
        [HttpPut]
        public async Task<IActionResult> CheckGoal([FromForm] int id, [FromForm] bool isChecked)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal is not null)
            {
                goal.Check = isChecked;
                _context.Update(goal);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();


        }
        // Put /DaysOfCode/UpdateNote
        [HttpPut]
        public async Task<IActionResult> UpdateNote([FromForm] int id, [FromForm] string text)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is not null)
            {
                note.Text = text;
                _context.Update(note);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        // Put /DaysOfCode/UpdateNote
        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromForm] int id, [FromForm] string name)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal is not null)
            {
                goal.Name = name;
                _context.Update(goal);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        // GET: DayOfCode/DeleteGoal/5
        [HttpGet]
        public async Task<IActionResult> DeleteGoal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goal == null)
            {
                return NotFound();
            }
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new {id=goal.DayOfCodeId});
        }
        // GET: DayOfCode/DeleteNote/5
        [HttpGet]
        public async Task<IActionResult> DeleteNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new {id=note.DayOfCodeId});
        }
        private bool DayOfCodeExists(int id)
        {
            return _context.DaysOfCode.Any(e => e.Id == id);
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
