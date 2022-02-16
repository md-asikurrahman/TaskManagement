using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Project
{
    public class CreateProjectModel : ProjectBaseModel
    {
        private IProjectService _projectService;
        private IMapper _mapper;

        public CreateProjectModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _projectService = scope.Resolve<IProjectService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateProjectModel(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public void CreateProject()
        {
            var project = new Managing.BusinessObjects.Project()
            {
                Title = this.Title,
                StartDate = this.StartDate,
                EstimatedClosingDate = this.EstimatedClosingDate,
                ProjectManager = this.ProjectManager,
                IsLocked = this.IsLocked,
                IsActive = this.IsActive,
            };

            _projectService.CreateProject(project);
        }
    }
}
