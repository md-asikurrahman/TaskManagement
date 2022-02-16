using System.Collections.Generic;

namespace TaskPerformedManagement.Managing.Services.TaskPerformed
{
    public interface ITaskPerformedService
    {
        IList<TaskManagement.Managing.BusinessObjects.TaskPerformed> GetAllTaskPerformed();
        TaskManagement.Managing.BusinessObjects.TaskPerformed GetTaskPerformed(int id);
        void CreateTaskPerformed(TaskManagement.Managing.BusinessObjects.TaskPerformed taskPerformedEmp);
        void UpdateTaskPerformed(TaskManagement.Managing.BusinessObjects.TaskPerformed taskPerformedEmp);
        void DeleteTaskPerformed(int id);
    }
}
