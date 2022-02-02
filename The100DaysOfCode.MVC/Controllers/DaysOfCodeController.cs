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
        //private readonly DayOfCodeContext _context;
        private readonly IConfiguration _config;
        private readonly DayOfCodeService _dayOfCodeService;

        public DaysOfCodeController(DayOfCodeService dayOfCodeService, IConfiguration config)
        {
            _dayOfCodeService = dayOfCodeService;
            _config = config;
        }

        // GET: DaysOfCode
        public async Task<IActionResult> Index()
        {
            return View(await _dayOfCodeService.GetDayOfCodeViewModelsAsync());
        }

        // GET: DaysOfCode/Day/5
        public async Task<IActionResult> Day(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dayOfCode = await _dayOfCodeService.GetDayOfCodeViewModelAsync((int)id);
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
        public async Task<IActionResult> CreateDay([Bind("Id,Title,Date")] DayOfCodeViewModel dayOfCode)
        {
            if (ModelState.IsValid)
            {
                await _dayOfCodeService.CreateDayOfCode(dayOfCode);
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

            var dayOfCode = _dayOfCodeService.GetDayOfCodeViewModelAsync((int)id);
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
        public async Task<IActionResult> EditDay(int id, [Bind("Id,Title,Date")] DayOfCodeViewModel dayOfCode)
        {
            if (id != dayOfCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                bool success = await _dayOfCodeService.EditDayOfCodeAsync(dayOfCode);
                if (success == false)
                {
                    return NotFound();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGoal(int id, string name)
        {
            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
            dayOfCode.Goals.Add(new GoalViewModel() { Name = name });
            _context.Update(dayOfCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new { id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(int id, string text)
        {
            var dayOfCode = await _context.DaysOfCode.FindAsync(id);
            dayOfCode.Notes.Add(new NoteViewModel() { Text = text });
            _context.Update(dayOfCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Day), new { id });
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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
        // Post: DayOfCode/DeleteGoal
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction(nameof(Day), new { id = goal.DayOfCodeId });
        }
        // Post: DayOfCode/DeleteNote/
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction(nameof(Day), new { id = note.DayOfCodeId });
        }
        private async Task<bool> DayOfCodeExists(int id)
        {
            if ((await _dayOfCodeService.GetDayOfCodeViewModelAsync(id)) is not null)
            {
                return true;
            }
            return false;
        }


    }
}
