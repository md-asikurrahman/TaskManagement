using TaskManagement.Data;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{
    public interface ITaskRepository : IRepository<Task, int>
    {
    }
}
