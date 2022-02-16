using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Models.Project;
using Autofac;
using TaskManagement.Models.Employee;
using System;

namespace TaskManagement.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILifetimeScope _scope;

        private readonly ManagingContext _context;

        public ProjectsController(ILifetimeScope scope, ManagingContext context)
        {
            _context = context;
            _scope = scope;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Project.ToListAsync());
            var model = _scope.Resolve<ProjectListModel>();
            model.ResolveDependency(_scope);

            var projects = model.GetProjects();

            return View(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<ProjectListModel>();
            model.ResolveDependency(_scope);

            var project = model.GetProject((int)id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var employeesModel = _scope.Resolve<EmployeeListModel>();
            var employees = employeesModel.GetEmployees();

            ViewData["EmpId"] = new SelectList(employees, "Id", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartDate,EstimatedClosingDate,ProjectManager,IsLocked,IsActive")] CreateProjectModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ResolveDependency(_scope);
                    model.CreateProject();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EditProjectsModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StartDate,EstimatedClosingDate,ProjectManager,IsLocked,IsActive")] EditProjectsModel model)
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
                    if (!ProjectExists(model.Id))
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

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<ProjectListModel>();
            model.ResolveDependency(_scope);

            var project = model.GetProject((int)id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = _scope.Resolve<ProjectListModel>();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
