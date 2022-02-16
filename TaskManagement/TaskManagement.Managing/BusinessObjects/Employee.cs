using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Managing.BusinessObjects
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(01300000000, 01900000000, ErrorMessage = "Please Enter a valid Mobile number")]
        public int Mobile { get; set; }
        [Required, Display(Name = "NID")]
        public int NationalId { get; set; }
        public string Photo { get; set; }
        public ICollection<TaskEmp> TaskEmp { get; set; }
        public ICollection<ProjectEmp> ProjectEmp { get; set; }
        public TaskPerformed TaskPerformed { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
