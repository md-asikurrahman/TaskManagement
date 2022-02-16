using TaskManagement.Data;

namespace TaskManagement.Managing.Entities
{
    public class ProjectEmp : IEntity<int>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
        public string ProjectRole { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}
