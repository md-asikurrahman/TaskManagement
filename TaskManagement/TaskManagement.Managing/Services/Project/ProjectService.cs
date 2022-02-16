using AutoMapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.UnitOfWorks;

namespace TaskManagement.Managing.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IManagingUnitOfWork _managingUnitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IManagingUnitOfWork managingUnitOfWork,
            IMapper mapper)
        {
            _managingUnitOfWork = managingUnitOfWork;
            _mapper = mapper;
        }

        public IList<Project> GetAllProject()
        {
            var projectEntities = _managingUnitOfWork.Projects.GetAll();
            var projects = new List<Project>();

            foreach (var entity in projectEntities)
            {
                var project = _mapper.Map<Project>(entity);
                projects.Add(project);
            }

            return projects;
        }
        public Project GetProject(int id)
        {
            var project = _managingUnitOfWork.Projects.GetById(id);

            if (project == null) return null;

            return _mapper.Map<Project>(project);
        }

        public void CreateProject(Project project)
        {
            //if (project == null)
            //    throw new InvalidParameterException("Project was not provided");

            //if (IsNIDAlreadyUsed(project.NationalId))
            //    throw new InvalidParameterException("NationalId already exists");

            //if (IsMobileAlreadyUsed(project.Mobile))
            //    throw new InvalidParameterException("Mobile already exists");

            //if (IsEmailAlreadyUsed(project.Email))
            //    throw new InvalidParameterException("Email already exists");

            _managingUnitOfWork.Projects.Add(
                _mapper.Map<Entities.Project>(project)
             );

            _managingUnitOfWork.Save();
        }

        public void UpdateProject(Project project)
        {
            if (project == null)
                throw new InvalidOperationException("Project is missing");

            var projectEntity = _managingUnitOfWork.Projects.GetById(project.Id);

            if (projectEntity != null)
            {
                _mapper.Map(project, projectEntity);
                _managingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find project");
        }

        public void DeleteProject(int id)
        {
            _managingUnitOfWork.Projects.Remove(id);
            _managingUnitOfWork.Save();
        }

//        private bool IsNIDAlreadyUsed(int nationalId) =>
//    _managingUnitOfWork.Projects.GetCount(x => x.NationalId == nationalId) > 0;

//        private bool IsMobileAlreadyUsed(int mobile) =>
//_managingUnitOfWork.Projects.GetCount(x => x.Mobile == mobile) > 0;

//        private bool IsEmailAlreadyUsed(string email) =>
//    _managingUnitOfWork.Projects.GetCount(x => x.Email == email) > 0;
    }
}
