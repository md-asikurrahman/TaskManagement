using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Managing.BusinessObjects
{
    public class TaskEmp
    {
        public int Id { get; set; }
        [Display(Name ="Task")]
        public int TaskId { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public Task Tasks { get; set; }
        public Employee Employee { get; set; }
        public ICollection<TaskPerformed> TaskPerformed { get; set; }
    }
}
