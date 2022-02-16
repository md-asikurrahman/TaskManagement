using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data;

namespace TaskManagement.Managing.Repositories.TaskPerformed
{
    public interface ITaskPerformedRepository : IRepository<Entities.TaskPerformed, int>
    {
    }
}
