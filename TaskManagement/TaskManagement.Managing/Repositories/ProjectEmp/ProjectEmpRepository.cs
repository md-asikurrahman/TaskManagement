using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{
    public class ProjectEmpRepository : Repository<ProjectEmp, int>,
IProjectEmpRepository
    {
        public ProjectEmpRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
