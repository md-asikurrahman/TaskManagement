using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Data;

namespace TaskManagement.Managing.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedClosingDate { get; set; }
        public string ProjectManager { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<ProjectEmp> ProjectEmp { get; set; }
        public Employee Employee { get; set; }
    }
}
