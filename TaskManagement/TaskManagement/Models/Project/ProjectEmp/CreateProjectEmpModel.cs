using Autofac;
using AutoMapper;
using ProjectManagement.Managing.Services.Project;

namespace TaskManagement.Models.Project.ProjectEmp
{
    public class CreateProjectEmpModel : ProjectEmpBaseModel
    {
        private IProjectEmpService _projectEmpService;
        private IMapper _mapper;

        public CreateProjectEmpModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _projectEmpService = scope.Resolve<IProjectEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateProjectEmpModel(IProjectEmpService projectEmpService, IMapper mapper)
        {
            _projectEmpService = projectEmpService;
            _mapper = mapper;
        }

        public void CreateProjectEmp()
        {
            var projectEmp = new Managing.BusinessObjects.ProjectEmp()
            {
                ProjectId = this.ProjectId,
                EmployeeId = this.EmployeeId,
                IsActive  = this.IsActive,
                ProjectRole = this.ProjectRole
            };

            _projectEmpService.CreateProjectEmp(projectEmp);
        }
    }
}
