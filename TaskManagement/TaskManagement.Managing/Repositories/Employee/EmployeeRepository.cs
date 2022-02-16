using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Repositories
{

    public class EmployeeRepository : Repository<Employee, int>,
    IEmployeeRepository
    {
        public EmployeeRepository(IManagingContext context)
            : base((DbContext)context)
        {

        }
    }
}
