using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Employee
{
    public class EditEmployeeModel : EmployeeBaseModel
    {
        private IEmployeeService _emploeeService;
        private IMapper _mapper;
        public EditEmployeeModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _emploeeService = scope.Resolve<IEmployeeService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditEmployeeModel(IEmployeeService employeeService, IMapper mapper)
        {
            _emploeeService = employeeService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var employee = new Managing.BusinessObjects.Employee()
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email,
                NationalId = this.NationalId,
                Mobile = this.Mobile,
                Photo = this.Photo
            };

            _emploeeService.UpdateEmployee(employee);
        }

        public void LoadModelData(int id)
        {
            var employee = _emploeeService.GetEmployee(id);
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.NationalId = employee.NationalId;
            this.Mobile = employee.Mobile;
            this.Email = employee.Email;
            this.Photo = employee.Photo; 
        }
    }
}
