using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Managing.Services
{
    public interface ITaskService
    {
        IList<BusinessObjects.Task> GetAllTask();
        BusinessObjects.Task GetTask(int id);
        void CreateTask(BusinessObjects.Task taskEmp);
        void UpdateTask(BusinessObjects.Task taskEmp);
        void DeleteTask(int id);
    }
}
