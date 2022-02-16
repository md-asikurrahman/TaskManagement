using Autofac;
using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Project
{
    public class ProjectListModel : ProjectBaseModel
    {
        private IProjectService _projectService;
        private IMapper _mapper;

        public ProjectListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _projectService = scope.Resolve<IProjectService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public ProjectListModel(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public IList<Managing.BusinessObjects.Project> GetProjects()
        
        {
            var projects = _projectService.GetAllProject();
            return projects;
        }

        public Managing.BusinessObjects.Project GetProject(int id)
        {
            var project = _projectService.GetProject(id);
            return project; 
        }

        internal void Delete(int id)
        {
            _projectService.DeleteProject(id);
        }
    }
}
