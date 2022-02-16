using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{
    public class ProjectRepository : Repository<Project, int>,IProjectRepository
    {
        public ProjectRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
