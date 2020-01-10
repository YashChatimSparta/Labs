using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_34_Gym_Website_MVC_Core;

namespace Lab_34_Gym_Website_MVC_Core.Controllers
{
    public class WorkoutLogsController : Controller
    {
        private readonly GymModel _context;

        public WorkoutLogsController(GymModel context)
        {
            _context = context;
        }

        // GET: WorkoutLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkoutLogs.ToListAsync());
        }

        // GET: WorkoutLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLogs
                .FirstOrDefaultAsync(m => m.WorkoutLogId == id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            return View(workoutLog);
        }

        // GET: WorkoutLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkoutLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutLogId,DateTime,ExerciseId")] WorkoutLog workoutLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutLog);
        }

        // GET: WorkoutLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLogs.FindAsync(id);
            if (workoutLog == null)
            {
                return NotFound();
            }
            return View(workoutLog);
        }

        // POST: WorkoutLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutLogId,DateTime,ExerciseId")] WorkoutLog workoutLog)
        {
            if (id != workoutLog.WorkoutLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutLogExists(workoutLog.WorkoutLogId))
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
            return View(workoutLog);
        }

        // GET: WorkoutLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLogs
                .FirstOrDefaultAsync(m => m.WorkoutLogId == id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            return View(workoutLog);
        }

        // POST: WorkoutLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutLog = await _context.WorkoutLogs.FindAsync(id);
            _context.WorkoutLogs.Remove(workoutLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLogs.Any(e => e.WorkoutLogId == id);
        }
    }
}
