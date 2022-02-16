using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using Autofac;
using TaskManagement.Models.Project;
using TaskManagement.Models.Employee;
using TaskManagement.Models.Project.ProjectEmp;

namespace TaskManagement.Controllers
{
    public class ProjectEmpsController : Controller
    {
        private readonly ILifetimeScope _scope;

        private readonly ManagingContext _context;

        public ProjectEmpsController(ILifetimeScope scope, ManagingContext context)
        {
            _context = context;
            _scope = scope;
        }

        // GET: ProjectEmps
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<ProjectEmpListModel>();
            model.ResolveDependency(_scope);

            var projectEmps = model.GetProjectEmps();
            //return View(await _context.TaskEmp.ToListAsync());
            return View(projectEmps);
        }

        // GET: ProjectEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<ProjectEmpListModel>();
            model.ResolveDependency(_scope);

            var projectEmp = model.GetProjectEmp((int)id);
            if (projectEmp == null)
            {
                return NotFound();
            }

            return View(projectEmp);
        }

        // GET: ProjectEmps/Create
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

        // POST: ProjectEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,EmployeeId,IsActive,ProjectRole")] CreateProjectEmpModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                model.CreateProjectEmp();

                return RedirectToAction(nameof(Index));
            }
            var projectsModel = _scope.Resolve<ProjectListModel>();
            var projects = projectsModel.GetProjects();

            ViewData["ProjectId"] = new SelectList(projects, "Id", "Title", model.ProjectId);
            return View(model);
        }

        // GET: ProjectEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EditProjectEmpModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }

            var projectsModel = _scope.Resolve<ProjectListModel>();
            var projects = projectsModel.GetProjects();

            ViewData["ProjectId"] = new SelectList(projects, "Id", "Title", model.ProjectId);
            return View(model);
        }

        // POST: ProjectEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,EmployeeId,IsActive,ProjectRole")]  
        
        EditProjectEmpModel model)
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
                    if (!ProjectEmpExists(model.Id))
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

            var projectsModel = _scope.Resolve<ProjectListModel>();
            var projects = projectsModel.GetProjects();

            ViewData["ProjectId"] = new SelectList(projects, "Id", "Title", model.ProjectId);
            return View(model);
        }

        // GET: ProjectEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<ProjectEmpListModel>();
            model.ResolveDependency(_scope);

            var projectEmp = model.GetProjectEmp((int)id);

            if (projectEmp == null)
            {
                return NotFound();
            }

            return View(projectEmp);
        }

        // POST: ProjectEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = _scope.Resolve<ProjectEmpListModel>();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectEmpExists(int id)
        {
            return _context.ProjectEmp.Any(e => e.Id == id);
        }
    }
}
