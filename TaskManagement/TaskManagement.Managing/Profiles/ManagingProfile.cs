using AutoMapper;
using EO = TaskManagement.Managing.Entities;
using BO = TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Managing.Profiles
{
    public class ManagingProfile : Profile
    {
        public ManagingProfile()
        {
            CreateMap<EO.TaskEmp, BO.TaskEmp>().ReverseMap();
            CreateMap<EO.ProjectEmp, BO.ProjectEmp>().ReverseMap();
            CreateMap<EO.Employee, BO.Employee>().ReverseMap();
            CreateMap<EO.Task, BO.Task>().ReverseMap();
            CreateMap<EO.Project, BO.Project>().ReverseMap();
        }
    }
}
