using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Membership.Contexts;
using Autofac;
using TaskManagement.Models.Task.TaskPerformed;
using TaskManagement.Models.Task.TaskEmps;
using System;

namespace TaskManagement.Controllers
{
    public class TasksPerformedController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ManagingContext _context;

        public TasksPerformedController(ILifetimeScope scope, ManagingContext context)
        {
            _scope = scope;
            _context = context;
        }

        // GET: TaskPerformeds
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<TaskPerformedListModel>();
            model.ResolveDependency(_scope);

            var tasksPerformed = model.GetTaskPerformeds();
            return View(tasksPerformed);
        }

        // GET: TaskPerformeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskPerformedListModel>();
            model.ResolveDependency(_scope);

            var taskPerformed = model.GetTaskPerformed((int)id);

            if (taskPerformed == null)
            {
                return NotFound();
            }

            return View(taskPerformed);
        }

        // GET: TaskPerformeds/Create
        public IActionResult Create()
        {
            var taskEmpsModel = _scope.Resolve<TaskEmpsListModel>();
            var taskEmps = taskEmpsModel.GetTaskEmps();

            ViewData["TaskEmpId"] = new SelectList(taskEmps, "Id", "Id");
            return View();
        }

        // POST: TaskPerformeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskEmpId,WorkDate,CompletePCT,Remarks,HoursConsumed")] CreateTaskPerformedModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ResolveDependency(_scope);
                    model.CreateTaskPerformed();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            var taskEmpsModel = _scope.Resolve<TaskEmpsListModel>();
            var taskEmps = taskEmpsModel.GetTaskEmps();

            ViewData["TaskEmpId"] = new SelectList(taskEmps, "Id", "Id", model.TaskEmpId);
            return View(model);
        }

        // GET: TaskPerformeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EditTaskPerformedModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }

            var taskEmpsModel = _scope.Resolve<TaskEmpsListModel>();
            var taskEmps = taskEmpsModel.GetTaskEmps();

            ViewData["TaskEmpId"] = new SelectList(taskEmps, "Id", "Id", model.TaskEmpId);
            return View(model);
        }

        // POST: TaskPerformeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskEmpId,WorkDate,CompletePCT,Remarks,HoursConsumed")] EditTaskPerformedModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    model.ResolveDependency(_scope);
                    model.Update();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskPerformedExists(model.Id))
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

            var taskEmpsModel = _scope.Resolve<TaskEmpsListModel>();
            var taskEmps = taskEmpsModel.GetTaskEmps();

            ViewData["TaskEmpId"] = new SelectList(taskEmps, "Id", "Id", model.TaskEmpId);
            return View(model);
        }

        // GET: TaskPerformeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskPerformedListModel>();
            model.ResolveDependency(_scope);

            var taskPerformed = model.GetTaskPerformed((int)id);

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
            var model = _scope.Resolve<TaskPerformedListModel>();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskPerformedExists(int id)
        {
            return _context.TaskPerformed.Any(e => e.Id == id);
        }
    }
}
