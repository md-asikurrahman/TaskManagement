using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Managing.BusinessObjects;
using TaskManagement.Managing.Services.Task;

namespace TaskManagement.Models.Task.TaskEmps
{
    public class TaskEmpBaseModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public Managing.BusinessObjects.Task Tasks { get; set; }
        public Managing.BusinessObjects.Employee Employee { get; set; }
        public ICollection<TaskPerformed> TaskPerformed { get; set; }
    }
}
