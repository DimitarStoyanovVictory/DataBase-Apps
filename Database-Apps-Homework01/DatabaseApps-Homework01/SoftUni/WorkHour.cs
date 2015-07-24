using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSoftUni
{
    public partial class WorkHour
    {
        public WorkHour()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int WorkHoursID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(100)]
        public string Task { get; set; }

        [StringLength(100)]
        public string Comments { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
