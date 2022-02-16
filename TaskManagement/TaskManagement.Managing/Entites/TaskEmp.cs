using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Data;

namespace TaskManagement.Managing.Entities
{
    public class TaskEmp : IEntity<int>
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public Task Tasks { get; set; }
        public Employee Employee { get; set; }
        public ICollection<TaskPerformed> TaskPerformed { get; set; }
    }
}
