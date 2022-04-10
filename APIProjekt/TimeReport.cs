using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIProjekt.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Week { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
