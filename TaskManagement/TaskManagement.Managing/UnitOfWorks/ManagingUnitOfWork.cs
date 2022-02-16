using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Repositories;
using TaskManagement.Managing.Repositories.TaskPerformed;

namespace TaskManagement.Managing.UnitOfWorks
{
    public class ManagingUnitOfWork : UnitOfWork, IManagingUnitOfWork
    {
        public ITaskEmpRepository TaskEmps { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public ITaskRepository Tasks { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IProjectEmpRepository ProjectEmps { get; private set; }
        //public ITaskPerformedRepository TasksPerformed { get; private set; }

        public ManagingUnitOfWork(IManagingContext context,
            ITaskEmpRepository taskEmps,
            IEmployeeRepository employees,
            ITaskRepository tasks,
            IProjectRepository projects,
            IProjectEmpRepository projectEmps
            //ITaskPerformedRepository tasksPerformed
            ) : base((DbContext)context)
        {
            TaskEmps = taskEmps;
            Employees = employees;
            Tasks = tasks;
            Projects = projects;
            ProjectEmps = projectEmps;
            //    TasksPerformed = tasksPerformed;
            //
        }
    }
}
