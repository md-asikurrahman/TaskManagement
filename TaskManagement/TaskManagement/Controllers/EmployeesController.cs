using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Contexts;
using TaskManagement.Models.Employee;
using Autofac;
using System;

namespace TaskManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILifetimeScope _scope;

        private readonly ManagingContext _context;

        public EmployeesController(ILifetimeScope scope, ManagingContext context)
        {
            _context = context;
            _scope = scope;
        }
        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<EmployeeListModel>();
            model.ResolveDependency(_scope);

            var employees = model.GetEmployees();

            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EmployeeListModel>();
            model.ResolveDependency(_scope);

            var employee = model.GetTaskEmp((int)id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Mobile,NationalId,Photo")] CreateEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ResolveDependency(_scope);
                    model.CreateEmployee();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

                //_context.Add(employee);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EditEmployeeModel>();
            model.ResolveDependency(_scope);
            model.LoadModelData((int)id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Mobile,NationalId,Photo")] EditEmployeeModel model)
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
                    //if (!EmployeeExists(model.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _scope.Resolve<EmployeeListModel>();
            model.ResolveDependency(_scope);

            var employee = model.GetTaskEmp((int)id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var employee = await _context.Employee.FindAsync(id);
            //_context.Employee.Remove(employee);
            //await _context.SaveChangesAsync();

            var model = _scope.Resolve<EmployeeListModel>();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
