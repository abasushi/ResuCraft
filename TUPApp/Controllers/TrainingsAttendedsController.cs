using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TUPApp.Models;

namespace TUPApp.Controllers
{
    public class TrainingsAttendedsController : Controller
    {
        public class Dropdown
        {
            public int ID { get; set; }

            public string Name { get; set; }
        }

        private readonly TupContext _context;

        public TrainingsAttendedsController(TupContext context)
        {
            _context = context;
        }

        // GET: TrainingsAttendeds
        public async Task<IActionResult> Index()
        {
            var tupContext = _context.TrainingsAttendeds.Include(t => t.Student);
            return View(await tupContext.ToListAsync());
        }

        // GET: TrainingsAttendeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainingsAttendeds == null)
            {
                return NotFound();
            }

            var trainingsAttended = await _context.TrainingsAttendeds
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingsAttended == null)
            {
                return NotFound();
            }

            return View(trainingsAttended);
        }

        // GET: TrainingsAttendeds/Create
        public IActionResult Create()
        {
            var trainings = _context.Students
               .Select(x => new Dropdown
               {
                   ID = x.Id,
                   Name = x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName
               }).ToList();

            ViewData["StudentId"] = new SelectList(trainings, "ID", "Name");
            return View();
        }

        // POST: TrainingsAttendeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Training,YearAttended,StudentId")] TrainingsAttended trainingsAttended)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingsAttended);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", trainingsAttended.StudentId);
            return View(trainingsAttended);
        }

        // GET: TrainingsAttendeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainingsAttendeds == null)
            {
                return NotFound();
            }

            var trainingsAttended = await _context.TrainingsAttendeds.FindAsync(id);
            if (trainingsAttended == null)
            {
                return NotFound();
            }
            var trainings = _context.Students
               .Select(x => new Dropdown
               {
                   ID = x.Id,
                   Name = x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName
               }).ToList();

            ViewData["StudentId"] = new SelectList(trainings, "ID", "Name", trainingsAttended.StudentId);
            return View(trainingsAttended);
        }

        // POST: TrainingsAttendeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Training,YearAttended,StudentId")] TrainingsAttended trainingsAttended)
        {
            if (id != trainingsAttended.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingsAttended);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingsAttendedExists(trainingsAttended.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", trainingsAttended.StudentId);
            return View(trainingsAttended);
        }

        // GET: TrainingsAttendeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainingsAttendeds == null)
            {
                return NotFound();
            }

            var trainingsAttended = await _context.TrainingsAttendeds
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingsAttended == null)
            {
                return NotFound();
            }

            return View(trainingsAttended);
        }

        // POST: TrainingsAttendeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainingsAttendeds == null)
            {
                return Problem("Entity set 'TupContext.TrainingsAttendeds'  is null.");
            }
            var trainingsAttended = await _context.TrainingsAttendeds.FindAsync(id);
            if (trainingsAttended != null)
            {
                _context.TrainingsAttendeds.Remove(trainingsAttended);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingsAttendedExists(int id)
        {
          return (_context.TrainingsAttendeds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
