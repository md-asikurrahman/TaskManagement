using AutoMapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.UnitOfWorks;

namespace TaskManagement.Managing.Services
{
    public class TaskService : ITaskService
    {
        private readonly IManagingUnitOfWork _managingUnitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IManagingUnitOfWork managingUnitOfWork,
            IMapper mapper)
        {
            _managingUnitOfWork = managingUnitOfWork;
            _mapper = mapper;
        }

        public IList<BusinessObjects.Task> GetAllTask()
        {
            var taskEntities = _managingUnitOfWork.Tasks.GetAll();
            var tasks = new List<BusinessObjects.Task>();

            foreach (var entity in taskEntities)
            {
                var task = _mapper.Map<BusinessObjects.Task>(entity);
                tasks.Add(task);
            }

            return tasks;
        }
        public BusinessObjects.Task GetTask(int id)
        {
            var task = _managingUnitOfWork.Tasks.GetById(id);

            if (task == null) return null;

            return _mapper.Map<BusinessObjects.Task>(task);
        }

        public void CreateTask(BusinessObjects.Task task)
        {
            if (task == null)
                throw new InvalidParameterException("Task was not provided");

            //if (IsNIDAlreadyUsed(task.NationalId))
            //    throw new InvalidParameterException("NationalId already exists");

            //if (IsMobileAlreadyUsed(task.Mobile))
            //    throw new InvalidParameterException("Mobile already exists");

            //if (IsEmailAlreadyUsed(task.Email))
            //    throw new InvalidParameterException("Email already exists");

            _managingUnitOfWork.Tasks.Add(
                _mapper.Map<Entities.Task>(task)
             );

            _managingUnitOfWork.Save();
        }

        public void UpdateTask(BusinessObjects.Task task)
        {
            if (task == null)
                throw new InvalidOperationException("Task is missing");

            var taskEntity = _managingUnitOfWork.Tasks.GetById(task.Id);

            if (taskEntity != null)
            {
                _mapper.Map(task, taskEntity);
                _managingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find task");
        }

        public void DeleteTask(int id)
        {
            _managingUnitOfWork.Tasks.Remove(id);
            _managingUnitOfWork.Save();
        }

//        private bool IsNIDAlreadyUsed(int nationalId) =>
//    _managingUnitOfWork.Tasks.GetCount(x => x.NationalId == nationalId) > 0;

//        private bool IsMobileAlreadyUsed(int mobile) =>
//_managingUnitOfWork.Tasks.GetCount(x => x.Mobile == mobile) > 0;

//        private bool IsEmailAlreadyUsed(string email) =>
//    _managingUnitOfWork.Tasks.GetCount(x => x.Email == email) > 0;
    }
}
