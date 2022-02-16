using Autofac;
using System.Collections.Generic;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Task
{
    public class TaskListModel : TaskBaseModel
    {
        private ITaskService _taskService;

        public TaskListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskService = scope.Resolve<ITaskService>();
        }

        public TaskListModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IList<Managing.BusinessObjects.Task> GetTasks()

        {
            var tasks = _taskService.GetAllTask();
            return tasks;
        }

        public Managing.BusinessObjects.Task GetTask(int id)
        {
            var task = _taskService.GetTask(id);
            return task;
        }

        internal void Delete(int id)
        {
            _taskService.DeleteTask(id);
        }
    }
}
