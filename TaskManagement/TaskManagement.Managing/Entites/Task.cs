using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using TaskManagement.Data;

namespace TaskManagement.Managing.Entities
{
    public class Task : IEntity<int>
    {
        public int Id { get; set; }
        [Required,Display(Name ="Task Name"),StringLength(200)]
        public string TaskName { get; set; }
        public double ECHour { get; set; }
        public int CompleteStatus { get; set; }
        public string Dependancy { get; set; }
        public Project Project { get; set; }
        public ICollection<TaskEmp> TaskEmp { get; set; }
    }
}
