using Autofac;
using AutoMapper;
using TaskPerformedManagement.Managing.Services;

namespace TaskManagement.Models.Task.TaskPerformed
{
    public class EditTaskPerformedModel : TaskPerformedBaseModel
    {
        private ITaskPerformedService _emploeeService;
        private IMapper _mapper;
        public EditTaskPerformedModel()
        {
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _emploeeService = scope.Resolve<ITaskPerformedService>();
            _mapper = scope.Resolve<IMapper>();
        }

        public EditTaskPerformedModel(ITaskPerformedService taskPerformedService, IMapper mapper)
        {
            _emploeeService = taskPerformedService;
            _mapper = mapper;
        }

        internal void Update()
        {
            var taskPerformed = new Managing.BusinessObjects.TaskPerformed()
            {
                Id = this.Id,
                TaskEmpId = this.TaskEmpId,
                WorkDate = this.WorkDate,
                CompletePCT = this.CompletePCT,
                Remarks = this.Remarks,
                HoursConsumed = this.HoursConsumed
            };

            _emploeeService.UpdateTaskPerformed(taskPerformed);
        }

        public void LoadModelData(int id)
        {
            var taskPerformed = _emploeeService.GetTaskPerformed(id);
            this.Id = taskPerformed.Id;
            this.TaskEmpId = taskPerformed.TaskEmpId;
            this.WorkDate = taskPerformed.WorkDate;
            this.CompletePCT = taskPerformed.CompletePCT;
            this.Remarks = taskPerformed.Remarks;
            this.HoursConsumed = taskPerformed.HoursConsumed;
        }
    }
}
