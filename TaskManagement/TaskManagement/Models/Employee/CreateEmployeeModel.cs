using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Employee
{
    public class CreateEmployeeModel : EmployeeBaseModel
    {
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        public CreateEmployeeModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _employeeService = scope.Resolve<IEmployeeService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateEmployeeModel(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public void CreateEmployee()
        {
            var employee = new Managing.BusinessObjects.Employee()
            {
                Name = this.Name,
                Email = this.Email,
                NationalId = this.NationalId,
                Mobile = this.Mobile,
                Photo = this.Photo
            };

            _employeeService.CreateEmployee(employee);
        }
    }
}
