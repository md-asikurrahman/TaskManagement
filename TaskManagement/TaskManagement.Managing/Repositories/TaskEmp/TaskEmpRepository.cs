using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{
    public class TaskEmpRepository : Repository<TaskEmp, int>,
    ITaskEmpRepository
    {
        public TaskEmpRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
