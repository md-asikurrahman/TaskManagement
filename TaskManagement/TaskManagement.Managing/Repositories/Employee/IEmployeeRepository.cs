using TaskManagement.Data;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{

    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}
