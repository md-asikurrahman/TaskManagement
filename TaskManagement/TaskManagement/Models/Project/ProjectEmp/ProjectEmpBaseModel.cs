namespace TaskManagement.Models.Project.ProjectEmp
{
    public class ProjectEmpBaseModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
        public string ProjectRole { get; set; }
        public Managing.BusinessObjects.Project Project { get; set; }
        public Managing.BusinessObjects.Employee Employee { get; set; }
    }
}
