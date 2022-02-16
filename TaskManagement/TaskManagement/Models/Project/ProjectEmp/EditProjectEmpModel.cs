using Autofac;
using AutoMapper;
using ProjectManagement.Managing.Services.Project;

namespace TaskManagement.Models.Project.ProjectEmp
{
    public class EditProjectEmpModel : ProjectEmpBaseModel
    {
        private IProjectEmpService _projectEmpService;
        private IMapper _mapper;
        public EditProjectEmpModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _projectEmpService = scope.Resolve<IProjectEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditProjectEmpModel(IProjectEmpService projectEmpService, IMapper mapper)
        {
            _projectEmpService = projectEmpService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var projectEmp = new Managing.BusinessObjects.ProjectEmp()
            {
                Id = this.Id,
                ProjectId = this.ProjectId,
                EmployeeId = this.EmployeeId,
                IsActive = this.IsActive,
                ProjectRole = this.ProjectRole
            };

            _projectEmpService.UpdateProjectEmp(projectEmp);
        }

        public void LoadModelData(int id)
        {
            var projectEmp = _projectEmpService.GetProjectEmp(id);
            this.Id = projectEmp.Id;
            this.ProjectId = projectEmp.ProjectId;
            this.EmployeeId = projectEmp.EmployeeId;
            this.IsActive = projectEmp.IsActive;
            this.ProjectRole = projectEmp.ProjectRole;
        }
    }
}
