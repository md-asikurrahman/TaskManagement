using TaskManagement.Data;
using TaskManagement.Managing.Repositories;
using TaskManagement.Managing.Repositories.TaskPerformed;

namespace TaskManagement.Managing.UnitOfWorks
{
    public interface IManagingUnitOfWork : IUnitOfWork
    {
        ITaskEmpRepository TaskEmps { get; }
        IEmployeeRepository Employees { get; }
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        IProjectEmpRepository ProjectEmps { get; }
       // ITaskPerformedRepository TasksPerformed { get;  }
    }
}
