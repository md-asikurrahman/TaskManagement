using Autofac;
using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.Services.Task;

namespace TaskManagement.Models.Task.TaskEmps
{
    public class TaskEmpsListModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public Managing.BusinessObjects.Task Tasks { get; set; }
        public Managing.BusinessObjects.Employee Employee { get; set; }

        public ICollection<TaskPerformed> TaskPerformed { get; set; }

        private ITaskEmpService _taskEmpService;
        private IMapper _mapper;

        public TaskEmpsListModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskEmpService = scope.Resolve<ITaskEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public TaskEmpsListModel(ITaskEmpService TaskEmpService, IMapper mapper)
        {
            _taskEmpService = TaskEmpService;
            _mapper = mapper;
        }

        public IList<TaskEmp> GetTaskEmps()
        
        {
            var taskEmps = _taskEmpService.GetTaskEmps();
            return taskEmps;
        }

        public TaskEmp GetTaskEmp(int id)
        {
            var taskEmp = _taskEmpService.GetTaskDetails(id, "Employee");
            return taskEmp; 
        }

        internal void Delete(int id)
        {
            _taskEmpService.DeleteTaskEmp(id);
        }
    }
}
