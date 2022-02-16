using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Models.Task
{
    public class TaskBaseModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Task Name"), StringLength(200)]
        public string TaskName { get; set; }
        public double ECHour { get; set; }
        public int CompleteStatus { get; set; }
        public string Dependancy { get; set; }
        public Managing.BusinessObjects.Project Project { get; set; }
        public ICollection<TaskEmp> TaskEmp { get; set; }
    }
}
