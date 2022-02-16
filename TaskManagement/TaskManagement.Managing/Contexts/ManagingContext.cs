using Microsoft.EntityFrameworkCore;
using TaskManagement.Managing.Entities;

namespace TaskManagement.Managing.Contexts
{
    public class ManagingContext : DbContext, IManagingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ManagingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectEmp> ProjectEmp { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskEmp> TaskEmp { get; set; }
        public DbSet<TaskPerformed> TaskPerformed { get; set; }
    }
}
