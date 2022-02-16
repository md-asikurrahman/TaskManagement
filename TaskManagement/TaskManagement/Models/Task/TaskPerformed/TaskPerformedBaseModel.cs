using System;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Models.Task.TaskPerformed
{
    public class TaskPerformedBaseModel
    {
        public int Id { get; set; }
        public int TaskEmpId { get; set; }
        public DateTime WorkDate { get; set; }
        public int CompletePCT { get; set; }
        public string Remarks { get; set; }
        public int HoursConsumed { get; set; }
        public TaskEmp TaskEmp { get; set; }
    }
}
