using Autofac;
using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Employee
{
    public class EmployeeListModel : EmployeeBaseModel
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public EmployeeListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _employeeService = scope.Resolve<IEmployeeService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EmployeeListModel(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public IList<Managing.BusinessObjects.Employee> GetEmployees()
        
        {
            var employees = _employeeService.GetAllEmployee();
            return employees;
        }

        public Managing.BusinessObjects.Employee GetTaskEmp(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return employee; 
        }

        internal void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
