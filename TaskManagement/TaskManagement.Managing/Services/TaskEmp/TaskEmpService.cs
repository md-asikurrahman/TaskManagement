using AutoMapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.UnitOfWorks;

namespace TaskManagement.Managing.Services.Task
{
    public class TaskEmpService : ITaskEmpService
    {
        private readonly IManagingUnitOfWork _managingUnitOfWork;
        private readonly IMapper _mapper;

        public TaskEmpService(IManagingUnitOfWork managingUnitOfWork,
            IMapper mapper)
        {
            _managingUnitOfWork = managingUnitOfWork;
            _mapper = mapper;
        }

        public IList<TaskEmp> GetTaskEmps()
        {
            var taskEmpsEntities = _managingUnitOfWork.TaskEmps.GetAll();
            var taskEmps = new List<TaskEmp>();

            foreach (var entity in taskEmpsEntities)
            {
                var taskEmp = _mapper.Map<TaskEmp>(entity);
                taskEmps.Add(taskEmp);
            }

            return taskEmps;
        }
        public TaskEmp GetTaskEmp(int id)
        {
            //var taskEmp = _managingUnitOfWork.TaskEmps.GetDynamic( id == 0 ? null : x => x.Id == id, null,
            //"Task", false);

            var taskEmp = _managingUnitOfWork.TaskEmps.GetById(id);

            if (taskEmp == null) return null;

            return _mapper.Map<TaskEmp>(taskEmp);
        }

        public TaskEmp GetTaskDetails(int id, string includes)
        {
            var taskEmp = _managingUnitOfWork.TaskEmps.GetById(id, includes);

            if (taskEmp == null) return null;

            return _mapper.Map<TaskEmp>(taskEmp);
        }

        public void CreateTaskEmp(TaskEmp taskEmp)

        {
            if (taskEmp == null)
                throw new InvalidParameterException("TaskEmp was not provided");

            _managingUnitOfWork.TaskEmps.Add(
                _mapper.Map<Entities.TaskEmp>(taskEmp)

             );

            _managingUnitOfWork.Save();

        }

        public void UpdateTaskEmp(TaskEmp taskEmp)
        {
            if (taskEmp == null)
                throw new InvalidOperationException("TaskEmp is missing");

            var taskEmpEntity = _managingUnitOfWork.TaskEmps.GetById(taskEmp.Id);

            if (taskEmpEntity != null)
            {
                _mapper.Map(taskEmp, taskEmpEntity);
                _managingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find taskEmp");
        }

        public void DeleteTaskEmp(int id)
        {
            _managingUnitOfWork.TaskEmps.Remove(id);
            _managingUnitOfWork.Save();
        }
    }
}
