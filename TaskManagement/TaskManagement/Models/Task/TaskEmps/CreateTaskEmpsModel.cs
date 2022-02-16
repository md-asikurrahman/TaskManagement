using Autofac;
using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.Services.Task;

namespace TaskManagement.Models.Task.TaskEmps
{
    public class CreateTaskEmpsModel : TaskEmpBaseModel
    {
        private ITaskEmpService _taskEmpService;
        private IMapper _mapper;

        public CreateTaskEmpsModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskEmpService = scope.Resolve<ITaskEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateTaskEmpsModel(ITaskEmpService taskEmpService, IMapper mapper)
        {
            _taskEmpService = taskEmpService;
            _mapper = mapper;
        }

        public void CreateTaskEmp()
        {
            var taskEmp = new TaskEmp()
            {
                TaskId = this.TaskId,
                EmployeeId = this.EmployeeId,
            };

            _taskEmpService.CreateTaskEmp(taskEmp);
        }
    }
}
