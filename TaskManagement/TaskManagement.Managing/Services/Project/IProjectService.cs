using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Managing.Services
{
    public interface IProjectService
    {
        IList<Project> GetAllProject();
        Project GetProject(int id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
