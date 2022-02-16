using AutoMapper;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.UnitOfWorks;

namespace ProjectManagement.Managing.Services.Project
{
    public class ProjectEmpService : IProjectEmpService
    {
        private readonly IManagingUnitOfWork _managingUnitOfWork;
        private readonly IMapper _mapper;

        public ProjectEmpService(IManagingUnitOfWork managingUnitOfWork,
            IMapper mapper)
        {
            _managingUnitOfWork = managingUnitOfWork;
            _mapper = mapper;
        }

        public IList<ProjectEmp> GetProjectEmps()
        {
            var projectEmpsEntities = _managingUnitOfWork.ProjectEmps.GetAll();
            var projectEmps = new List<ProjectEmp>();

            foreach (var entity in projectEmpsEntities)
            {
                var projectEmp = _mapper.Map<ProjectEmp>(entity);
                projectEmps.Add(projectEmp);
            }

            return projectEmps;
        }
        public ProjectEmp GetProjectEmp(int id)
        {
            //var projectEmp = _managingUnitOfWork.ProjectEmps.GetDynamic( id == 0 ? null : x => x.Id == id, null,
            //"Project", false);

            var projectEmp = _managingUnitOfWork.ProjectEmps.GetById(id);

            if (projectEmp == null) return null;

            return _mapper.Map<ProjectEmp>(projectEmp);
        }

        public ProjectEmp GetProjectDetails(int id, string includes)
        {
            var projectEmp = _managingUnitOfWork.ProjectEmps.GetById(id, includes);

            if (projectEmp == null) return null;

            return _mapper.Map<ProjectEmp>(projectEmp);
        }

        public void CreateProjectEmp(ProjectEmp projectEmp)

        {
            if (projectEmp == null)
                throw new InvalidParameterException("ProjectEmp was not provided");

            _managingUnitOfWork.ProjectEmps.Add(
                _mapper.Map<TaskManagement.Managing.Entities.ProjectEmp>(projectEmp)

             );

            _managingUnitOfWork.Save();

        }

        public void UpdateProjectEmp(ProjectEmp projectEmp)
        {
            if (projectEmp == null)
                throw new InvalidOperationException("ProjectEmp is missing");

            var projectEmpEntity = _managingUnitOfWork.ProjectEmps.GetById(projectEmp.Id);

            if (projectEmpEntity != null)
            {
                _mapper.Map(projectEmp, projectEmpEntity);
                _managingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find projectEmp");
        }

        public void DeleteProjectEmp(int id)
        {
            _managingUnitOfWork.ProjectEmps.Remove(id);
            _managingUnitOfWork.Save();
        }
    }
}
