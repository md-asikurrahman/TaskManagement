using Autofac;
using AutoMapper;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.Services.Task;

namespace TaskManagement.Models.Task.TaskEmps
{
    public class EditTaskEmpModel : TaskEmpBaseModel
    {
        private ITaskEmpService _taskEmpService;
        private IMapper _mapper;
        public EditTaskEmpModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskEmpService = scope.Resolve<ITaskEmpService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditTaskEmpModel(ITaskEmpService taskEmpService, IMapper mapper)
        {
            _taskEmpService = taskEmpService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var taskEmp = new TaskEmp()
            {
                Id = this.Id,
                TaskId = this.TaskId,
                EmployeeId = this.EmployeeId
            };

            _taskEmpService.UpdateTaskEmp(taskEmp);
        }

        public void LoadModelData(int id)
        { 
            var taskEmp = _taskEmpService.GetTaskEmp(id);
            this.Id = taskEmp.Id;
            this.TaskId = taskEmp.TaskId;
            this.EmployeeId = taskEmp.EmployeeId; 
        }
    }
}
