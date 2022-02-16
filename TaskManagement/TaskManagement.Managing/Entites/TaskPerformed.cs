using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data;

namespace TaskManagement.Managing.Entities
{
    public class TaskPerformed : IEntity<int>
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
