using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Project
{
    public class EditProjectsModel : ProjectBaseModel
    {
        private IProjectService _emploeeService;
        private IMapper _mapper;
        public EditProjectsModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _emploeeService = scope.Resolve<IProjectService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditProjectsModel(IProjectService projectService, IMapper mapper)
        {
            _emploeeService = projectService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var project = new Managing.BusinessObjects.Project()
            {
                Id = this.Id,
                Title = this.Title,
                StartDate = this.StartDate,
                EstimatedClosingDate = this.EstimatedClosingDate,
                ProjectManager = this.ProjectManager,
                IsLocked = this.IsLocked,
                IsActive = this.IsActive,
            };

            _emploeeService.UpdateProject(project);
        }

        public void LoadModelData(int id)
        {
            var project = _emploeeService.GetProject(id);
            this.Id = project.Id;
            this.Title = project.Title;
            this.StartDate = project.StartDate;
            this.EstimatedClosingDate = project.EstimatedClosingDate;
            this.ProjectManager = project.ProjectManager;
            this.IsLocked = project.IsLocked; 
            this.IsActive = project.IsActive; 
        }
    }
}
