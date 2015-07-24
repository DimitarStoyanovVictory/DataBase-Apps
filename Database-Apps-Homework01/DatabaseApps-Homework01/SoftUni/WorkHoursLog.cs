using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSoftUni
{
    public partial class WorkHoursLog
    {
        [Key]
        public int WorkHoursLogsId { get; set; }

        public DateTime ChangeDate { get; set; }

        public DateTime? OldTaskDate { get; set; }

        [StringLength(125)]
        public string OldTask { get; set; }

        public short? OldHours { get; set; }

        public string OldComments { get; set; }

        public DateTime? NewTaskDate { get; set; }

        [StringLength(125)]
        public string NewTask { get; set; }

        public short? NewHours { get; set; }

        public string NewComments { get; set; }

        [Required]
        [StringLength(6)]
        public string Command { get; set; }
    }
}
