using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Task
{
    public class EditTaskModel : TaskBaseModel
    {
        private ITaskService _emploeeService;
        private IMapper _mapper;
        public EditTaskModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _emploeeService = scope.Resolve<ITaskService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditTaskModel(ITaskService taskService, IMapper mapper)
        {
            _emploeeService = taskService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var task = new Managing.BusinessObjects.Task()
            {
                Id = this.Id,
                TaskName = this.TaskName,
                ECHour = this.ECHour,
                CompleteStatus = this.CompleteStatus,
                Dependancy = this.Dependancy
            };

            _emploeeService.UpdateTask(task);
        }

        public void LoadModelData(int id)
        {
            var task = _emploeeService.GetTask(id);
            this.Id = task.Id;
            this.TaskName = task.TaskName;
            this.ECHour = task.ECHour;
            this.CompleteStatus = task.CompleteStatus;
            this.Dependancy = task.Dependancy;
        }
    }
}
