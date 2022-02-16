using Autofac;
using TaskManagement.Models.Employee;
using TaskManagement.Models.Project;
using TaskManagement.Models.Project.ProjectEmp;
using TaskManagement.Models.Task;
using TaskManagement.Models.Task.TaskEmps;

namespace TaskManagement
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateEmployeeModel>().AsSelf();
            builder.RegisterType<EditEmployeeModel>().AsSelf();
            builder.RegisterType<EmployeeListModel>().AsSelf();

            builder.RegisterType<TaskEmpsListModel>().AsSelf();
            builder.RegisterType<CreateTaskEmpsModel>().AsSelf();
            builder.RegisterType<EditTaskEmpModel>().AsSelf();

            builder.RegisterType<ProjectEmpListModel>().AsSelf();
            builder.RegisterType<CreateProjectEmpModel>().AsSelf();
            builder.RegisterType<EditProjectEmpModel>().AsSelf();

            builder.RegisterType<TaskListModel>().AsSelf();
            builder.RegisterType<CreateTaskModel>().AsSelf();
            builder.RegisterType<EditTaskModel>().AsSelf();

            builder.RegisterType<ProjectListModel>().AsSelf();
            builder.RegisterType<CreateProjectModel>().AsSelf();
            builder.RegisterType<EditProjectsModel>().AsSelf();

            base.Load(builder);
        }
    }
}
