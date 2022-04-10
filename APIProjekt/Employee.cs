using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIProjekt.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<TimeReport> TimeReport { get; set; }
    }
}
