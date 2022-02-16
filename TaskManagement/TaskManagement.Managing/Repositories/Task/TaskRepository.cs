using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{
    public class TaskPerformedRepository : Repository<Task, int>,
ITaskRepository
    {
        public TaskPerformedRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
