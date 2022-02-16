using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;

namespace ProjectManagement.Managing.Services.Project
{
    public interface IProjectEmpService
    {
        IList<ProjectEmp> GetProjectEmps();
        ProjectEmp GetProjectDetails(int id, string includes);
        ProjectEmp GetProjectEmp(int id);
        void CreateProjectEmp(ProjectEmp projectEmp);
        void UpdateProjectEmp(ProjectEmp projectEmp);
        void DeleteProjectEmp(int id);
    }
}
