using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.BusinessObjects;
using Autofac;
using TaskManagement.Models.Task;
using System;
using TaskManagement.Models.Employee;
using TaskManagement.Models.Project;

namespace TaskManagement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILifetimeScope _scope;

        
        private readonly ManagingContext _context;

        public TasksController(ILifetimeScope scope, ManagingContext context)
        {
            _scope = scope;
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<TaskListModel>();
            model.ResolveDependency(_scope);

            var tasks = model.GetTasks();
            return View(tasks);
            //return View(await _context.Tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskListModel>();
            model.ResolveDependency(_scope);

            var task = model.GetTask((int)id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            var projectsModel = _scope.Resolve<ProjectListModel>();
            var projects = projectsModel.GetProjects();

            var employeesModel = _scope.Resolve<EmployeeListModel>();
            var employees = employeesModel.GetEmployees();

            ViewData["ProjectId"] = new SelectList(projects, "Id", "Title");
            ViewData["EmployeeId"] = new SelectList(employees, "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,ECHour,CompleteStatus,Dependancy")] CreateTaskModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ResolveDependency(_scope);
                    model.CreateTask();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

                //_context.Add(tasks);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _scope.Resolve<EditTaskModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,ECHour,CompleteStatus,Dependancy")] EditTaskModel model)
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
                    if (!TasksExists(model.Id))
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
            return View(model);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskListModel>();
            model.ResolveDependency(_scope);

            var task = model.GetTask((int)id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = _scope.Resolve<TaskListModel>();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
