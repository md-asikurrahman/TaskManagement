using Autofac;
using AutoMapper;
using ProjectManagement.Managing.Services.Project;
using System.Collections.Generic;

namespace TaskManagement.Models.Project.ProjectEmp
{
    public class ProjectEmpListModel : ProjectEmpBaseModel
    {
        private IProjectEmpService _projectEmpService;
        private IMapper _mapper;

        public ProjectEmpListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _projectEmpService = scope.Resolve<IProjectEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public ProjectEmpListModel(IProjectEmpService ProjectEmpService, IMapper mapper)
        {
            _projectEmpService = ProjectEmpService;
            _mapper = mapper;
        }

        public IList<Managing.BusinessObjects.ProjectEmp> GetProjectEmps()

        {
            var projectEmps = _projectEmpService.GetProjectEmps();
            return projectEmps;
        }

        public Managing.BusinessObjects.ProjectEmp GetProjectEmp(int id)
        {
            var projectEmp = _projectEmpService.GetProjectDetails(id, "Project");
            return projectEmp;
        }

        internal void Delete(int id)
        {
            _projectEmpService.DeleteProjectEmp(id);
        }
    }
}
