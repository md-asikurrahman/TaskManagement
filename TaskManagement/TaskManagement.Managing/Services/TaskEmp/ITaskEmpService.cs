using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Managing.Services.Task
{
    public interface ITaskEmpService
    {
        IList<TaskEmp> GetTaskEmps();
        TaskEmp GetTaskDetails(int id, string includes);
        TaskEmp GetTaskEmp(int id);
        void CreateTaskEmp(TaskEmp taskEmp);
        void UpdateTaskEmp(TaskEmp taskEmp);
        void DeleteTaskEmp(int id);
    }
}
