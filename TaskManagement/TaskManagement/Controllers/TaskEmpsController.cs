using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using Autofac;
using TaskManagement.Models.Task.TaskEmps;
using TaskManagement.Models.Task;
using TaskManagement.Models.Employee;

namespace TaskManagement.Controllers
{
    public class TaskEmpsController : Controller
    {
        private readonly ILifetimeScope _scope;

        private readonly ManagingContext _context;

        public TaskEmpsController(ILifetimeScope scope, ManagingContext context)
        {
            _context = context;
            _scope = scope;
        }

        // GET: TaskEmps
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<TaskEmpsListModel>();
            model.ResolveDependency(_scope);

            var taskEmps = model.GetTaskEmps();
            //return View(await _context.TaskEmp.ToListAsync());
            return View(taskEmps);
        }

        // GET: TaskEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskEmpsListModel>();
            model.ResolveDependency(_scope);

            var taskEmp = model.GetTaskEmp((int)id);
            if (taskEmp == null)
            {
                return NotFound();
            }

            return View(taskEmp);
        }

        // GET: TaskEmps/Create
        public IActionResult Create()
        {
            var tasksModel = _scope.Resolve<TaskListModel>();
            var tasks = tasksModel.GetTasks();

            var employeesModel = _scope.Resolve<EmployeeListModel>();
            var employees = employeesModel.GetEmployees();

            ViewData["TaskId"] = new SelectList(tasks, "Id", "TaskName");
            ViewData["EmployeeId"] = new SelectList(employees, "Id", "Name");
            return View();
        }

        // POST: TaskEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskId,EmployeeId")] CreateTaskEmpsModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                model.CreateTaskEmp();

                //_context.Add(model);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TaskEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EditTaskEmpModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: TaskEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskId,EmployeeId")] EditTaskEmpModel model)
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
                    if (!TaskEmpExists(model.Id))
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

        // GET: TaskEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<TaskEmpsListModel>();
            model.ResolveDependency(_scope);

            var taskEmp = model.GetTaskEmp((int)id);

            if (taskEmp == null)
            {
                return NotFound();
            }

            return View(taskEmp);
        }

        // POST: TaskEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var model = _scope.Resolve<TaskEmpsListModel>();

            //model.Delete(id);

            var taskEmp = await _context.TaskEmp.FindAsync(id);
            _context.TaskEmp.Remove(taskEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEmpExists(int id)
        {
            return _context.TaskEmp.Any(e => e.Id == id);
        }
    }
}
