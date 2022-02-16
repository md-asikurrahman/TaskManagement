using Autofac;
using AutoMapper;
using TaskManagement.Managing.Services;
using TaskPerformedManagement.Managing.Services;

namespace TaskManagement.Models.Task.TaskPerformed
{
    public class CreateTaskPerformedModel : TaskPerformedBaseModel
    {
        private ITaskPerformedService _taskPerformedService;
        private IMapper _mapper;

        public CreateTaskPerformedModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _taskPerformedService = scope.Resolve<ITaskPerformedService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public CreateTaskPerformedModel(ITaskPerformedService taskPerformedService, IMapper mapper)
        {
            _taskPerformedService = taskPerformedService;
            _mapper = mapper;
        }

        public void CreateTaskPerformed()
        {
            var taskPerformed = new Managing.BusinessObjects.TaskPerformed()
            {
                TaskEmpId = this.TaskEmpId,
                WorkDate = this.WorkDate,
                CompletePCT = this.CompletePCT,
                Remarks = this.Remarks,
                HoursConsumed = this.HoursConsumed
            };

            _taskPerformedService.CreateTaskPerformed(taskPerformed);
        }
    }
}
