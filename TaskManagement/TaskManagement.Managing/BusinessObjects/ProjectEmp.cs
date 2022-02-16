namespace TaskManagement.Managing.BusinessObjects
{
    public class ProjectEmp
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
