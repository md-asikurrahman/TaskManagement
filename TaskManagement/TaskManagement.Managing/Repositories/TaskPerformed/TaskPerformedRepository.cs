using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;

namespace TaskManagement.Managing.Repositories.TaskPerformed
{
    public class TaskPerformedRepository : Repository<Entities.TaskPerformed, int>,
ITaskPerformedRepository
    {
        public TaskPerformedRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
