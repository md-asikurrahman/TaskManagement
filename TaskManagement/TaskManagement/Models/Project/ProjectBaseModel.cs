using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Managing.BusinessObjects;

namespace TaskManagement.Models.Project
{
    public class ProjectBaseModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedClosingDate { get; set; }
        public string ProjectManager { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Managing.BusinessObjects.Task> Tasks { get; set; }
        public ICollection<Managing.BusinessObjects.ProjectEmp> ProjectEmp { get; set; }
        public Managing.BusinessObjects.Employee Employee { get; set; }
    }
}
