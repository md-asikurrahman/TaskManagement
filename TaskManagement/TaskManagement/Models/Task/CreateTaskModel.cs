using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;

namespace TaskManagement.Models.Task
{
    public class CreateTaskModel : TaskBaseModel
    {
        private ITaskService _taskService;
        private IMapper _mapper;

        public CreateTaskModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskService = scope.Resolve<ITaskService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateTaskModel(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        public void CreateTask()
        {
            var task = new Managing.BusinessObjects.Task()
            {
                TaskName = TaskName,
                ECHour = ECHour,
                CompleteStatus = CompleteStatus,
                Dependancy = Dependancy, 
                Project = Project = Project,
                TaskEmp = TaskEmp
            };

            _taskService.CreateTask(task);
        }
    }
}
