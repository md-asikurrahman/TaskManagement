using Autofac;
using ProjectManagement.Managing.Services.Project;
using TaskManagement.Managing.Contexts;
using TaskManagement.Managing.Repositories;
using TaskManagement.Managing.Services;
using TaskManagement.Managing.Services.Task;
using TaskManagement.Managing.UnitOfWorks;

namespace TaskManagement.Managing
{
    public class ManagingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ManagingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ManagingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ManagingContext>().As<IManagingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TaskEmpService>().As<ITaskEmpService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TaskEmpRepository>().As<ITaskEmpRepository>()
            .InstancePerLifetimeScope();


            builder.RegisterType<ProjectEmpService>().As<IProjectEmpService>()
    .InstancePerLifetimeScope();

            builder.RegisterType<ProjectEmpRepository>().As<IProjectEmpRepository>()
            .InstancePerLifetimeScope();


            builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>()
            .InstancePerLifetimeScope();


            builder.RegisterType<TaskService>().As<ITaskService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<TaskPerformedRepository>().As<ITaskRepository>()
            .InstancePerLifetimeScope();


            builder.RegisterType<ProjectService>().As<IProjectService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<ProjectRepository>().As<IProjectRepository>()
            .InstancePerLifetimeScope();

            builder.RegisterType<ManagingUnitOfWork>().As<IManagingUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
