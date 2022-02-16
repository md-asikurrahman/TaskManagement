using Autofac;
using AutoMapper;
using System.Collections.Generic;
using TaskPerformedManagement.Managing.Services;

namespace TaskManagement.Models.Task.TaskPerformed
{
    public class TaskPerformedListModel : TaskPerformedBaseModel
    {
        private ITaskPerformedService _taskPerformedService;
        private IMapper _mapper;

        public TaskPerformedListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskPerformedService = scope.Resolve<ITaskPerformedService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public TaskPerformedListModel(ITaskPerformedService taskPerformedService, IMapper mapper)
        {
            _taskPerformedService = taskPerformedService;
            _mapper = mapper;
        }

        public IList<Managing.BusinessObjects.TaskPerformed> GetTaskPerformeds()

        {
            var taskPerformeds = _taskPerformedService.GetAllTaskPerformed("TaskEmp");
            return taskPerformeds;
        }

        public Managing.BusinessObjects.TaskPerformed GetTaskPerformed(int id)
        {
            var taskPerformed = _taskPerformedService.GetTaskPerformedDetails(id, "TaskEmp");
            return taskPerformed;
        }

        internal void Delete(int id)
        {
            _taskPerformedService.DeleteTaskPerformed(id);
        }
    }
}
