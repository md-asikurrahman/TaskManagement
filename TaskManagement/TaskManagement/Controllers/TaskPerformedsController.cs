using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Membership.Contexts;

namespace TaskManagement.Controllers
{
    public class TaskPerformedsController : Controller
    {
        private readonly ManagingContext _context;

        public TaskPerformedsController(ManagingContext context)
        {
            _context = context;
        }

        // GET: TaskPerformeds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskPerformed.Include(t => t.TaskEmp);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskPerformeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskPerformed = await _context.TaskPerformed
                .Include(t => t.TaskEmp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskPerformed == null)
            {
                return NotFound();
            }

            return View(taskPerformed);
        }

        // GET: TaskPerformeds/Create
        public IActionResult Create()
        {
            ViewData["TaskEmpId"] = new SelectList(_context.TaskEmp, "Id", "Id");
            return View();
        }

        // POST: TaskPerformeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskEmpId,WorkDate,CompletePCT,Remarks,HoursConsumed")] TaskPerformed taskPerformed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskPerformed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskEmpId"] = new SelectList(_context.TaskEmp, "Id", "Id", taskPerformed.TaskEmpId);
            return View(taskPerformed);
        }

        // GET: TaskPerformeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskPerformed = await _context.TaskPerformed.FindAsync(id);
            if (taskPerformed == null)
            {
                return NotFound();
            }
            ViewData["TaskEmpId"] = new SelectList(_context.TaskEmp, "Id", "Id", taskPerformed.TaskEmpId);
            return View(taskPerformed);
        }

        // POST: TaskPerformeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskEmpId,WorkDate,CompletePCT,Remarks,HoursConsumed")] TaskPerformed taskPerformed)
        {
            if (id != taskPerformed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskPerformed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskPerformedExists(taskPerformed.Id))
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
            ViewData["TaskEmpId"] = new SelectList(_context.TaskEmp, "Id", "Id", taskPerformed.TaskEmpId);
            return View(taskPerformed);
        }

        // GET: TaskPerformeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskPerformed = await _context.TaskPerformed
                .Include(t => t.TaskEmp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskPerformed == null)
            {
                return NotFound();
            }

            return View(taskPerformed);
        }

        // POST: TaskPerformeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskPerformed = await _context.TaskPerformed.FindAsync(id);
            _context.TaskPerformed.Remove(taskPerformed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskPerformedExists(int id)
        {
            return _context.TaskPerformed.Any(e => e.Id == id);
        }
    }
}
